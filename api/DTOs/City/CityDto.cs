using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Hotel;

namespace api.DTOs.City 
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<HotelBaseDto> Hotels { get; set; } = new List<HotelBaseDto>();
    }
}