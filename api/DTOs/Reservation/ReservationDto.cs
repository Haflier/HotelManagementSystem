using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Reservation 
{
    public class ReservationDto : ReservationBaseDto
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string ApiUserId { get; set; }
    }
}