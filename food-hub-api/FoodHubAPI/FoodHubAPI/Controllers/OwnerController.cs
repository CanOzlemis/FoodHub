using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
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
using static FoodHubAPI.Models.Enum.enums;

namespace FoodHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {

        private readonly ApplicationContext _context;
        private UserManager<User> _userManager;
        private readonly SmtpSettings _smtpSettings; //for mailing
        private readonly IWebHostEnvironment _env; //for mailing

        public OwnerController(
            ApplicationContext context, 
            UserManager<User> userManager,
            IOptions<SmtpSettings> smtpSettings,
            IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _smtpSettings = smtpSettings.Value;
            _env = env;
        }



        // GET: api/Owner/OwnerRestaurantDetails
        [HttpGet]
        [Route("OwnerRestaurantDetails")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<Object>> GetDetailsBasedOnOwner()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = await _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            var rating = await _context.RatingAndReview
                .Where(x => x.RestaurantId == restaurant.RestaurantId)
                .OrderBy(x => x.Created)
                .Take(5).ToListAsync();
            var Image = await _context.Images.Where(x => x.RestaurantId == restaurant.RestaurantId).Select(x => x.Image).FirstOrDefaultAsync();

            string happiness;
            if(rating.Count == 0)
            {
                happiness = "Empty";
            }else
            {
                var avgRating = rating.Average(x => x.Rating);
                happiness = (avgRating >= 3) ? "Happy" : (avgRating >= 2) ? "Satisfied" : "Unhappy";
            }

            var restaurantDetail = await _context.RestaurantDetails.FindAsync(restaurant.RestaurantId);
            if (restaurantDetail == null)
            {
                return NotFound();
            }
            restaurantDetail.Rating = float.Parse(restaurantDetail.Rating.ToString("N2"));

            var workingTime = await _context.WorkingTimes.Where(x => x.RestaurantId == restaurantDetail.Id).OrderBy(x => x.Day).Select(x => new
            {
                Id = x.Id,
                RestaurantId = x.RestaurantId,
                Day = x.Day,
                OpenAt = new { Hour = x.OpenTime.Hours < 10 ? ('0' + x.OpenTime.Hours.ToString()) : (x.OpenTime.Hours.ToString()), Minute = x.OpenTime.Minutes < 10 ? ('0' + x.OpenTime.Minutes.ToString()) : (x.OpenTime.Minutes.ToString()) },
                CloseAt = new { Hour = x.CloseTime.Hours < 10 ? ('0' + x.CloseTime.Hours.ToString()) : (x.CloseTime.Hours.ToString()), Minute = x.CloseTime.Minutes < 10 ? ('0' + x.CloseTime.Minutes.ToString()) : (x.CloseTime.Minutes.ToString()) },
            }).ToListAsync();


            return new { restaurantDetail, workingTime, happiness, Image };

        }


        // HttpPatch: api/Owner/Update
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPatch]
        [Route("Update")]
        [Authorize(Roles = "Owner, Admin")]
        public async Task<IActionResult> UpdateRestaurantDetails(UpdatedRestaurantDetailsModel newRestaurantDetail)
        {
            //Get rid off whitespace
            newRestaurantDetail.newRestaurantDetails.About = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.About) ? "" : newRestaurantDetail.newRestaurantDetails.About.Trim();
            newRestaurantDetail.newRestaurantDetails.Facebook = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.Facebook) ? "" : newRestaurantDetail.newRestaurantDetails.Facebook.Trim();
            newRestaurantDetail.newRestaurantDetails.Instagram = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.Instagram) ? "" : newRestaurantDetail.newRestaurantDetails.Instagram.Trim();
            newRestaurantDetail.newRestaurantDetails.MapSrc = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.MapSrc) ? "" : newRestaurantDetail.newRestaurantDetails.MapSrc.Trim();
            newRestaurantDetail.newRestaurantDetails.PhoneNumber = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.PhoneNumber) ? "" : newRestaurantDetail.newRestaurantDetails.PhoneNumber.Trim();
            newRestaurantDetail.newRestaurantDetails.Twitter = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.Twitter) ? "" : newRestaurantDetail.newRestaurantDetails.Twitter.Trim();

            //If empty, set to null
            newRestaurantDetail.newRestaurantDetails.About = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.About) ? null : newRestaurantDetail.newRestaurantDetails.About;
            newRestaurantDetail.newRestaurantDetails.Facebook = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.Facebook) ? null : newRestaurantDetail.newRestaurantDetails.Facebook;
            newRestaurantDetail.newRestaurantDetails.Instagram = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.Instagram) ? null : newRestaurantDetail.newRestaurantDetails.Instagram;
            newRestaurantDetail.newRestaurantDetails.MapSrc = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.MapSrc) ? null : newRestaurantDetail.newRestaurantDetails.MapSrc;
            newRestaurantDetail.newRestaurantDetails.PhoneNumber = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.PhoneNumber) ? null : newRestaurantDetail.newRestaurantDetails.PhoneNumber;
            newRestaurantDetail.newRestaurantDetails.Twitter = String.IsNullOrEmpty(newRestaurantDetail.newRestaurantDetails.Twitter) ? null : newRestaurantDetail.newRestaurantDetails.Twitter;



            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = await _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefaultAsync();

            RestaurantDetail restaurantDetail = await _context.RestaurantDetails.FindAsync(restaurant.RestaurantId);

            if (restaurantDetail == null)
            {
                return NotFound();
            }

            if( newRestaurantDetail.newRestaurantDetails.Image != null && newRestaurantDetail.newRestaurantDetails.Image.Length > 0)
            {

                //deal with image
                Images imageData = await _context.Images.Where(x => x.RestaurantId == restaurant.RestaurantId).FirstOrDefaultAsync();

                //Image compression
                System.IO.MemoryStream myMemStream = new System.IO.MemoryStream(newRestaurantDetail.newRestaurantDetails.Image);
                System.Drawing.Image fullsizeImage = System.Drawing.Image.FromStream(myMemStream);
                System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(533, 300, null, IntPtr.Zero); //maintain the 16:9 ratio with 533, 300
                System.IO.MemoryStream myResult = new System.IO.MemoryStream();
                newImage.Save(myResult, System.Drawing.Imaging.ImageFormat.Jpeg);  //Save it as jpeg
                newRestaurantDetail.newRestaurantDetails.Image =  myResult.ToArray();  //Returns a new byte array.

                if (imageData == null)
                {
                    imageData = new Images
                    {
                        RestaurantId = restaurant.RestaurantId,
                        Image = newRestaurantDetail.newRestaurantDetails.Image
                    };
                    await _context.Images.AddAsync(imageData);
                }
                else
                {
                    imageData.Image = newRestaurantDetail.newRestaurantDetails.Image;
                }
            }


            restaurantDetail.About = newRestaurantDetail.newRestaurantDetails.About;
            restaurantDetail.MinOrderPrice = newRestaurantDetail.newRestaurantDetails.MinOrderPrice;
            restaurantDetail.AverageDeliveryTime = newRestaurantDetail.newRestaurantDetails.AverageDeliveryTime;
            restaurantDetail.MapSrc = newRestaurantDetail.newRestaurantDetails.MapSrc;
            restaurantDetail.Facebook = newRestaurantDetail.newRestaurantDetails.Facebook;
            restaurantDetail.Instagram = newRestaurantDetail.newRestaurantDetails.Instagram;
            restaurantDetail.Twitter = newRestaurantDetail.newRestaurantDetails.Twitter;
            restaurantDetail.PhoneNumber = newRestaurantDetail.newRestaurantDetails.PhoneNumber;
            restaurantDetail.Updated = DateTime.Now;

            _context.Entry(restaurantDetail).State = EntityState.Modified;

            foreach (var workingTime in newRestaurantDetail.newWorkingTimes)
            {
                //12:34
                int openHour = converStringTimeToInt(workingTime.OpenTime[0], workingTime.OpenTime[1]);
                int openMinute = converStringTimeToInt(workingTime.OpenTime[3], workingTime.OpenTime[4]);
                int closeHour = converStringTimeToInt(workingTime.CloseTime[0], workingTime.CloseTime[1]);
                int closeMinute = converStringTimeToInt(workingTime.CloseTime[3], workingTime.CloseTime[4]);

                // Checking for times to be correct ( open time cant be before close time)
                if (openHour > closeHour) { BadRequest(new { message = "Openning hour can't be after closing hour" }); }
                else if ((openHour == closeHour) && (openMinute > closeMinute))
                {
                    BadRequest(new { message = "Openning time can't be after closing time (hours are same, minutes are wrong)" });
                }

                WorkingTimes column = await _context.WorkingTimes.Where(x => x.RestaurantId == restaurantDetail.Id && x.Day == workingTime.Day).FirstOrDefaultAsync();
                column.OpenTime = new TimeSpan(openHour, openMinute, 0);
                column.CloseTime = new TimeSpan(closeHour, closeMinute, 0);
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        // POST: api/Owner/AddItemToMenu
        [HttpPost]
        [Route("AddItemToMenu")]
        [Authorize(Roles = "Owner")]
        public async Task<Object> AddItemToMenu(MenuModel model)
        {
            //Get rid off whitespace
            model.About = String.IsNullOrEmpty(model.About) ? "" : model.About.Trim();
            model.Name = String.IsNullOrEmpty(model.Name) ? "" : model.Name.Trim();
            model.Category = String.IsNullOrEmpty(model.Category) ? "" : model.Category.Trim();


            if (String.IsNullOrEmpty(model.Category) ||
                String.IsNullOrEmpty(model.Name) ||
                (model.Price < 0))
            {
                return BadRequest("Can't contain empty fields or price cant be lower than 0!");
            }

            if(model.Name.Length > 50)
            {
                return BadRequest("The item name is too long! (max character limit is 50)");
            }
            
            if(model.Category.Length > 25)
            {
                return BadRequest("The item category name is too long! (max character limit is 25)");
            }

            if(model.About.Length > 200)
            {
                return BadRequest("The item about section is too long! (max character limit is 200)");
            }

            if(model.Price > 999)
            {
                return BadRequest("Invalid price, max price is 999!");
            }


            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefault();

            //Preparing a lambda function to capitalise the first letter of all words
            Func<string, string> capitaliseString = (string text) =>
            {
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            };

            //Apply the fix to the strings if it was typed wrong (initial letters are capitilised while other letters are small)
            model.Category = capitaliseString(model.Category);

            Menu newMenuItem = new Menu
            {
                RestaurantId = restaurant.RestaurantId,
                Category = String.IsNullOrEmpty(model.Category) ? null : model.Category,
                Name = String.IsNullOrEmpty(model.Name) ? null : model.Name,
                About = String.IsNullOrEmpty(model.About) ? null : model.About,
                Price = model.Price
            };

            try
            {
                _context.Menu.Add(newMenuItem);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //GET : api/Owner/Menu
        [HttpGet]
        [Route("Menu")]
        [Authorize(Roles = "Owner")]
        public async Task<ActionResult<Object>> GetMenu()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefault();

            List<Menu> MenuItems = await _context.Menu.Where(x => x.RestaurantId == restaurant.RestaurantId).ToListAsync();

            return MenuItems;

        }


        // DELETE: api/Owner/Menu/5
        [HttpDelete("Menu/{id}")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> DeleteMenuItem(int id)
        {

            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefault();

            var result = await _context.Menu.Where(x => x.RestaurantId == restaurant.RestaurantId && x.Id == id).FirstOrDefaultAsync();

            if (result != null)
            {
                _context.Menu.Remove(result);
            } else
            {
                return BadRequest(new { message = "You don't have access to delete this item" });
            }

            await _context.SaveChangesAsync();

            return Ok();
        }



        // PATCH: api/Owner/Menu/Update
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPatch]
        [Route("Menu/Update")]
        [Authorize(Roles = "Owner, Admin")]
        public async Task<IActionResult> UpdateMenuItem(MenuModeWithId editedModel)
        {
            //Get rid off whitespace
            editedModel.Name = String.IsNullOrEmpty(editedModel.Name) ? "" : editedModel.Name.Trim();
            editedModel.About = String.IsNullOrEmpty(editedModel.About) ? "" : editedModel.About.Trim();
            editedModel.Category = String.IsNullOrEmpty(editedModel.Category) ? "" : editedModel.Category.Trim();

            if (String.IsNullOrEmpty(editedModel.Category) ||
                String.IsNullOrEmpty(editedModel.Name) ||
                (editedModel.Price < 0))
            {
                return BadRequest("Can't contain empty fields or price cant be lower than 0!");
            }

            if (editedModel.Name.Length > 50)
            {
                return BadRequest("The item name is too long! (max character limit is 50)");
            }

            if (editedModel.Category.Length > 25)
            {
                return BadRequest("The item category name is too long! (max character limit is 25)");
            }

            if (editedModel.About.Length > 200)
            {
                return BadRequest("The item about section is too long! (max character limit is 200)");
            }

            if (editedModel.Price > 999)
            {
                return BadRequest("Invalid price, max price is 999!");
            }

            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefault();

            Menu result = _context.Menu.Where(x => x.RestaurantId == restaurant.RestaurantId && x.Id == editedModel.Id).FirstOrDefault();

            if (result == null)
            {
                return NotFound();
            }

            result.Name = String.IsNullOrEmpty(editedModel.Name) ? null : editedModel.Name;
            result.About = String.IsNullOrEmpty(editedModel.About) ? null : editedModel.About;
            result.Price = editedModel.Price;
            result.Category = String.IsNullOrEmpty(editedModel.Category) ? null : editedModel.Category;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        //GET : api/Owner/GetOrders
        [HttpGet]
        [Route("GetOrders")]
        [Authorize(Roles = "Owner")]
        public async Task<List<GetOrdersModel>> GetOrders()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefault();

            List<Menu> MenuItems = await _context.Menu.Where(x => x.RestaurantId == restaurant.RestaurantId).ToListAsync();

            List<Order> orders = await _context.Order
                .Where(x =>
                x.RestaurantId == restaurant.RestaurantId &&
                x.Status != Status.Completed.ToString() &&
                x.Status != Status.Rejected.ToString()).OrderBy(x => x.Created)
                .ToListAsync();


            List<GetOrdersModel> result = new List<GetOrdersModel> { };
            foreach (Order order in orders)
            {
                User userData = await _context.ApplicationUsers.Where(x => x.Id == order.UserId).FirstOrDefaultAsync();

                List<OrderDetailsNamed> orderDetails = _context.OrderDetails.Where(x => x.OrderId == order.Id).Select(x => new OrderDetailsNamed
                {
                    ProductName = x.ProductName,
                    ProductPrice = x.ProductUnitPrice,
                    Quantity = x.Quantity
                }).ToList();



                if (userData != null)
                {
                    result.Add(new GetOrdersModel
                    {
                        UserId = userData.Id,
                        OrderId = order.Id,
                        UserFullName = userData.FirstName + " " + userData.LastName,
                        PhoneNumber = userData.PhoneNumber,
                        PhoneNumberConfirmed = userData.PhoneNumberConfirmed,
                        Address = order.Address,
                        Note = order.Note,
                        Status = order.Status,
                        Created = order.Created,
                        Updated = order.Updated,
                        Details = orderDetails,
                        Total = orderDetails.Sum(x => x.Quantity * x.ProductPrice)
                    });
                }
            }
            return result;
        }


        [HttpGet]
        [Route("GetDailyOrderChartData")]
        [Authorize(Roles = "Owner")]
        public async Task<object> GetDailyOrderChartData()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefault();

            var orders = _context.Order
                .Where(x =>
                x.RestaurantId == restaurant.RestaurantId &&
                x.Status != Status.Rejected.ToString())
                .AsEnumerable()
                .GroupBy(x => x.Created.ToString("yyyy-MM-dd")).Take(30);
            //If there is no record of orders, send 2 days with count 0 to be displayed in chart
            if(!orders.Any())
            {
                return new List<Tuple<string, int>> { Tuple.Create(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), 0), Tuple.Create(DateTime.Now.ToString("yyyy-MM-dd"), 0) };
            }


            var result = new
            {
                Date = orders.Select(g => g.Key).ToList(),
                Total = orders.Select(g => g.Count()).ToList(),
            };

            List<Tuple<string, int>> chartData = new List<Tuple<string, int>> { Tuple.Create(result.Date[0], result.Total[0]) }; //Storing data as pairs in order to comfortably modify and move them without losing the sequence
            for(int i = 1; i < result.Date.Count; i++) // the first index is added on chartData initialisation
            {
                chartData.Add( new Tuple<string, int>(result.Date[i], result.Total[i]));
            }

            if (result.Date.Last() != DateTime.Now.ToString("yyyy-MM-dd")) //making sure that the last date will be today if there has been no orders yet
            {
                chartData.Add(new Tuple<string, int>(DateTime.Now.ToString("yyyy-MM-dd"), 0));
            }

            DateTime lastDate = new DateTime(Int32.Parse(chartData.Last().Item1.Substring(0, 4)), Int32.Parse(chartData.Last().Item1.Substring(5, 2)), Int32.Parse(chartData.Last().Item1.Substring(8, 2)));
            DateTime dateIterator = new DateTime(Int32.Parse(result.Date[0].Substring(0, 4)), Int32.Parse(result.Date[0].Substring(5, 2)), Int32.Parse(result.Date[0].Substring(8, 2)));
            for (int i = 0; dateIterator != lastDate; i++)
            {
                if (chartData[i].Item1 != dateIterator.ToString("yyyy-MM-dd")) 
                {
                    chartData.Add(new Tuple<string, int>(dateIterator.ToString("yyyy-MM-dd"), 0)); //add the missing days to the chart if they had no orders that day (shown as 0)
                    i--;
                }
                dateIterator = dateIterator.AddDays(1);
            }

            chartData.Sort((x, y) => x.Item1.CompareTo(y.Item1));
            if(chartData.Count() > 30 )
            {
                chartData.RemoveRange(0, chartData.Count() - 30);
            }




            //Template values for the chart
            //var result = new
            //{
            //    Date = new string[] { "2020-12-29", "2020-12-30" },
            //    Total = new int[] { 5, 16 }
            //};

            return chartData;
        }


        // PATCH: api/Owner/Order/AcceptOrder
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPatch]
        [Route("Order/AcceptOrder")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> AcceptOrder(PutOrderModel model)
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefault();
            var orderData = _context.Order.Where(x => x.Id == model.OrderId && x.RestaurantId == restaurant.RestaurantId).FirstOrDefault();

            if (orderData == null)
            {
                return NotFound(new { message = "Couldnt find the order with the Id " + model.OrderId });
            }

            orderData.Status = Status.Accepted.ToString();
            orderData.Updated = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // PATCH: api/Owner/Order/AcceptOrder
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPatch]
        [Route("Order/CompleteOrder")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> CompleteOrder(PutOrderModel model)
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefault();
            var orderData = _context.Order.Where(x => x.Id == model.OrderId && x.RestaurantId == restaurant.RestaurantId).FirstOrDefault();
            var orderDetails = _context.OrderDetails.Where(x => x.OrderId == orderData.Id).Select(x => new { quantity = x.Quantity, unitPrice = x.ProductUnitPrice }).ToList();

            if (orderData == null)
            {
                return NotFound(new { message = "Couldn't find the order with the Id: " + model.OrderId });
            }
            if (orderDetails == null)
            {
                return BadRequest(new { message = "Couldn't get the details of the order with the id: " + model.OrderId });
            }

            orderData.Status = Status.Completed.ToString();
            orderData.Updated = DateTime.Now;

            // Update the "previous earnings" table with the new accepted order. This will initiate a new row if the data does not exist, and if it does exist, it will update the total.
            var earningHistory = _context.PreviousEarnings.Where(x => x.RestaurantId == restaurant.RestaurantId && x.Year == DateTime.Now.Year && x.Month == DateTime.Now.Month).FirstOrDefault();
            if(earningHistory == null)
            {
                PreviousEarnings addEarnings = new PreviousEarnings
                {
                    RestaurantId = restaurant.RestaurantId,
                    Month = DateTime.Now.Month,
                    Year = DateTime.Now.Year,
                    Total = orderDetails.Sum(x => x.unitPrice * x.quantity)
                };

                await _context.PreviousEarnings.AddAsync(addEarnings);
            }else
            {
                earningHistory.Total += orderDetails.Sum(x => x.unitPrice * x.quantity);
            }


            try
            {
                await _context.SaveChangesAsync();             
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // PATCH: api/Owner/Order/AcceptOrder
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPatch]
        [Route("Order/RejectOrder")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> RejectOrder(RejectOrderModel model)
        {
            //Get rid off whitespace
            model.Note = String.IsNullOrEmpty(model.Note) ? "" : model.Note.Trim();

            if (String.IsNullOrEmpty(model.Note) )
            {
                return BadRequest(new { message = "Rejection reason can't be empty" });
            }

            //If empty, set to null
            model.Note = String.IsNullOrEmpty(model.Note) ? null : model.Note;


            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefault();
            var orderData = _context.Order.Where(x => x.Id == model.OrderId && x.RestaurantId == restaurant.RestaurantId).FirstOrDefault();

            if (orderData == null)
            {
                return NotFound(new { message = "Couldnt find the order with the Id " + model.OrderId });
            }

            orderData.Status = Status.Rejected.ToString();
            orderData.Note = "REJECTION NOTE = " + model.Note + " ---------- YOUR NOTE = " + orderData.Note; //Save the rejection message as note
            orderData.Updated = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }


        // PATCH: /api/Owner/AddResponse
        [HttpPatch]
        [Route("AddResponse")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> AddReviewAndComment(AddReviewResponseModel model)
        {
            //Get rid off whitespace
            model.Response = String.IsNullOrEmpty(model.Response) ? "" : model.Response.Trim();

            if (String.IsNullOrEmpty(model.Response))
            {
                return BadRequest(new { message = "The response can't be empty" });
            }

            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var order = _context.Order.Where(x => x.Id == model.OrderId).FirstOrDefault();

            if (order == null)
            {
                return NotFound(new { message = "Couldn't find the orderId with the id '" + model.OrderId + "'" });
            }
            if (order.RestaurantId != order.RestaurantId)
            {
                return BadRequest(new { message = "This review does not belong to this restaurant!" });
            }
            bool RestaurantHasAlreadyResponded = _context.RatingAndReview.Where(x => x.OrderId == order.Id).FirstOrDefault().Response != null;
            if (RestaurantHasAlreadyResponded)
            {
                return BadRequest(new { message = "A response already exists for this order!" });
            }


            RatingAndReview result =_context.RatingAndReview.Where(x => x.OrderId == model.OrderId).FirstOrDefault();
            result.Response = String.IsNullOrEmpty(model.Response) ? null : model.Response;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST: /api/Owner/AddResponse
        [HttpPatch]
        [Route("DeleteComment")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> DeleteComment(IdModel model)
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var order = _context.Order.Where(x => x.Id == model.Id).FirstOrDefault();

            if (order == null)
            {
                return NotFound(new { message = "Couldn't find the orderId with the id '" + model.Id + "'" });
            }
            if (order.RestaurantId != order.RestaurantId)
            {
                return BadRequest(new { message = "This review does not belong to this restaurant!" });
            }

            RatingAndReview result = _context.RatingAndReview.Where(x => x.OrderId == model.Id).FirstOrDefault();
            result.Deleted = true;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // GET: /api/Owner/GetReviewAndResponses
        [HttpGet]
        [Route("GetReviewAndResponses")]
        [Authorize(Roles = "Owner")]
        public async Task<object> GetReviewAndResponses()
        {
            string userId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == userId).FirstOrDefault();



            var result = await _context.RatingAndReview.Where(x => x.RestaurantId == restaurant.RestaurantId).Select( x => new
            {
                x.OrderId,
                x.Rating,
                Response = x.Deleted ? null : x.Response,
                x.Deleted,
                Comment = x.Deleted ? "[MESSAGE HAS BEEN REMOVED]" : x.Comment,
                x.Created
            }).OrderByDescending(x => x.Created).ToListAsync();

            return result;
        }



        // PATCH: api/Owner/ConfirmPhoneNumber
        [HttpPatch]
        [Route("ConfirmPhoneNumber")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> ConfirmPhoneNumber(UserIdModel model)
        {
            string ownerId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == ownerId).FirstOrDefault();
            var user = _context.ApplicationUsers.Where(x => x.Id == model.UserId).FirstOrDefault();
            if(user == null)
            {
                return NotFound(new { message = "Couldn't find the user." });
            }
            if (user.PhoneNumberConfirmed) //phone number already confirmed
            {
                return Ok(); //No need to show error. Act like success
            }

            var hasOrder = _context.Order
                .Where(x => x.UserId == model.UserId && x.RestaurantId == restaurant.RestaurantId 
                && x.Status != Status.Completed.ToString()
                && x.Status != Status.Rejected.ToString()
                ).FirstOrDefault() != null;

            if (!hasOrder)
            {
                return BadRequest(new { message = "You are not allowed to confirm this users phone number. The user does not have any active orders for you." });
            }

            user.PhoneNumberConfirmed = true;
            user.Updated = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        [Route("isPhoneConfirmed")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> IsPhoneConfirmed(string UserId)
        {
            string ownerId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = await _context.RestaurantOwner.Where(x => x.UserId == ownerId).FirstOrDefaultAsync();
            var user = await _context.Users.Where(x => x.Id == UserId).FirstOrDefaultAsync();
            if (user == null)
            {
                return BadRequest(new { message = "Couldn't find the user." });
            }

            var hasOrder = await _context.Order
                .Where(x => x.UserId == UserId && x.RestaurantId == restaurant.RestaurantId
                && x.Status != Status.Completed.ToString()
                && x.Status != Status.Rejected.ToString()
                ).FirstOrDefaultAsync() != null;

            if (!hasOrder)
            {
                return BadRequest(new { message = "Forbidden: Can't show if the user phone number is confirmed." });
            }
            return Ok(user.PhoneNumberConfirmed);
        }


        [HttpGet]
        [Route("GetEarningsHistory")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> GetEarningsHistory()
        {
            string ownerId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == ownerId).FirstOrDefault();
            List<object> result = new List<object>();

            var history = await _context.Order.Where(x => x.RestaurantId == restaurant.RestaurantId && x.Status == Status.Completed.ToString())
                .GroupBy(x => new { x.Updated.Year, x.Updated.Month })
                .Select(x => new { Year = x.Key.Year, Month = x.Key.Month })
                .OrderByDescending(x => x.Year)
                .ThenByDescending(x => x.Month)
                .ToListAsync();


            foreach(var h in history)
            {
                DateTime start = new DateTime(h.Year, h.Month, 1, 0, 0, 0); // explicityly pointing the date '2020-05-1 00:00:00'

                //Get the total value of the orders by (quantity * unitprice) and group them by the date to combine them with the orders later on
                var income = await _context.Order.Join(_context.OrderDetails, orderId => orderId.Id, fk => fk.OrderId,
                    (orderId, fk) => new { Order = orderId, UnitPrice = fk.ProductUnitPrice, Quantity = fk.Quantity})
                    .Where(x => x.Order.RestaurantId == restaurant.RestaurantId && x.Order.Status == Status.Completed.ToString()
                    && (x.Order.Updated >= start && x.Order.Updated < start.AddMonths(1)))
                    .GroupBy(x => x.Order.Updated.Day).Select(x => new
                    {
                        Day = x.Key,
                        Value = x.Sum(x => x.Quantity * x.UnitPrice)
                    }).ToListAsync();

                //Gets the order count from the orders to see how many orders have been made on that specific day
                var orders = await _context.Order
                    .Where(x => x.RestaurantId == restaurant.RestaurantId && x.Status == Status.Completed.ToString()
                    && (x.Updated >= start && x.Updated < start.AddMonths(1)))
                    .GroupBy(x => x.Updated.Day).Select(x => new
                    {
                        Day = x.Key,
                        Total = x.Count()
                    }).ToListAsync();

                //Initialise list (did it like this in order for the intelisense to work for .Find(), It couldn't see the object names such as x=> x.Day )
                //Combine both tables 'income' and 'orders' in one list 
                var daily = new[]
                {
                    new {Day = 0, Total = 0, Value = -1f}
                }.ToList();
                foreach(var inc in income)
                {
                    var found = orders.Find(x => x.Day == inc.Day);
                    if(found != null)
                    {
                        daily.Add(new
                        {
                            Day = inc.Day,
                            Total = found.Total,
                            Value = inc.Value
                        });
                    }
                }


                //All the date array will be stored in the tmp
                List<object> tmp = new List<object>();
                //To see how much was earned that month in total
                float monthTotal = 0;

                //Using counter to track if it is end of month for looping, all the missing dates are added while the existing ones are placed in the array
                DateTime counter = new DateTime(h.Year, h.Month, 1);
                for(int i = 1; i == counter.Day; i++)
                {
                    var found = daily.Find(x => x.Day == i);
                    counter = counter.AddDays(1);
                    if(found == null)
                    {
                        tmp.Add(new
                        {
                            Day = i,
                            Total = 0,
                            Value = 0
                        });
                    }else
                    {
                        tmp.Add(new
                        {
                            Day = found.Day,
                            Total = found.Total,
                            Value = found.Value
                        });
                        monthTotal += found.Value;
                    }
                }
               

                result.Add ( new
                {
                    history = new { Year = h.Year, Month = h.Month, Total = monthTotal },
                    dailyData = tmp
                });


                //This part deals with the earnings history as well as the previous earnings. Updates the data if it is not same and checks if all data exists for all the months
                var previousEarning = await _context.PreviousEarnings.Where(x => x.RestaurantId == restaurant.RestaurantId && x.Year == h.Year && x.Month == h.Month).FirstOrDefaultAsync();
                if( previousEarning == null )
                {
                    PreviousEarnings addPreviousEarning = new PreviousEarnings
                    {
                        RestaurantId = restaurant.RestaurantId,
                        Year = h.Year,
                        Month = h.Month,
                        Total = monthTotal
                    };

                    await _context.PreviousEarnings.AddAsync(addPreviousEarning);
                }else if(previousEarning.Total != monthTotal)
                {
                    previousEarning.Total = monthTotal;
                }

                try
                {
                    await _context.SaveChangesAsync();
                }catch (Exception e)
                {
                    throw e;
                }
            }

            return Ok(result);
        }



        [HttpGet]
        [Route("GetEarningsData")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> GetActiveEarnings()
        {
            string ownerId = User.Claims.First(x => x.Type == "UserID").Value;
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == ownerId).FirstOrDefault();
            float thisMonthEarnings = await _context.PreviousEarnings
                .Where(x => x.RestaurantId == restaurant.RestaurantId && x.Year == DateTime.Now.Year && x.Month == DateTime.Now.Month)
                .Select(x => x.Total)
                .FirstOrDefaultAsync();
            //AverageAsync(x => x.Total).Result;
            var expectedEarningsQuery = await _context.PreviousEarnings.Where(x => x.RestaurantId == restaurant.RestaurantId).ToListAsync();
            float expectedEarnings = 0f;

            if (expectedEarningsQuery.Count > 0)
            {
                expectedEarnings = expectedEarningsQuery.Average(x => x.Total);
            }

            return Ok(new { ThisMonthsEarning = thisMonthEarnings, ExpectedEarnings = expectedEarnings});
        }



        // PATCH: /api/Owner/DisableRestaurant
        [HttpPatch]
        [Route("DisableRestaurant")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> DisableRestaurant()
        {
            string ownerId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(ownerId);
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == ownerId).FirstOrDefault();
            
            if(restaurant == null)
            {
                return NotFound(new { message = "Couldn't match the account to the restaurant" });
            }

            var restaurantDetails = await _context.RestaurantDetails.Where(x => x.Id == restaurant.RestaurantId).FirstOrDefaultAsync();

            if(restaurantDetails == null)
            {
                return BadRequest(new { message = "Something went wrong while retrieving restaurant details... Please try again later" });
            }

            restaurantDetails.Active = false;
            restaurantDetails.Updated = DateTime.Now;
            SendEmailAsync(user.Email, "Your restaurant has been disabled - Food Hub", "<h1>Your restaurant has been disabled</h1>" +
                "<p>We would like to inform you that your restaurant has been manually disabled by your account. This mail is sent for information purposes only.</p>");


            //Cancel all active orders
            var allActiveRestaurantOrders = await _context.Order.Where(x => x.RestaurantId == restaurantDetails.Id && x.Status == Status.Waiting.ToString() || x.Status == Status.Accepted.ToString()).ToListAsync();
            foreach (var order in allActiveRestaurantOrders)
            {
                order.Status = Status.Rejected.ToString();
                order.Note = "THE RESTAURANT HAS BEEN DISABLED... Your note: " + order.Note;
                order.Updated = DateTime.Now;
            }

            //Inform the users that their orders have been rejected
            var rejectedUsers = allActiveRestaurantOrders.GroupBy(x => x.UserId).ToList();
            foreach (var rejectedUser in rejectedUsers)
            {
                var rejectedUserEmail = _context.ApplicationUsers.Where(x => x.Id == rejectedUser.Key).Select(x => x.Email).FirstOrDefault();

                SendEmailAsync(rejectedUserEmail, "Your order has been cancelled - Food Hub", "<h1>Your order has been rejected</h1>" +
               "<p>We are sorry to inform you that your order(s) for '" + restaurantDetails.Name + "' have been cancelled due to the restaurant being disabled. </p>");
            }

            try { await _context.SaveChangesAsync(); return Ok(); }
            catch (Exception e) { throw e; }
        }


        // PATCH: /api/Owner/DisableRestaurant
        [HttpPatch]
        [Route("RequestRestaurantActivation")]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> RequestRestaurantActivation()
        {
            string ownerId = User.Claims.First(x => x.Type == "UserID").Value;
            var user = await _userManager.FindByIdAsync(ownerId);
            var restaurant = _context.RestaurantOwner.Where(x => x.UserId == ownerId).FirstOrDefault();

            if (restaurant == null)
            {
                return BadRequest(new { message = "Couldn't match the account to the restaurant" });
            }

            var restaurantDetails = await _context.RestaurantDetails.Where(x => x.Id == restaurant.RestaurantId).FirstOrDefaultAsync();

            if (restaurantDetails == null)
            {
                return BadRequest(new { message = "Something went wrong while retrieving restaurant details... Please try again later" });
            }

            //If the restaurant already requested it before, just return Ok(), without making any updates
            if (restaurantDetails.ActivationRequest) { return Ok(); }

            restaurantDetails.Updated = DateTime.Now;
            restaurantDetails.ActivationRequest = true;

            //For future if there are multiple admins, this will make sure to mail them all.
            var admins = await _context.UserRoles.Where(x => x.RoleId == "2").Select(x => x.UserId).ToListAsync(); // roleId 2 == ADMIN
            foreach(var adminId in admins)
            {
                var admin = await _userManager.FindByIdAsync(adminId);
                SendEmailAsync(admin.Email, "Restaurant activation request - Food Hub " + restaurantDetails.Name, "<h1>Restaurant '" + restaurantDetails.Name + "' is requesting to be activated</h1>" +
                    "<h2>Restaurant Id : " + restaurantDetails.Id + "</h2>");
            }

            try { await _context.SaveChangesAsync(); return Ok(); }
            catch (Exception e) { throw e; }

        }


        private int converStringTimeToInt(char cFirstDigit, char cSecondDigit)
        {
            int iFirstDigit = (int)cFirstDigit - 48;
            int iSecondDigit = (int)cSecondDigit - 48;

            return (iFirstDigit != 0 ?
                    ( (iFirstDigit * 10) + iSecondDigit) :
                    (iSecondDigit));
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
