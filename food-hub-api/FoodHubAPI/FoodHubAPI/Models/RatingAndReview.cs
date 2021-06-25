using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class RatingAndReview
    {
        [Key]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("RestaurantDetail")]
        public int? RestaurantId { get; set; }
        public RestaurantDetail RestaurantDetail { get; set; }
        public float Rating { get; set; }
        public string Comment { get; set; }
        public bool Deleted { get; set; }
        public string Response { get; set; }
        public DateTime Created { get; set; }
    }
}
