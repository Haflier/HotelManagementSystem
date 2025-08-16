using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOsa.Reservation 
{
    public class ReservationForRoomDto
    {
        public DateTime CheckinDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string ApiUserId { get; set; }
    }
}