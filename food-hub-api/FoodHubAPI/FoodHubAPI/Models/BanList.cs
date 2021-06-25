using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class BanList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        public string? Reason { get; set; }
        public DateTime Created { get; set; }
    }
}
