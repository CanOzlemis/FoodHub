using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class ApplicantRestaurants
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string RestaurantName { get; set; }
        [Required]
        public string RestaurantCity { get; set; }
        [Required]
        public string RestaurantStreet { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public bool EmailConfirmed { get; set; } = false;
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string GUID { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
