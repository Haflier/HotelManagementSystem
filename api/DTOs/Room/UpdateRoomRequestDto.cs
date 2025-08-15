using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Room 
{
    public class UpdateRoomRequestDto : RoomBaseDto
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
    }
}