using AmazonOrderAPI.DataContext.Entities;
using MarketplaceWebServiceOrders.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonOrderAPI.DataContext
{
   public class OrderContext : DbContext
    {

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<AmazonMWSConfig> AmazonMWSConfig { set; get; }
        public DbSet<Warehouses> Warehouses { set; get; }


    }
}
