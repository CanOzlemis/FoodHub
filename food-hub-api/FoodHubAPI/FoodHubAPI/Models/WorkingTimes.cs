using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class WorkingTimes
    {
        //TODO: RestaurantId and Day should be the Key's 
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("RestaurantDetail")]
        public int RestaurantId { get; set; }
        public RestaurantDetail RestaurantDetail { get; set; }
        [Required]
        public int Day { get; set; }
        [Required]
        [Column(TypeName = "time")]
        public TimeSpan OpenTime { get; set; }
        [Required]
        [Column(TypeName = "time")]
        public TimeSpan CloseTime { get; set; }

    }
}
