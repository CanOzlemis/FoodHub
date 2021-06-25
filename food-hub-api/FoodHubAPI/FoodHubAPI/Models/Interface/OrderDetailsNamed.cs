using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class OrderDetailsNamed
    {
        public string ProductName { get; set; }
        public float ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
