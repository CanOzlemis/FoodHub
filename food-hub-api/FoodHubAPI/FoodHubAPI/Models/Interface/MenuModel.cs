using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class MenuModel
    {
        public string Category { get; set; }
        public string Name { get; set; }
        public string? About { get; set; }
        public float Price { get; set; }
    }
}
