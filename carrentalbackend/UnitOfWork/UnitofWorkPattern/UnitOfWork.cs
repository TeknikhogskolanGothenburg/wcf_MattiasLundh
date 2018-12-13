
using Services;
using Services.IServices;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;

namespace UnitsOfWork.UnitofWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DbContext Context;

        public ICarService CarService { get; set; }
        public IBookingService BookingService { get; set; }
        public ICustomerService CustomerService { get; set; }

        public UnitOfWork()
        {
            this.Context = new DatabaseContext();
            CarService = new CarService(Context);
            BookingService = new BookingService(Context);
            CustomerService = new CustomerService(Context);
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

    }
}
