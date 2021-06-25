using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class EmailConfirmationModel
    {
        public string UserId { get; set; }
        public string Hash { get; set; }
    }
}
