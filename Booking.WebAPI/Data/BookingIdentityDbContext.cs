using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Booking.WebAPI.Data
{
    public class BookingIdentityDbContext : IdentityDbContext
    {
        public BookingIdentityDbContext(DbContextOptions<BookingIdentityDbContext> options) : base(options)
        {
            
        }
    }
}
