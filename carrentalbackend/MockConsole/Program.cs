using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsOfWork.UnitofWorkPattern;
using Domain;
using Context;
using System.Configuration;
using wcfCarRentalService;

namespace MockConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            //var x = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            //Console.WriteLine(x);

            //UnitOfWork unitOfWork = new UnitOfWork();
            //var car = unitOfWork.CarService.FindByID(5);

            UnitOfWork dbAccess = new UnitOfWork();
            List<Car> bookableCars = dbAccess.CarService.GetBookable(DateTime.Now, DateTime.Now.AddDays(3));
            bookableCars.ForEach(c => c.Bookings.ToList().ForEach(b => Console.WriteLine("Car (" + b.Car + ") booked untill " + b.EndTime)));
            Console.ReadKey();
        }
    }
}
