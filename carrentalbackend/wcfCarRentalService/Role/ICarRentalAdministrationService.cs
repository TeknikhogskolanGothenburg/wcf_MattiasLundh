using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Domain;
using System.ServiceModel.Web;
using wcfCarRentalService.Exceptions;

namespace wcfCarRentalService.Role
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarRentalAdministrationService" in both code and config file together.
    [ServiceContract]
    public interface ICarRentalAdministrationService
    {
        [OperationContract]
        string[] Description();

        [OperationContract]
        void AddCar(Car car);

        [OperationContract]
        void RemoveCar(int carId);

        [OperationContract]
        [FaultContract(typeof(NoDataAvaliable))]
        [FaultContract(typeof(AccessDenied))]
        CarInfo GetCar(CarRequest carRequest);

        [OperationContract(Name = "GetUnbookedCars")]
        Car[] GetAvaliableCars(DateTime from, DateTime to);

        [OperationContract]
        void ReturnCar(int carId);

        [OperationContract]
        void LendCar(int carId);

        [OperationContract]
        Customer[] GetCustomers();

        [OperationContract]
        [FaultContract(typeof(NoDataAvaliable))]
        Booking[] GetBookingsByRelation(BaseEntity entity);
    }
}
