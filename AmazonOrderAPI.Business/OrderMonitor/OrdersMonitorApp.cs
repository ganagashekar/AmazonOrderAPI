using AmazonAPI;
using AmazonAPI.Feeds.MarketplaceWebService.FeedBuilder;
using AmazonAPI.Feeds.MarketplaceWebService.Model;
using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.Common.EnumOps;
using AmazonOrderAPI.Business.EnumOps;
using AmazonOrderAPI.DataContext;
using AmazonOrderAPI.DataContext.Entities;

using AmazonOrderExtentions.CoreExtentions;

using eZTrackerOrderClient;

using LoggerService;

using Microsoft.Extensions.Options;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using IMWSResponse = MarketplaceWebServiceOrders.Model.IMWSResponse;

namespace AmazonOrderAPI.OrderMonitor
{
    public class OrdersMonitorApp : BaseCommonClass
    {
        private IMarketplaceWebServiceOrders ordersClient;
        private OrderContext _dbContext;
        private MWSConfig MWSConfig;
        private readonly MarketplaceWebServiceOrdersConfig ordersConfig;

        private NLog.Logger _amazonOrderLOG;

        public OrdersMonitorApp(OrderContext dbContext, ILoggerManager logger, IOptions<AppSetting> _Setting, Seller _Seller
          ) : base(logger, _Setting)
        {
            _amazonOrderLOG = NLog.LogManager.GetLogger("AmazonOrderLogger");

            _dbContext = dbContext;
            MWSConfig = new MWSConfig(_dbContext, _Seller.SellerId);

            #region Initialize API

            AccessKey = MWSConfig.GetConfig()["AccessKey"];
            SecretKey = MWSConfig.GetConfig()["SecretKey"];
            // SellerId = MWSConfig.GetConfig()["SellerId"];
            Seller_PkID = _Seller.Id;
            SellerId = _Seller.SellerId;
            appName = MWSConfig.GetConfig()["AppName"];
            appVersion = MWSConfig.GetConfig()["AppVersion"];
            serviceURL = MWSConfig.GetConfig()["ServiceURL"];
            mwsAuthToken = MWSConfig.GetConfig()["MWSAuthToken"];
            MarketplaceId = MWSConfig.GetConfig()["MarketplaceId"];
            bool isProxyEnabled = setting.Value.ProxySetting.IsProxyEnabled;
            ordersConfig = new MarketplaceWebServiceOrdersConfig
            {
                ServiceURL = serviceURL,
                ProxyPort = isProxyEnabled ? setting.Value.ProxySetting.ProxyPortNumber : default(int),
                ProxyHost = isProxyEnabled ? setting.Value.ProxySetting.ProxyHost : string.Empty
            };

            ordersClient = new MarketplaceWebServiceOrdersClient(AccessKey, SecretKey, appName, appVersion, ordersConfig);

            AmazonCredential amazonCredential = new AmazonCredential()
            {
                AccessKeyID = AccessKey,
                SecretAccessKey = SecretKey,
                //MerchantID = ""; //Need to Be Specific
                MarketplaceID = MarketplaceId
                //SellerID = ""; //Need to Be Specific
            };

            AmazonConnection amazonConnection = new AmazonConnection(amazonCredential);

            List<OrderFulfillmentFeedMessage> OrderFulfillmentFeedMessages = new List<OrderFulfillmentFeedMessage>();

            OrderFulfillmentFeedMessage OrderFulfillmentFeedMessage = new OrderFulfillmentFeedMessage();
            OrderFulfillmentFeedMessage.AmazonOrderID = "050-1234567-1234567";
            OrderFulfillmentFeedMessage.FulfillmentDate = DateTime.Now;
            OrderFulfillmentFeedMessage.fulfillmentData.CarrierName = "Bombax";
            OrderFulfillmentFeedMessage.fulfillmentData.ShippingMethod = "Standard";
            OrderFulfillmentFeedMessage.fulfillmentData.ShipperTrackingNumber = "123321";
            OrderFulfillmentFeedMessage.fulfillmentItem.AmazonOrderItemCode = "12345678901234";
            OrderFulfillmentFeedMessage.fulfillmentItem.Quantity = "1";
            OrderFulfillmentFeedMessages.Add(OrderFulfillmentFeedMessage);

            XmlDocument amazonOrderFulfillmentXml = OrderFulfillmentFeedBuilder.BuildOrderFulfillmentFeedXml(OrderFulfillmentFeedMessages);

            amazonConnection.Feeds.SubmitFeed(EFeedType.OrderFulfillment, MWSUtil.GetXMLAsString(amazonOrderFulfillmentXml));

            #endregion Initialize API
        }

        #region Properties

        public DateTime DateTimeBegin = new DateTime(2000, 1, 1);
        public string AccessKey;
        public string SecretKey;
        public string SellerId;
        public string appName;
        public string appVersion;
        public string serviceURL;
        public string mwsAuthToken;
        public string MarketplaceId;
        public long Seller_PkID;

        #endregion Properties

        public async Task TimedTasksRunListOrder()
        {
            try
            {
                //DateTime updatedAfterDefault = (DateTime.ParseExact(setting.Value.GlobalConstants.InitialDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));
                var ezTrackerAppSetting = setting.Value.ToDestination<AppSetting, Ez_AppSetting>();
                IQueryable<DateTime> seller = from s in _dbContext.Sellers where s.SellerId == SellerId.ToString() select s.CreatedDate;
                DateTime sellerCreatedDate = seller.First();
                DateTime updatedAfterDefault = sellerCreatedDate.Date.AddDays(ezTrackerAppSetting.GlobalConstants.SellerOrderStartDateBefore);

                DateTime updatedBeforeDefault = DateTime.Now.AddMinutes(-5);

                var query = from o in _dbContext.Orders where o.SellerId == Seller_PkID orderby o.LastUpdateDate descending select o;

                if (query.Any())
                {
                    DateTime? tempDate = query.First().LastUpdateDate;
                    DateTime lastUpdate = DateTimeBegin;
                    if (tempDate != null)
                    {
                        lastUpdate = (DateTime)tempDate;
                    }

                    await GetOrdersForTimeWindow(this, lastUpdate, updatedBeforeDefault);
                }
                else
                {
                    await GetOrdersForTimeWindow(this, updatedAfterDefault, updatedBeforeDefault);
                }
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message);
            }
        }

        public async Task TimedTasksRunListOrderItems()
        {
            try
            {
                DateTime updatedBeforeDefault = DateTime.Now.AddMinutes(-5);

                var query = _dbContext.Orders.OrderByDescending(x => x.LastUpdateDate).Where(x => x.ListOrderItemStatusId == (int)EnumReferenceRecords.OrderCreated && x.SellerId == Seller_PkID && x.Seller.IsActive == true).ToList();// && orderStatus.Contains(x.OrderStatus)).ToList();
                var Warehousedata = _dbContext.Warehouses.Where(x => x.Seller.SellerId == SellerId).ToList();
                if (query.Any())
                {
                    foreach (var items in query)
                    {
                        DateTime? tempDate = items.LastUpdateDate;
                        DateTime lastUpdate = DateTimeBegin;  // silly assignment so we cover the else case.
                        if (tempDate != null)
                        {
                            lastUpdate = (DateTime)tempDate;
                        }

                        _logger.LogInfo("Last update date is : " + lastUpdate);

                        await GetOrdersItemsForTimeWindow(this, lastUpdate, updatedBeforeDefault, items.AmazonOrderId, items.Id, Warehousedata);
                    }
                }
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message);
            }
        }

        public async Task TimedTasksRunSendAcknowledgementFeed()
        {
            try
            {
                DateTime updatedBeforeDefault = DateTime.Now.AddMinutes(-5);
                var ezTrackerAppSetting = setting.Value.ToDestination<AppSetting, Ez_AppSetting>();
                var query = _dbContext.OrderItems.OrderByDescending(x => x.Orders.LastUpdateDate).Where(x => x.Orders.ListOrderItemStatusId == (int)EnumReferenceRecords.OrderItemsRead && x.SellerId == Seller_PkID && x.Seller.IsActive == true && x.Orders.IsEzShipOrder == false && x.Orders.LastUpdateDate.Date >= updatedBeforeDefault.Date.AddDays(ezTrackerAppSetting.GlobalConstants.AcknowledgeOrdersBefore)).ToList().Take(10000);
                if (query.Any())
                {
                    await SendAcknowledgementFeedForTimeWindow(this, query);
                }
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message);
            }
        }

        public async Task TimedTasksRunSendFulfillmentFeed()
        {
            try
            {
                DateTime updatedBeforeDefault = DateTime.Now.AddMinutes(-5);
                var ezTrackerAppSetting = setting.Value.ToDestination<AppSetting, Ez_AppSetting>();
                var query = _dbContext.OrderItems.OrderByDescending(x => x.Orders.LastUpdateDate).Where(x => x.Orders.ListOrderItemStatusId == (int)EnumReferenceRecords.OrderAcknowledgeSuccessful && x.SellerId == Seller_PkID && x.Seller.IsActive == true && x.Orders.IsEzShipOrder == false && x.Orders.LastUpdateDate.Date >= updatedBeforeDefault.Date.AddDays(ezTrackerAppSetting.GlobalConstants.FulfillOrdersBefore)).ToList();
                if (query.Any())
                {
                    await SendFulfillmentFeedForTimeWindow(this, query);
                }
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message);
            }
        }

        private Task<ListOrdersResponse> InvokeListOrders(DateTime createdAfter, DateTime createdBefore, string[] reforderStatus, string[] reforderPayments, string[] refFFCM)
        {
            ListOrdersRequest request = new ListOrdersRequest();
            try
            {
                request = new ListOrdersRequest
                {
                    SellerId = SellerId,
                    MWSAuthToken = mwsAuthToken,
                    LastUpdatedAfter = createdAfter.AddSeconds(1),
                    LastUpdatedBefore = createdBefore,
                    OrderStatus = reforderStatus.ToList(),
                    PaymentMethod = reforderPayments.ToList(),
                    FulfillmentChannel = refFFCM.ToList(),
                    MarketplaceId = (new string[] { MarketplaceId }).ToList()
                };
                decimal maxResultsPerPage = 100;
                request.MaxResultsPerPage = maxResultsPerPage;
                return Task.FromResult(ordersClient.ListOrders(request));
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message + " SellerId = " + SellerId + " mwsAuthToken = " + mwsAuthToken + " request = " + request);
                throw ex;
            }
            finally
            {
                request = null;
            }
        }

        private Task<ListOrdersByNextTokenResponse> InvokeListOrdersByNextToken(string nextToken)
        {
            ListOrdersByNextTokenRequest request;
            try
            {
                request = new ListOrdersByNextTokenRequest
                {
                    SellerId = SellerId,
                    MWSAuthToken = mwsAuthToken,
                    NextToken = nextToken
                };
                return Task.FromResult(ordersClient.ListOrdersByNextToken(request));
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message);
                throw ex;
            }
            finally
            {
                request = null;
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

        private void LogFeedResponseOrException(string responsevalue, bool IsException, Exception ex, string FeedSubmissionId, int FeedTypeId, IEnumerable<OrderItem> orderItems)
        {
            FeedResponse response;
            FeedException FeedException;
            try
            {
                if (!IsException)
                {
                    foreach (var orderItem in orderItems)
                    {
                        response = new FeedResponse
                        {
                            Response = responsevalue.Encrypt(),
                            FeedTypeId = FeedTypeId,
                            FeedSubmissionId = FeedSubmissionId,
                            OrderItemId = orderItem.OrderItemId,
                            FeedProcessingStatusId = (int)EFeedProcessingStatus.Submitted
                        };

                        _dbContext.FeedResponse.Add(response);
                    }
                        
                }
                else
                {
                    foreach (var orderItem in orderItems)
                    {
                        FeedException = new FeedException
                        {
                            Response = responsevalue.Encrypt(),
                            Exception = ex.GetserializeJsonString().ToString(),
                            OrderItemId = orderItem.OrderItemId,
                            FeedTypeId = FeedTypeId
                        };
                        _dbContext.FeedException.Add(FeedException);
                    }
                }
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message + " responsevalue = " + responsevalue + " IsException = " + IsException + " FeedSubmissionId = "+ FeedSubmissionId + " FeedTypeId = "+ FeedTypeId+ " orderItems = "+ string.Join(",", orderItems));
            }
            finally
            {
                response = null;
                FeedException = null;
            }
        }

        private async Task<string> GetOrdersForTimeWindow(
            OrdersMonitorApp theApp,
            DateTime updatedAfter,
            DateTime updatedBefore
            )
        {
            IMWSResponse response;
            ListOrdersResponse listOrdersResponse = null;
            ListOrdersByNextTokenResponse listOrdersByNextTokenResponse = null;
            string nextTokenFromRequest = null;
            List<Order> ordersFromRequest;
            bool IsEzShipOrder = false;
            try
            {
                var RequiredReferenceRecords = (new string[] { nameof(EnumReferenceRecordType.MWSOrderStatus), nameof(EnumReferenceRecordType.MWSPaymentMethod), nameof(EnumReferenceRecordType.MWSFFMC), nameof(EnumReferenceRecordType.EzShipServiceLevel) });
                var referenceRecords = _dbContext.ReferenceRecords.Where(x => RequiredReferenceRecords.Contains(x.ReferenceRecordTypes.Name)).ToList();
                var refOrderStatus = referenceRecords.Where(x => x.ReferenceRecordTypeId == ((int)EnumReferenceRecordType.MWSOrderStatus)).Select(x => x.Name).ToArray();
                var reforderPayments = referenceRecords.Where(x => x.ReferenceRecordTypeId == ((int)EnumReferenceRecordType.MWSPaymentMethod)).Select(x => x.Name).ToArray();
                var reffulfillmentChannel = referenceRecords.Where(x => x.ReferenceRecordTypeId == ((int)EnumReferenceRecordType.MWSFFMC)).Select(x => x.Name).ToArray();
                var ezShipServiceLevel = referenceRecords.Where(x => x.ReferenceRecordTypeId == ((int)EnumReferenceRecordType.EzShipServiceLevel)).Select(x => x.Displaytext).ToArray();
                do
                {
                    try
                    {
                        if (nextTokenFromRequest != null)
                        {
                            response = await theApp.InvokeListOrdersByNextToken(nextTokenFromRequest);
                            listOrdersByNextTokenResponse = (ListOrdersByNextTokenResponse)response;

                            nextTokenFromRequest = listOrdersByNextTokenResponse.ListOrdersByNextTokenResult.NextToken;
                            ordersFromRequest = listOrdersByNextTokenResponse.ListOrdersByNextTokenResult.Orders;
                            _amazonOrderLOG.Info("Resposne: " + ordersFromRequest.GetserializeJsonStringEncrypt().ToString() + "TimestampNextToken: " + DateTime.Now + "'");
                        }
                        else
                        {
                            // we are making a request for the first time.
                            response = await theApp.InvokeListOrders(updatedAfter, updatedBefore, refOrderStatus, reforderPayments, reffulfillmentChannel);

                            listOrdersResponse = (ListOrdersResponse)response;

                            nextTokenFromRequest = listOrdersResponse.ListOrdersResult.NextToken;
                            ordersFromRequest = listOrdersResponse.ListOrdersResult.Orders;

                            _amazonOrderLOG.Info("Resposne: " + ordersFromRequest.GetserializeJsonStringEncrypt().ToString() + "Timestamp: " + DateTime.Now + "'");
                        }

                        MarketplaceWebServiceOrders.Model.ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;

                        // We recommend logging the request id and timestamp of every call.
                        _logger.LogInfo("RequestId: " + rhmd.RequestId + "Timestamp: " + rhmd.Timestamp);
                        _amazonOrderLOG.Info("RequestId: " + rhmd.RequestId + "Timestamp: " + rhmd.Timestamp);
                        _logger.LogInfo(ordersFromRequest.GetserializeJsonStringEncrypt().ToString());

                        LogOrderResposneException(response.GetserializeJsonStringEncrypt(), false, null, string.Empty);

                        foreach (Order order in ordersFromRequest)
                        {
                            try
                            {
                                IsEzShipOrder = false;
                                order.ListOrderItemStatusId = (int)EnumReferenceRecords.OrderCreated;
                                order.LastUpdateDate = DateTime.Now;
                                var queryDuplicateCheck = from o in _dbContext.Orders
                                                          where o.AmazonOrderId == order.AmazonOrderId
                                                          select o;

                                if (order.ShippingAddress == null)
                                {
                                    order.ShippingAddressStatusId = (int)AddressStatusEnum.AddressNotSpecified;
                                }

                                foreach (string shipServiceLevel in ezShipServiceLevel)
                                {
                                    if (order.ShipServiceLevel.Equals(shipServiceLevel))
                                    {
                                        IsEzShipOrder = true;
                                        break;
                                    }
                                }
                                if (IsEzShipOrder)
                                {
                                    order.IsEzShipOrder = true;
                                }
                                else
                                {
                                    order.IsEzShipOrder = false;
                                }
                                if (queryDuplicateCheck.Any())
                                {
                                    //var dbOrder = queryDuplicateCheck.First();
                                    //_dbContext.Orders.Remove(dbOrder);
                                    //_dbContext.Orders.Add(order);
                                }
                                else
                                {
                                    order.SellerId = Seller_PkID;
                                    _dbContext.Orders.Add(order);
                                }
                            }
                            catch (Exception ex)
                            {
                                _amazonOrderLOG.Error(ex);
                                _logger.LogError("Message: " + ex.Message + " order = " + order);
                                LogOrderResposneException(response.GetserializeJsonStringEncrypt(), true, ex, order.AmazonOrderId);
                                break;
                            }
                        }

                        _dbContext.SaveChanges();

                        Thread.Sleep(30000);
                    }
                    catch (Exception ex)
                    {
                        _amazonOrderLOG.Error(ex);
                        _logger.LogError("Message: " + ex.Message + " listOrdersByNextTokenResponse = " + listOrdersByNextTokenResponse + " listOrdersResponse = " + listOrdersResponse);
                        LogOrderResposneException(null, true, ex, string.Empty);
                    }
                } while (nextTokenFromRequest != null);
            }
            catch (MarketplaceWebServiceOrdersException ex)
            {
                // Exception properties are important for diagnostics.
                MarketplaceWebServiceOrders.Model.ResponseHeaderMetadata rhmd = ex.ResponseHeaderMetadata;
                Console.WriteLine("383 Service Exception:");
                if (rhmd != null)
                {
                    _logger.LogError("386 RequestId: " + rhmd.RequestId);
                    _logger.LogError("387 Timestamp: " + rhmd.Timestamp);
                }
                _logger.LogError("389 Message: " + ex.Message);
                _logger.LogError("390 StatusCode: " + ex.StatusCode);
                _logger.LogError("391 ErrorCode: " + ex.ErrorCode);
                _logger.LogError("392 ErrorType: " + ex.ErrorType);

                _logger.LogError(ex.InnerException.Message);
                _amazonOrderLOG.Error(ex);

                _amazonOrderLOG.Info(rhmd.GetserializeJsonStringEncrypt());
                LogOrderResposneException(rhmd.GetserializeJsonStringEncrypt(), true, ex, string.Empty);
                return "Something Went Wrong please try again";
            }
            finally
            {
                response = null;
                listOrdersResponse = null;
                listOrdersByNextTokenResponse = null;
                nextTokenFromRequest = null;
                ordersFromRequest = null;

                //RequiredReferenceRecords = null;
                //referenceRecords = null;
                //refOrderStatus = null;
                //reforderPayments = null;
                //reffulfillmentChannel = null;
            }
            return "Completed Successfully";
        }

        private Task<ListOrderItemsResponse> InvokeListOrderItems(DateTime createdAfter, DateTime createdBefore, string amazonOrderId)
        {
            ListOrderItemsRequest request;

            try
            {
                request = new ListOrderItemsRequest();
                request.SellerId = SellerId;
                request.MWSAuthToken = mwsAuthToken;
                request.AmazonOrderId = amazonOrderId;
                return Task.FromResult(ordersClient.ListOrderItems(request));
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message + " SellerId = " + SellerId + " mwsAuthToken = " + mwsAuthToken + " amazonOrderId = " + amazonOrderId);

                throw ex;
            }
            finally
            {
                request = null;
            }
        }

        private Task<ListOrderItemsByNextTokenResponse> InvokeListOrderItemsByNextToken(string nextToken)
        {
            ListOrderItemsByNextTokenRequest request;
            try
            {
                request = new ListOrderItemsByNextTokenRequest();
                request.SellerId = SellerId;
                request.MWSAuthToken = mwsAuthToken;
                request.NextToken = nextToken;
                return Task.FromResult(ordersClient.ListOrderItemsByNextToken(request));
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message);

                throw ex;
            }
            finally
            {
                request = null;
            }
        }

        private Task<SubmitFeedResponse> InvokeSendAcknowledgementFeed(List<OrderAcknowledgementFeedMessage> orderAcknowledgementFeedMessages, AmazonConnection amazonConnection)
        {
            XmlDocument amazonOrderAcknowledgementXml;
            try
            {
                amazonOrderAcknowledgementXml = OrderAcknowledgementFeedBuilder.BuildOrderAcknowledgementFeedXml(orderAcknowledgementFeedMessages);

                return Task.FromResult(amazonConnection.Feeds.SubmitFeed(EFeedType.OrderAcknowledgement, MWSUtil.GetXMLAsString(amazonOrderAcknowledgementXml)));
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message);

                throw ex;
            }
            finally
            {
                amazonOrderAcknowledgementXml = null;
            }
        }

        private Task<SubmitFeedResponse> InvokeSendFulfillmentFeed(List<OrderFulfillmentFeedMessage> OrderFulfillmentFeedMessages, AmazonConnection amazonConnection)
        {
            XmlDocument amazonOrderFulfillmentXml;
            try
            {
                amazonOrderFulfillmentXml = OrderFulfillmentFeedBuilder.BuildOrderFulfillmentFeedXml(OrderFulfillmentFeedMessages);

                return Task.FromResult(amazonConnection.Feeds.SubmitFeed(EFeedType.OrderFulfillment, MWSUtil.GetXMLAsString(amazonOrderFulfillmentXml)));
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                _logger.LogError("Message: " + ex.Message);

                throw ex;
            }
            finally
            {
                OrderFulfillmentFeedMessages = null;
            }
        }

        private long? GetandMapWarehouses_orderItem(string SKU, List<Warehouse> lstWarehouses)
        {
            try
            {
                if (SKU.ToUpper().Contains('-'))
                {
                    string[] addressShortCode = SKU.Split('-');

                    var result = lstWarehouses.FirstOrDefault(x => x.WarehouseLocationCode.ToUpper() == addressShortCode.LastOrDefault().ToUpper());
                    if (result.Id.IsNotNull())
                    {
                        return result.Id;
                    }
                    else
                    {
                        var resultDefalut = lstWarehouses.FirstOrDefault(x => x.WarehouseLocationCode.ToUpper() == "DEFAULT");
                        if (resultDefalut.Id.IsNotNull())
                        {
                            return resultDefalut.Id;
                        }
                        else
                        {
                            return default(long?);
                        }
                    }
                }
                else
                {
                    return default(long?);
                }
            }
            catch (Exception ex)
            {
                _amazonOrderLOG.Error(ex);
                return default(long?);
            }
        }

        private async Task<string> GetOrdersItemsForTimeWindow(
            OrdersMonitorApp theApp,
            DateTime updatedAfter,
            DateTime updatedBefore,
            string AmazonOrderId,
            long OrderId, List<Warehouse> lstWarehouse
            )
        {
            IMWSResponse response;
            ListOrderItemsResponse listOrdersResponse = null;
            ListOrderItemsByNextTokenResponse listOrdersByNextTokenResponse = null;
            string nextTokenFromRequest = null;
            List<OrderItem> ordersFromRequest;
            string Response_AmazonOrderId = AmazonOrderId;

            string orderItemIdList = "";

            try
            {


                do
                {
                    try
                    {
                        // if this is not the first request, get the rest of the request.
                        if (nextTokenFromRequest != null)
                        {
                            Console.WriteLine("Get the next of the data");
                            response = await theApp.InvokeListOrderItemsByNextToken(nextTokenFromRequest);

                            listOrdersByNextTokenResponse = (ListOrderItemsByNextTokenResponse)response;
                            // Response_AmazonOrderId = listOrdersByNextTokenResponse.ListOrderItemsByNextTokenResult.AmazonOrderId;
                            nextTokenFromRequest = listOrdersByNextTokenResponse.ListOrderItemsByNextTokenResult.NextToken;
                            ordersFromRequest = listOrdersByNextTokenResponse.ListOrderItemsByNextTokenResult.OrderItems;
                        }
                        else
                        {
                            // we are making a request for the first time.
                            response = await theApp.InvokeListOrderItems(updatedAfter, updatedBefore, AmazonOrderId);

                            listOrdersResponse = (ListOrderItemsResponse)response;

                            // Response_AmazonOrderId = listOrdersByNextTokenResponse.ListOrderItemsByNextTokenResult.AmazonOrderId;
                            nextTokenFromRequest = listOrdersResponse.ListOrderItemsResult.NextToken;
                            ordersFromRequest = listOrdersResponse.ListOrderItemsResult.OrderItems;
                        }

                        MarketplaceWebServiceOrders.Model.ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;

                        // We recommend logging the request id and timestamp of every call.

                        _logger.LogInfo("RequestId: " + rhmd.RequestId + "Timestamp: " + rhmd.Timestamp);

                        _logger.LogInfo(ordersFromRequest.GetserializeJsonStringEncrypt().ToString());

                        
                        foreach (OrderItem orderItem in ordersFromRequest)
                        {
                            try
                            {
                                orderItem.OrderId = OrderId;
                                orderItem.Orders.LastUpdateDate = DateTime.Now;
                                orderItem.WarehouseId = GetandMapWarehouses_orderItem(orderItem.SellerSKU, lstWarehouse);
                                orderItem.ItemStatusId = orderItem.WarehouseId.IsNull() ? (int)EnumReferenceRecords.InvalidSKU : (int)EnumReferenceRecords.OrderItemsCreated;
                                var queryDuplicateCheck = from o in _dbContext.Orders
                                                          join x in _dbContext.OrderItems on o.Id equals x.OrderId
                                                          where o.AmazonOrderId == Response_AmazonOrderId & x.OrderItemId == orderItem.OrderItemId
                                                          select x;

                                orderItemIdList = string.IsNullOrEmpty(orderItemIdList)? orderItem.OrderItemId : orderItemIdList + ", " + orderItem.OrderItemId;

                                if (queryDuplicateCheck.Any())
                                {
                                    //var dbOrder = queryDuplicateCheck.First();
                                    //_dbContext.OrderItems.Remove(dbOrder);
                                    //_dbContext.OrderItems.Add(orderItem);
                                }
                                else
                                {
                                    orderItem.SellerId = Seller_PkID;
                                    _dbContext.OrderItems.Add(orderItem);
                                }
                                var order = _dbContext.Orders.FirstOrDefault(x => x.Id == OrderId);
                                order.ListOrderItemStatusId = (int)EnumReferenceRecords.OrderItemsCreated;
                                order.LastUpdateDate = DateTime.Now;
                            }
                            catch (Exception ex)
                            {
                                _amazonOrderLOG.Error(ex);
                                _logger.LogError("Message: " + ex.Message + " orderItem = " + orderItem);
                                LogOrderItemsResponseOrException(response.GetserializeJsonStringEncrypt().ToString(), true, ex, orderItem.OrderItemId);
                                break;
                            }
                        }

                        _dbContext.SaveChanges();
                        LogOrderItemsResponseOrException(response.GetserializeJsonStringEncrypt().ToString(), false, null, orderItemIdList);
                    }
                    catch (Exception ex)
                    {
                        _amazonOrderLOG.Error(ex);
                        _logger.LogError("Message: " + ex.Message + " listOrdersResponse = " + listOrdersResponse + " listOrdersByNextTokenResponse = " + listOrdersByNextTokenResponse);
                        LogOrderItemsResponseOrException(null, true, ex, orderItemIdList);
                    }

                    Thread.Sleep(2000);
                } while (nextTokenFromRequest != null);
            }
            catch (MarketplaceWebServiceOrdersException ex)
            {
                MarketplaceWebServiceOrders.Model.ResponseHeaderMetadata rhmd = ex.ResponseHeaderMetadata;
                Console.WriteLine("613 Service Exception:");
                if (rhmd != null)
                {
                    _logger.LogError("616 RequestId: " + rhmd.RequestId);
                    Console.WriteLine("617 Timestamp: " + rhmd.Timestamp);
                }
                _logger.LogError("619 Message: " + ex.Message);
                _logger.LogError("620 StatusCode: " + ex.StatusCode);
                _logger.LogError("621 ErrorCode: " + ex.ErrorCode);
                _logger.LogError("622 ErrorType: " + ex.ErrorType);

                _amazonOrderLOG.Error(ex);

                _amazonOrderLOG.Info(rhmd.GetserializeJsonStringEncrypt());

                LogOrderItemsResponseOrException(rhmd.GetserializeJsonStringEncrypt(), true, ex, orderItemIdList);
                return "Something Went Wrong please try again";
            }
            finally
            {
                response = null;
                listOrdersResponse = null;
                listOrdersByNextTokenResponse = null;
                ordersFromRequest = null;

            }
            return "Completed Successfully";
        }

        private async Task<string> SendAcknowledgementFeedForTimeWindow(
            OrdersMonitorApp theApp,
            IEnumerable<OrderItem> orderItems
            )
        {
            FeedSubmissionInfo feedSubmissionInfo = null;
            AmazonCredential amazonCredential = null;
            AmazonConnection amazonConnection = null;
            List<OrderAcknowledgementFeedMessage> orderAcknowledgementFeedMessages = new List<OrderAcknowledgementFeedMessage>();
            
            SubmitFeedResponse submitFeedResponse = null;
            SubmitFeedResult Result = null;

            try
            {
                amazonCredential = new AmazonCredential()
                {
                    AccessKeyID = AccessKey,
                    SecretAccessKey = SecretKey,
                    MerchantID = SellerId,
                    MarketplaceID = MarketplaceId,
                    MWSAuthToken = mwsAuthToken
                };

                amazonConnection = new AmazonConnection(amazonCredential);

                foreach(var orderItem in orderItems)
                {
                    OrderAcknowledgementFeedMessage orderAcknowledgementFeedMessage = new OrderAcknowledgementFeedMessage();
                    orderAcknowledgementFeedMessage.AmazonOrderID = orderItem.Orders.AmazonOrderId;
                    orderAcknowledgementFeedMessage.StatusCode = "Success";
                    orderAcknowledgementFeedMessage.acknowledgementItem.AmazonOrderItemCode = orderItem.OrderItemId;
                    orderAcknowledgementFeedMessages.Add(orderAcknowledgementFeedMessage);
                }

                submitFeedResponse = await theApp.InvokeSendAcknowledgementFeed(orderAcknowledgementFeedMessages, amazonConnection);
                
                LogFeedResponseOrException(submitFeedResponse.GetserializeJsonStringEncrypt().ToString(), false, null, submitFeedResponse?.SubmitFeedResult?.FeedSubmissionInfo?.FeedSubmissionId, (int)EFeedType.OrderAcknowledgement, orderItems);

                if (submitFeedResponse.IsSetSubmitFeedResult())
                {
                    Result = submitFeedResponse.SubmitFeedResult;
                    if (Result.IsSetFeedSubmissionInfo())
                        feedSubmissionInfo = Result.FeedSubmissionInfo;
                    else
                        feedSubmissionInfo = null;
                }
                else
                    feedSubmissionInfo = null;

                if (feedSubmissionInfo != null)
                {
                    foreach (var orderItem in orderItems)
                    {
                        var order = _dbContext.Orders.FirstOrDefault(x => x.Id == orderItem.OrderId);
                        order.ListOrderItemStatusId = (int)EnumReferenceRecords.OrderAcknowledgeStarted;
                        order.LastUpdateDate = DateTime.Now;
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (submitFeedResponse != null)
                {
                    AmazonAPI.Feeds.MarketplaceWebService.Model.ResponseHeaderMetadata rhmd = submitFeedResponse.ResponseHeaderMetadata;
                    Console.WriteLine("613 Service Exception:");
                    if (rhmd != null)
                    {
                        _logger.LogError("860 RequestId: " + rhmd.RequestId + " responseContext = " + rhmd.ResponseContext + " timestamp = " + rhmd.Timestamp);
                        Console.WriteLine("861 RequestId: " + rhmd.RequestId + " responseContext = " + rhmd.ResponseContext + " timestamp = " + rhmd.Timestamp);
                    }
                    _logger.LogError("863 Message: " + ex.Message + "StatusCode: " + ex.StackTrace+ "ErrorCode: " + ex.Source+ "ErrorType: " + ex.InnerException);

                    _amazonOrderLOG.Error(ex);

                    _amazonOrderLOG.Info(rhmd.GetserializeJsonStringEncrypt());

                    LogFeedResponseOrException(rhmd.GetserializeJsonStringEncrypt(), true, ex, string.Empty, (int)EFeedType.OrderAcknowledgement, orderItems);
                    return "Something Went Wrong please try again";
                }
                return "Something Went Wrong please try again";
            }
            finally
            {
                feedSubmissionInfo = null;
                amazonCredential = null;
                amazonConnection = null;
                orderAcknowledgementFeedMessages = null;
                submitFeedResponse = null;
                Result = null;
            }
            return "Completed Successfully";
        }

        private async Task<string> GetFeedProcessingStatusForTimeWindow(
            OrdersMonitorApp theApp,
            IEnumerable<OrderItem> orderItems
            )
        {
            FeedSubmissionInfo feedSubmissionInfo = null;
            AmazonCredential amazonCredential = null;
            AmazonConnection amazonConnection = null;
            List<OrderAcknowledgementFeedMessage> orderAcknowledgementFeedMessages = new List<OrderAcknowledgementFeedMessage>();

            SubmitFeedResponse submitFeedResponse = null;
            SubmitFeedResult Result = null;

            try
            {
                amazonCredential = new AmazonCredential()
                {
                    AccessKeyID = AccessKey,
                    SecretAccessKey = SecretKey,
                    MerchantID = SellerId,
                    MarketplaceID = MarketplaceId,
                    MWSAuthToken = mwsAuthToken
                };

                amazonConnection = new AmazonConnection(amazonCredential);

                foreach (var orderItem in orderItems)
                {
                    OrderAcknowledgementFeedMessage orderAcknowledgementFeedMessage = new OrderAcknowledgementFeedMessage();
                    orderAcknowledgementFeedMessage.AmazonOrderID = orderItem.Orders.AmazonOrderId;
                    orderAcknowledgementFeedMessage.StatusCode = "Success";
                    orderAcknowledgementFeedMessage.acknowledgementItem.AmazonOrderItemCode = orderItem.OrderItemId;
                    orderAcknowledgementFeedMessages.Add(orderAcknowledgementFeedMessage);
                }

                submitFeedResponse = await theApp.InvokeSendAcknowledgementFeed(orderAcknowledgementFeedMessages, amazonConnection);

                LogFeedResponseOrException(submitFeedResponse.GetserializeJsonStringEncrypt().ToString(), false, null, submitFeedResponse?.SubmitFeedResult?.FeedSubmissionInfo?.FeedSubmissionId, (int)EFeedType.OrderAcknowledgement, orderItems);

                if (submitFeedResponse.IsSetSubmitFeedResult())
                {
                    Result = submitFeedResponse.SubmitFeedResult;
                    if (Result.IsSetFeedSubmissionInfo())
                        feedSubmissionInfo = Result.FeedSubmissionInfo;
                    else
                        feedSubmissionInfo = null;
                }
                else
                    feedSubmissionInfo = null;

                if (feedSubmissionInfo != null)
                {
                    foreach (var orderItem in orderItems)
                    {
                        var order = _dbContext.Orders.FirstOrDefault(x => x.Id == orderItem.OrderId);
                        order.ListOrderItemStatusId = (int)EnumReferenceRecords.OrderAcknowledgeStarted;
                        order.LastUpdateDate = DateTime.Now;
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (submitFeedResponse != null)
                {
                    AmazonAPI.Feeds.MarketplaceWebService.Model.ResponseHeaderMetadata rhmd = submitFeedResponse.ResponseHeaderMetadata;
                    Console.WriteLine("613 Service Exception:");
                    if (rhmd != null)
                    {
                        _logger.LogError("860 RequestId: " + rhmd.RequestId + " responseContext = " + rhmd.ResponseContext + " timestamp = " + rhmd.Timestamp);
                        Console.WriteLine("861 RequestId: " + rhmd.RequestId + " responseContext = " + rhmd.ResponseContext + " timestamp = " + rhmd.Timestamp);
                    }
                    _logger.LogError("863 Message: " + ex.Message + "StatusCode: " + ex.StackTrace + "ErrorCode: " + ex.Source + "ErrorType: " + ex.InnerException);

                    _amazonOrderLOG.Error(ex);

                    _amazonOrderLOG.Info(rhmd.GetserializeJsonStringEncrypt());

                    LogFeedResponseOrException(rhmd.GetserializeJsonStringEncrypt(), true, ex, string.Empty, (int)EFeedType.OrderAcknowledgement, orderItems);
                    return "Something Went Wrong please try again";
                }
                return "Something Went Wrong please try again";
            }
            finally
            {
                feedSubmissionInfo = null;
                amazonCredential = null;
                amazonConnection = null;
                orderAcknowledgementFeedMessages = null;
                submitFeedResponse = null;
                Result = null;
            }
            return "Completed Successfully";
        }

        private async Task<string> SendFulfillmentFeedForTimeWindow(
            OrdersMonitorApp theApp,
            IEnumerable<OrderItem> orderItems
            )
        {
            FeedSubmissionInfo feedSubmissionInfo = null;
            AmazonCredential amazonCredential = null;
            AmazonConnection amazonConnection = null;
            List<OrderFulfillmentFeedMessage> OrderFulfillmentFeedMessages = new List<OrderFulfillmentFeedMessage>();
            
            SubmitFeedResponse submitFeedResponse = null;
            SubmitFeedResult Result = null;

            try
            {
                amazonCredential = new AmazonCredential()
                {
                    AccessKeyID = AccessKey,
                    SecretAccessKey = SecretKey,
                    MerchantID = SellerId,
                    MarketplaceID = MarketplaceId,
                    MWSAuthToken = mwsAuthToken
                };

                amazonConnection = new AmazonConnection(amazonCredential);

                var ezTrackerAppSetting = setting.Value.ToDestination<AppSetting, Ez_AppSetting>();
                foreach (var orderItem in orderItems)
                {
                    OrderFulfillmentFeedMessage OrderFulfillmentFeedMessage = new OrderFulfillmentFeedMessage();
                    OrderFulfillmentFeedMessage.AmazonOrderID = orderItem.Orders.AmazonOrderId;
                    OrderFulfillmentFeedMessage.FulfillmentDate = DateTime.Now;
                    OrderFulfillmentFeedMessage.fulfillmentData.CarrierName = ezTrackerAppSetting.AppConstants.CourierCompanyName;
                    OrderFulfillmentFeedMessage.fulfillmentData.ShippingMethod = ezTrackerAppSetting.PickupRequestConstants.ServiceName;
                    OrderFulfillmentFeedMessage.fulfillmentData.ShipperTrackingNumber = orderItem.ConsignmentNo;
                    OrderFulfillmentFeedMessage.fulfillmentItem.AmazonOrderItemCode = orderItem.OrderItemId;
                    OrderFulfillmentFeedMessage.fulfillmentItem.Quantity = orderItem.QuantityOrdered.ToString();
                    OrderFulfillmentFeedMessages.Add(OrderFulfillmentFeedMessage);
                }
                submitFeedResponse = await theApp.InvokeSendFulfillmentFeed(OrderFulfillmentFeedMessages, amazonConnection);

                LogFeedResponseOrException(submitFeedResponse.GetserializeJsonStringEncrypt().ToString(), false, null, submitFeedResponse?.SubmitFeedResult?.FeedSubmissionInfo?.FeedSubmissionId, (int)EFeedType.OrderFulfillment, orderItems);

                if (submitFeedResponse.IsSetSubmitFeedResult())
                {
                    Result = submitFeedResponse.SubmitFeedResult;
                    if (Result.IsSetFeedSubmissionInfo())
                        feedSubmissionInfo = Result.FeedSubmissionInfo;
                    else
                        feedSubmissionInfo = null;
                }
                else
                    feedSubmissionInfo = null;

                if (feedSubmissionInfo != null)
                {
                    foreach (var orderItem in orderItems)
                    {
                        var order = _dbContext.Orders.FirstOrDefault(x => x.Id == orderItem.OrderId);
                        order.ListOrderItemStatusId = (int)EnumReferenceRecords.OrderFulfillmentStarted;
                        order.LastUpdateDate = DateTime.Now;
                        _dbContext.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (submitFeedResponse != null)
                {
                    AmazonAPI.Feeds.MarketplaceWebService.Model.ResponseHeaderMetadata rhmd = submitFeedResponse.ResponseHeaderMetadata;
                    Console.WriteLine("613 Service Exception:");
                    if (rhmd != null)
                    {
                        _logger.LogError("860 RequestId: " + rhmd.RequestId + " responseContext = " + rhmd.ResponseContext + " timestamp = " + rhmd.Timestamp);
                        Console.WriteLine("861 RequestId: " + rhmd.RequestId + " responseContext = " + rhmd.ResponseContext + " timestamp = " + rhmd.Timestamp);
                    }
                    _logger.LogError("863 Message: " + ex.Message + "StatusCode: " + ex.StackTrace + "ErrorCode: " + ex.Source + "ErrorType: " + ex.InnerException);

                    _amazonOrderLOG.Error(ex);

                    _amazonOrderLOG.Info(rhmd.GetserializeJsonStringEncrypt());

                    LogFeedResponseOrException(rhmd.GetserializeJsonStringEncrypt(), true, ex, string.Empty, (int)EFeedType.OrderFulfillment, orderItems);
                    return "Something Went Wrong please try again";
                }
                return "Something Went Wrong please try again";
            }
            finally
            {
                feedSubmissionInfo = null;
                amazonCredential = null;
                amazonConnection = null;
                OrderFulfillmentFeedMessages = null;
                submitFeedResponse = null;
                Result = null;
            }
            return "Completed Successfully";
        }



        //public CreateSubscriptionResponse CreateSubscription(
        //    OrdersMonitorApp theApp
        //    )
        //{
        //    MWSSubscriptionsServiceConfig config = new MWSSubscriptionsServiceConfig();
        //    config.ServiceURL = serviceURL;
        //    MWSSubscriptionsService client = new MWSSubscriptionsServiceClient(AccessKey, SecretKey, appName, appVersion, config);
        //    CreateSubscriptionResponse response = null;
        //    CreateSubscriptionInput request = new CreateSubscriptionInput();
        //    Subscription subscription = new Subscription();
        //    Destination destination = new Destination();
        //    try
        //    {
                
        //        request.SellerId = SellerId;
        //        request.MWSAuthToken = mwsAuthToken;
        //        request.MarketplaceId = MarketplaceId;

        //        destination.

        //        subscription.Destination = ;
        //        subscription.NotificationType = EnumReferenceRecords.FeedProcessingFinished.ToString();
        //        subscription.IsEnabled = true;

        //        request.Subscription = subscription;
        //        response = client.CreateSubscription(request);

        //        Console.WriteLine("Response:");
        //        AmazonMWS.Subscriptions.Model.ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;
        //        // We recommend logging the request id and timestamp of every call.
        //        Console.WriteLine("RequestId: " + rhmd.RequestId);
        //        Console.WriteLine("Timestamp: " + rhmd.Timestamp);
        //        string responseXml = response.ToXML();
        //        Console.WriteLine(responseXml);
        //        //AmazonMWS.Subscriptions.Model.ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;
        //        return response;
        //    }
        //    catch (MWSSubscriptionsServiceException ex)
        //    {
        //        // Exception properties are important for diagnostics.
        //        AmazonMWS.Subscriptions.Model.ResponseHeaderMetadata rhmd = ex.ResponseHeaderMetadata;
        //        Console.WriteLine("Service Exception:");
        //        if (rhmd != null)
        //        {
        //            Console.WriteLine("RequestId: " + rhmd.RequestId);
        //            Console.WriteLine("Timestamp: " + rhmd.Timestamp);
        //        }
        //        Console.WriteLine("Message: " + ex.Message);
        //        Console.WriteLine("StatusCode: " + ex.StatusCode);
        //        Console.WriteLine("ErrorCode: " + ex.ErrorCode);
        //        Console.WriteLine("ErrorType: " + ex.ErrorType);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        config = null;
        //        client = null;
        //        request = null;
        //        subscription = null;
        //    }
        //}

        //public string DeleteSubscription(
        //    OrdersMonitorApp theApp
        //    )
        //{
        //    MWSSubscriptionsServiceConfig config = new MWSSubscriptionsServiceConfig();
        //    config.ServiceURL = serviceURL;
        //    MWSSubscriptionsService client = new MWSSubscriptionsServiceClient(AccessKey, SecretKey, appName, appVersion, config);
        //    AmazonMWS.Subscriptions.Model.IMWSResponse response = null;
        //    DeleteSubscriptionInput request = new DeleteSubscriptionInput();
        //    Subscription subscription = new Subscription();
        //    try
        //    {

        //        request.SellerId = SellerId;
        //        request.MWSAuthToken = mwsAuthToken;
        //        request.MarketplaceId = MarketplaceId;

        //        request.NotificationType = "";
        //        request.Destination = new 


        //        response = client.CreateSubscription(request);

        //        AmazonMWS.Subscriptions.Model.ResponseHeaderMetadata rhmd = response.ResponseHeaderMetadata;
        //        string responseXml = response.ToXML();
        //        return responseXml;
        //    }
        //    catch (MWSSubscriptionsServiceException ex)
        //    {
        //        // Exception properties are important for diagnostics.
        //        AmazonMWS.Subscriptions.Model.ResponseHeaderMetadata rhmd = ex.ResponseHeaderMetadata;
        //        Console.WriteLine("Service Exception:");
        //        if (rhmd != null)
        //        {
        //            Console.WriteLine("RequestId: " + rhmd.RequestId);
        //            Console.WriteLine("Timestamp: " + rhmd.Timestamp);
        //        }
        //        Console.WriteLine("Message: " + ex.Message);
        //        Console.WriteLine("StatusCode: " + ex.StatusCode);
        //        Console.WriteLine("ErrorCode: " + ex.ErrorCode);
        //        Console.WriteLine("ErrorType: " + ex.ErrorType);
        //        throw ex;
        //    }
        //    finally
        //    {
        //        config = null;
        //        client = null;
        //        response = null;
        //        request = null;
        //        subscription = null;
        //    }
        //}

        //public DeleteSubscriptionResponse InvokeDeleteSubscription(MWSSubscriptionsService client)
        //{
        //    // Create a request.
        //    DeleteSubscriptionInput request = new DeleteSubscriptionInput();
        //    string sellerId = "example";
        //    request.SellerId = sellerId;
        //    string mwsAuthToken = "example";
        //    request.MWSAuthToken = mwsAuthToken;
        //    string marketplaceId = "example";
        //    request.MarketplaceId = marketplaceId;
        //    string notificationType = "example";
        //    request.NotificationType = notificationType;
        //    Destination destination = new Destination();
        //    request.Destination = destination;
        //    return client.DeleteSubscription(request);
        //}

        //public DeregisterDestinationResponse InvokeDeregisterDestination(MWSSubscriptionsService client)
        //{
        //    // Create a request.
        //    DeregisterDestinationInput request = new DeregisterDestinationInput();
        //    string sellerId = "example";
        //    request.SellerId = sellerId;
        //    string mwsAuthToken = "example";
        //    request.MWSAuthToken = mwsAuthToken;
        //    string marketplaceId = "example";
        //    request.MarketplaceId = marketplaceId;
        //    Destination destination = new Destination();
        //    request.Destination = destination;
        //    return client.DeregisterDestination(request);
        //}

        //public GetSubscriptionResponse InvokeGetSubscription(MWSSubscriptionsService client)
        //{
        //    // Create a request.
        //    GetSubscriptionInput request = new GetSubscriptionInput();
        //    string sellerId = "example";
        //    request.SellerId = sellerId;
        //    string mwsAuthToken = "example";
        //    request.MWSAuthToken = mwsAuthToken;
        //    string marketplaceId = "example";
        //    request.MarketplaceId = marketplaceId;
        //    string notificationType = "example";
        //    request.NotificationType = notificationType;
        //    Destination destination = new Destination();
        //    request.Destination = destination;
        //    return client.GetSubscription(request);
        //}

        //public ListRegisteredDestinationsResponse InvokeListRegisteredDestinations(MWSSubscriptionsService client)
        //{
        //    // Create a request.
        //    ListRegisteredDestinationsInput request = new ListRegisteredDestinationsInput();
        //    string sellerId = "example";
        //    request.SellerId = sellerId;
        //    string mwsAuthToken = "example";
        //    request.MWSAuthToken = mwsAuthToken;
        //    string marketplaceId = "example";
        //    request.MarketplaceId = marketplaceId;
        //    return client.ListRegisteredDestinations(request);
        //}

        //public ListSubscriptionsResponse InvokeListSubscriptions(MWSSubscriptionsService client)
        //{
        //    // Create a request.
        //    ListSubscriptionsInput request = new ListSubscriptionsInput();
        //    string sellerId = "example";
        //    request.SellerId = sellerId;
        //    string mwsAuthToken = "example";
        //    request.MWSAuthToken = mwsAuthToken;
        //    string marketplaceId = "example";
        //    request.MarketplaceId = marketplaceId;
        //    return client.ListSubscriptions(request);
        //}

        //public RegisterDestinationResponse InvokeRegisterDestination(MWSSubscriptionsService client)
        //{
        //    // Create a request.
        //    RegisterDestinationInput request = new RegisterDestinationInput();
        //    string sellerId = "example";
        //    request.SellerId = sellerId;
        //    string mwsAuthToken = "example";
        //    request.MWSAuthToken = mwsAuthToken;
        //    string marketplaceId = "example";
        //    request.MarketplaceId = marketplaceId;
        //    Destination destination = new Destination();
        //    request.Destination = destination;
        //    return client.RegisterDestination(request);
        //}

        //public SendTestNotificationToDestinationResponse InvokeSendTestNotificationToDestination(MWSSubscriptionsService client)
        //{
        //    // Create a request.
        //    SendTestNotificationToDestinationInput request = new SendTestNotificationToDestinationInput();
        //    string sellerId = "example";
        //    request.SellerId = sellerId;
        //    string mwsAuthToken = "example";
        //    request.MWSAuthToken = mwsAuthToken;
        //    string marketplaceId = "example";
        //    request.MarketplaceId = marketplaceId;
        //    Destination destination = new Destination();
        //    request.Destination = destination;
        //    return client.SendTestNotificationToDestination(request);
        //}

        //public UpdateSubscriptionResponse InvokeUpdateSubscription(MWSSubscriptionsService client)
        //{
        //    // Create a request.
        //    UpdateSubscriptionInput request = new UpdateSubscriptionInput();
        //    string sellerId = "example";
        //    request.SellerId = sellerId;
        //    string mwsAuthToken = "example";
        //    request.MWSAuthToken = mwsAuthToken;
        //    string marketplaceId = "example";
        //    request.MarketplaceId = marketplaceId;
        //    Subscription subscription = new Subscription();
        //    request.Subscription = subscription;
        //    return client.UpdateSubscription(request);
        //}

        //public AmazonMWS.Subscriptions.Model.GetServiceStatusResponse InvokeGetServiceStatus(MWSSubscriptionsService client)
        //{
        //    // Create a request.
        //    AmazonMWS.Subscriptions.Model.GetServiceStatusRequest request = new AmazonMWS.Subscriptions.Model.GetServiceStatusRequest();
        //    string sellerId = "example";
        //    request.SellerId = sellerId;
        //    string mwsAuthToken = "example";
        //    request.MWSAuthToken = mwsAuthToken;
        //    return client.GetServiceStatus(request);
        //}
    }
}