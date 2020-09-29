using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Customers.Db
{
    public class CustomersDbContext : DbContext
    {
        public CustomersDbContext( DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

    }
}
