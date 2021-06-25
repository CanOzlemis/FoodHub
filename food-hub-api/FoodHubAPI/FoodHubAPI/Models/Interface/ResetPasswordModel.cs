using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class ResetPasswordModel
    {
        public string UserId { get; set; }
        public string Hash { get; set; }
        public string NewPassword { get; set; }
    }
}
