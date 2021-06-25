using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static FoodHubAPI.Models.Enum.enums;

namespace FoodHubAPI.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        [ForeignKey("RestaurantDetail")]
        public int RestaurantId { get; set; }
        public RestaurantDetail RestaurantDetail { get; set; }

        [Required]
        public string Address { get; set; }
        public string Note { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime Updated { get; set; }
    }
}
