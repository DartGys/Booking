using AutoMapper;
using Booking.BLL.Models;
using Booking.DAL.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BLL.Common
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Apartament, ApartamentModel>()
                .ReverseMap();

            CreateMap<User, UserModel>() 
                .ReverseMap();

            CreateMap<Book, BookModel>()
                .ReverseMap();
        }
    }
}
