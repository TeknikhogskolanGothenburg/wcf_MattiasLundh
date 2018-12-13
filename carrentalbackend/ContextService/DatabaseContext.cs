using MappingEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Domain;

namespace Context
{
    public class DatabaseContext : DbContext
    {
        //ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString
        public DatabaseContext() : base("Server=.; Trusted_Connection=True; database=CarRentalDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarMapping());
            modelBuilder.Configurations.Add(new CustomerMapping());
            modelBuilder.Configurations.Add(new BookingMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
