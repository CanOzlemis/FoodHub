using FoodHubAPI.Models;
using FoodHubAPI.Models.Interface;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FoodHubAPI.Models.Enum.enums;

namespace FoodHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private UserManager<User> _userManager;
        private readonly SmtpSettings _smtpSettings; //for mailing
        private readonly IWebHostEnvironment _env; //for mailing

        public AdminController(
            ApplicationContext context, 
            UserManager<User> userManager,
            IOptions<SmtpSettings> smtpSettings,
            IWebHostEnvironment env
            )
        {
            _context = context;
            _userManager = userManager;
            _smtpSettings = smtpSettings.Value;
            _env = env;
        }


        // GET: api/Admin/Restaurants/GetAll
        [HttpGet]
        [Route("Restaurants/GetAll")]
        [Authorize(Roles = "Admin")]
        public async Task<object> RestaurantsGetAll()
        {
            //List of all restaurant details
            List<RestaurantDetail> RD = await _context.RestaurantDetails.OrderByDescending(x => x.ActivationRequest).ThenByDescending(x => x.Updated).ToListAsync();
            return Ok(RD);
        }

        // GET: api/Admin/RestaurantDetails/{id}
        [HttpGet]
        [Route("RestaurantDetails/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> RestaurantDetails(int id)
        {
            //Collect the restaurant details
            var restaurantDetails = await _context.RestaurantDetails.Where(x => x.Id == id).FirstOrDefaultAsync();
            //Collect the working times of the restaurant
            var workingTimes = await _context.WorkingTimes.Where(x => x.RestaurantId == restaurantDetails.Id).OrderBy(x => x.Day).Select(x => new
            {
                Id = x.Id,
                RestaurantId = x.RestaurantId,
                Day = x.Day,
                OpenAt = new { Hour = x.OpenTime.Hours < 10 ? ('0' + x.OpenTime.Hours.ToString()) : (x.OpenTime.Hours.ToString()), Minute = x.OpenTime.Minutes < 10 ? ('0' + x.OpenTime.Minutes.ToString()) : (x.OpenTime.Minutes.ToString()) },
                CloseAt = new { Hour = x.CloseTime.Hours < 10 ? ('0' + x.CloseTime.Hours.ToString()) : (x.CloseTime.Hours.ToString()), Minute = x.CloseTime.Minutes < 10 ? ('0' + x.CloseTime.Minutes.ToString()) : (x.CloseTime.Minutes.ToString()) },
            }).ToListAsync();

            //Collect the most recent 5 ratings and generate happiness from it
            var rating = await _context.RatingAndReview
                .Where(x => x.RestaurantId == restaurantDetails.Id)
                .OrderBy(x => x.Created)
                .Take(5).ToListAsync();
            //Collect the restaurant image
            var Image = await _context.Images.Where(x => x.RestaurantId == restaurantDetails.Id).Select(x => x.Image).FirstOrDefaultAsync();

            string happiness;
            if (rating.Count == 0)
            {
                happiness = "Empty";
            }
            else
            {
                var avgRating = rating.Average(x => x.Rating);
                happiness = (avgRating >= 3) ? "Happy" : (avgRating >= 2) ? "Satisfied" : "Unhappy";
            }

            var ownerId = await _context.RestaurantOwner.Where(x => x.RestaurantId == restaurantDetails.Id).Select(x => x.UserId).FirstOrDefaultAsync();
            //Collect the information of the restaurant owner
            var ownerInfo = await _context.ApplicationUsers.Where(x => x.Id == ownerId).Select(x => new
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Created = x.Created,
                Updated = x.Updated,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber
            }).FirstOrDefaultAsync();

            //Current earnings (this months) of the restaurant
            var currentEarnings = await _context.PreviousEarnings
                .Where(x => x.RestaurantId == restaurantDetails.Id && x.Year == DateTime.Now.Year && x.Month == DateTime.Now.Month)
                .Select(x => x.Total)
                .FirstOrDefaultAsync();

            //Earning history of the restaurant
            var previousMonthsEarnings = await _context.PreviousEarnings
                .Where(x => x.RestaurantId == restaurantDetails.Id)
                .OrderByDescending(x => x.Year).ThenByDescending(x => x.Month)
                .Select(x => new
                {
                    Year = x.Year,
                    Month = x.Month,
                    Total = x.Total
                }).ToListAsync();

            return Ok(new { 
                RestaurantDetails = restaurantDetails, 
                WorkingTimes = workingTimes, 
                OwnerInfo = ownerInfo, 
                CurrentEarnings = currentEarnings, 
                PreviousMonthsEarnings = previousMonthsEarnings,
                Image = Image,
                Happiness = happiness
            });
        }


        // GET: api/Admin/GetApplicants
        [HttpGet]
        [Route("GetApplicants")]
        [Authorize(Roles = "Admin")]
        public async Task<object> GetApplicants()
        {
            List<ApplicantRestaurants> applicants = await _context.ApplicantRestaurants.OrderBy(x => x.CreatedAt).ToListAsync();
            return Ok(applicants);
        }

        // POST: api/Applicant/Approve
        [HttpPost]
        [Route("Applicant/Approve")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<RestaurantDetail>> ApplicantApprove(IdModel model)
        {
            var Now = DateTime.Now;
            var applicant = await _context.ApplicantRestaurants.Where(x => x.Id == model.Id).FirstOrDefaultAsync();


            if(applicant == null)
            {
                return NotFound(new { message = "Applicant with this ID does not exist!" });
            }

            User tempUser = new User
            {
                FirstName = applicant.FirstName,
                LastName = applicant.LastName,
                Email = applicant.Email,
                EmailConfirmed = true,
                UserName = applicant.Email,
                PhoneNumber = applicant.PhoneNumber,
                PhoneNumberConfirmed = true,
                Created = Now,
                Updated = Now
            };

            bool doesExist = await _context.ApplicationUsers.Where(x => x.Email == tempUser.Email).FirstOrDefaultAsync() != null;
            if (doesExist)
            {
                return BadRequest(new { message = "This email is already registered." });
            }


            //Generate password for user that will follow the password requirements
            char[] password = new char[16];
            for(int i = 0; i < 16; i++)
            {
                if(i < 6)
                    password[i] = (char)new Random().Next(65, 91); //capital letters
                else if(i < 13)
                    password[i] = (char)new Random().Next(97, 123); //small letters
                else
                    password[i] = (char)new Random().Next(48, 58); //numbers
            }
            
            try
            {
                var resultUser = await _userManager.CreateAsync(tempUser, new string(password));
                await _userManager.AddToRoleAsync(tempUser, "Owner");
                //The user will be emailed the reset password link once all process is done
                
            }
            catch (Exception e)
            {
                throw e;
            }

            //Add restaurant to the database
            RestaurantDetail restaurant = new RestaurantDetail
            {
                Name = applicant.RestaurantName,
                About = "",
                Rating = 0,
                AverageDeliveryTime = 0,
                MinOrderPrice = 0,
                Approved = true,
                Created = Now,
                Updated = Now,
                Active = false,
                City = applicant.RestaurantCity,
                Street = applicant.RestaurantStreet
            };


            try
            {
                await _context.RestaurantDetails.AddAsync(restaurant);
                await _context.SaveChangesAsync();


                List<WorkingTimes> allWorkingTimes = new List<WorkingTimes> { };
                for (var i = 0; i < 7; i++)
                {
                    allWorkingTimes.Add(new WorkingTimes
                    {
                        RestaurantId = restaurant.Id,
                        Day = i,
                        OpenTime = new TimeSpan(0, 0, 0),
                        CloseTime = new TimeSpan(0, 0, 0)
                    });
                }
                await _context.WorkingTimes.AddRangeAsync(allWorkingTimes);
                await _context.SaveChangesAsync();


                RestaurantOwner owner = new RestaurantOwner
                {
                    RestaurantId = restaurant.Id,
                    UserId = tempUser.Id
                };

                await _context.RestaurantOwner.AddAsync(owner);
                _context.ApplicantRestaurants.Remove(applicant);

                await _context.SaveChangesAsync();

                string link = "http://localhost:4200/resetPassword?id=" + (string)tempUser.Id + "&hash=" + (string)tempUser.PasswordHash;
                SendEmailAsync(tempUser.Email, "Your restaurant has been accepted! - Food Hub",
                    "<h1>Your restaurant has been accepted! - Food Hub</h1>" +
                    "<hr>" +
                    "<p>Your restaurant has been accepted to Foob Hub. In order to login into your account you need to click the link below and set your password." +
                    "<br>" +
                    "Once you have chosen a password, you can login using this email to the system and start custimasing your details.</p>" +
                    "<a href=' " + link + "'> Choose your password</a>");

            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok();
        }


        // POST: api/Applicant/Decline
        [HttpPost]
        [Route("Applicant/Decline")]
        [Authorize(Roles = "Admin")]
        public async Task<object> ApplicantDecline(IdModel model)
        {
            var applicant = await _context.ApplicantRestaurants.Where(x => x.Id == model.Id).FirstOrDefaultAsync();

            if (applicant == null)
            {
                return NotFound(new { message = "Applicant with this ID does not exist!" });
            }

            _context.Remove(applicant);

            try
            {
                await _context.SaveChangesAsync();
                SendEmailAsync(applicant.Email, "Your restaurant has been declined! - Food Hub",
                "<h1>Your restaurant has been declined! - Food Hub</h1>" +
                "<hr>" +
                "<p>We are sorry to inform you that your partner application for Food Hub has been rejected." +
                "</p>");
            }
            catch(Exception e)
            {
                throw e;
            }

            return Ok();
        }


        // POST: api/EnableRestaurant
        [HttpPost]
        [Route("EnableRestaurant")]
        [Authorize(Roles = "Admin")]
        public async Task<object> EnableRestaurant(IdModel model)
        {
            var restaurant = await _context.RestaurantDetails.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (restaurant == null) { return NotFound(new { message = "Restaurant with this ID does not exist!" }); }

            var ownerId = await _context.RestaurantOwner.Where(x => x.RestaurantId == restaurant.Id).Select(x => x.UserId).FirstOrDefaultAsync();
            if(ownerId == null) { return BadRequest(new { message = "Could not find the owner for the restaurant!" }); }

            var ownerData = await _userManager.FindByIdAsync(ownerId);
            if(ownerData == null) { return BadRequest(new { message = "Couldn't retrieve the owner data!" }); }

            restaurant.Active = true;
            restaurant.Updated = DateTime.Now;
            restaurant.ActivationRequest = false;

            SendEmailAsync(ownerData.Email, "Your restaurant has been activated - Food Hub", "<h1>Your restaurant has been activated</h1>" +
                "<p>Your restaurant has been activated by our adminastrators. Your restaurant is now visible to everyone and you can keep using it normally. Thank you for your patiance.</p>");

            try { await _context.SaveChangesAsync(); }
            catch(Exception e) { throw e; }

            return Ok();
        }

        // POST: api/EnableRestaurant
        [HttpPost]
        [Route("DisableRestaurant")]
        [Authorize(Roles = "Admin")]
        public async Task<object> DisableRestaurant(IdModel model)
        {
            var restaurant = await _context.RestaurantDetails.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (restaurant == null) { return NotFound(new { message = "Restaurant with this ID does not exist!" }); }

            var ownerId = await _context.RestaurantOwner.Where(x => x.RestaurantId == restaurant.Id).Select(x => x.UserId).FirstOrDefaultAsync();
            if (ownerId == null) { return BadRequest(new { message = "Could not find the owner for the restaurant!" }); }

            var ownerData = await _userManager.FindByIdAsync(ownerId);
            if (ownerData == null) { return BadRequest(new { message = "Couldn't retrieve the owner data!" }); }


            SendEmailAsync(ownerData.Email, "Your restaurant has been disabled - Food Hub", "<h1>Your restaurant has been disabled</h1>" +
                "<p>Your restaurant has been disabled by our adminastrators. Your restaurant is now invisible to everyone, you can still login and manage your restaurant. " +
                "You can contact one of the adminastrators if you have any questions. Thank you for your patiance.</p>");

            restaurant.Active = false;
            restaurant.Updated = DateTime.Now;

            try { await _context.SaveChangesAsync(); }
            catch (Exception e) { throw e; }

            return Ok();
        }


        // GET: api/Admin/GetUsers
        [HttpGet]
        [Route("GetUsers")]
        [Authorize(Roles = "Admin")]
        public async Task<object> GetUsers()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;

            var users = await _context.ApplicationUsers.Where(x => x.Id != userId).Select(x => new
            {
                Name = x.FirstName + " " + x.LastName,
                x.FirstName,
                x.LastName,
                x.Address,
                x.Created,
                x.Email,
                x.EmailConfirmed,
                x.Id,
                x.PhoneNumber,
                x.PhoneNumberConfirmed,
                x.Updated,
                Role = _context.Roles.Where(y => _context.UserRoles.Where(t => t.UserId == x.Id).Select(z => z.RoleId).FirstOrDefault() == y.Id ).Select(y => y.Name).FirstOrDefault()
            }).OrderBy(x => x.Created).ToListAsync();
            return Ok(users);
        }


        // GET: api/Admin/GetUserDetails/{id}
        [HttpGet("GetUserDetails/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> GetUserDetails(string id)
        {
            var user = await _context.ApplicationUsers.Where(x => x.Id == id).Select( x => new 
            { 
                Name = x.FirstName + " " + x.LastName,
                x.FirstName,
                x.LastName,
                x.Address,
                x.Created,
                x.Email,
                x.EmailConfirmed,
                x.Id,
                x.PhoneNumber,
                x.PhoneNumberConfirmed,
                x.Updated
            }).FirstOrDefaultAsync();
            if(user == null) { return NotFound(new { message = "Couldn't find the user." }); }
            var allRoles = await _context.Roles.ToListAsync();
            var userRole = await _context.UserRoles.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
            var roleResult = allRoles.Find(x => x.Id == userRole.RoleId);

            var isBanned = await _context.BanList.Where(x => x.UserId == user.Id).FirstOrDefaultAsync() != null;
            //User order data, only the 7 most recent orders 
            List<Order> orders = _context.Order.Where(x => x.UserId == id).OrderByDescending(x => x.Created).Take(7).ToList();

            List<object> AllOrders = new List<object> { };
            foreach (Order order in orders)
            {
                List<OrderDetailsNamed> orderDetails = _context.OrderDetails.Where(x => x.OrderId == order.Id).Select(x => new OrderDetailsNamed
                {
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductUnitPrice,
                    Quantity = x.Quantity
                }).ToList();

                string nameOfRestaurant = _context.RestaurantDetails.Where(x => x.Id == order.RestaurantId).Select(x => x.Name).FirstOrDefault();
                var review = _context.RatingAndReview.Where(x => x.OrderId == order.Id).Select(x => new { x.Comment, x.Response, x.Rating }).FirstOrDefault();

                AllOrders.Add(new
                {
                    OrderId = order.Id,
                    Address = order.Address,
                    Note = order.Note,
                    Restaurant = nameOfRestaurant,
                    Status = order.Status,
                    Created = order.Created,
                    Updated = order.Updated,
                    Details = orderDetails,
                    Review = review
                });

            }

            return Ok(new { User = user, Role = roleResult.Name.ToString(), Orders = AllOrders, IsBanned = isBanned });
        }

        // GET: api/Admin/GetUserReviews/{id}
        [HttpGet("GetUserReviews/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<object> GetUserReviews(string id)
        {
            var user = await _context.ApplicationUsers.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user == null) { return NotFound(new { message = "Couldn't find the user." }); }

            List < Order > orders = _context.Order.Where(x => x.UserId == id).OrderByDescending(x => x.Created).ToList();

            List<object> reviews = new List<object> { };
            foreach (Order order in orders)
            {
                List<OrderDetailsNamed> orderDetails = _context.OrderDetails.Where(x => x.OrderId == order.Id).Select(x => new OrderDetailsNamed
                {
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductUnitPrice,
                    Quantity = x.Quantity
                }).ToList();

                string nameOfRestaurant = _context.RestaurantDetails.Where(x => x.Id == order.RestaurantId).Select(x => x.Name).FirstOrDefault();
                var review = _context.RatingAndReview.Where(x => x.OrderId == order.Id && x.Comment != "" && x.Comment != null).Select(x => new 
                { 
                    x.OrderId,
                    x.Comment, 
                    x.Rating, 
                    x.Created, 
                    x.Deleted,
                    RestaurantName = nameOfRestaurant 
                }).FirstOrDefault();


                if(review != null)
                {
                    reviews.Add(review);
                }
            }

            return Ok(reviews);
        }

        // DELETE: api/Admin/DeleteReview/{id}
        [HttpDelete]
        [Route("DeleteReview/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ConfirmPhoneNumber(int id)
        {
            var review = await _context.RatingAndReview.Where(x => x.OrderId == id).FirstOrDefaultAsync();

            if(review == null)
            {
                return NotFound(new { message = "Specified review could not be found." });
            }

            review.Deleted = true;
            
            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok();
        }


        // POST: api/Admin/ResetUserPassword
        [HttpPost]
        [Route("ResetUserPassword")]
        [Authorize(Roles = "Admin")]
        public async Task<object> ResetUserPassword(UserIdModel model)
        {
            User user = await _context.ApplicationUsers.Where(x => x.Id == model.UserId).FirstOrDefaultAsync();
            if (user == null) { return NotFound(new { message = "Couldn't find the user." }); }

            char[] password = new char[16];
            for (int i = 0; i < 16; i++)
            {
                if (i < 6)
                    password[i] = (char)new Random().Next(65, 91); //capital letters
                else if (i < 13)
                    password[i] = (char)new Random().Next(97, 123); //small letters
                else
                    password[i] = (char)new Random().Next(48, 58); //numbers
            }


            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, token, new string(password));

            if (result.Succeeded)
            {
                user.Updated = DateTime.Now;
                _context.SaveChanges();
                

                string link = "http://localhost:4200/resetPassword?id=" + (string)user.Id + "&hash=" + (string)user.PasswordHash;
                SendEmailAsync(user.Email, "Password reset request - Food Hub",
                                   "<h1>Password reset request - Food Hub</h1>" +
                                   "<hr>" +
                                   "<p>An administrator has resetted your password.</p>" +
                                   "<a href='" + link + "'> Click here to write your new password</a>");
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Password could not be resetted" });
            }


        }



        // POST: api/Admin/SendMail
        [HttpPost]
        [Route("SendMail")]
        [Authorize(Roles = "Admin")]
        public async Task<object> SendMail(SendMailModel model)
        {
            //Get rid off whitespace
            model.Body = String.IsNullOrEmpty(model.Body) ? "" : model.Body.Trim();
            model.Title = String.IsNullOrEmpty(model.Title) ? "" : model.Title.Trim();

            if(String.IsNullOrEmpty(model.Body) || String.IsNullOrEmpty(model.Title))
            {
                return BadRequest(new { message = "The title or the body can't be empty..." });
            }

            string adminId = User.Claims.First(x => x.Type == "UserID").Value;
            User admin = await _context.ApplicationUsers.Where(x => x.Id == adminId).FirstOrDefaultAsync();

            User user = await _context.ApplicationUsers.Where(x => x.Id == model.UserId).FirstOrDefaultAsync();
            if (user == null) { return NotFound(new { message = "Couldn't find the user." }); }


            SendEmailAsync(user.Email, model.Title + "- Food Hub", "<h1>Admin message - Food Hub</h1> <br>" +
                "<hr>" +
                "<p>(This mail is sent from the the Food Hub website by one of our administrators. Please do not respond to the mail since it will not be read) <br>" +
                "<strong>Admin name: " + admin.FirstName + "</strong></p>" +
                "<p>" + model.Body + "</p>");

            return Ok();
        }


        // POST: api/Admin/ConfirmPhoneNumber
        [HttpPost]
        [Route("ConfirmPhoneNumber")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ConfirmPhoneNumber(UserIdModel model)
        {
            var user = _context.ApplicationUsers.Where(x => x.Id == model.UserId).FirstOrDefault();
            if (user == null)
            {
                return BadRequest(new { message = "Couldn't find the user." });
            }
            if (user.PhoneNumberConfirmed) //phone number is already confirmed
            {
                return Ok(); //No need to show error. Act like success
            }

            user.PhoneNumberConfirmed = true;
            user.Updated = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/Admin/ConfirmEmail
        [HttpPost]
        [Route("ConfirmEmail")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ConfirmEmail(UserIdModel model)
        {
            var user = _context.ApplicationUsers.Where(x => x.Id == model.UserId).FirstOrDefault();
            if (user == null)
            {
                return BadRequest(new { message = "Couldnt find the user." });
            }
            if (user.EmailConfirmed) //email is already confirmed
            {
                return Ok(); //No need to show error. Act like success
            }

            user.EmailConfirmed = true;
            user.Updated = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok();
        }


        // GET: api/Admin/GetUsers
        [HttpGet]
        [Route("GetFeedbacks")]
        [Authorize(Roles = "Admin")]
        public async Task<object> GetFeedbacks()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;

            var feedbacks = await _context.Feedback.OrderByDescending(x => x.Type).ThenByDescending(x => x.Created).ToListAsync();

            return Ok(feedbacks);
        }

        // POST: api/Admin/BanUser
        [HttpPost]
        [Route("BanUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BanUser(BanModel model)
        {
            var user = _context.ApplicationUsers.Where(x => x.Id == model.UserId).FirstOrDefault();
            if (user == null)
            {
                return BadRequest(new { message = "Couldn't find the user." });
            }

            var checkUserBan = await _context.BanList.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();

            if(checkUserBan != null)
            {
                return BadRequest(new { message = "This user is already banned." });
            }

            BanList obj = new BanList
            {
                UserId = user.Id
            };

            await _context.BanList.AddAsync(obj);
            await _context.SaveChangesAsync();

            SendEmailAsync(user.Email, "You have been banned - Food Hub", "<h1>You have been banned</h1>" +
                    "<p>Your account with the mail '" + user.Email + "' has been banned by one of our admins.</p>");

            var allRoles = await _context.Roles.ToListAsync();
            var userRole = await _context.UserRoles.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
            var roleResult = allRoles.Find(x => x.Id == userRole.RoleId);

            if(roleResult.Name == "Owner")
            {
                //Disable the restaurant
                var restaurantId = await _context.RestaurantOwner.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();
                var restaurant = await _context.RestaurantDetails.Where(x => x.Id == restaurantId.RestaurantId).FirstOrDefaultAsync();
                restaurant.Active = false;
                restaurant.Updated = DateTime.Now;

                SendEmailAsync(user.Email, "Your restaurant has been disabled - Food Hub", "<h1>Your restaurant has been disabled</h1>" +
                    "<p>We would like to inform you that your restaurant has been disabled because your account has been banned. All of your orders have been rejected. This mail is sent for information purposes only.</p>");

                //Cancel all active orders
                var allActiveRestaurantOrders = await _context.Order.Where(x => x.RestaurantId == restaurant.Id && x.Status == Status.Waiting.ToString() || x.Status == Status.Accepted.ToString()).ToListAsync();
                foreach(var order in allActiveRestaurantOrders)
                {
                    order.Status = Status.Rejected.ToString();
                    order.Note = "THE RESTAURANT HAS BEEN DISABLED... Your note: " + order.Note;
                    order.Updated = DateTime.Now;
                }

                //Inform the users that their orders have been rejected
                var rejectedUsers = allActiveRestaurantOrders.GroupBy(x => x.UserId).ToList();
                foreach(var rejectedUser in rejectedUsers)
                {
                    var rejectedUserEmail = _context.ApplicationUsers.Where(x => x.Id == rejectedUser.Key).Select(x => x.Email).FirstOrDefault();

                    SendEmailAsync(rejectedUserEmail, "Your order has been cancelled - Food Hub", "<h1>Your order has been rejected</h1>" +
                   "<p>We are sorry to inform you that your order(s) for '" + restaurant.Name + "' have been cancelled due to the restaurant being disabled. </p>");
                }

                try { await _context.SaveChangesAsync(); return Ok(); }
                catch (Exception e) { throw e; }
            } else if (roleResult.Name == "User")
            {
                var userOrders = await _context.Order.Where(x => x.UserId == user.Id && (x.Status != Status.Rejected.ToString() || x.Status != Status.Completed.ToString())).ToListAsync();

                foreach(var order in userOrders)
                {
                    order.Status = Status.Rejected.ToString();
                    order.Updated = DateTime.Now;
                    order.Note = "THIS USER HAS BEEN BANNED... Your note: " + order.Note;
                }

                try { await _context.SaveChangesAsync(); return Ok(); }
                catch (Exception e) { throw e; }
            }

            return Ok();
        }

        // POST: api/Admin/UnbanUser
        [HttpPost]
        [Route("UnbanUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UnbanUser(UserIdModel model)
        {
            var user = _context.ApplicationUsers.Where(x => x.Id == model.UserId).FirstOrDefault();
            if (user == null)
            {
                return BadRequest(new { message = "Couldn't find the user." });
            }

            var bannedUser = await _context.BanList.Where(x => x.UserId == user.Id).FirstOrDefaultAsync();

            if (bannedUser == null)
            {
                return BadRequest(new { message = "This user is not banned." });
            }


            SendEmailAsync(user.Email, "You have been unbanned - Food Hub", "<h1>You have been unbanned!</h1>" +
                        "<p>Your account with the mail '" + user.Email + "' has been unbanned by one of our admins. Enjoy using the system.</p>");

            _context.BanList.Remove(bannedUser);
            await _context.SaveChangesAsync();

            return Ok();
        }




        private async Task SendEmailAsync(string email, string subject, string body) //mailing function
        {
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
