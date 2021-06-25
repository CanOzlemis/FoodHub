using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class ApplicantRestaurantModel
    {
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string RestaurantName { get; set; }
        [Required]
        public string RestaurantCity { get; set; }
        [Required]
        public string RestaurantStreet { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

    }
}
