using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Model.Reports;
using AmazonOrderAPI.Business.Repositories.IServices;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Controllers
{
    //[Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
    //[Authorize(Policy = AuthorizationConsts.AdminPolicy)]
    // [Authorize(Policy = AuthorizationConsts.CourierUserPolicy)]
    [Authorize]
    public class DashBoardController : BaseController
    {
        public IDashboardService dashboardServices;

        public DashBoardController(IDashboardService _dashboardServices, ILoggerManager logger, IOptions<AppSetting> settings)
            : base(logger, settings)
        {
            dashboardServices = _dashboardServices;
        }

        public async Task<IActionResult> Index()
        {
            OrderStatusReport model = new OrderStatusReport();

            if (model.FromDate == null)
                model.FromDate = DateTime.Now;

            if (model.ToDate == null)
                model.ToDate = DateTime.Now;

            var viewModel = await (dashboardServices.BuildReportViewModel(ClientId, SellerId, model));
            return View(viewModel);
        }
         
        public IActionResult DashBoard (OrderStatusReport model)
        {
            if (model.FromDate == null)
                model.FromDate = DateTime.Now;
            
            if (model.ToDate == null)
                model.ToDate = DateTime.Now;
            var ViewModel = dashboardServices.GetDashboardCards(model);
            return PartialView(ViewModel);
        }

        public async Task<IActionResult> Reports(OrderStatusReport model = null)
        {
            if (model.FromDate == null)
                model.FromDate = DateTime.Now;

            if (model.ToDate == null)
                model.ToDate = DateTime.Now;

            var viewModel = await (dashboardServices.BuildReportViewModel(ClientId, SellerId, model));
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult OrderReport(OrderStatusReport model)
        {
            if (model.FromDate == null)
                model.FromDate = DateTime.Now;

            if (model.ToDate == null)
                model.ToDate = DateTime.Now;
            var ViewModel = dashboardServices.GetOrderReport(model);

            return PartialView(ViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> SearchReferenceRecord(string ReferenceRecord, int limit = 0)
        {
            var scopes = await dashboardServices.SearchReferenceRecord(ReferenceRecord, limit);

            return Ok(scopes);
        }
    }
}