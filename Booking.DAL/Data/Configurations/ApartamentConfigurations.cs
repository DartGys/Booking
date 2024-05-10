using Booking.DAL.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.DAL.Data.Configurations
{
    public class ApartamentConfigurations : IEntityTypeConfiguration<Apartament>
    {
        public void Configure(EntityTypeBuilder<Apartament> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Location)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Rooms) 
                .IsRequired();

            builder.Property(x => x.Owner)
                .IsRequired();

            builder.HasMany(x => x.Books)
                .WithOne(b => b.Apartament)
                .HasForeignKey(b => b.ApartamentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
