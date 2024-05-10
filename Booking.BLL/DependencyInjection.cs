using Booking.BLL.Common;
using Booking.BLL.Interfaces;
using Booking.BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);

            services.AddScoped<IApartamentService, ApartamentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}
