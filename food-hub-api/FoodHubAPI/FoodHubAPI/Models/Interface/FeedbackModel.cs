using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FoodHubAPI.Models.Enum.enums;

namespace FoodHubAPI.Models.Interface
{
    public class FeedbackModel
    {
        public string FeedbackType { get; set; }
        public string Message { get; set; }
    }
}
