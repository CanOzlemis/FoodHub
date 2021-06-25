using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class RejectOrderModel
    {
        public int OrderId { get; set; }
        public string Note { get; set; }
    }
}
