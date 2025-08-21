using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.OrderItem 
{
    public class OrderItemBaseDto
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}