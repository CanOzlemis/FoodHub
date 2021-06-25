using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class AssignOwnerModel
    {
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
