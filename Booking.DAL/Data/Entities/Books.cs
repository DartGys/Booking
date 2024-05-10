using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DAL.Data.Entities
{
    public class Books
    {
        public Guid UserId { get; set; }
        public Guid ApartamentId { get; set; }
        public Apartaments Apartaments { get; set; }
        public User User { get; set; }
    }
}
