using Microsoft.AspNetCore.Identity;

namespace HotelBookingApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Prenotazione> Prenotazioni { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
