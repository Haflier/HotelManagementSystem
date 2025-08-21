using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Order 
{
    public class OrderDto : OrderBaseDto
    {
        public int Id { get; set; }
        public string ApiUserId { get; set; }
    }
}