using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.DTOs.Hotel 
{
    public class HotelDto : HotelBaseDto
    {
        public int Id { get; set; } 
        public int CityId { get; set; }
    }
}