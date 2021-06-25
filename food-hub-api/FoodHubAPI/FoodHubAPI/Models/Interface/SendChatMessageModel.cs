using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class SendChatMessageModel
    {
        public string ToUserId { get; set; }
        public string Message { get; set; }
    }
}
