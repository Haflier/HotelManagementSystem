using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace api.Models 
{
    public class ApiUser : IdentityUser
    {
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}