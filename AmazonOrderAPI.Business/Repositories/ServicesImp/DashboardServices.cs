using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Common.EnumOps;
using AmazonOrderAPI.Business.Helpers;
using AmazonOrderAPI.Business.Model.Dashboard;
using AmazonOrderAPI.Business.Model.Reports;
using AmazonOrderAPI.Business.Repositories.IServices;
using AmazonOrderAPI.DataContext;
using AmazonOrderExtentions.CoreExtentions;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Business.Repositories.ServicesImp
{
    public class DashboardServices : BaseCommonClass, IDashboardService
    {
        private readonly OrderContext _dbContext;

        public DashboardServices(OrderContext dbContext, ILoggerManager logger, IOptions<AppSetting> setting)
            : base(logger, setting)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public DashBoardOrder GetDashboardCards(OrderStatusReport model)
        {
            var SellerIds = model.SellerId.ToLongArrayComma();
            DashBoardOrder lstCardsResult;
            try
            {
                lstCardsResult = new DashBoardOrder();
                _dbContext.ChangeTracker.LazyLoadingEnabled = false;

                var OrderItems = (from a in _dbContext.OrderItems
                                  where SellerIds.Contains(a.SellerId) &&
                                    ((a.CreatedDate.Value.Date >= model.FromDate.Value.Date
                                   && a.CreatedDate.Value.Date <= model.ToDate.Value.Date))
                                  select a).OrderByDescending(x => x.CreatedDate).ToList();
                _dbContext.ChangeTracker.LazyLoadingEnabled = true;
                CountCards Cards = new CountCards
                {
                    CardName = "Total Orders",
                    CardValue = OrderItems.Any() ? OrderItems.Count().ToString() : "0",
                    StatusId = default(long?),
                    Class = "fa fa-tasks fa-2x "
                };

                lstCardsResult.ListCountCards.Add(Cards);

                Cards = new CountCards
                {
                    CardName = " Processed Orders",
                    CardValue = OrderItems.Any() ? OrderItems.Where(x => x.ItemStatusId == (int)EnumReferenceRecords.OrderItemsRead).Count().ToString() : "0",
                    StatusId = (int)EnumReferenceRecords.OrderItemsRead,
                    Class = "fa fa-check fa-2x"
                };
                lstCardsResult.ListCountCards.Add(Cards);

                Cards = new CountCards
                {
                    CardName = " Acknowledged Orders",
                    CardValue = OrderItems.Any() ? OrderItems.Where(x => x.ItemStatusId == (int)EnumReferenceRecords.OrderAcknowledgeSuccessful).Count().ToString() : "0",
                    StatusId = (int)EnumReferenceRecords.OrderAcknowledgeSuccessful,
                    Class = "fa fa-check fa-2x"
                };
                lstCardsResult.ListCountCards.Add(Cards);

                Cards = new CountCards
                {
                    CardName = " Fulfilled Orders",
                    CardValue = OrderItems.Any() ? OrderItems.Where(x => x.ItemStatusId == (int)EnumReferenceRecords.OrderFulfillmentSuccessful).Count().ToString() : "0",
                    StatusId = (int)EnumReferenceRecords.OrderFulfillmentSuccessful,
                    Class = "fa fa-check fa-2x"
                };
                lstCardsResult.ListCountCards.Add(Cards);

                Cards = new CountCards
                {
                    CardName = "Failed Orders",
                    CardValue = OrderItems.Where(x => x.ItemStatusId == (int)EnumReferenceRecords.PickupRequestFailed).Count().ToString(),
                    StatusId = (int)EnumReferenceRecords.PickupRequestFailed,
                    Class = "fa fa-exclamation-triangle fa-2x"
                };
                lstCardsResult.ListCountCards.Add(Cards);

                Cards = new CountCards
                {
                    CardName = "Pending Orders",
                    CardValue = OrderItems.Where(x => x.ItemStatusId == (int)EnumReferenceRecords.OrderItemsCreated).Count().ToString(),
                    StatusId = (int)EnumReferenceRecords.OrderItemsCreated,
                    Class = "fa  fa-clock-o fa-2x"
                };

                lstCardsResult.ListCountCards.Add(Cards);
                Cards = new CountCards
                {
                    CardName = "Invalid SKU Orders",
                    CardValue = OrderItems.Where(x => x.ItemStatusId == (int)EnumReferenceRecords.InvalidSKU).Count().ToString(),
                    StatusId = (int)EnumReferenceRecords.InvalidSKU,
                    Class = "fa  fa-exclamation-circle fa-2x"
                };

                lstCardsResult.ListCountCards.Add(Cards);

                // var orderVMGridmodel = OrderItems.ToDestinationList<OrderItem, OrderItemDetail>();

                //var orderVMGridmodel = OrderItems.ToDestinationList<OrderItem, OrderItemDetail>();
                //lstCardsResult.OrderItemDetail = orderVMGridmodel;
                return lstCardsResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message);
                throw ex;
            }
        }

        public OrderStatusReport GetOrderReport(OrderStatusReport StatusReport)
        {
            var Status = StatusReport.StatusItems.IsNotNull() ? StatusReport.StatusItems.ToLongArrayComma() : null;
            var SellerId = StatusReport.SellerId.IsNotNull() ? StatusReport.SellerId.ToLongArrayComma() : null;
            try
            {
                var OrderItems = (from a in _dbContext.OrderItems
                                  where ((Status != null) ? Status.Contains(a.ItemStatusId) : true) && ((SellerId != null) ? SellerId.Contains(a.SellerId) : true)
                                   && ((a.CreatedDate.Value.Date >= StatusReport.FromDate
                                   && a.CreatedDate.Value.Date <= StatusReport.ToDate))

                                  select new OrderItemStatusDetail
                                  {
                                      Id = a.Id,
                                      AmazonOrderId = a.Orders.AmazonOrderId,
                                      OrderId = a.OrderItemId,
                                      DropOffPincode = a.Orders.DefaultShipFromLocationAddress.PostalCode.Decrypt(),
                                      DropOffCity = a.Orders.DefaultShipFromLocationAddress.City.Decrypt(),
                                      PickupPincode = a.Warehouse.PostalCode,
                                      PickupCity = a.Warehouse.City,
                                      PickupAddress = (a.Warehouse.AddressLine1 + "" + a.Warehouse.AddressLine2 + " " + a.Warehouse.AddressLine3 + " " + a.Warehouse.PostalCode + " " + a.Warehouse.Name + " " + a.Warehouse.Phone),
                                      Reason = a.PickupFailureReason,
                                      ReferenceNumber = (a.ItemStatusId == ((int)EnumReferenceRecords.InvalidSKU)
                                      ? String.Format("{0}/{1}", "NA", a.SellerSKU) : string.Format("{0}/{1}", a.Warehouse.WarehouseLocationCode, a.eZTrackReferenceNumber)),
                                      Status = a.ItemStatus.Displaytext,
                                      Title = a.Title,
                                      OrderDate = a.Orders.PurchaseDate.StringToNullableDateTime().Value,
                                      ConsignmentNo = a.ConsignmentNo,
                                      sellerId = a.SellerId
                                  }).ToList();

                if (!OrderItems.Any())
                {
                    return StatusReport;
                }

                StatusReport.StatusReport = OrderItems;
                return StatusReport;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message);
                throw ex;
            }
            finally
            {
            }
        }

        public async Task<List<string>> SearchReferenceRecord(string referenceRecord, int limit)
        {
            var referencerecords = await _dbContext.ReferenceRecords
                .WhereIf(!string.IsNullOrEmpty(referenceRecord), x => x.Name.Contains(referenceRecord))
                .TakeIf(x => x.Id, limit > 0, limit)
                .Select(x => x.Name).ToListAsync();

            return referencerecords;
        }

        public async Task<OrderStatusReport> BuildReportViewModel(string ClientID, string SellerId, OrderStatusReport Report = null)
        {
            if (Report == null)
            {
                Report = new OrderStatusReport();
                Report.FromDate = DateTime.Now;
                Report.ToDate = DateTime.Now;
            }
            List<string> status = new List<string>() {nameof(EnumReferenceRecords.OrderItemsCreated) , nameof(EnumReferenceRecords.OrderItemsRead),
                nameof(EnumReferenceRecords.InvalidSKU),nameof(EnumReferenceRecords.PickupRequestFailed)
            };
            Report.Status = await PopulateReferenceRecordsAsync(Report, status);

            Report.Sellers = await PopulateSellersAsync(Report, SellerId, ClientID);
            return await Task.FromResult(Report);
        }

        private async Task<List<SelectItem>> PopulateReferenceRecordsAsync(OrderStatusReport client, List<string> Ids)
        {
            var referencerecords = await _dbContext.ReferenceRecords.Where(y => Ids.Contains(y.Name.ToString())).Select(x => new SelectItem { Id = x.Id, Text = x.Displaytext }).ToListAsync();

            //referencerecords.Insert(0, new SelectItem { Id = -1, Text = "All" });
            return referencerecords;
        }

        private async Task<List<SelectItem>> PopulateSellersAsync(OrderStatusReport client, string sellerIds, string ClientID)
        {
            var referencerecords = await _dbContext.Sellers.Where(x => x.IsStage == false && x.ClientId == ClientID).Where(x => !string.IsNullOrEmpty(sellerIds) == true ? x.SellerName.Trim() == sellerIds.Trim() : true).Select(x => new SelectItem { Id = x.Id, Text = x.SellerName }).ToListAsync();

            //referencerecords.Insert(0, new SelectItem { Id = -1, Text = "All" });
            return referencerecords;
        }
    }
}