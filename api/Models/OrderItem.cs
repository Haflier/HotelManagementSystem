using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models 
{
    [Table("OrderItem")]
    public class OrderItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice => Quantity * UnitPrice;
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int? FoodId { get; set; }
        public Food Food { get; set; }
        public int? DrinkId { get; set; }
        public Drink Drink { get; set; }
    }
}