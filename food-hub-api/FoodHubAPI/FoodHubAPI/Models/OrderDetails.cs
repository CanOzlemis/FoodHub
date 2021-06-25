using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodHubAPI.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        //ProductId, productName and unitPrice is not foreign key because menu can be changed and it if that happens it will effect these details. So we store a copy
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public float ProductUnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
