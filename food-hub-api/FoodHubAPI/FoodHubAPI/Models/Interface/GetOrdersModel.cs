using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models.Interface
{
    public class GetOrdersModel
    {

        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public int OrderId { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string Address { get; set; }
        public string? Note { get; set; }
        public string Restaurant { get; set; }
        public string Status { get; set; }
        public float Total { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public List<OrderDetailsNamed> Details { get; set; }
        public bool AllowReview { get; set; }

    }
}

