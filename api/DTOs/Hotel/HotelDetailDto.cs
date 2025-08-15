using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Room;
using api.Models;

namespace api.DTOs.Hotel
{
    public class HotelDetailDto : HotelDto
    {
        public ICollection<RoomForHotelDto> Rooms { get; set; } = new List<RoomForHotelDto>();
    }
}