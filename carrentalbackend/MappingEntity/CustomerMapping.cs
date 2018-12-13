using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace MappingEntity
{
    public class CustomerMapping : EntityTypeConfiguration<Customer>
    {
        public CustomerMapping()
        {
            HasKey(x => x.ID);
            ToTable(nameof(Customer));
        }
    }
}
