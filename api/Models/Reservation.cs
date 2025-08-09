using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace api.Models 
{
    [Table("Reservation")]
    public class Reservation
    {
        public int Id { get; set; }
        public string ChosenRoom { get; set; } = string.Empty;
        public DateTime CheckinDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePerDay { get; set; }
        public int TotalNights => (CheckinDate - CheckOutDate).Days;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice => TotalNights * PricePerDay;
        public DateTime CreatedAt { get; set; }
        public string ApiUserId { get; set; }
        public ApiUser User { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}