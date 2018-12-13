using Domain;
using Repository;
using Services.IServices;
using System.Collections.Generic;
using System.Data.Entity;

namespace Services.Services
{
    public class CustomerService : Repository<Customer>, ICustomerService
    {
        public CustomerService(DbContext context) : base(context)
        {

        }
    }
}
