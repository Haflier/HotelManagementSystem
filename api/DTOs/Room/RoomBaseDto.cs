using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Service;
using api.Models;

namespace api.DTOs.Room 
{
    public class RoomBaseDto
    {
        public string RoomNumber { get; set; } = string.Empty;
        public int BedNumbers { get; set; }
        public bool IsAvailable { get; set; }
        public decimal BasePricePerDay { get; set; }
    }
}