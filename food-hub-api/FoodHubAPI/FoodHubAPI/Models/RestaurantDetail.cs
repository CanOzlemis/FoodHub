using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class RestaurantDetail
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(64)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(200)")]
        public string About { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public float Rating { get; set; } = 0;
        [Required]
        public int AverageDeliveryTime { get; set; } = 0;
        [Required]
        public float MinOrderPrice { get; set; } = 0;
        [Required]
        public bool Approved { get; set; } = false;
        [Required]
        public bool Active { get; set; } = false; //To be able to disable restaurants 
        public string MapSrc { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public bool ActivationRequest { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime Created { get; set; }
        [Required]
        [Column(TypeName = "DateTime2")]
        public DateTime Updated { get; set; }

    }
}
