using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Factor 
{
    public class CreateFactorRequestDto
    {
        public decimal FinalPrice { get; set; }
        public string ApiUserId { get; set; }
    }
}