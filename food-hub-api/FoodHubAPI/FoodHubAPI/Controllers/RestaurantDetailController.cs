using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodHubAPI.Models;
using FoodHubAPI.Models.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantDetailController : ControllerBase
    {

        private readonly ApplicationContext _context;

        public RestaurantDetailController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/RestaurantDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetRestaurantDetails(string Name = null, string City = null)
        {
            List<RestaurantDetail> RD = new List<RestaurantDetail>();

            string nameParam = Name != null ? Name : "";
            string cityParam = City != null ? City : "";
            //List of restaurants with the search
            RD = await _context.RestaurantDetails.Where(x => x.Active == true && x.Name.Contains(nameParam) && x.City.Contains(cityParam) ).ToListAsync();
            


            //Initialise result with dummy data in order to be able to use functions such as orderbyDescending for sorting
            var result = new[] { new 
            { 
                restaurantDetail = new RestaurantDetail(), 
                workingTime = new 
                    { 
                        OpenAt = new { Hour = string.Empty, Minute = string.Empty},
                        CloseAt = new { Hour = string.Empty, Minute = string.Empty},
                        Day = 0,
                        RestaurantId = 0,
                        Id = 0
                    }, 
                isOpen = false, 
                wr = 0f, 
                Image = new byte[0] } 
            }.ToList();
            var today = ((int)DateTime.Now.DayOfWeek + 6) % 7; // + 6 and % 7 because for system the day 0 is Sunday. Made it like this for making the first day Monday

            foreach (var restaurant in RD)
            {
                float numberOfRatings = _context.RatingAndReview.Where(x => x.RestaurantId == restaurant.Id).Count();
                float WR = 
                    (numberOfRatings / (numberOfRatings + RD.Count()) )
                    * restaurant.Rating 
                    + (RD.Count() / (numberOfRatings + RD.Count()) ); //Calculating the weighted ratings for better sorting

                var Image = await _context.Images.Where(x => x.RestaurantId == restaurant.Id).Select(x => x.Image).FirstOrDefaultAsync();

                WorkingTimes workingTimeDb = await _context.WorkingTimes
                    .Where(x => x.RestaurantId == restaurant.Id && x.Day == today)
                    .OrderBy(x => x.Day)
                    .FirstOrDefaultAsync();
                bool isOpen = (workingTimeDb.OpenTime.TotalMinutes < new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).TotalMinutes)
                    && new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).TotalMinutes < workingTimeDb.CloseTime.TotalMinutes;

                string Openinghour = workingTimeDb.OpenTime.Hours < 10 ? ('0' + workingTimeDb.OpenTime.Hours.ToString()) : (workingTimeDb.OpenTime.Hours.ToString());
                string OpeningMinute = workingTimeDb.OpenTime.Minutes < 10 ? ('0' + workingTimeDb.OpenTime.Minutes.ToString()) : (workingTimeDb.OpenTime.Minutes.ToString());
                string ClosingHour = workingTimeDb.CloseTime.Hours < 10 ? ('0' + workingTimeDb.CloseTime.Hours.ToString()) : (workingTimeDb.CloseTime.Hours.ToString());
                string ClosingMinute = workingTimeDb.CloseTime.Minutes < 10 ? ('0' + workingTimeDb.CloseTime.Minutes.ToString()) : (workingTimeDb.CloseTime.Minutes.ToString());

                var workingTime = new
                {
                    OpenAt = new { Hour = Openinghour, Minute = OpeningMinute },
                    CloseAt = new { Hour = ClosingHour, Minute = ClosingMinute },
                    Day = workingTimeDb.Day,
                    RestaurantId = workingTimeDb.RestaurantId,
                    Id = workingTimeDb.Id
                };

                result.Add(new { restaurantDetail = restaurant, workingTime, isOpen, wr = WR, Image = Image });
            }
            result.RemoveAt(0); // remove the temporary interface object that was created initially with result
            result.Sort((first, second) => second.wr.CompareTo(first.wr));
            
            return result;
        }

        // GET: api/RestaurantDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Object>> GetRestaurantDetail(int id)
        {
            var restaurantDetail = await _context.RestaurantDetails.FindAsync(id);
            var today = ((int)DateTime.Now.DayOfWeek + 6) % 7; // + 6 and % 7 because for system the day 0 is Sunday. Made it like this for making the first day Monday

            if (restaurantDetail == null)
            {
                return NotFound();
            }

            restaurantDetail.Rating = float.Parse( restaurantDetail.Rating.ToString("N2"));

            WorkingTimes workingTimeDb = await _context.WorkingTimes
                .Where(x => x.RestaurantId == id && x.Day == today)
                .OrderBy(x => x.Day)
                .FirstOrDefaultAsync();

            bool isOpen = (workingTimeDb.OpenTime.TotalMinutes < new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).TotalMinutes)
                            && new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, 0).TotalMinutes < workingTimeDb.CloseTime.TotalMinutes;

            //Displaying time in 2 digit format such as 07:05 rather than 7:05
            string Openinghour = workingTimeDb.OpenTime.Hours < 10 ? ('0' + workingTimeDb.OpenTime.Hours.ToString()) : (workingTimeDb.OpenTime.Hours.ToString());
            string OpeningMinute = workingTimeDb.OpenTime.Minutes < 10 ? ('0' + workingTimeDb.OpenTime.Minutes.ToString()) : (workingTimeDb.OpenTime.Minutes.ToString());
            string ClosingHour = workingTimeDb.CloseTime.Hours < 10 ? ('0' + workingTimeDb.CloseTime.Hours.ToString()) : (workingTimeDb.CloseTime.Hours.ToString());
            string ClosingMinute = workingTimeDb.CloseTime.Minutes < 10 ? ('0' + workingTimeDb.CloseTime.Minutes.ToString()) : (workingTimeDb.CloseTime.Minutes.ToString());

            var workingTime = new
            {
                OpenAt = new { Hour = Openinghour, Minute = OpeningMinute },
                CloseAt = new { Hour = ClosingHour, Minute = ClosingMinute },
                Day = workingTimeDb.Day,
                RestaurantId = workingTimeDb.RestaurantId,
                Id = workingTimeDb.Id
            };

            
            return new { restaurantDetail, workingTime, isOpen};


        }


        // GET: api/RestaurantDetail/Menu/5
        [HttpGet("Menu/{id}")]
        public async Task<ActionResult<Object>> GetRestaurantMenu(int id)
        {
            var restaurantDetail = await _context.RestaurantDetails.FindAsync(id);
            if(restaurantDetail == null) { return NotFound(); }

            List<Menu> restaurantMenu = await _context.Menu.Where(x => x.RestaurantId == id).ToListAsync();

            if(restaurantMenu != null) { return restaurantMenu; }

            return NotFound();
        }


        [HttpGet("GetReviewAndComments/{restaurantId}")]
        // GET: api/RestaurantDetail/GetReviewAndComments
        public async Task<object> GetReviewAndComments(int restaurantId)
        {
            var result = _context.RatingAndReview.Where(x => x.RestaurantId == restaurantId).Select(x => new
            {
                x.Rating,
                Comment = x.Deleted ? "[MESSAGE HAS BEEN REMOVED]" : x.Comment,
                x.Created,
                Response = x.Deleted ? null : x.Response,
                x.Deleted
            }).OrderByDescending(x => x.Created).ToList();

            return result;
        }


    }
}
