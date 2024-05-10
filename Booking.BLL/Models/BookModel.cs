using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BLL.Models
{
    public class BookModel
    {
        public Guid? Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ApartamentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
    }
}
