using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.OrderItem 
{
    public class CreateOrderItemRequestDto
    {
        public int Quantity { get; set; }
        public int? FoodId { get; set; }
        public int? DrinkId { get; set; }
    }
}