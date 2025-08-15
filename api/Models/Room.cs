using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace api.Models 
{
    [Table("Room")]
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int BedNumbers { get; set; }
        public bool IsAvailable { get; set; } = true;
        public List<Service> ActiveServices { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BasePricePerDay { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPricePerDay => BasePricePerDay + (RoomServices?.Sum(rs => rs.Service.Price) ?? 0);
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public ICollection<RoomService> RoomServices { get; set; }
    }
}