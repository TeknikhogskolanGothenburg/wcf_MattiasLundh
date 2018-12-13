using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Domain;
using System.Net.Security;

namespace wcfCarRentalService.Role
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarRentalCustomerService" in both code and config file together.
    [ServiceContract]
    public interface ICarRentalCustomerService
    {
        [OperationContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        Customer GetCustomer(string email);

        [OperationContract]
        void AddCustomer(Customer customer);

        [OperationContract]
        void RemoveCustomer(int customerId);

        [OperationContract]
        void UpdateCustomer(Customer customer);

        [OperationContract]
        Car[] GetAvaliableCars(DateTime from, DateTime to);

        [OperationContract]
        void AddBooking(Booking booking);

        [OperationContract]
        void RemoveBooking(int bookingId);

        [OperationContract]
        Booking[] GetBookingsByCustomerId(int customerId);
    }
}
