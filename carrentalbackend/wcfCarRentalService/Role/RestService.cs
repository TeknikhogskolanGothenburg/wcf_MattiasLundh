using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using UnitsOfWork.UnitofWorkPattern;

namespace wcfCarRentalService.Role
{
    public class RestService : IRestService
    {
        UnitOfWork _dataAccess;

        public RestService()
        {
            _dataAccess = new UnitOfWork();
        }

        public void AddCustomer(Customer customer)
        {
            _dataAccess.CustomerService.Insert(customer);
            try
            {
                _dataAccess.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.InnerException.Message);
                Console.WriteLine("---");
                Console.WriteLine(e.InnerException.StackTrace);
                throw e;
            }
        }

        public Customer[] GetCustomers()
        {
            return _dataAccess.CustomerService.GetAll().ToArray();
        }
    }
}