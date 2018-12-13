using Domain;
using Repository;
using Services.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Services.Services
{
    public class BookingService : Repository<Booking>, IBookingService
    {
        public BookingService(DbContext context) : base(context)
        {
        }

        public ICollection GetAllAvailableBookings()
        {
            return GetAllWhere(x => x.StartTime.Day >= DateTime.UtcNow.Day).ToList();
        }

        public IEnumerable<Booking> GetBookingsByCustomerId(int customerId)
        {
            return GetAllWhere(b => b.CustomerID == customerId);
        }
    }
}
