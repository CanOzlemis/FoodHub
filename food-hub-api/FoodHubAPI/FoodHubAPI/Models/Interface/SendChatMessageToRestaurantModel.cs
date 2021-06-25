using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class SendChatMessageToRestaurantModel
    {
        public int RestaurantId { get; set; }
        public string Message { get; set; }
    }
}
