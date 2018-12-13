using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using UnitsOfWork.UnitofWorkPattern;
using wcfCarRentalService.Exceptions;
using System.ServiceModel;
using System.IO;


namespace wcfCarRentalService.Role
{
    public class CarRentalService : ICarRentalAdministrationService, ICarRentalCustomerService
    {
        public string[] Description()
        {
            string[] descriptionText = File.ReadAllLines("./../../../../description.txt");
            return descriptionText;
        }

        UnitOfWork _dataAccess;
        public CarRentalService()
        {
            _dataAccess = new UnitOfWork();
        }

        public void AddBooking(Booking booking)
        {
            _dataAccess.BookingService.Insert(booking);
            _dataAccess.Save();
        }

        public void AddCar(Car car)
        {
            _dataAccess.CarService.Insert(car);
            _dataAccess.Save();
        }

        public void AddCustomer(Customer customer)
        {
            _dataAccess.CustomerService.Insert(customer);
            _dataAccess.Save();
        }

        public CarInfo GetCar(CarRequest carRequest)
        {
            if (carRequest.Key != "grantAccess")
            {
                FaultException exception = new FaultException<AccessDenied>(
                    new AccessDenied { Info = "Invalid Key: try [grantAccess]" },
                    new FaultReason("unauthenticated request")
                    );
                throw exception;
            }
            Car car = _dataAccess.CarService.FindByID(carRequest.CarId);
            if (null == car)
            {
                NoDataAvaliable fault = new NoDataAvaliable();
                fault.Info = string.Format("no car with Id:{0} in database", carRequest.CarId);
                throw new FaultException<NoDataAvaliable>(fault);
            }
            return new CarInfo(car);
        }

        public Car[] GetAvaliableCars(DateTime from, DateTime to)
        {
            var cars = _dataAccess.CarService.GetBookable(from, to);
            return cars.ToArray();
        }

        public Booking[] GetBookingsByCustomerId(int customerId)
        {
            var customer = _dataAccess.CustomerService.FindByID(customerId);
            if (null == customer)
            {
                throw new FaultException<NoDataAvaliable>(
                    new NoDataAvaliable { Info = "no such user, try a different user ID" });
            }
            return _dataAccess.BookingService.GetBookingsByCustomerId(customerId).ToArray();
        }

        public Customer GetCustomer(string email)
        {
            return _dataAccess.CustomerService.Find(c => c.Email == email).FirstOrDefault();
        }

        public Customer[] GetCustomers()
        {
            return _dataAccess.CustomerService.GetAll().ToArray();
        }

        public void LendCar(int carId)
        {
            _dataAccess.CarService.LendCar(carId);
            _dataAccess.Save();
        }

        public void RemoveBooking(int bookingId)
        {
            var booking = _dataAccess.BookingService.FindByID(bookingId);
            _dataAccess.BookingService.Delete(booking);
            _dataAccess.Save();
        }

        public void RemoveCar(int carId)
        {
            var car = _dataAccess.CarService.FindByID(carId);
            _dataAccess.CarService.Delete(car);
            _dataAccess.Save();
        }

        public void RemoveCustomer(int customerId)
        {
            var customer = _dataAccess.CustomerService.FindByID(customerId);
            _dataAccess.CustomerService.Delete(customer);
            _dataAccess.Save();
        }

        public void ReturnCar(int carId)
        {
            _dataAccess.CarService.ReturnCar(carId);
            _dataAccess.Save();
        }

        public void UpdateCustomer(Customer customer)
        {
            Customer c = _dataAccess.CustomerService.FindByID(customer.ID);
            c.FirstName = customer.FirstName ?? c.FirstName;
            c.LastName = customer.LastName ?? c.LastName;
            c.Tel = customer.Tel == 0 ? c.Tel : customer.Tel;
            c.Email = customer.Email ?? c.Email;
            _dataAccess.Save();
        }

        public Booking[] GetBookingsByRelation(BaseEntity entity)
        {
            IEnumerable<Booking> result;
            if (entity.GetType() == typeof(Car))
            {
                Car car = _dataAccess.CarService.FindByID(entity.ID) ??
                    throw new FaultException<NoDataAvaliable>(
                        new NoDataAvaliable { Info = string.Format("no car with id: {0} in database", entity.ID) });
                result = car.Bookings;
            }
            else
            {
                Customer customer = _dataAccess.CustomerService.FindByID(entity.ID) ??
                    throw new FaultException<NoDataAvaliable>(
                        new NoDataAvaliable { Info = string.Format("no customer with id: {0} in database", entity.ID) });
                result = customer.Bookings;
            }

            return result.ToArray();

        }
    }
}
