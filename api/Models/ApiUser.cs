using Microsoft.AspNetCore.Identity;

namespace api.Models 
{
    public class ApiUser : IdentityUser
    {
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<Order> Orders { get; set; }
        public Factor Factor { get; set; }
    }
}