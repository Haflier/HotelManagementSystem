using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Factor 
{
    public class FactorBaseDto
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public decimal FinalPrice { get; set; }
    }
}