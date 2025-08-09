using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models 
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice { get; set; }
        public bool IsFinalized { get; set; }
        public string ApiUserId { get; set; }
        public ApiUser User { get; set; }
    }
}