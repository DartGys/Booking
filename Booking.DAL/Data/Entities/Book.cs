﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DAL.Data.Entities
{
    public class Book
    {
        public Guid Id {  get; set; }
        public Guid UserId { get; set; }
        public Guid ApartamentId { get; set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public Apartament Apartament { get; set; }
        public User User { get; set; }
    }
}
