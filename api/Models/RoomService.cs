using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models 
{
    [Table("RoomService")]
    public class RoomService
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}