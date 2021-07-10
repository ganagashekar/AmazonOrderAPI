using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Common.EnumOps;
using AmazonOrderAPI.Business.Model;
using AmazonOrderAPI.Business.Model.Reports;
using AmazonOrderAPI.Business.Repositories.IServices;
using AmazonOrderAPI.Business.RequestTypes;
using AmazonOrderAPI.Business.ResponseTypes;
using AmazonOrderAPI.Business.ResponseTypes.Common;
using AmazonOrderAPI.DataContext;
using AmazonOrderAPI.DataContext.Entities;
using AmazonOrderExtentions.CoreExtentions;
using eZTrackerOrderClient;
using eZTrackerOrderClient.RequestModel;
using eZTrackerOrderClient.ResponseModel;
using eZTrackerOrderClient.Services;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Business.Repositories.ServicesImp
{
    public class OrderFetchServices : BaseCommonClass, IOrderFetchServices
    {
        private readonly OrderContext _dbContext;

        private NLog.Logger _Logger;

        public OrderFetchServices(OrderContext dbContext, ILoggerManager logger, IOptions<AppSetting> setting
            ) : base(logger, setting)
        {
            _dbContext = dbContext;
            _Logger = NLog.LogManager.GetLogger("eZTrackerLogger");
        }

        public async Task<OrderItemStatusDetail> GetOrderById(long OrderId)
        {
            try
            {
                var OrderItemsDTO = await _dbContext.OrderItems.Where(x => x.Id == OrderId).ToListAsync();
                var SellerWareHouserList = await _dbContext.Warehouses.Where(x => x.Seller.Id == OrderItemsDTO.FirstOrDefault().SellerId).ToListAsync();

                var OrderItems = (from a in OrderItemsDTO

                                  select new OrderItemStatusDetail
                                  {
                                      OrderId = a.OrderItemId,
                                      DropOffPincode = a.Orders.DefaultShipFromLocationAddress.PostalCode.Decrypt(),
                                      DropOffCity = a.Orders.DefaultShipFromLocationAddress.City.Decrypt(),
                                      PickupPincode = a.Warehouse.IsNotNull() ? a.Warehouse.PostalCode : string.Empty,
                                      PickupCity = a.Warehouse.IsNotNull() ? a.Warehouse.City : string.Empty,
                                      PickupAddress = a.Warehouse.IsNotNull() ? (a.Warehouse.AddressLine1 + "" + a.Warehouse.AddressLine2 + " " + a.Warehouse.AddressLine3 + " " + a.Warehouse.PostalCode + " " + a.Warehouse.Name + " " + a.Warehouse.Phone) : string.Empty,
                                      Reason = a.PickupFailureReason,
                                      DisablSaving = ((a.ItemStatusId == ((int)EnumReferenceRecords.InvalidSKU) || a.ItemStatusId == ((int)EnumReferenceRecords.PickupRequestFailed)) ? false:true), 
                                      ReferenceNumber = (a.ItemStatusId == ((int)EnumReferenceRecords.InvalidSKU)
                                      ? String.Format("{0}/{1}", a.Orders.AmazonOrderId, a.SellerSKU) : a.eZTrackReferenceNumber),
                                      Status = a.ItemStatus.Displaytext,
                                      Title = a.Title,
                                      DropAddress = a.Orders.DefaultShipFromLocationAddress.AddressLine1.Decrypt() + "  "
                                      + a.Orders.DefaultShipFromLocationAddress.AddressLine2.Decrypt() + " " +
                                       a.Orders.DefaultShipFromLocationAddress.AddressLine3.Decrypt() + " " + a.Orders.DefaultShipFromLocationAddress.City.Decrypt()
                                       + " " + a.Orders.DefaultShipFromLocationAddress.PostalCode.Decrypt(),
                                      Id = a.Id,
                                      DropMobileNumber = a.Orders.DefaultShipFromLocationAddress.Phone.Decrypt(),
                                      DropUserName = a.Orders.DefaultShipFromLocationAddress.Name.Decrypt(),
                                      PickupMobileNumber = a.Warehouse.IsNotNull() ? a.Warehouse.Phone : string.Empty,
                                      PickupUserName = a.Warehouse.IsNotNull() ? a.Warehouse.Name : string.Empty,
                                      SellerSKU = a.SellerSKU,
                                      OrderDate = a.Orders.PurchaseDate.StringToNullableDateTime().Value,
                                      IsPrime = a.Orders.IsPrime ?? false,
                                      LastUpdatedDate = a.Orders.LastUpdateDate.StringToNullableDateTime().Value,
                                      LatestShipDate = a.Orders.LatestShipDate.StringToNullableDateTime().Value,
                                      WareHouse = PopulateWareHouseAsync(a.WarehouseId, SellerWareHouserList),
                                      WarehouseId = a.WarehouseId ?? 0,
                                      ASIN = a.ASIN,
                                      ConditionId = a.ConditionId,
                                      ConditionSubTypeId = a.ConditionSubtypeId,
                                      IsGift = a.IsGift ?? false,
                                      OrderItemId = a.OrderItemId,
                                      IsSerialNumberRequired = a.SerialNumberRequired ?? false,
                                      QuantityOrdered = a.QuantityOrdered ?? 0,
                                      QuantityShipped = a.QuantityShipped ?? 0,
                                      ConsignmentNo = a.ConsignmentNo,
                                      sellerId = a.SellerId
                                  }).ToList();

                return await Task.FromResult(OrderItems.FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
        }

        private List<SelectItem> PopulateWareHouseAsync(long? Id, List<Warehouse> warehouses)
        {
            var lstofwareHouse = warehouses.Where(x => Id != null ? x.Id == Id.Value : true).Select(x => new SelectItem { Id = x.Id, Text = x.WarehouseLocationCode }).ToList();

            if (Id.IsNull())
            {
                lstofwareHouse.Insert(0, new SelectItem { Id = 0, Text = "Select" });
            }

            return (lstofwareHouse);
        }

        public async Task<Response> RetryOrders(OrderStatusReport model)
        {
            var ezTrackerAppSetting = setting.Value.ToDestination<AppSetting, Ez_AppSetting>();
            PickupBookingServices pickupBookingServices = new PickupBookingServices(ezTrackerAppSetting);
            ListPickupRequestModel lstpickupRequestModel = new ListPickupRequestModel();
            List<OrdersItemInfo> lstordersItemInfo = new List<OrdersItemInfo>();
            try
            {
                string Message = string.Empty;
                var SellerId = model.SellerId.IsNotNull() ? model.SellerId.ToLongArrayComma() : null;
                var OrderItemsConditions = (new string[] { nameof(EnumReferenceRecords.PickupRequestFailed) });
                var OrderItems = _dbContext.OrderItems.Where(x => SellerId.Contains(x.SellerId)).Where(x => x.CreatedDate.Value.Date >= model.FromDate.Value.Date && x.CreatedDate.Value.Date <= model.ToDate.Value.Date && OrderItemsConditions.Contains(x.ItemStatus.Name)).ToList();
                var result = OrderItems.ToDestinationList<OrderItem, OrderItemVM>();
                lstordersItemInfo = result.ToDestinationList<OrderItemVM, OrdersItemInfo>().ToList();
                var pickupRequests = lstordersItemInfo.ToDestinationList<OrdersItemInfo, PickupRequestModel>().ToList();

                foreach (var items in pickupRequests)
                {
                    var pickupresposne = (await pickupBookingServices.BulkOrderBooking(items));
                    if (pickupresposne.IsNotNull())
                    {
                        _Logger.Info("result");

                        _Logger.Info(pickupresposne.GetserializeJsonString().ToString());
                        var Item = OrderItems.First(d => d.Id == pickupresposne.Id);
                        Item.eZTrackReferenceNumber = pickupresposne.PickupRequestNumber;
                        Item.ItemStatusId = pickupresposne.IsError == "false" ? (int)EnumReferenceRecords.OrderItemsRead : (int)EnumReferenceRecords.PickupRequestFailed;
                        Item.PickupFailureReason = pickupresposne.IsError == "false" ? string.Empty : pickupresposne.ErrorMessage;
                        Item.ConsignmentNo = pickupresposne.ConsignmentNo;
                        Item.Orders.LastUpdateDate = DateTime.Now.ToString();
                        _dbContext.SaveChanges();
                    }
                }

                return ResponseServices.CreateResponse("Success", "", "", Codes.SuccessCode);
            }
            catch (System.Exception ex)
            {
                _Logger.Error(ex);
                return ResponseServices.CreateResponse("Error", "", ex, Codes.SuccessCode);
            }
            finally
            {
                pickupBookingServices = null;
                lstpickupRequestModel = null;
                lstordersItemInfo = null;
            }
        }

        public async Task<Response> GetOrders(OrderRequest OrderRequest)
        {
            var ezTrackerAppSetting = setting.Value.ToDestination<AppSetting, Ez_AppSetting>();
            PickupBookingServices pickupBookingServices = new PickupBookingServices(ezTrackerAppSetting);
            ListPickupRequestModel lstpickupRequestModel = new ListPickupRequestModel();
            List<OrdersItemInfo> lstordersItemInfo = new List<OrdersItemInfo>();

            try
            {
                string Message = string.Empty;

                var OrderItemsConditions = (new string[] { nameof(EnumReferenceRecords.OrderItemsCreated), nameof(EnumReferenceRecords.PickupRequestFailed) });
                // var Sellerlist = _dbContext.Sellers.Where(x => x.IsActive == true && x.Id == ).ToList();
                var OrderItems = _dbContext.OrderItems.Where(x => x.CreatedDate.Value.Date >= DateTime.Now.Date.AddDays(ezTrackerAppSetting.GlobalConstants.RetryDaysBefore) && OrderItemsConditions.Contains(x.ItemStatus.Name) && x.Seller.IsAutoManual == false ).ToList();
                var result = OrderItems.ToDestinationList<OrderItem, OrderItemVM>();
                lstordersItemInfo = result.ToDestinationList<OrderItemVM, OrdersItemInfo>().ToList();
                var pickupRequests = lstordersItemInfo.ToDestinationList<OrdersItemInfo, PickupRequestModel>().ToList();

                foreach (var items in pickupRequests)
                {
                    var pickupresposne = (await pickupBookingServices.BulkOrderBooking(items));
                    if (pickupresposne.IsNotNull())
                    {
                        _Logger.Info("result");

                        _Logger.Info(pickupresposne.GetserializeJsonString().ToString());
                        var Item = OrderItems.First(d => d.Id == pickupresposne.Id);
                        Item.eZTrackReferenceNumber = pickupresposne.PickupRequestNumber;
                        Item.ItemStatusId = pickupresposne.IsError == "false" ? (int)EnumReferenceRecords.OrderItemsRead : (int)EnumReferenceRecords.PickupRequestFailed;
                        Item.PickupFailureReason = pickupresposne.IsError == "false" ? string.Empty : pickupresposne.ErrorMessage;
                        Item.ConsignmentNo = pickupresposne.ConsignmentNo;
                        Item.Orders.LastUpdateDate = DateTime.Now.ToString();
                        _dbContext.SaveChanges();
                    }
                }

                return ResponseServices.CreateResponse("Success", "", "", Codes.SuccessCode);
            }
            catch (System.Exception ex)
            {
                _Logger.Error(ex);
                return ResponseServices.CreateResponse("Error", "", ex, Codes.SuccessCode);
            }
            finally
            {
                pickupBookingServices = null;
                lstpickupRequestModel = null;
                lstordersItemInfo = null;
            }

            #region Commented

            //OrderItems.ForEach(x => x.OrderItemStatus = (int)OrderItemStatusEnum.OrderItemsRead);
            //_dbContext.SaveChanges();
            //var OrderItemsquery = from data in OrderItems
            //                               join refCode in eZServicePickupOrderResult on data.Id equals refCode.Id into joined
            //                          from subCode in joined.DefaultIfEmpty()
            //                          select new OrderItem
            //                          {
            //                              Id = subCode?.Id ?? data.Id,
            //                              IsSentEzTrack =subCode.IsError=="false" ? true:false,
            //                              eZTrackReferenceNumber = subCode.PickupRequestNumber
            //                          };

            //_dbContext.SaveChanges();
            //return ResponseServices.CreateResponse(Message, string.Empty, new ListOrderTransaction
            //{
            //    OrdersItems = result.ToDestinationList<OrderItemVM, OrdersItemInfo>().ToList()
            //}, Codes.SuccessCode);

            #endregion Commented
        }

        public async Task<Response> RetryOrder(long orderId)
        {
            var OrderItemsConditions = (new string[] { nameof(EnumReferenceRecords.OrderItemsCreated), nameof(EnumReferenceRecords.PickupRequestFailed) });
            var eZServicePickupOrderResult = await sendPickupRequest(orderId,OrderItemsConditions);
            return ResponseServices.CreateResponse("Success", "", eZServicePickupOrderResult, Codes.SuccessCode);
        }

        //public async Task<Response> AcknowledgeOrder(long orderId)
        //{
        //    var OrderItemsConditions = (new string[] { nameof(EnumReferenceRecords.OrderItemsRead) });
        //    var eZServicePickupOrderResult = await sendAcknowledgeOrder(orderId, OrderItemsConditions);
        //    return ResponseServices.CreateResponse("Success", "", eZServicePickupOrderResult, Codes.SuccessCode);
        //}

        //public async Task<Response> FulfillOrder(long orderId)
        //{
        //    var OrderItemsConditions = (new string[] { nameof(EnumReferenceRecords.OrderAcknowledgeSuccessful)});
        //    var eZServicePickupOrderResult = await sendFulfillOrder(orderId, OrderItemsConditions);
        //    return ResponseServices.CreateResponse("Success", "", eZServicePickupOrderResult, Codes.SuccessCode);
        //}

        public async Task<Response> PickupOrder(long orderId,  long WarehouseId)
        {
            OrderItemStatusDetail orderItemStatusDetail = new OrderItemStatusDetail();
            orderItemStatusDetail.Id = orderId;
            orderItemStatusDetail.WarehouseId = WarehouseId;
            var SaveOrUpdateOrderDetailsResult = await SaveOrUpdateOrderDetails(orderItemStatusDetail);

            if(SaveOrUpdateOrderDetailsResult)
            {
                var OrderItemsConditions = (new string[] { nameof(EnumReferenceRecords.OrderItemsCreated) });
                var eZServicePickupOrderResult = await sendPickupRequest(orderId, OrderItemsConditions);
                return ResponseServices.CreateResponse("Success", "", eZServicePickupOrderResult, Codes.SuccessCode);
            }
            else
            {
                return ResponseServices.CreateResponse("Warehouse Updation Failed", "", SaveOrUpdateOrderDetailsResult, Codes.ErrorCode);
            }
        }

        public async Task<PickupBookingResponse> sendPickupRequest(long orderId, string[] OrderItemsConditions)
        {
            var ezTrackerAppSetting = setting.Value.ToDestination<AppSetting, Ez_AppSetting>();
            PickupBookingServices pickupBookingServices = new PickupBookingServices(ezTrackerAppSetting);
            ListPickupRequestModel lstpickupRequestModel = new ListPickupRequestModel();

            try
            {
                string Message = string.Empty;

                var OrderItems = _dbContext.OrderItems.First(x => x.Id == orderId);

                var result = OrderItems.ToDestination<OrderItem, OrderItemVM>();
                var lstordersItemInfo = result.ToDestination<OrderItemVM, OrdersItemInfo>();
                var LstPickupRequestModel = lstordersItemInfo.ToDestination<OrdersItemInfo, PickupRequestModel>();
                var eZServicePickupOrderResult = (await pickupBookingServices.BulkOrderBooking(LstPickupRequestModel));
                if (eZServicePickupOrderResult.IsNotNull())
                {
                    OrderItems.eZTrackReferenceNumber = eZServicePickupOrderResult.PickupRequestNumber;
                    OrderItems.ItemStatusId = eZServicePickupOrderResult.IsError == "false" ? (int)EnumReferenceRecords.OrderItemsRead : (int)EnumReferenceRecords.PickupRequestFailed;
                    OrderItems.PickupFailureReason = eZServicePickupOrderResult.IsError == "false" ? string.Empty : eZServicePickupOrderResult.ErrorMessage;
                    OrderItems.ConsignmentNo = eZServicePickupOrderResult.ConsignmentNo;
                    OrderItems.Orders.LastUpdateDate = DateTime.Now.ToString();
                }

                _dbContext.SaveChanges();

                return eZServicePickupOrderResult;
            }
            catch (System.Exception ex)
            {
                _Logger.Error(ex);
                return null;
            }
            finally
            {
                pickupBookingServices = null;
                lstpickupRequestModel = null;
            }
        }

        public async Task<bool> SaveOrUpdateOrderDetails(OrderItemStatusDetail _orderItem)
        {
            try
            {
                var OrderItems = await _dbContext.OrderItems.FirstOrDefaultAsync(x => x.Id == _orderItem.Id);
                if (OrderItems.IsNotNull() && OrderItems.ItemStatusId == (int)(EnumReferenceRecords.InvalidSKU))
                {
                    OrderItems.WarehouseId = _orderItem.WarehouseId;
                    OrderItems.ItemStatusId = (int)(EnumReferenceRecords.OrderItemsCreated);
                    OrderItems.Orders.LastUpdateDate = DateTime.Now.ToString();
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message);
                _Logger.Error(ex);
                return false;
            }
        }
    }
}