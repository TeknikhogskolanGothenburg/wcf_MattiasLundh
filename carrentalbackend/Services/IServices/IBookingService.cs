using Domain;
using Repository;
using System.Collections;
using System.Collections.Generic;

namespace Services.IServices
{
    public interface IBookingService : IRepository<Booking>
    {
        /// <summary>
        /// Creates a Booking , if the car is avaliable and returns a booking.
        //It will return Null if the operation failed!
        /// </summary>
        /// <param name="booking"> The booking you want to save</param>
        /// <param name="car">The car you want to rent</param>
        /// <param name="customer">the custumer in the database </param>
        /// <returns> Booking or Null</returns>
        ICollection GetAllAvailableBookings();
        IEnumerable<Booking> GetBookingsByCustomerId(int customerId);
    }
}
