using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Repositories.IServices;
using AmazonOrderAPI.Filters;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AmazonOrderAPI.Controllers
{
    [Route("Orders")]
    [ApiController]
    [TypeFilter(typeof(LoggingFilterAttribute))]
    public class OrdersController : BaseController
    {
        public IOrderFetchServices orderFetchServices;

        public OrdersController(IOrderFetchServices _orderFetchServices, ILoggerManager logger, IOptions<AppSetting> settings) : base(logger, settings)
        {
            orderFetchServices = _orderFetchServices;
        }

        [Route("RuneZTrackerPickupRequest")]
        public IActionResult GetOrders()
        {
            var ResultOrders = orderFetchServices.GetOrders(new Business.RequestTypes.OrderRequest());
            // return Ok(ResultOrders
            return new EmptyResult();
        }
    }
}