using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Writers;

namespace api.Models 
{
    [Table("Factor")]
    public class Factor
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal FinalPrice { get; set; }
        public string ApiUserId { get; set; }
        public ApiUser User { get; set; }
    }
}