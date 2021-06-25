using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class User : IdentityUser
    {
        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }
        [Required]
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }
        public string Address { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public DateTime Updated { get; set; }

    }
}
