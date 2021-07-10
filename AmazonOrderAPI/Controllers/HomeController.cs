using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Model.Reports;
using AmazonOrderAPI.Business.Repositories.IServices;
using AmazonOrderAPI.Business.ResponseTypes.Common;

using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Controllers
{
    [Route("Home")]
    public class HomeController : BaseController
    {
        public IOrderFetchServices orderFetchServices;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(IOrderFetchServices _orderFetchServices, IStringLocalizer<HomeController> localizer, ILoggerManager logger, IOptions<AppSetting> settings) : base(logger, settings)
        {
            orderFetchServices = _orderFetchServices;
            _localizer = localizer;
        }

        [AllowAnonymous]
        [Route("RuneZTrackerPickupRequest")]
        public IActionResult GetOrders()
        {
            var ResultOrders = orderFetchServices.GetOrders(new Business.RequestTypes.OrderRequest());
            return new EmptyResult();
        }

        [HttpGet]
        [Route("RetryOrder")]
        public IActionResult RetryOrder(long OrderId)
        {
            var ViewModel = orderFetchServices.RetryOrder(OrderId);
            return Json(ViewModel);
        }

        //[HttpGet]
        //[Route("AcknowledgeOrder")]
        //public IActionResult AcknowledgeOrder(long OrderId)
        //{
        //    var ViewModel = orderFetchServices.AcknowledgeOrder(OrderId);
        //    return Json(ViewModel);
        //}

        //[HttpGet]
        //[Route("FulfillOrder")]
        //public IActionResult FulfillOrder(long OrderId)
        //{
        //    var ViewModel = orderFetchServices.FulfillOrder(OrderId);
        //    return Json(ViewModel);
        //}

        [HttpGet]
        [Route("PickupOrder")]
        public async Task<IActionResult> PickupOrderAsync(long OrderId, long WarehouseId)
        {
            Response ViewModel = await orderFetchServices.PickupOrder(OrderId, WarehouseId);
            if(ViewModel.Message.ToLower().Contains("success"))
            {
                SuccessNotification(string.Format(_localizer["PickupSuccess"], OrderId), _localizer["SuccessTitle"]);
            }
            else
            {
                FailureNotification(string.Format(_localizer["WarehouseUpdateFailed"], OrderId), _localizer["FailureTitle"]);
            }
            return Json(ViewModel);
        }

        [HttpPost]
        [Route("OrderReportAsync")]
        public async Task<IActionResult> OrderReportAsync(OrderStatusReport model)
        {
            if (model.FromDate == null)
                model.FromDate = DateTime.Now;

            if (model.ToDate == null)
                model.ToDate = DateTime.Now;
            var ViewModel = await orderFetchServices.RetryOrders(model);

            return Json(ViewModel);
        }

        [HttpGet]
        [Route("GetOrderDetails")]
        public async Task<IActionResult> GetOrderDetails(long OrderId)
        {
            var ViewModel = await orderFetchServices.GetOrderById(OrderId);

            return PartialView(ViewModel);
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveOrUpdateOrderDetails")]
        public async Task<IActionResult> SaveOrUpdateOrderDetails(OrderItemStatusDetail OrderItems)
        {
            var result = await orderFetchServices.SaveOrUpdateOrderDetails(OrderItems);

            return Json(result);
        }
    }
}