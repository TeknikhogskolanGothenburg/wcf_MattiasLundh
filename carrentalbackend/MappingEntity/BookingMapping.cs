using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MappingEntity
{
    public class BookingMapping : EntityTypeConfiguration<Booking>
    {
        public BookingMapping()
        {
            HasRequired(x => x.Car).WithMany(g => g.Bookings).HasForeignKey(p => p.CarID);
            HasRequired(x => x.Customer).WithMany(g => g.Bookings).HasForeignKey(p => p.CustomerID);
            HasKey(x => x.ID);
            ToTable(nameof(Booking));
        }
    }
}
