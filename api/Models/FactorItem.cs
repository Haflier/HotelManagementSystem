using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models 
{
    [Table("FactorItem")]
    public class FactorItem
    {
        public int Id { get; set; }
        public ICollection<Reservation> ReserveDetails { get; set; }
        public ICollection<Order> OrderDetails { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int FactorId { get; set; }
        public Factor Factor { get; set; }
    }
}