using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FoodHubAPI.Models;
using FoodHubAPI.Models.Interface;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using static FoodHubAPI.Models.Enum.enums;

namespace FoodHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private readonly ApplicationSettings _appSettings;
        private readonly ApplicationContext _context;
        private readonly SmtpSettings _smtpSettings; //for mailing
        private readonly IWebHostEnvironment _env; //for mailing

        public UsersController
            (
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IOptions<ApplicationSettings> appSettings,
            ApplicationContext context,
            IOptions<SmtpSettings> smtpSettings,
            IWebHostEnvironment env
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appSettings = appSettings.Value;
            _context = context;
            _smtpSettings = smtpSettings.Value;
            _env = env;
        }

        [HttpPost]
        [Route("Register")]
        //POST api/Users/Register
        public async Task<Object> PostApplicationUser(UserModel model)
        {

            //Get rid off any whitespace
            model.FirstName = String.IsNullOrEmpty(model.FirstName) ? "" : model.FirstName.Trim();
            model.LastName = String.IsNullOrEmpty(model.LastName) ? "" : model.LastName.Trim();
            model.Email = String.IsNullOrEmpty(model.Email) ? "" : model.Email.Trim();
            model.PhoneNumber = String.IsNullOrEmpty(model.PhoneNumber) ? "" : model.PhoneNumber.Trim();

            if (String.IsNullOrEmpty(model.FirstName) ||
                String.IsNullOrEmpty(model.LastName) || 
                String.IsNullOrEmpty(model.Email) ||
                String.IsNullOrEmpty(model.Password) ||
                String.IsNullOrEmpty(model.PhoneNumber))
            {
                return BadRequest(new { message = "Can't contain empty fields" });
            }

            if(model.Password.Length != model.Password.Trim().Length)
            {
                return BadRequest(new { message = "Password can't contain spaces" });
            }

            //Max length for name's in the database is 50 characters
            if(model.FirstName.Length > 50 || model.LastName.Length > 50)
            {
                return BadRequest(new { message = "First or last name can't be longer than 50 characters!" });
            }

            var addr = new System.Net.Mail.MailAddress(model.Email);
            if (addr.Address != model.Email)
            {
                return BadRequest(new { message = "Not a valid Email." });
            }

            bool isApplicant = _context.ApplicantRestaurants.Where(x => x.Email == model.Email).FirstOrDefault() != null;
            if (isApplicant)
            {
                return BadRequest(new { message = "This email is already used for restaurant registration!" });
            }

            bool isUser = _context.ApplicationUsers.Where(x => x.Email == model.Email).FirstOrDefault() != null;
            if (isUser)
            {
                return BadRequest(new { message = "The email \""+ model.Email + "\" is already registered in the system" });
            }

            //Preparing a lambda function to capitalise the first letter of all words 
            Func<string, string> capitaliseString = (string text) =>
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            };

            //Apply the fix to the strings if it was typed wrong  (initial letters are capitilised while other letters are small)
            model.FirstName = capitaliseString(model.FirstName);
            model.LastName = capitaliseString(model.LastName);

            model.Role = "User"; //Default users get the role of "User"
            var creationTime = DateTime.Now;
            var applicationUser = new User()
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Created = creationTime,
                Updated = creationTime
            };

            bool hasDigit = false;
            for (int i = 0; i < model.Password.Length; i++)
            {
                if (model.Password[i] < 58 && 47 < model.Password[i]) // has a digit
                {
                    hasDigit = true;
                    break;
                }
            }

            if (!(hasDigit && model.Password.Length >= 6)) // Password requirements
            {
                return BadRequest(new { message = "Password must contain at least one number and must be of length 6 or more" });
            }


            try
            {
                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                await _userManager.AddToRoleAsync(applicationUser, model.Role);

                var user = _context.Users.Where(x => x.Email == model.Email).FirstOrDefault();

                string link = "http://localhost:4200/confirmMail?id=" + (string)user.Id + "&hash=" + (string)user.PasswordHash;

                SendEmailAsync(model.Email, "Thank you for registering - Food Hub",
                "<h3>Thank you for signing up to <strong> Food Hub <strong><h3>" +
                "<br>" +
                "<hr>" +
                "<h4>First Name: " + model.FirstName + "<h4>" +
                "<h4>Last Name: " + model.LastName + "<h4>" +
                "<p>Your confirmation link: <strong><a href='" + link + "'> Click to confirm your email</a> <strong></p>");

                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("Login")]
        // POST: /api/Users/Login
        public async Task<IActionResult> Login (LoginModel user)
        {

            //Get rid off whitespace
            user.Email = String.IsNullOrEmpty(user.Email) ? "" : user.Email.Trim();
            

            if(String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.Password))
            {
                return BadRequest(new { message = "Email / password input field can't be left empty." });
            }

            if(user.Password.Length != user.Password.Trim().Length)
            {
                return BadRequest(new { message = "Password can't contain spaces" });
            }

            user.Password = String.IsNullOrEmpty(user.Password) ? "" : user.Password.Trim();


            var dbUser = await _userManager.FindByEmailAsync(user.Email);
            if(dbUser != null && await _userManager.CheckPasswordAsync(dbUser, user.Password))
            {


                //Check if the user is banned
                var isBanned = _context.BanList.Where(x => x.UserId == dbUser.Id).FirstOrDefault();
                if (isBanned != null)
                {
                    return BadRequest(new { message = "THIS USER IS BANNED" + (String.IsNullOrEmpty(isBanned.Reason) ? "" : ("REASON: " + isBanned.Reason) )   });
                }

                if (!dbUser.EmailConfirmed)
                {
                    return Ok(); //Return an empty success so that in front-end when we see empty return we know the e-mail is not confirmed
                }

                //Get the role for the user
                var role = await _userManager.GetRolesAsync(dbUser);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] 
                    {
                        new Claim("UserID", dbUser.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType, role.FirstOrDefault())  //Assing the role to the token
                    }),
                    Expires = DateTime.UtcNow.AddDays(1), // After 1 day this token cant be used
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature) 
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Ok(new { token });

            } else
            {
                return BadRequest(new { message = "Email or password is incorrect." });
            }
        }


        [HttpPost]
        [Route("ResendConfirmationMail")]
        //POST api/Users/ResendConfirmationMail
        public async Task<Object> ResendConfirmationMail(StringModel model)
        {

            var addr = new System.Net.Mail.MailAddress(model.Text);
            if (addr.Address != model.Text)
            {
                return BadRequest(new { message = "Not a valid Email." });
            }

            var user = _context.ApplicationUsers.Where(x => x.Email == model.Text).FirstOrDefault();

            if(user == null)
            {
                return NotFound(new { message = "Couldn't find the user in the system!" });
            }


            string link = "http://localhost:4200/confirmMail?id=" + (string)user.Id + "&hash=" + (string)user.PasswordHash;

            SendEmailAsync(user.Email, "Thank you for registering - Food Hub",
            "<h3>Thank you for signing up to <strong> Food Hub <strong><h3>" +
            "<br>" +
            "<hr>" +
            "<h4>First Name: " + user.FirstName + "<h4>" +
            "<h4>Last Name: " + user.LastName + "<h4>" +
            "<p>Your confirmation link: <strong><a href='" + link + "'> Click to confirm your email</a> <strong></p>");

            return Ok(new { message = "You should receive a email from us shortly!" });
        }


        [HttpPost]
        [Route("ConfirmMail")]
        //POST api/Users/ConfirmMail
        public async Task<Object> ConfirmMail(EmailConfirmationModel model)
        {
            //Get rid off whitespace
            model.Hash = model.Hash.Trim();
            model.UserId = model.UserId.Trim();

            var dbUser = await _userManager.FindByIdAsync(model.UserId);
            if(dbUser != null)
            {
                if(model.Hash == dbUser.PasswordHash)
                {
                    if (dbUser.EmailConfirmed)
                    {
                        return BadRequest(new { message = "This email is already confirmed." });
                    }
                    dbUser.EmailConfirmed = true;
                    await _context.SaveChangesAsync();
                    return Ok();
                } else
                {
                   return  BadRequest(new { message = "Critidentials did not match!" });
                }
            } 

            return BadRequest(new { message = "Wrong critidentials." });
        }


        [HttpPost]
        [Route("ResetPasswordMail")]
        //POST api/Users/ResetPasswordMail
        public async Task<Object> ResetPasswordMail(ResetPasswordMailModel model)
        {

            var dbUser = await _userManager.FindByEmailAsync(model.Email);
            if (dbUser != null)
            {
                string link = "http://localhost:4200/resetPassword?id=" + (string)dbUser.Id + "&hash=" + (string)dbUser.PasswordHash;

                SendEmailAsync(model.Email, "Password reset request - Food Hub", 
                    "<h1>Password reset request - Food Hub</h1>" +
                    "<hr>" +
                    "<p>Someone has requested to reset this email's password, if it was not you that requested this, please ignore.</p>" +
                    "<a href='" + link + "'> Click to reset your password</a>");
            }

            //If the email is registered as a applicant
            var applicantUser = _context.ApplicantRestaurants.Where(x => x.Email == model.Email).FirstOrDefault();
            if( applicantUser != null)
            {
                SendEmailAsync(model.Email, "Password reset request - Food Hub",
                    "<h1>Password reset request - Food Hub</h1>" +
                    "<hr>" +
                    "<p>Someone has requested to reset this email's password, if it was not you that requested this, please ignore.</p>" +
                    "<p><strong>This email was used to apply for a restaurant. Since the application is still being reviewed, you " +
                    "can't access this account until restaurant application is completed. Thank you for your patience.</strong></p>");
            }

            return Ok(); // Even If the mail could not be found, just show success
        }


        [HttpPost]
        [Route("ResetPassword")]
        //POST api/Users/ResetPassword
        public async Task<Object> ResetPassword(ResetPasswordModel model) 
        {
            //Get rid off whitespace
            model.UserId = String.IsNullOrEmpty(model.UserId) ? "" : model.UserId.Trim();
            model.Hash = String.IsNullOrEmpty(model.Hash) ? "" : model.Hash.Trim();

            if(String.IsNullOrEmpty(model.NewPassword) || model.NewPassword.Length != model.NewPassword.Trim().Length)
            {
                return BadRequest(new { message = "Password can't be empty and can't contain spaces" });
            }


            model.NewPassword = model.NewPassword.Trim();

            if(String.IsNullOrEmpty(model.UserId) || String.IsNullOrEmpty(model.Hash) || String.IsNullOrEmpty(model.NewPassword))
            {
                return BadRequest(new { message = "Can't change the password, an input field was submitted empty" });
            }

            var dbUser = await _userManager.FindByIdAsync(model.UserId);
            if (dbUser != null)
            {
                if (model.Hash == dbUser.PasswordHash)
                {
                    bool hasDigit = false;
                    for(int i = 0; i < model.NewPassword.Length; i++)
                    {
                        if(model.NewPassword[i] < 58 && 47 < model.NewPassword[i]) // has a digit
                        {
                            hasDigit = true;
                            break;
                        }
                    }

                    if(hasDigit && model.NewPassword.Length >= 6)
                    {
                        //Change the password
                        var token = await _userManager.GeneratePasswordResetTokenAsync(dbUser);
                        var result = await _userManager.ResetPasswordAsync(dbUser, token, model.NewPassword);

                        if( result.Succeeded )
                        {
                            dbUser.Updated = DateTime.Now;
                            _context.SaveChanges();
                            return Ok(new { message = "Password resetted succesfuly" });
                        }else
                        {
                            return BadRequest(new { message = "Password could not be resetted" });
                        }
                            
                    }else
                    {
                        return BadRequest(new { message = "Password must contain at least one number and must be of length 6 or more" });
                    }

                }else
                {
                    return BadRequest(new { message = "Critidentials does not match" }); // password has does not match
                }
            }

            return BadRequest(new { message = "Critidentials does not match" }); // The user could not be found
        }


        //When the user want to changee their password from their profile while logged in
        [HttpPost]
        [Route("ChangePassword")]
        [Authorize]
        //POST api/Users/ChangePassword
        public async Task<Object> ChangePassword(StringModel model)
        {

            if (String.IsNullOrEmpty(model.Text))
            {
                return BadRequest(new { message = "Password can't be set empty!" });
            }


            if (model.Text.Trim().Length != model.Text.Length)
            {
                return BadRequest(new { message = "Password can't contain spaces!" });
            }

            //Get rid off whitespace
            model.Text = String.IsNullOrEmpty(model.Text) ? "" : model.Text.Trim();

            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {

                bool hasDigit = false;
                for (int i = 0; i < model.Text.Length; i++)
                {
                    if (model.Text[i] < 58 && 47 < model.Text[i]) // has a digit
                    {
                        hasDigit = true;
                        break;
                    }
                }

                if (hasDigit && model.Text.Length >= 6)
                {
                    //Change the password
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await _userManager.ResetPasswordAsync(user, token, model.Text);

                    if (result.Succeeded)
                    {
                        user.Updated = DateTime.Now;
                        _context.SaveChanges();
                        return Ok(new { message = "Password changed succesfuly" });
                    }
                    else
                    {
                        return BadRequest(new { message = "Password could not be changed" });
                    }

                }
                else
                {
                    return BadRequest(new { message = "Password must contain at least one number and must be of length 6 or more" });
                }

            }

            return BadRequest(new { message = "Can't match the critidentials" }); // The user could not be found
        }


        [HttpGet]
        [Route("UserInfo")]
        [Authorize]
        public async Task<Object> GetUserInfo()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            string nameOfRestaurant;

            //Store all the user related data
            var userResult = new
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                Address = user.Address
            };

            //Lifetime number of orders
            int numberOfOrders = _context.Order.Where(x => x.UserId == userId && x.Status == Status.Completed.ToString()).Count();
            //Find the restaurant that this users mostly orders from.This gives the Id, need the name
            var mostOrderRestaurant = _context.Order
                .Where(x => x.UserId == userId && x.Status == Status.Completed.ToString())
                .GroupBy(x => x.RestaurantId).Select(x => new { RestaurantId = x.Key, Times = x.Count() }).FirstOrDefault();

            nameOfRestaurant = mostOrderRestaurant == null ? null : _context.RestaurantDetails.Where(x => x.Id == mostOrderRestaurant.RestaurantId).Select(x => x.Name).FirstOrDefault();

            var mostOrderRestaurantResult = new
            {
                RestaurantName = nameOfRestaurant,
                Times = mostOrderRestaurant == null ? 0 : mostOrderRestaurant.Times
            };

            nameOfRestaurant = "";  // Emptying the string for the next usage


            //Highest rating that the user gave with the data such as the restaurant name, comment, response etc
            var highestRatingData = _context.Order
                .Join(_context.RatingAndReview, OrderId => OrderId.Id, RatingFk => RatingFk.OrderId,
                (OrderId, RatingFk) => new { UserId = OrderId.UserId, Status = OrderId.Status, Rating = RatingFk.Rating, Comment = RatingFk.Comment, Response = RatingFk.Response, RestaurantId = RatingFk.RestaurantId, Time = RatingFk.Created })
                .Where(x => x.UserId == userId && x.Status == Status.Completed.ToString())
                .OrderByDescending(x => x.Rating).ThenByDescending(x => x.Time)
                .FirstOrDefault();

            nameOfRestaurant = highestRatingData == null ? null : _context.RestaurantDetails.Where(x => x.Id == highestRatingData.RestaurantId).Select(x => x.Name).FirstOrDefault();

            var highestRatingDataResult = new
            {
                RestaurantName = nameOfRestaurant,
                Rating = highestRatingData == null ? 0 : highestRatingData.Rating,
                Comment = highestRatingData == null ? "": highestRatingData.Comment,
                Response = highestRatingData == null ? "": highestRatingData.Response
            };

            nameOfRestaurant = "";  // Emptying the string for the next usage


            //Most expensive order ever given by this user
            var highestOrder = _context.Order
                .Where(x => x.Status == Status.Completed.ToString() && x.UserId == userId)
                .Join(_context.OrderDetails, orderId => orderId.Id, fk => fk.OrderId,
                (orderId, fk) => new { RestaurantId = orderId.RestaurantId, OrderId = orderId.Id, UnitPrice = fk.ProductUnitPrice, Quantity = fk.Quantity })
                .GroupBy(x => new { x.OrderId, x.RestaurantId }).Select(x => new
                {
                    OrderId = x.Key,
                    Value = x.Sum(x => x.Quantity * x.UnitPrice)
                }).OrderByDescending(x => x.Value).FirstOrDefault();

            var highestOrderDetails = _context.Order
                .Where(x => x.Status == Status.Completed.ToString() && x.UserId == userId)
                .Join(_context.OrderDetails, orderId => orderId.Id, fk => fk.OrderId,
                (orderId, fk) => new { RestaurantId = orderId.RestaurantId, OrderId = orderId.Id, Price = fk.ProductUnitPrice, Quantity = fk.Quantity, Total = fk.Quantity * fk.ProductUnitPrice, Name = fk.ProductName })
                .DefaultIfEmpty();
                

            var highestOrderDetailsResult = highestOrder == null ? null: highestOrderDetails.Where(x => x.OrderId == highestOrder.OrderId.OrderId).ToList();




            nameOfRestaurant = highestOrder == null ? null : _context.RestaurantDetails.Where(x => x.Id == highestOrder.OrderId.RestaurantId).Select(x => x.Name).FirstOrDefault();

            var highestOrderResult = new
            {
                Value = highestOrder == null ? 0 : highestOrder.Value,
                RestaurantName = nameOfRestaurant,
                Details = highestOrderDetailsResult
            };
            nameOfRestaurant = "";  // Emptying the string for the next usage


            //Most recent order data
            var recentOrder = _context.Order.Where(x => x.UserId == userId).OrderByDescending(x => x.Created).FirstOrDefault();
            var recentDetails = recentOrder == null ? null :_context.OrderDetails.Where(x => x.OrderId == recentOrder.Id).Select(x => new { Name = x.ProductName, Price = x.ProductUnitPrice, Quantity = x.Quantity, Total = x.Quantity * x.ProductUnitPrice }).ToList();
            nameOfRestaurant = recentOrder == null ? null : _context.RestaurantDetails.Where(x => x.Id == recentOrder.RestaurantId).Select(x => x.Name).FirstOrDefault();

            var recentOrderResult = new
            {
                LastUpdate = recentOrder == null ? new DateTime() : recentOrder.Updated,
                Total = recentDetails == null ? 0 : recentDetails.Sum(x => x.Price * x.Quantity),
                Details = recentDetails,
                RestaurantName = nameOfRestaurant
            };
            nameOfRestaurant = "";  // Emptying the string for the next usage



            var favRestaurants = _context.FavouriteRestaurants
                .Join(_context.RestaurantDetails, FavResId => FavResId.RestaurantId, RestDetails => RestDetails.Id,
                (FavResId, RestDetails) =>
                new
                {
                    UserId = FavResId.UserId,
                    RestId = RestDetails.Id,
                    Name = RestDetails.Name,
                    About = RestDetails.About,
                    Rating = RestDetails.Rating,
                    AverageDeliveryTime = RestDetails.AverageDeliveryTime,
                    MinOrderPrice = RestDetails.MinOrderPrice,
                    City = RestDetails.City,
                    Street = RestDetails.Street,
                    Active = RestDetails.Active
                })
                .Where(x => x.UserId == user.Id && x.Active == true).ToList();


            var restaurantImages = new List<Images>();
            foreach(var restaurant in favRestaurants)
            {
                restaurantImages.Add( _context.Images.Where(x => x.RestaurantId == restaurant.RestId).FirstOrDefault());
                
            }


            return Ok(new
            {
                userResult,
                numberOfOrders,
                mostOrderRestaurantResult,
                highestRatingDataResult,
                highestOrderResult,
                recentOrderResult,
                favRestaurants,
                restaurantImages
            });
        }

        [HttpPost]
        [Route("ToggleFavorite")]
        [Authorize]
        // POST: /api/Users/ToggleFavorite
        public async Task<IActionResult> ToggleFavorite(IdModel model)
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            string message;

            var result = _context.FavouriteRestaurants.Where(x => x.UserId == user.Id && x.RestaurantId == model.Id).FirstOrDefault();
            if( result == null)
            {
                var restaurantExists = _context.RestaurantDetails.Where(x => x.Id == model.Id && x.Approved == true && x.Active == true).FirstOrDefault() != null;
                if (!restaurantExists)
                {
                    return NotFound(new { message = "The restaurant with the id '" + model.Id + "' does not exist." });
                }
                FavouriteRestaurants newRestaurant = new FavouriteRestaurants
                {
                    RestaurantId = model.Id,
                    UserId = user.Id
                };
                await _context.AddAsync(newRestaurant);
                message = "Restaurant has been added to your favorites.";
            }else
            {
                _context.Remove(result);
                message = "Restaurant has been removed from your favorites.";
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = message});
            }
            catch(Exception e)
            {
                throw e;
            }
  
        }


        [HttpPost]
        [Route("Feedback")]
        [Authorize]
        // POST: /api/Users/Feedback
        public async Task<IActionResult> Feedback(FeedbackModel model)
        {
            //Get rid off whitespace
            model.FeedbackType = String.IsNullOrEmpty(model.FeedbackType) ? "" : model.FeedbackType.Trim();
            model.Message = String.IsNullOrEmpty(model.Message) ? "" : model.Message.Trim();

            if(String.IsNullOrEmpty(model.Message) || String.IsNullOrEmpty(model.FeedbackType))
            {
                return BadRequest(new { message = "Message or feedback type was submitted empty!" });
            }


            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            if(string.IsNullOrEmpty(model.Message) || string.IsNullOrEmpty(model.FeedbackType))
            {
                return BadRequest(new { message = "Can't contain empty fields." });
            }

            if (!Enum.GetNames(typeof(FeedbackType)).Contains(model.FeedbackType)) //Checks all the enum names to see if it has the topic that the user sent
            {
                return NotFound(new { message = "The topic '" + model.FeedbackType + "' does not exist." });
            }

            Feedback data = new Feedback
            {
                Type = model.FeedbackType,
                UserId = user.Id,
                Message = model.Message,
                Created = DateTime.Now
            };

            _context.Feedback.Add(data);
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception e)
            {
                throw e;
            }
            
        }



        [HttpGet]
        [Route("GetRole")]
        [Authorize]
        public async Task<Object> GetUserRole()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var role = await _userManager.GetRolesAsync(user);

            return Ok(new { role });
        }

        [HttpGet]
        [Route("GetAddress")]
        [Authorize]
        public async Task<Object> GetAddress()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            var address = _context.ApplicationUsers.Where(x => x.Id == user.Id).Select(x => x.Address).FirstOrDefault();

            return Ok(new { address });
        }

        [HttpPost]
        [Route("ChangeAddress")]
        [Authorize]
        public async Task<Object> ChangeAddress(StringModel model)
        {
            model.Text = String.IsNullOrEmpty(model.Text) ? "" : model.Text.Trim();

            if(model.Text.Length > 300)
            {
                return BadRequest(new { message = "Address can't be longer than 300 characters!" });
            }

            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);
            user.Address = String.IsNullOrEmpty(model.Text) ? "" : model.Text;
            user.Updated = DateTime.Now;

            //Preparing a lambda function to capitalise the first letter of all words
            Func<string, string> capitaliseString = (string text) =>
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            };

            //Apply the fix to the strings if it was typed wrong
            user.Address = capitaliseString(user.Address);


            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [HttpPost]
        [Route("SendOrder")]
        [Authorize]
        // POST: /api/Users/SendOrder
        public async Task<IActionResult> SendOrder(OrderModel order)
        {

            //Get rid off whitespace
            order.Address = String.IsNullOrEmpty(order.Address) ? "" : order.Address.Trim();
            order.Note = String.IsNullOrEmpty(order.Note) ? "" : order.Note.Trim();

            if (String.IsNullOrEmpty(order.Address))
            {
                return BadRequest(new { message = "Address field can't be empty!" });
            }


            if (order.Note?.Length > 200)
            {
                return BadRequest(new { message = "Order note is too long! (max allowed character is 200)" });
            }

            if(order.Address.Length > 300)
            {
                return BadRequest(new { message = "Address is too long! (max allowed character is 300)" });
            }

            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(userId);

            // Selecting the amount as object in order to see if the restaurant "where" clause will return any value. If it does not the restaurant was not found. 
            // If it does, later on the minOrderAmount.Amount will be used
            var minOrderAmount =  _context.RestaurantDetails.Where(x => x.Id == order.RestaurantId && x.Active == true).Select(x => new { Amount = x.MinOrderPrice }).FirstOrDefault();

            if(minOrderAmount == null)
            {
                return BadRequest(new { message = "Can't make this order. Restaurant is either no longer active or something went wrong" });
            }

            List<Menu> restaurantMenu = _context.Menu.Where(x => x.RestaurantId == order.RestaurantId ).ToList();

            //check if the restaurant has all the items in the order (in case front-end user changed some id's)
            foreach(var product in order.Detail)
            {
                if(restaurantMenu.Find(x => x.Id == product.ProductId) == null) { //if the product couldnt be found
                    return BadRequest(new { message = "The productId '" + product.ProductId + "' does not belong to this restaurant!" });
                }
            }

            //Check if the order meets the minimum order price requirement
            float total = 0;
            foreach (var orderDetail in order.Detail)
            {
                total += orderDetail.Quantity * restaurantMenu.Find(x => x.Id == orderDetail.ProductId).Price;
            }

            if(total < minOrderAmount.Amount)
            {
                return BadRequest(new { message = "The minimum order price is '" + minOrderAmount.Amount + " ₺'." });
            }

            //Checking if the restaurant is working at the time of the order
            var today = (((int)DateTime.Now.DayOfWeek + 6) % 7);
            WorkingTimes workingTime = _context.WorkingTimes
                    .Where(x => x.RestaurantId == order.RestaurantId && x.Day == today).FirstOrDefault();
            bool isOpen = (workingTime.OpenTime.TotalMinutes < new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).TotalMinutes)
                && new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).TotalMinutes < workingTime.CloseTime.TotalMinutes;

            if (!isOpen)
            {
                return BadRequest(new { message = "Cant send order while the restuarant is closed" });
            }

            DateTime now = DateTime.Now;
            Order postOrder = new Order
            {
                UserId = userId,
                RestaurantId = order.RestaurantId,
                Address = order.Address,
                Note = String.IsNullOrEmpty(order.Note) ? null : order.Note,
                Status = Status.Waiting.ToString(),
                Created = now,
                Updated = now
            };

           
            _context.Order.Add(postOrder);
            try
            {
                await _context.SaveChangesAsync(); //the Id of it now is assigned to postOrder.Id . Will be used to add orderDetails
            }
            catch(Exception ex)
            {
                throw ex;
            }

            //Saving the details of the order in the database
            List<OrderDetails> postOrderDetails = new List<OrderDetails> { };
            foreach(var orderDetail in order.Detail)
            {
                postOrderDetails.Add(new OrderDetails
                {
                    OrderId = postOrder.Id,
                    ProductId = orderDetail.ProductId,
                    ProductName = restaurantMenu.Find(x => x.Id == orderDetail.ProductId).Name,
                    ProductUnitPrice = restaurantMenu.Find(x => x.Id == orderDetail.ProductId).Price,
                    Quantity = orderDetail.Quantity
                });
            }
            _context.OrderDetails.AddRange(postOrderDetails);
            try { await _context.SaveChangesAsync(); }
            catch (Exception e) 
            { 
                //Something went wrong while adding the deatils, remove the order.
                _context.Remove(postOrder);  //If the details failed to add, remove the initial order;
                await _context.SaveChangesAsync();
                throw e;
            }


            return Ok();
        }

        [HttpGet]
        [Route("GetOrderHistory/{page}")]
        [Authorize]
        public async Task<IActionResult> GetOrderHistory(int page)
        {
            int itemPerPage = 5;
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            User userData = _context.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();
            List<Order> orders = _context.Order.Where(x => x.UserId == userId).OrderByDescending(x => x.Created).Skip(page * itemPerPage).Take(5).ToList();

            if(userData == null)
            {
                return BadRequest(new { message = "User data is null" });
            }
            

            List<GetOrdersModel> result = new List<GetOrdersModel> { };
            foreach (Order order in orders)
            {
                List<OrderDetailsNamed> orderDetails = _context.OrderDetails.Where(x => x.OrderId == order.Id).Select(x => new OrderDetailsNamed
                {
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductUnitPrice,
                    Quantity = x.Quantity
                }).ToList();

                //Check if the user should be allowed to give a rating (if the order is complete)
                var checkReview = _context.RatingAndReview.Where(x => x.OrderId == order.Id).FirstOrDefault();
                var AllowReview = false;
                //Users wont be able to review any longer if a week has passed since completion
                if (checkReview == null && order.Status == Status.Completed.ToString() && order.Updated.AddDays(7) > DateTime.Now)
                {
                    AllowReview = true;
                }

                string nameOfRestaurant = _context.RestaurantDetails.Where(x => x.Id == order.RestaurantId).Select(x => x.Name).FirstOrDefault();

                result.Add(new GetOrdersModel
                {
                    UserId = userData.Id,
                    OrderId = order.Id,
                    UserFullName = userData.FirstName + " " + userData.LastName,
                    PhoneNumber = userData.PhoneNumber,
                    Address = order.Address,
                    Note = order.Note,
                    Restaurant = nameOfRestaurant,
                    Status = order.Status,
                    Created = order.Created,
                    Updated = order.Updated,
                    Details = orderDetails,
                    AllowReview = AllowReview
                });

            }
            return Ok(result);
        }

        [HttpPost]
        [Route("AddReviewAndComment")]
        [Authorize]
        // POST: /api/Users/AddReviewAndComment
        public async Task<IActionResult> AddReviewAndComment(AddReviewAndCommentModel model)
        {
            //Get rid off whitespace
            model.Comment = String.IsNullOrEmpty(model.Comment) ? "" : model.Comment.Trim();


            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            User userData = _context.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();
            var order = _context.Order.Where(x => x.Id == model.OrderId).FirstOrDefault();
            
            if(order == null)
            {
                return NotFound(new { message = "Couldnt find the orderId with the id '" + model.OrderId + "'" });
            }
            if(order.UserId != userId)
            {
                return BadRequest(new { message = "This order does not belong to this user!" });
            }
            bool UserHasAlreadyReviewed = _context.RatingAndReview.Where(x => x.OrderId == order.Id).FirstOrDefault() != null;
            if (UserHasAlreadyReviewed)
            {
                return BadRequest(new { message = "A review has already been done on this order!" });
            }


            RatingAndReview result = new RatingAndReview
            {
                OrderId = order.Id,
                RestaurantId = order.RestaurantId,
                Rating = model.Rating,
                Comment = model.Comment,
                Deleted = false,
                Created = DateTime.Now
            };
            _context.Add(result);
            await _context.SaveChangesAsync(); //Saving the data to database in order to calculate the rating for the store on the next lines

            int countOfRatings = _context.RatingAndReview.Where(x => x.RestaurantId == order.RestaurantId).Count();
            float sumOfRatings = _context.RatingAndReview.Where(x => x.RestaurantId == order.RestaurantId).Sum(x=> x.Rating);


            float restaurantAvgRating = countOfRatings == 0 ? model.Rating : (sumOfRatings / countOfRatings); //model.Rating will be activated only if it is the first rating
            RestaurantDetail restaurant = _context.RestaurantDetails.Where(x => x.Id == order.RestaurantId).FirstOrDefault();
            restaurant.Rating = restaurantAvgRating;

            
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPost]
        [Route("SendChatMessage")]
        [Authorize]
        //POST api/Users/SendChatMessage
        public async Task<Object> SendChatMessage(SendChatMessageModel model)
        {
            //Get rid off whitespace
            model.Message = String.IsNullOrEmpty(model.Message) ? "" : model.Message.Trim();

            if (String.IsNullOrEmpty(model.Message))
            {
                return BadRequest(new { message = "The message can't be empty!" });
            }

            if (model.Message.Length > 300)
            {
                return BadRequest(new { message = "The message is too long!" });
            }


            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            User fromUser = _context.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();

            User toUser = await _userManager.FindByIdAsync(model.ToUserId);
            if (fromUser == null || toUser == null)
            {
                return NotFound(new { message = "The specified user can't be found! " });
            }

            var conversation = _context.Chat
                .Where(x =>
                (x.FromUserId == fromUser.Id || x.ToUserId == fromUser.Id) &&
                (x.FromUserId == model.ToUserId || x.ToUserId == model.ToUserId)
                ).FirstOrDefault();
            //.GroupBy(x => x.ConversationId)
            string conversationId = "";

            if(conversation == null)
            {
                string guid = "";
                //Generate a unique Id for the conversation
                //Generating GUID and keeps on looping until a unique GUID is created to be stored in in database
                do
                {
                    //GUID = globally unique identifier. Generates a set of string that will be used to generate a unique link
                    guid = Guid.NewGuid().ToString("N");
                    var checkDbForConversation = _context.Chat.Where(x => x.ConversationId == guid).FirstOrDefault();
                    if (checkDbForConversation == null)
                        break;

                } while (true);
                conversationId = guid;
            }else
            {
                //conversationId = conversation.Key;
                conversationId = conversation.ConversationId;
            }


            //If the message is between a user and restaurant, we need to maintain the "names" to be the name of the restaurant rather than the restaurant owner
            //That's the reason for this block of code
            var isSenderOwner = _context.RestaurantOwner.Where(x => x.UserId == fromUser.Id).FirstOrDefault();
            var isReceiverOwner = _context.RestaurantOwner.Where(x => x.UserId == toUser.Id).FirstOrDefault();
            string fromUserName = "";
            string toUserName = "";

            if(isSenderOwner != null)
            {
                fromUserName = _context.RestaurantDetails.Where(x => x.Id == isSenderOwner.RestaurantId).Select(x => x.Name).FirstOrDefault();
            }else if (isReceiverOwner != null)
            {
                toUserName = _context.RestaurantDetails.Where(x => x.Id == isReceiverOwner.RestaurantId).Select(x => x.Name).FirstOrDefault();
            }


            Chat sendChat = new Chat
            {
                ConversationId = conversationId,
                FromUserId = fromUser.Id,
                FromUserName = fromUserName == "" ? fromUser.FirstName + " " + fromUser.LastName : fromUserName,
                ToUserId = toUser.Id,
                ToUserName = toUserName == "" ? toUser.FirstName + " " + toUser.LastName : toUserName,
                Message = model.Message,
                SentAt = DateTime.Now,
                Read = false
            };

            await _context.Chat.AddAsync(sendChat);
            try { await _context.SaveChangesAsync(); return Ok( new { ConversationId = conversationId }); }
            catch (Exception e) { throw e; }
        }


        [HttpPost]
        [Route("SendChatMessageToRestaurant")]
        [Authorize]
        //POST api/Users/SendChatMessageToRestaurant
        public async Task<Object> SendChatMessageToRestaurant(SendChatMessageToRestaurantModel model)
        {
            //Get rid off whitespace
            model.Message = String.IsNullOrEmpty(model.Message) ? "" : model.Message.Trim();

            if (model.Message.Length > 300)
            {
                return BadRequest(new { message = "The message is too long!" });
            }


            //This is called when user is directly messaging the restaurant from the restaurant menu. It works for initiating the message
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            User fromUser = _context.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();
            var ToUserId = _context.RestaurantOwner.Where(x => x.RestaurantId == model.RestaurantId).Select(x => x.UserId).FirstOrDefault();
            User toUser = await _userManager.FindByIdAsync(ToUserId);

            if (fromUser == null || toUser == null)
            {
                return NotFound(new { message = "The specified user can't be found!" });
            }

            var conversation = _context.Chat
                .Where(x =>
                (x.FromUserId == fromUser.Id || x.ToUserId == fromUser.Id) &&
                (x.FromUserId == ToUserId || x.ToUserId == ToUserId)
                ).FirstOrDefault();
            //.GroupBy(x => x.ConversationId)
            string conversationId = "";

            if (conversation == null)
            {
                string guid = "";
                //Generate a unique Id for the conversation
                //Generating GUID and keeps on looping until a unique GUID is created to be stored in in database
                do
                {
                    //GUID = globally unique identifier. Generates a set of string that will be used to generate a unique link
                    guid = Guid.NewGuid().ToString("N");
                    var checkDbForConversation = _context.Chat.Where(x => x.ConversationId == guid).FirstOrDefault();
                    if (checkDbForConversation == null)
                        break;

                } while (true);
                conversationId = guid;
            }
            else
            {
                //conversationId = conversation.Key;
                conversationId = conversation.ConversationId;
            }

            //If the call is made with empty message, this is made to retrieve the conversationId. Just return the conversationId
            if (string.IsNullOrEmpty(model.Message))
            {
                return Ok(new { ConversationId = conversationId });
            }

            var restaurantDetails = _context.RestaurantDetails.Where(x => x.Id == model.RestaurantId).FirstOrDefault();

            Chat sendChat = new Chat
            {
                ConversationId = conversationId,
                FromUserId = fromUser.Id,
                FromUserName = fromUser.FirstName + " " + fromUser.LastName,
                ToUserId = toUser.Id,
                ToUserName = restaurantDetails.Name,
                Message = model.Message,
                SentAt = DateTime.Now,
                Read = false
            };

            await _context.Chat.AddAsync(sendChat);
            try { await _context.SaveChangesAsync(); return Ok(new { ConversationId = conversationId }); }
            catch (Exception e) { throw e; }
        }


        [HttpGet]
        [Route("GetConversation/{id}")]
        [Authorize]
        //GET api/Users/GetConversation/id=21131sadsa
        public async Task<Object> GetConversation(string id)
        {

            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            User user = _context.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();

            var conversation = _context.Chat.Where(x => x.ConversationId == id && (x.FromUserId == user.Id || x.ToUserId == user.Id)).OrderBy(x => x.SentAt).ToList();

            foreach(var convo in conversation)
            {
                if (convo.ToUserId == user.Id)
                    convo.Read = true;
                try { await _context.SaveChangesAsync(); }
                catch (Exception e) { throw e; }
            }

            return Ok(conversation);
        }

        [HttpGet]
        [Route("GetConversations")]
        [Authorize]
        //GET api/Users/GetConversations
        public async Task<Object> GetConversations()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            User user = _context.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();

            var conversationsIds = _context.Chat
                .Where(x => x.FromUserId == user.Id || x.ToUserId == user.Id)
                .OrderByDescending(x => x.SentAt)
                .GroupBy(x => x.ConversationId)
                .Select(x => new { ConversationId = x.Key, UnreadMessages = x.Where(x => x.Read == false && x.ToUserId == user.Id).Count() })
                .ToList();

            var conversations = new[] { new { ConversationWith = "", ConversationWithId = "", LastMessageAt = DateTime.Now, ConversationId = "", Unread = 0 } }.ToList();
            conversations.Clear();

            foreach(var convoId in conversationsIds)
            {
                var lastMessage = _context.Chat.Where(x => x.ConversationId == convoId.ConversationId).OrderByDescending(x => x.SentAt).FirstOrDefault();
                var conversation = new
                {
                    ConversationWith = lastMessage.FromUserId == user.Id ? lastMessage.ToUserName : lastMessage.FromUserName,
                    ConversationWithId = lastMessage.FromUserId == user.Id ? lastMessage.ToUserId : lastMessage.FromUserId,
                    LastMessageAt = lastMessage.SentAt,
                    ConversationId = convoId.ConversationId,
                    Unread = convoId.UnreadMessages
                };
                conversations.Add(conversation);
            }


            return Ok(conversations.OrderByDescending(x => x.LastMessageAt));


        }


        [HttpGet]
        [Route("GetUnreadCount")]
        [Authorize]
        //GET api/Users/GetUnreadCount
        public async Task<Object> GetUnreadCount()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            User user = _context.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();

            int numberOfUnreadMessages = _context.Chat
                .Where(x => x.Read == false && x.ToUserId == user.Id).Count();
            return Ok(numberOfUnreadMessages);
        }




        [HttpPost]
        [Route("AddApplicantRestaurant")]
        //POST api/Users/AddApplicantRestaurant
        public async Task<Object> AddApplicantRestaurant(ApplicantRestaurantModel model)
        {
            //Get rid off whitespace
            model.RestaurantName = String.IsNullOrEmpty(model.RestaurantName) ? "" : model.RestaurantName.Trim();
            model.RestaurantCity = String.IsNullOrEmpty(model.RestaurantCity) ? "" : model.RestaurantCity.Trim();
            model.RestaurantStreet = String.IsNullOrEmpty(model.RestaurantStreet) ? "" : model.RestaurantStreet.Trim();
            model.FirstName = String.IsNullOrEmpty(model.FirstName) ? "" : model.FirstName.Trim();
            model.LastName = String.IsNullOrEmpty(model.LastName) ? "" : model.LastName.Trim();
            model.Email = String.IsNullOrEmpty(model.Email) ? "" : model.Email.Trim();
            model.PhoneNumber = String.IsNullOrEmpty(model.PhoneNumber) ? "" : model.PhoneNumber.Trim();




            if ( (String.IsNullOrEmpty(model.RestaurantName)) ||
                (String.IsNullOrEmpty(model.RestaurantCity)) ||
                (String.IsNullOrEmpty(model.RestaurantStreet)) ||
                (String.IsNullOrEmpty(model.FirstName)) ||
                (String.IsNullOrEmpty(model.LastName)) ||
                (String.IsNullOrEmpty(model.Email)) ||
                (String.IsNullOrEmpty(model.PhoneNumber)))  
            {
                return BadRequest(new { message = "There can't be empty fields!" });
            }

            var addr = new System.Net.Mail.MailAddress(model.Email);
            if (addr.Address != model.Email)
            {
                return BadRequest(new { message = "Not a valid Email." });
            }

            var dbUser = _context.ApplicationUsers.Where(x => x.Email == model.Email).FirstOrDefault();
            if(dbUser != null) // If there already is someone with this email
            {
                return BadRequest(new { message = "This email is already registered in the system, the email '" + model.Email + "' can't be used as partner account." });
            }

            //Check if the email has already submitted a registration
            var dbApplicant = _context.ApplicantRestaurants.Where(x => x.Email == model.Email).FirstOrDefault();
            if(dbApplicant != null)
            {
                return BadRequest(new { message = "This email has already applied for partner registration" });
            }

            string guid = "";
            //Generating GUID and keeps on looping until a unique GUID is created to be stored in in database
            do
            {
                //GUID = globally unique identifier. Generates a set of string that will be used to generate a unique link
                guid = Guid.NewGuid().ToString("N");
                var checkDbforApplicant = _context.ApplicantRestaurants.Where(x => x.GUID == guid).FirstOrDefault();
                if(checkDbforApplicant == null)
                    break;
                
            } while (true);


            //Preparing a lambda function to capitalise the first letter of all words
            Func<string, string> capitaliseString = (string text) => 
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            };

            //Apply the fix to the strings if it was typed wrong
            model.RestaurantName = capitaliseString(model.RestaurantName);
            model.RestaurantCity = capitaliseString(model.RestaurantCity);
            model.RestaurantStreet = capitaliseString(model.RestaurantStreet);
            model.FirstName = capitaliseString(model.FirstName);
            model.LastName = capitaliseString(model.LastName);



            ApplicantRestaurants applicant = new ApplicantRestaurants
            {
                RestaurantName = model.RestaurantName,
                RestaurantCity = model.RestaurantCity,
                RestaurantStreet = model.RestaurantStreet,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                EmailConfirmed = false,
                PhoneNumber = model.PhoneNumber,
                GUID = guid,
                CreatedAt = DateTime.Now
            };

            _context.ApplicantRestaurants.Add(applicant);
            try
            {
                await _context.SaveChangesAsync();


                string link = "http://localhost:4200/partner/confirmEmail?guid=" + guid + "&id=" +applicant.Id;

                SendEmailAsync(model.Email, "Confirm your Email - Food Hub ",
                    "<h3>Thank you for signing up to <strong> Food Hub <strong> as a partner!<h3>" +
                    "<br>" +
                    "<hr>" +
                    "<h3>Partner details:</h3>" +
                    "<h5>Applicant ID: " + applicant.Id + " <h5>" +
                    "<h5>Restaurant name: " + model.RestaurantName + " <h5>" +
                    "<h5>Restaurant city: " + model.RestaurantCity + " <h5>" +
                    "<h5>Restaurant street: " + model.RestaurantStreet + " <h5>" +
                    "<h5>Applicant full name: " + model.FirstName + " " + model.LastName + " <h5>" +
                    "<h5>Applicant phone number: " + model.PhoneNumber + " <h5>" +
                    "<hr>" +
                    "<p>Before we can proceed on reviewing your application we need to prove the legitamacy of your email, please click the link below " +
                    "to confirm this email.</p>" +
                    "<p>Your confirmation link: <strong><a href='" + link + "'> Click to confirm your email</a> <strong></p>");


                return Ok();
            }
            catch (Exception e){
                new InvalidOperationException(e.Message);
                
            }

            return BadRequest(new { message = "Something went wrong, could not add restaurant to applicant list."});
        }


        [HttpPost]
        [Route("PartnerConfirmMail")]
        //POST api/Users/PartnerConfirmMail
        public async Task<Object> PartnerConfirmMail(PartnerConfirmMailModel model)
        {

            var dbApplicant = _context.ApplicantRestaurants.Where(x => x.Id == model.Id && x.GUID == model.GUID).FirstOrDefault();
            if (dbApplicant != null)
            {
                if (dbApplicant.EmailConfirmed)
                {
                    return BadRequest(new { message = "This email is already confirmed." });
                }
                dbApplicant.EmailConfirmed = true;
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest(new { message = "Wrong critidentials." });
        }



        private async Task SendEmailAsync(string email, string subject, string body) //mailing function
        {
            email = email.Trim();
            subject = subject.Trim();
            body = body.Trim();


            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(_smtpSettings.SenderName, _smtpSettings.SenderEmail));
                message.To.Add(new MailboxAddress("Food Hub User", email));
                message.Subject = subject;
                message.Body = new TextPart("html")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    if (_env.IsDevelopment())
                    {
                        await client.ConnectAsync(_smtpSettings.Server, _smtpSettings.Port, true);
                    }
                    else
                    {
                        await client.ConnectAsync(_smtpSettings.Server);
                    }

                    await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
                    //await client.AuthenticateAsync("food.hub.project.noreply@gmail.com", "graduationproject");
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }

            await Task.CompletedTask;
        }



    }
}
