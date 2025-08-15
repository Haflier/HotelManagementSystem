using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.DTOs.Service 
{
    public class ServiceDetailDto : ServiceBaseDto
    {
        public ICollection<RoomService> RoomServices { get; set; }
    }
}