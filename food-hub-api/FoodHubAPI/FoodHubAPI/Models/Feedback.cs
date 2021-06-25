using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static FoodHubAPI.Models.Enum.enums;

namespace FoodHubAPI.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime Created { get; set; }
    }
}
