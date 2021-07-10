using Amazon.APIEngine.Api;
using Amazon.APIEngine.Models;
using Amazon.Runtime;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Amazon.SellingPartnerAPIAA;
using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.DataContext;
using AmazonOrderAPI.DataContext.Entities;
using AmazonOrderExtentions.CoreExtentions;
using eZTrackerOrderClient;
using LoggerService;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Amazon.APIEngine.Models.Order;
using DTO = AmazonOrderAPI.DataContext.Entities;
using Order = AmazonOrderAPI.DataContext.Entities.Order;

namespace AmazonOrderAPI.Business.OrderMonitor
{
    public class SPOrders : BaseCommonClass
    {
        public const string AccessTokenHeaderName = "x-amz-access-token";
        private IOrdersV0Api ordersV0Api;
        private OrderContext _dbContext;
        private NLog.Logger _amazonOrderLOG;
        public DateTime DateTimeBegin = new DateTime(2000, 1, 1);
        public SPOrders(IOrdersV0Api _ordersV0Api, OrderContext dbContext, ILoggerManager logger, IOptions<AppSetting> _Setting) :
            base(logger, _Setting)
        {
            ordersV0Api = _ordersV0Api;
            _dbContext = dbContext;
        }
        public async Task GetOrdersAsync()
        {
            var Sellerlist = _dbContext.Sellers.Where(x => x.IsActive == true && x.IsStage == false).ToList();
            try
            {
                foreach (var Seller in Sellerlist)
                {
                    GetOrdersResponse getOrdersResponse = null;
                    DateTime checkDate = DateTime.UtcNow.AddDays(-5);
                    GenerateAuthenticationHeaders(Seller);
                    var ezTrackerAppSetting = setting.Value.ToDestination<AppSetting, Ez_AppSetting>();
                    DateTime sellerCreatedDate = Seller.CreatedDate.Value;
                    DateTime updatedAfterDefault = sellerCreatedDate.Date.AddDays(ezTrackerAppSetting.GlobalConstants.SellerOrderStartDateBefore);
                    DateTime updatedBeforeDefault = DateTime.Now.AddMinutes(-5);
                    var query = from o in _dbContext.Orders where o.SellerId == Convert.ToInt32(Seller.Id) orderby o.LastUpdateDate descending select o;
                    if (query.Any())
                    {
                        DateTime? tempDate = query.First().LastUpdateDate.StringToNullableDateTime().Value;
                        DateTime lastUpdate = DateTimeBegin;
                        if (tempDate != null)
                        {
                            lastUpdate = (DateTime)tempDate.Value.AddSeconds(1);
                        }
                        getOrdersResponse = await ordersV0Api.GetOrdersAsync((new List<string>() { "ATVPDKIKX0DER" }), "TEST_CASE_200");

                        //Task.Run(async () =>
                        //{
                        //  getOrdersResponse = await ordersV0Api.GetOrdersAsync((new List<string>() { Seller.MarketplaceId }), lastUpdate);
                        //}).GetAwaiter().GetResult();
                        //Task.Run(async () =>
                        //{
                        //    getOrderItemsResponse = await ordersV0Api.GetOrderItemsAsync("TEST_CASE_200", "");
                        //}).GetAwaiter().GetResult();

                    }
                    else
                    {
                        //   await ordersV0Api.GetOrdersAsync((new List<string>() { Seller.MarketplaceId, "A21TJRUUN4KGV" }), updatedAfterDefault.AddSeconds(1).ToString(), updatedBeforeDefault.ToString());
                        getOrdersResponse = await ordersV0Api.GetOrdersAsync((new List<string>() { "ATVPDKIKX0DER" }), "TEST_CASE_200");

                    }
                    if (getOrdersResponse.Errors != null)
                    {
                        LogOrderResposneException(getOrdersResponse.ToString(), true, new Exception(getOrdersResponse.Errors.ToString()), "");
                        throw new Exception(getOrdersResponse.Errors.ToString());
                    }

                    try
                    {
                        LogOrderResposneException(getOrdersResponse.ToString(), false, null, "");
                        List<DTO.Order> orders = new List<DTO.Order>();
                        foreach (var x in getOrdersResponse.Payload.Orders)
                        {
                            DTO.Order order = new DTO.Order(x.PaymentMethodDetails.ToList());
                            order = x.ToDestination<Amazon.APIEngine.Models.Order, Order>();
                            List<DTO.PaymentExecutionDetailItem> paymentExecutionDetailItems = new List<DTO.PaymentExecutionDetailItem>();
                            order.SellerId = Seller.Id;
                           

                            order.DefaultShipFromLocationAddress = new DTO.Address("");
                            if (x.DefaultShipFromLocationAddress.IsNotNull())
                            {
                                order.DefaultShipFromLocationAddress = new DTO.Address(
                                x.DefaultShipFromLocationAddress.Name,
                                 x.DefaultShipFromLocationAddress.AddressLine1,
                                x.DefaultShipFromLocationAddress.AddressLine2,
                                x.DefaultShipFromLocationAddress.AddressLine3
                                , x.DefaultShipFromLocationAddress.City, x.DefaultShipFromLocationAddress.County, x.DefaultShipFromLocationAddress.District, x.DefaultShipFromLocationAddress.StateOrRegion, x.DefaultShipFromLocationAddress.Municipality,
                                x.DefaultShipFromLocationAddress.PostalCode, x.DefaultShipFromLocationAddress.CountryCode, x.DefaultShipFromLocationAddress.Phone,
                                x.DefaultShipFromLocationAddress.AddressType.Value.ToString()
                                 );
                            }
                            try
                            {
                                order.FulfillmentInstruction = new DTO.FulfillmentInstruction
                                {
                                    AmazonOrderId = x.AmazonOrderId,
                                    FulfillmentSupplySourceId = x.FulfillmentInstruction.IsNotNull() ? x.FulfillmentInstruction.FulfillmentSupplySourceId : ""
                                };
                                order.OrderTotal = new DTO.Money { AmazonOrderId = x.AmazonOrderId, Amount = x.OrderTotal.Amount, CurrencyCode = x.OrderTotal.CurrencyCode };
                                order.PaymentExecutionDetail = x.PaymentExecutionDetail.IsNotNull() ?
                                x.PaymentExecutionDetail.Select(z => new DTO.PaymentExecutionDetailItem { Payment = new DTO.Money { AmazonOrderId = x.AmazonOrderId, Amount = z.Payment.Amount, CurrencyCode = z.Payment.CurrencyCode }, PaymentMethod = z.PaymentMethod }).ToList() : null;

                            }
                            catch (Exception ex)
                            {
                                LogOrderResposneException(getOrdersResponse.ToString(), true, ex, "");
                            }
                            orders.Add(order);
                        }
                        _dbContext.Orders.AddRange(orders);
                        _dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        LogOrderResposneException(getOrdersResponse.ToString(), true, ex, "");
                        throw ex;
                    }
                    Task.WaitAll();
                    Thread.Sleep(30000);
                }
            }
            catch (Exception ex)
            {
                LogOrderResposneException(ex.InnerException.Message, true, ex, "");
                throw ex;
            }


        }

        private void GenerateAuthenticationHeaders(Seller Seller)
        {
            AssumeRoleResponse assumeRoleResponse = null;
            Task.Run(async () =>
            {
                assumeRoleResponse = await GetAssumeRoleTokenDetail(Seller);
            }).GetAwaiter().GetResult();

            ordersV0Api.Configuration.AccessToken = GenerateRequestToken.GetAccessTokenForSeller(Seller);
            ordersV0Api.Configuration.AddDefaultHeader(AccessTokenHeaderName, ordersV0Api.Configuration.AccessToken);
            ordersV0Api.Configuration.AddDefaultHeader("X-Amz-Security-Token", assumeRoleResponse.Credentials.SessionToken);
            ordersV0Api.Configuration.BasePath = Seller.SellerAPIEndPoint;
            ordersV0Api.Configuration.AWSAuthenticationCredentials = new AWSAuthenticationCredentials()
            {
                AccessKeyId = assumeRoleResponse.Credentials.AccessKeyId,
                SecretKey = assumeRoleResponse.Credentials.SecretAccessKey,
                Region = Seller.Region
            };
        }

        private static async Task<AssumeRoleResponse> GetAssumeRoleTokenDetail(Seller seller)
        {
            // AWS IAM user data, NOT seller central dev data
            try
            {
                var accessKey = seller.AWS_AccessKey;
                var secretKey = seller.AWS_Secretkey;

                var credentials = new BasicAWSCredentials(accessKey, secretKey);

                var client = new AmazonSecurityTokenServiceClient(credentials);

                var assumeRoleRequest = new AssumeRoleRequest()
                {
                    DurationSeconds = 3600,
                    RoleArn = seller.AWS_RoleARN,
                    RoleSessionName = DateTime.Now.Ticks.ToString()
                };
                var assumeRoleResponse = await client.AssumeRoleAsync(assumeRoleRequest);
                return assumeRoleResponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task GetOrderItemsAsync()
        {
            string nextTokenFromRequest = null;

            try
            {


                var Sellerlist = _dbContext.Sellers.Where(x => x.IsActive == true && x.IsStage == false).ToList();
                foreach (var Seller in Sellerlist)
                {
                    GenerateAuthenticationHeaders(Seller);

                    DateTime updatedBeforeDefault = DateTime.Now.AddMinutes(-5);

                    var query = _dbContext.Orders.OrderByDescending(x => x.LastUpdateDate).Where(x => x.ListOrderItemStatusId == (int)OrderStatusEnum.Unshipped && x.SellerId == Convert.ToInt32(Seller.SellerId) && x.Seller.IsActive == true).ToList();// && orderStatus.Contains(x.OrderStatus)).ToList();
                    var Warehousedata = _dbContext.Warehouses.Where(x => x.Seller.SellerId == SellerId).ToList();
                    if (query.Any())
                    {
                        foreach (var items in query)
                        {
                            List<OrderItemList> OrderItemList = new List<OrderItemList>();
                            // DateTime? tempDate = items.LastUpdateDate;
                            DateTime lastUpdate = DateTimeBegin;  // silly assignment so we cover the else case.
                                                                  //if (tempDate != null)
                                                                  //{
                                                                  //    lastUpdate = (DateTime)tempDate;
                                                                  //}

                            _logger.LogInfo("Last update date is : " + lastUpdate);

                            do
                            {
                                try
                                {

                                    var orderItemsResponse = await ordersV0Api.GetOrderItemsAsync("TEST_CASE_200", nextTokenFromRequest);
                                    if (orderItemsResponse.IsNotNull())
                                    {
                                        OrderItemList.Add(orderItemsResponse.Payload.OrderItems);
                                        nextTokenFromRequest = orderItemsResponse.Payload.NextToken;
                                    }


                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            while (nextTokenFromRequest != null);


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message);
            }


        }

        private void LogOrderResposneException(string Response, bool IsException, Exception ex, string AmazonOrderId)
        {
            OrderResponse response;
            OrderException OrderException;
            try
            {
                if (!IsException)
                {
                    response = new OrderResponse();
                    response.Response = Response.Encrypt();

                    _dbContext.OrderResponse.Add(response);
                }
                else
                {
                    OrderException = new OrderException();
                    OrderException.Response = Response.Encrypt();
                    OrderException.Exception = ex.GetserializeJsonString().ToString();
                    OrderException.AmazonOrderId = AmazonOrderId;

                    _dbContext.OrderException.Add(OrderException);
                }
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message);
            }
            finally
            {
                response = null;
                OrderException = null;
            }
        }

        private void LogOrderItemsResponseOrException(string responsevalue, bool IsException, Exception ex, string OrderItemId)
        {
            OrderItemResponse response;
            OrderItemException OrderException;
            try
            {
                if (!IsException)
                {
                    response = new OrderItemResponse
                    {
                        Response = responsevalue.Encrypt()
                    };

                    _dbContext.OrderItemResponse.Add(response);
                }
                else
                {
                    OrderException = new OrderItemException
                    {
                        Response = responsevalue.Encrypt(),
                        Exception = ex.GetserializeJsonString().ToString(),
                        OrderItemId = OrderItemId
                    };

                    _dbContext.OrderItemException.Add(OrderException);
                }
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message + " responsevalue = " + responsevalue + " IsException = " + IsException + " OrderItemId = " + OrderItemId);
            }
            finally
            {
                response = null;
                OrderException = null;
            }
        }

    }
}


#region comment
//order.AmazonOrderId = x.AmazonOrderId;
//order.PurchaseDate = x.PurchaseDate;
//order.LastUpdateDate = x.LastUpdateDate;
//order.OrderStatus = x.OrderStatus;
//order.SellerOrderId = x.SellerOrderId;
//order.FulfillmentChannel = x.FulfillmentChannel;
//order.SalesChannel = x.SalesChannel;

//order.ShipServiceLevel = x.ShipServiceLevel;
//order.NumberOfItemsShipped = x.NumberOfItemsShipped;
//order.NumberOfItemsUnshipped = x.NumberOfItemsUnshipped;
//order.PaymentMethod = x.PaymentMethod;
//order.MarketplaceId = x.MarketplaceId;
//order.ShipmentServiceLevelCategory = x.ShipmentServiceLevelCategory;
//order.EasyShipShipmentStatus = x.EasyShipShipmentStatus;
//order.CbaDisplayableShippingLabel = x.CbaDisplayableShippingLabel;
//order.OrderType = x.OrderType;
//order.EarliestShipDate = x.EarliestShipDate;
//order.LatestShipDate = x.LatestShipDate;
//order.EarliestDeliveryDate = x.EarliestDeliveryDate;
//order.LatestDeliveryDate = x.LatestDeliveryDate;
//order.IsBusinessOrder = x.IsBusinessOrder;
//order.IsPrime = x.IsPrime;
//order.IsPremiumOrder = x.IsPremiumOrder;
//order.IsGlobalExpressEnabled = x.IsGlobalExpressEnabled;
//order.ReplacedOrderId = x.ReplacedOrderId;
//order.IsReplacementOrder = x.IsReplacementOrder;
//order.PromiseResponseDueDate = x.PromiseResponseDueDate;
//order.IsEstimatedShipDateSet = x.IsEstimatedShipDateSet;
//order.IsSoldByAB = x.IsSoldByAB;
#endregion