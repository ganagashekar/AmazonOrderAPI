using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Repositories.IServices;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Controllers
{
    [Route("TimedTasks")]
    public class TimedTasksController : BaseController
    {
        public IAmazonServices amazonServices;

        public TimedTasksController(IAmazonServices _amazonServices, ILoggerManager logger, IOptions<AppSetting> settings) : base(logger, settings)
        {
            amazonServices = _amazonServices;
        }

        [AllowAnonymous]
        [Route("RunListOrder")]
        public async Task<IActionResult> RunListOrder()
        {
            await amazonServices.ImportAmazonOrders();
            return new EmptyResult();
        }

        [AllowAnonymous]
        [Route("RunListOrderItems")]
        public async Task<IActionResult> RunListOrderItems()
        {
            await amazonServices.ImportAmazonOrderItems();
            return new EmptyResult();
        }

        [AllowAnonymous]
        [Route("RunArchiveOrders")]
        public async Task<IActionResult> ArchiveOrders()
        {
            await amazonServices.ArchiveOrders();
            return new EmptyResult();
        }

        [AllowAnonymous]
        [Route("RunAcknowledgementFeed")]
        public IActionResult RunAcknowledgementFeed()
        {
            var ResultOrders = amazonServices.SendAcknowledgementFeed();
            return new EmptyResult();
        }

        [AllowAnonymous]
        [Route("RunFulfillmentFeed")]
        public IActionResult RunFulfillmentFeed()
        {
            var ResultOrders = amazonServices.SendFulfillmentFeed();
            return new EmptyResult();
        }

        [AllowAnonymous]
        [Route("OrdersV0Api/Orders")]
        public async Task<IActionResult> RunGetOrdersAsync()
        {
             await amazonServices.ImportOrders();
            return new EmptyResult();
        }
    }
}