using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DAL.Data.Entities
{
    public class Apartament
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int Rooms {  get; set; }
        public string Owner { get; set; }
    }
}
