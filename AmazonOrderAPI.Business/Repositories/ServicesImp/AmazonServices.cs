using Amazon.APIEngine.Api;
using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Repositories.IServices;
using AmazonOrderAPI.DataContext;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Business.Repositories.ServicesImp
{
    public class AmazonServices : BaseCommonClass, IAmazonServices
    {
        private readonly OrderContext _dbContext;
        private IOptions<AppSetting> Setting;
        public AmazonServices(OrderContext dbContext, ILoggerManager logger, IOptions<AppSetting> _setting
           ) : base(logger, _setting)

        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Setting = _setting;
        }

        public async Task<string> ImportAmazonOrderItems()
        {
            var Sellerlist = _dbContext.Sellers.Where(x => x.IsActive == true && x.IsStage == false).ToList();
            foreach (var Seller in Sellerlist)
            {
                //var OrdersMonitor = new OrdersMonitorApp(_dbContext, _logger, setting, Seller);
                //await OrdersMonitor.TimedTasksRunListOrderItems();
            }
            return string.Empty;
        }

        public async Task<string> ImportAmazonOrders()
        {
            var Sellerlist = _dbContext.Sellers.Where(x => x.IsActive == true && x.IsStage == false).ToList();
            foreach (var Seller in Sellerlist)
            {
                //var OrdersMonitor = new OrdersMonitorApp(_dbContext, _logger, setting, Seller);
                //await OrdersMonitor.TimedTasksRunListOrder();
            }
            return string.Empty;
        }

        public async Task<string> SendAcknowledgementFeed()
        {
            var Sellerlist = _dbContext.Sellers.Where(x => x.IsActive == true && x.IsStage == false).ToList();
            foreach (var Seller in Sellerlist)
            {
                //var OrdersMonitor = new OrdersMonitorApp(_dbContext, _logger, setting, Seller);
                //await OrdersMonitor.TimedTasksRunSendAcknowledgementFeed();
            }
            return string.Empty;
        }

        public async Task<string> SendFulfillmentFeed()
        {
            var Sellerlist = _dbContext.Sellers.Where(x => x.IsActive == true && x.IsStage == false).ToList();
            foreach (var Seller in Sellerlist)
            {
                //var OrdersMonitor = new OrdersMonitorApp(_dbContext, _logger, setting, Seller);
                //await OrdersMonitor.TimedTasksRunSendFulfillmentFeed();
            }
            return string.Empty;
        }

        public async Task<string> ArchiveOrders()
        {
            var NewDate = DateTime.Now.AddDays(-30);
            var CmdAddresstext = "INSERT INTO amz.AddressHistry SELECT * FROM  amz.Address where cast(CreatedDate as Date) <='" + NewDate.ToString("yyyy-MM-dd") + "'";
            await _dbContext.Database.ExecuteSqlCommandAsync(CmdAddresstext);

            var cmdOrderItems = "INSERT INTO amz.OrderItemsHistry SELECT* FROM  amz.OrderItems where cast(CreatedDate as Date)<='" + NewDate.ToString("yyyy/MM/dd") + "'";
            await _dbContext.Database.ExecuteSqlCommandAsync(cmdOrderItems);

            var CmdOrderItemstext = "INSERT INTO amz.OrdersHistry SELECT* FROM  amz.Orders where cast(CreatedDate as Date)<='" + NewDate.ToString("yyyy/MM/dd") + "'";
            await _dbContext.Database.ExecuteSqlCommandAsync(CmdOrderItemstext);

            await _dbContext.Database.ExecuteSqlCommandAsync("Delete FROM  amz.OrderItems where cast(CreatedDate as Date)<='" + NewDate.ToString("yyyy/MM/dd") + "'");
            await _dbContext.Database.ExecuteSqlCommandAsync("Delete FROM  amz.Orders where cast(CreatedDate as Date)<='" + NewDate.ToString("yyyy/MM/dd") + "'");
            await _dbContext.Database.ExecuteSqlCommandAsync("Delete FROM  amz.Address where cast(CreatedDate as Date)<='" + NewDate.ToString("yyyy/MM/dd") + "'");
            return string.Empty;
        }

        public async Task<string> ImportOrders()
        {

            OrderMonitor.SPOrders SPOrders = new OrderMonitor.SPOrders(new OrdersV0Api("https://sandbox.sellingpartnerapi-eu.amazon.com/"), _dbContext, _logger, Setting);
           await SPOrders.GetOrdersAsync();
         //  await SPOrders.GetOrderItemsAsync();
            return string.Empty;
        }
        public async Task<string> ImportOrderItems()
        {


            OrderMonitor.SPOrders SPOrders = new OrderMonitor.SPOrders(new OrdersV0Api(), _dbContext, _logger, Setting);

            await SPOrders.GetOrderItemsAsync();
            return string.Empty;
        }
    }
}