using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Service 
{
    public class UpdateServiceRequestDto : ServiceBaseDto
    {
        public int Id { get; set; }
    }
}