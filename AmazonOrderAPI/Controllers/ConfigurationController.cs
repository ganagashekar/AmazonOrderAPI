using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Model;
using AmazonOrderAPI.Business.Model.Seller;
using AmazonOrderAPI.Business.Repositories.IServices;
using LoggerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Controllers
{
    //[Authorize(Roles = "SellerUser,Admin")]
    [Authorize(Roles = "Admin")]
    public class ConfigurationController : BaseController
    {
        private readonly ISellerServices _sellerServices;
        private readonly IStringLocalizer<ConfigurationController> _localizer;

        public ConfigurationController(ISellerServices sellerServices, IStringLocalizer<ConfigurationController> localizer,
            ILoggerManager logger, IOptions<AppSetting> settings) : base(logger, settings)
        {
            _sellerServices = sellerServices;
            _localizer = localizer;
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        [Route("[controller]/[action]/{id:int}")]
        public async Task<IActionResult> Seller(long id)
        {
            if (id == default(long))
            {
                var clientDto = _sellerServices.BuildSellerViewModel();
                return View(clientDto);
            }

            var client = await _sellerServices.GetSellerAsync(id);
            client = _sellerServices.BuildSellerViewModel(client);

            return View(client);
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Sellers(int? page, string search)
        {
            ViewBag.Search = search;
            return View(await _sellerServices.GetSellersAsync(ClientId, SellerId, search, page ?? 1));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SellerSaveOrUpdate(SellerVM Seller)
        {
            Seller.ClientId = ClientId;
            Seller = _sellerServices.BuildSellerViewModel(Seller);
            if (!ModelState.IsValid)
            {
                return View(Seller);
            }
            await _sellerServices.AddOrUpdateSellerAsync(Seller);
            SuccessNotification(string.Format(_localizer["SuccessAddClient"], Seller.SellerName), _localizer["SuccessTitle"]);
            return RedirectToAction("Seller", new { Seller.Id });
        }

        [Route("Configuration/GetWarehouseDetails")]
        public async Task<IActionResult> GetWarehouseDetails(long Id, long SellerId = 0)
        {
            var Model = await _sellerServices.GetWareHouseDetails(Id, SellerId);
            return PartialView(Model);
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> WareHouse(WarehouseVM warehouseVM)
        {
            var JsonResult = await _sellerServices.AddOrUpdateWareHouse(warehouseVM);

            SuccessNotification(string.Format(_localizer["SuccessWareHouseUpdate"], warehouseVM.PostalCode), _localizer["SuccessTitle"]);

            return RedirectToAction("WareHouseComponent", new { _SellerId = warehouseVM.SellerId });
        }

        public IActionResult WareHouseComponent(long _SellerId = 0)
        {
            return ViewComponent("WareHouse", new { SellerId = _SellerId });
        }

        public async Task<IActionResult> DeleteWareHouse(long Id, long SellerId = 0)
        {
            var sellerId = await _sellerServices.DeleteWareHouse(Id, SellerId);

            SuccessNotification(string.Format(_localizer["SuccessWareHouseDelete"], Id), _localizer["SuccessTitle"]);

            return RedirectToAction("WareHouseComponent", new { _SellerId = sellerId });
        }

        [HttpGet]
        [Route("[controller]/[action]/{id:long}")]
        public async Task<IActionResult> SellerDelete(long Id)
        {
            await _sellerServices.DeleteSeller(Id);

            SuccessNotification(string.Format(_localizer["SuccessClientDelete"], Id), _localizer["SuccessTitle"]);

            return RedirectToAction("Sellers");
        }

        [HttpGet]
        [Route("[controller]/[action]/{id:long}")]
        public async Task<IActionResult> SellerClone(long Id)
        {
            await _sellerServices.CloneSeller(Id);
            return RedirectToAction("Sellers");
        }

        [HttpGet]
        [Route("GetWareHouseDropDown")]
        public IActionResult GetWareHouseDropDown(long SellerId)
        {
            var ViewModel = _sellerServices.GetWareHouseDropDown(SellerId);
            return Json(ViewModel);
        }
    }
}