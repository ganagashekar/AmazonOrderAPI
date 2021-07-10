using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Helpers;
using AmazonOrderAPI.Business.Model;
using AmazonOrderAPI.Business.Model.Seller;
using AmazonOrderAPI.Business.Repositories.IServices;
using AmazonOrderAPI.DataContext;
using AmazonOrderAPI.DataContext.Entities;
using AmazonOrderExtentions.CoreExtentions;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Business.Repositories.ServicesImp
{
    public class SellerServices : BaseCommonClass, ISellerServices
    {
        public readonly OrderContext _dbContext;

        public SellerServices(OrderContext dbContext, ILoggerManager logger, IOptions<AppSetting> setting)
            : base(logger, setting)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public SellerVM BuildSellerViewModel(SellerVM seller = null)
        {
            if (seller == null)
            {
                var clientDto = new SellerVM
                {
                    //AccessKey = seller.AccessKey,
                    //AppName = seller.AppName,
                    //Country = seller.Country,
                    //ClientId = seller.ClientId,
                    //Id = seller.Id,
                    //IsStage = seller.IsStage,
                    //MWSAuthToken = seller.MWSAuthToken,

                    //MarketplaceId = seller.MarketplaceId,
                    //SellerId = seller.SellerId,
                    //SecretKey = seller.SecretKey,
                    //SellerName = seller.SellerName,
                    //ServiceURL = seller.ServiceURL
                };
                return (clientDto);
            }
            else
            {
                return (seller);
            }

            // return clientDto;

            //seller.AccessTokenTypes = GetAccessTokenTypes();
            //seller.RefreshTokenExpirations = GetTokenExpirations();
            //seller.RefreshTokenUsages = GetTokenUsage();
            //seller.ProtocolTypes = GetProtocolTypes();

            //PopulateClientRelations(client);
        }

        private void PopulateClientRelations(SellerVM client)
        {
            //ComboBoxHelpers.PopulateValuesToList(client.AllowedScopesItems, client.AllowedScopes);
            //ComboBoxHelpers.PopulateValuesToList(client.PostLogoutRedirectUrisItems, client.PostLogoutRedirectUris);
            //ComboBoxHelpers.PopulateValuesToList(client.IdentityProviderRestrictionsItems, client.IdentityProviderRestrictions);
            //ComboBoxHelpers.PopulateValuesToList(client.RedirectUrisItems, client.RedirectUris);
            //ComboBoxHelpers.PopulateValuesToList(client.AllowedCorsOriginsItems, client.AllowedCorsOrigins);
            //ComboBoxHelpers.PopulateValuesToList(client.AllowedGrantTypesItems, client.AllowedGrantTypes);
        }

        public async Task<SellerVM> GetSellerAsync(long SellerId)
        {
            //.Include(x => x.AllowedGrantTypes)
            //.Include(x => x.RedirectUris)
            //.Include(x => x.PostLogoutRedirectUris)
            //.Include(x => x.AllowedScopes)
            //.Include(x => x.ClientSecrets)
            //.Include(x => x.Claims)
            //.Include(x => x.IdentityProviderRestrictions)
            //.Include(x => x.AllowedCorsOrigins)
            //.Include(x => x.Properties)

            var Sellers = await _dbContext.Sellers.Where(x => x.Id == SellerId).SingleOrDefaultAsync();
            var result = Sellers.ToDestination<Seller, SellerVM>();
            return (result);
        }

        public async Task<List<WarehouseVM>> GetWareHouseData(long sellerId)
        {
            var WarehousesResult = await _dbContext.Warehouses.Where(x => x.SellerId == sellerId).ToListAsync();
            var result = WarehousesResult.ToDestinationList<Warehouse, WarehouseVM>();
            return result;
        }

        public async Task<List<SelectItem>> GetWareHouseDropDown(long sellerId)
        {
            var WarehousesResult = await _dbContext.Warehouses.Where(x => x.SellerId == sellerId).ToListAsync();
            var result = WarehousesResult.ToDestinationList<Warehouse, SelectItem>();
            return result;
        }

        public async Task<WarehouseVM> GetWareHouseDetails(long Id, long SellerId = 0)
        {
            WarehouseVM _WarehouseVM;
            try
            {
                if (Id == default(long))
                {
                    _WarehouseVM = new WarehouseVM();
                    _WarehouseVM.SellerId = SellerId;
                }
                else
                {
                    var WarehousesResult = await _dbContext.Warehouses.Where(x => x.Id == Id).SingleOrDefaultAsync();
                    _WarehouseVM = WarehousesResult.ToDestination<Warehouse, WarehouseVM>();
                }
                return _WarehouseVM;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _WarehouseVM = null;
            }
        }

        public async Task<SellersVM> GetSellersAsync(string ClientId, string SellerId, string search = "", int page = 1, int pageSize = 10)
        {
            var pagedList = new PagedList<SellerVM>();
            try
            {
                Expression<Func<Seller, bool>> searchCondition = x => (x.ClientId.Contains(search) || x.SellerId.Contains(search));
                var clients = (await _dbContext.Sellers.Where(x => x.ClientId == ClientId).Where(x => !string.IsNullOrEmpty(SellerId) ? x.SellerName == SellerId : true).WhereIf(!string.IsNullOrEmpty(search), searchCondition).PageBy(x => x.Id, page, pageSize).ToListAsync());
                pagedList.Data.AddRange(clients.ToDestinationList<Seller, SellerVM>());
                pagedList.TotalCount = (await _dbContext.Sellers.WhereIf(!string.IsNullOrEmpty(search), searchCondition).CountAsync());
                pagedList.PageSize = pageSize;
                var result = pagedList.ToDestinationPaged<SellerVM, SellersVM>();
                return (result);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                pagedList = null;
            }
            
        }

        public async Task<bool> AddOrUpdateWareHouse(WarehouseVM warehouseVM)
        {
            try
            {
                var WareHouseModel = await _dbContext.Warehouses.FirstOrDefaultAsync(x => x.Id == warehouseVM.Id);
                if (WareHouseModel.IsNull())
                {
                    WareHouseModel = new Warehouse();
                    _dbContext.Warehouses.Add(WareHouseModel);
                }
                WareHouseModel.AddressLine1 = warehouseVM.AddressLine1;
                WareHouseModel.AddressLine2 = warehouseVM.AddressLine2;
                WareHouseModel.AddressLine3 = warehouseVM.AddressLine3;
                WareHouseModel.PostalCode = warehouseVM.PostalCode;
                WareHouseModel.Name = warehouseVM.Name;
                WareHouseModel.Phone = warehouseVM.Phone;
                WareHouseModel.WarehouseLocationName = warehouseVM.WarehouseLocationName;
                WareHouseModel.SellerId = warehouseVM.SellerId;
                WareHouseModel.IsActive = warehouseVM.IsActive;

                WareHouseModel.WarehouseLocationCode = warehouseVM.WarehouseLocationCode;

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task AddOrUpdateSellerAsync(SellerVM client)
        {
            try
            {
                var SellerModel = await _dbContext.Sellers.FirstOrDefaultAsync(x => x.Id == client.Id);
                if (SellerModel.IsNull())
                {
                    SellerModel = new Seller();
                    _dbContext.Sellers.Add(SellerModel);
                }
                SellerModel.AccessKey = client.AccessKey;
                //SellerModel.AppName = client.AppName;
                SellerModel.ClientId = client.ClientId;
                SellerModel.CustomerCode = client.CustomerCode;
                SellerModel.Country = client.Country;
                SellerModel.CountryCode = client.CurrencyCode;
                SellerModel.CreatedDate = DateTime.Now;
                SellerModel.CurrencyCode = client.CurrencyCode;
                SellerModel.IsStage = client.IsStage;
                SellerModel.MarketplaceId = client.MarketplaceId;
                SellerModel.MWSAuthToken = client.MWSAuthToken;
                SellerModel.SecretKey = client.SecretKey;
                SellerModel.SellerId = client.SellerId;
                SellerModel.SellerName = client.SellerName;
                SellerModel.ServiceURL = client.ServiceURL;
                SellerModel.IsAutoManual = client.IsAutoManual;
                SellerModel.IsShouldbeGenConsNo = client.IsShouldbeGenConsNo;
                SellerModel.IsActive = client.IsActive;
                SellerModel.CreatedBy = client.CreatedBy;
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public async Task DeleteSeller(long sellerId)
        {
            try
            {
                var SellerModel = await _dbContext.Sellers.FirstOrDefaultAsync(x => x.Id == sellerId);
                _dbContext.Remove(SellerModel);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<long> DeleteWareHouse(long id, long SellerId = 0)
        {
            try
            {
                var Warehouses = await _dbContext.Warehouses.FirstOrDefaultAsync(x => x.Id == id);
                _dbContext.Remove(Warehouses);
                _dbContext.SaveChanges();
                return Warehouses.SellerId;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task CloneSeller(long sellerId)
        {
            try
            {
                var SellerModel = await _dbContext.Sellers.FirstOrDefaultAsync(x => x.Id == sellerId);

                var entity = _dbContext.Sellers
                    .AsNoTracking()
                    //.Include(x => x.)
                    .FirstOrDefault(x => x.Id == sellerId);

                var data = entity.ToDestination<Seller, Seller>();

                _dbContext.Add(data);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}