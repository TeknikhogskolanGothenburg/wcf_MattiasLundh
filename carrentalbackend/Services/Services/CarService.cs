using Domain;
using Repository;
using Services.IServices;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
    public class CarService : Repository<Car>, ICarService
    {
        public CarService(DbContext context) : base(context)
        {

        }
        /// <summary>
        /// Finds all unbooked cars within a time span
        /// </summary>
        /// <param name="from"> the start of the time span</param>
        /// <param name="to">the end of the time span</param>
        /// <returns></returns>
        public List<Car> GetBookable(DateTime from, DateTime to)
        {
            Context.Configuration.ProxyCreationEnabled = false;
            List<Car> cars = Context.Set<Car>()
                .Include(c => c.Bookings)
                .ToList();
            List<Car> unbookedCars = cars.Where(c =>
            c.Bookings == null ||
            c.Bookings.Where(b => !(b.StartTime > to || b.EndTime < from)).ToList().Count == 0)
            .ToList();
            Context.Configuration.ProxyCreationEnabled = true;
            return unbookedCars;
        }

        public void ReturnCar(int id)
        {
            FindByID(id).Avaliable = true;
        }

        public void LendCar(int id)
        {
            FindByID(id).Avaliable = false;
        }
    }
}
