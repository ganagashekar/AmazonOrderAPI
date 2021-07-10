using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Model;
using AmazonOrderAPI.Business.Model.Seller;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Business.Repositories.IServices
{
    public interface ISellerServices
    {
        SellerVM BuildSellerViewModel(SellerVM seller = null);

        Task<SellerVM> GetSellerAsync(long SellerId);

        Task<SellersVM> GetSellersAsync(string ClientId, string SellerId, string search, int page = 1, int pageSize = 10);

        Task<List<WarehouseVM>> GetWareHouseData(long sellerId);

        Task<WarehouseVM> GetWareHouseDetails(long Id, long SellerId = 0);

        Task<bool> AddOrUpdateWareHouse(WarehouseVM warehouseVM);

        Task AddOrUpdateSellerAsync(SellerVM client);

        Task DeleteSeller(long sellerId);

        Task CloneSeller(long sellerId);

        Task<long> DeleteWareHouse(long id, long SellerId = 0);

        Task<List<SelectItem>> GetWareHouseDropDown(long sellerId);
    }
}