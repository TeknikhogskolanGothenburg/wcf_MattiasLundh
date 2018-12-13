using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsOfWork.UnitofWorkPattern
{
    public interface IUnitOfWork
    {
        int Save();
        void Dispose();
        //Repositories exemepl
        ICarService CarService { get; set; }
        IBookingService BookingService { get; set; }
        ICustomerService CustomerService { get; set; }

    }
}
