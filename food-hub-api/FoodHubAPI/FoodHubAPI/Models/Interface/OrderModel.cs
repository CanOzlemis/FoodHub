using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static FoodHubAPI.Models.Enum.enums;

namespace FoodHubAPI.Models.Interface
{

    
    public class OrderModel
    {
        public int RestaurantId { get; set; }
        public string Address { get; set; }
        public string? Note { get; set; }
        public List<OrderDetailsModel> Detail { get; set; }

    }

    public class OrderDetailsModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class OwnerOrderModel : OrderModel
    {
        public string UserId { get; set; }
    }

}
