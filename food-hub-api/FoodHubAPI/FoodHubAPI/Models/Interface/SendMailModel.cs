using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class SendMailModel
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
