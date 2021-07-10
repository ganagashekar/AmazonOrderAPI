using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Repositories.IServices;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace AmazonOrderAPI.ViewComponents
{
    public class WareHouseViewComponent : ViewComponent
    {
        private readonly ISellerServices _sellerServices;

        public WareHouseViewComponent(ISellerServices sellerServices, ILoggerManager logger, IOptions<AppSetting> settings)
        {
            _sellerServices = sellerServices;
        }

        public async Task<IViewComponentResult> InvokeAsync(long SellerId)
        {
            var result = (await _sellerServices.GetWareHouseData(SellerId));
            return View(result);
        }
    }
}