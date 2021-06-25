using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class RestaurantOwner
    {
        [Key]
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        [ForeignKey("RestaurantDetail")]
        public int RestaurantId { get; set; }
        public RestaurantDetail RestaurantDetail { get; set; }
    }
}
