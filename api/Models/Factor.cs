using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models 
{
    [Table("Factor")]
    public class Factor
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<FactorItem> Items { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinalPrice { get; set; }
    }
}