using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class ChangePasswordModel
    {
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
    }
}
