using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.API.Orders.Db
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext( DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Order> orders { get; set; }

        public virtual DbSet<OrderItem> orderItems { get; set; }

    }
}
