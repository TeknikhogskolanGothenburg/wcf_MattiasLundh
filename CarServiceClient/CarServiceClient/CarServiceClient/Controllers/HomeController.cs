using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using CarServiceClient.CarRentalService;
using CarServiceClient.Models;

namespace CarServiceClient.Controllers
{
    public class HomeController : Controller
    {

        private ICarRentalCustomerService _customerClient = new CarRentalCustomerServiceClient("WSHttpBinding_ICarRentalCustomerService");
        private ICarRentalAdministrationService _adminClient = new CarRentalAdministrationServiceClient("WSHttpBinding_ICarRentalAdministrationService");
        private ICarRentalAdministrationService _adminClientTcp = new CarRentalAdministrationServiceClient("NetTcpBinding_ICarRentalAdministrationService");

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cars()
        {
            return View();
        }

        public ActionResult Bookings()
        {
            return View();
        }

        public ActionResult Customers()
        {
            return View();
        }

        public ActionResult Documentation()
        {
            Description model = new Description();
            _adminClient.Description().ToList().ForEach(line => model.document += "\n" + line);
            return View(model);
        }

        public ActionResult GetCarById(int CarId)
        {
            Car[] cars = new Car[1];
            CarInfo car;
            try
            {
                car = _adminClient.GetCar(new CarRequest("grantAccess1", CarId));
            }

            catch (FaultException<NoDataAvaliable> e)
            {
                ViewBag.Message = e.Detail.Info;
                return PartialView("../partial/partialCars", new Car[0]);
            }
            catch (FaultException<AccessDenied> e)
            {
                ViewBag.Message = e.Detail.Info;
                return PartialView("../partial/partialCars", new Car[0]);
            }
            cars[0] = new Car
            {
                ID = car.Id,
                RegistrationNumber = car.RegistrationNumber,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Avaliable = car.Avaliable
            };
            return PartialView("../partial/partialCars", cars);
        }

        public ActionResult GetAvaliableCars(DateTime from, DateTime to)
        {
            var cars = _customerClient.GetAvaliableCars(from, to);
            ((CarRentalCustomerServiceClient)_customerClient).Close();
            return PartialView("../partial/partialCars", cars);
        }

        public ActionResult AddCar(Car car)
        {
            _adminClient.AddCar(car);
            ((CarRentalAdministrationServiceClient)_adminClient).Close();
            return View("Cars");
        }

        public ActionResult RemoveCar(int id)
        {
            _adminClientTcp.RemoveCar(id);
            ((CarRentalAdministrationServiceClient)_adminClientTcp).Close();
            return new EmptyResult();
        }

        public ActionResult GetCustomers()
        {
            var customers = _adminClient.GetCustomers();
            ((CarRentalAdministrationServiceClient)_adminClient).Close();
            return PartialView("../partial/partialCustomers", customers);
        }

        public ActionResult AddCustomer(Customer customer)
        {
            _customerClient.AddCustomer(customer);
            ((CarRentalCustomerServiceClient)_customerClient).Close();
            return View("Customers");
        }

        public ActionResult RemoveCustomer(int id)
        {
            _customerClient.RemoveCustomer(id);
            ((CarRentalCustomerServiceClient)_customerClient).Close();
            return new EmptyResult();
        }

        public ActionResult GetBookings(int Id, string bookingType)
        {
            BaseEntity requestObject;
            if (bookingType == "car")
            {
                requestObject = new Car { ID = Id };
            }
            else
            {
                requestObject = new Customer { ID = Id };
            }

            Booking[] bookings = new Booking[0];
            try
            {
                bookings = _adminClient.GetBookingsByRelation(requestObject);
            }
            catch (FaultException<NoDataAvaliable> e)
            {
                ViewBag.Message = e.Detail.Info;
            }

            return PartialView("../partial/partialBookings", bookings);
        }

        public ActionResult AddBooking(Booking booking)
        {
            _customerClient.AddBooking(booking);
            ((CarRentalCustomerServiceClient)_customerClient).Close();
            return View("Bookings");
        }

        public ActionResult RemoveBooking(int bookingId)
        {
            _customerClient.RemoveBooking(bookingId);
            ((CarRentalCustomerServiceClient)_customerClient).Close();
            return new EmptyResult();
        }

        public ActionResult SetAvailability(int carId, bool available)
        {
            if (available)
            {
                _adminClient.ReturnCar(carId);
            }
            else
            {
                _adminClient.LendCar(carId);
            }
            ((CarRentalAdministrationServiceClient)_adminClient).Close();
            return new EmptyResult();
        }
    }
}