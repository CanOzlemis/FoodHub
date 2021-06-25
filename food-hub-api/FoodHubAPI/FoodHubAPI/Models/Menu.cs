using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("RestaurantDetail")]
        public int RestaurantId { get; set; }
        public RestaurantDetail RestaurantDetail { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Name { get; set; }
        public string? About { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
