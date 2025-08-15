using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Service;
using api.Models;

namespace api.DTOs.Room 
{
    public class RoomDetailDto : RoomBaseDto
    {
        public List<ServiceDto> ActiveServices { get; set; } = new List<ServiceDto>();
        public ICollection<Reservation> reservations { get; set; } = new LinkedList<Reservation>();
    }
}