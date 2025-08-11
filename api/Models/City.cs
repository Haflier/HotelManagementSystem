using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models 
{
    [Table("City")]
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Hotel> Hotels { get; set; }
    }
}