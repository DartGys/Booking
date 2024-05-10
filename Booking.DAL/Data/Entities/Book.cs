using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DAL.Data.Entities
{
    public class Book
    {
        public Guid UserId { get; set; }
        public Guid ApartamentId { get; set; }
        public Apartament Apartaments { get; set; }
        public User User { get; set; }
    }
}
