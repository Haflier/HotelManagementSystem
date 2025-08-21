using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.OrderItem 
{
    public class OrderItemDto : OrderItemBaseDto
    {
        public int Id { get; set; }
        public int? FoodId { get; set; }
        public int? DrinkId { get; set; }
        public int OrderId { get; set; }
    }
}