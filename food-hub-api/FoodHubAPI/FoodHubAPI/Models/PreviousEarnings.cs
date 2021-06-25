using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class PreviousEarnings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("RestaurantDetail")]
        public int RestaurantId { get; set; }
        public RestaurantDetail RestaurantDetail { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public float Total { get; set; }
    }
}
