using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.DTOs.Room 
{
    public class RoomForHotelDto
    {
        public string RoomNumber { get; set; } = string.Empty;
        public int BedNumbers { get; set; }
        public decimal BasePricePerDay { get; set; }
        public ICollection<Reservation> reservations { get; set; } = new List<Reservation>();
    }
}