using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.DTOs.Hotel
{
    public class HotelDetailDto : HotelDto
    {
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}