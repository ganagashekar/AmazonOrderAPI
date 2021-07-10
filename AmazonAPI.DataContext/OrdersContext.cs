using AmazonOrderAPI.DataContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace AmazonOrderAPI.DataContext
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        //public DbSet<MarketplaceWebServiceOrders.Model.Order> Orders { get; set; }
        //public DbSet<MarketplaceWebServiceOrders.Model.OrderItem> OrderItems { get; set; }

        public DbSet<Entities.Order> Orders { get; set; }
        public DbSet<Entities.OrderItem> OrderItems { get; set; }

        public DbSet<Seller> Sellers { set; get; }
        public DbSet<Warehouse> Warehouses { set; get; }

        public DbSet<OrderException> OrderException { set; get; }
        public DbSet<OrderResponse> OrderResponse { set; get; }
        public DbSet<OrderItemException> OrderItemException { set; get; }
        public DbSet<OrderItemResponse> OrderItemResponse { set; get; }
        public DbSet<FeedException> FeedException { set; get; }
        public DbSet<FeedResponse> FeedResponse { set; get; }

        public DbSet<ReferenceRecord> ReferenceRecords { set; get; }
        public DbSet<ReferenceRecordType> ReferenceRecordTypes { set; get; }
    }
}