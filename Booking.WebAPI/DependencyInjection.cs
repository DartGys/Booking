using Booking.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Booking.WebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("IdentityConnection");

            services.AddDbContext<BookingIdentityDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddAuthorization();


            return services;
        }
    }
}
