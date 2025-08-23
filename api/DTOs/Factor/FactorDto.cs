using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Factor 
{
    public class FactorDto : FactorBaseDto
    {
        public int Id { get; set; }
        public string ApiUserId { get; set; }
    }
}