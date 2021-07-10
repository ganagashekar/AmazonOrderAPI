/*******************************************************************************
 * Copyright 2009-2018 Amazon Services. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License");
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 * This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 * CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 *******************************************************************************
 * List Orders Request
 * API Version: 2013-09-01
 * Library Version: 2018-10-31
 * Generated: Mon Oct 22 22:40:35 UTC 2018
 */

using MWSClientCsRuntime;
using System;
using System.Collections.Generic;

namespace MarketplaceWebServiceOrders.Model
{
    public class ListOrdersRequest : AbstractMwsObject
    {
        private string _sellerId;
        private string _mwsAuthToken;
        private DateTime? _createdAfter;
        private DateTime? _createdBefore;
        private DateTime? _lastUpdatedAfter;
        private DateTime? _lastUpdatedBefore;
        private List<string> _orderStatus;
        private List<string> _marketplaceId;
        private List<string> _fulfillmentChannel;
        private List<string> _paymentMethod;
        private string _buyerEmail;
        private string _sellerOrderId;
        private decimal? _maxResultsPerPage;
        private List<string> _tfmShipmentStatus;
        private List<string> _easyShipShipmentStatus;

        /// <summary>
        /// Gets and sets the SellerId property.
        /// </summary>
        public string SellerId
        {
            get { return _sellerId; }
            set { _sellerId = value; }
        }

        /// <summary>
        /// Sets the SellerId property.
        /// </summary>
        /// <param name="sellerId">SellerId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithSellerId(string sellerId)
        {
            _sellerId = sellerId;
            return this;
        }

        /// <summary>
        /// Checks if SellerId property is set.
        /// </summary>
        /// <returns>true if SellerId property is set.</returns>
        public bool IsSetSellerId()
        {
            return _sellerId != null;
        }

        /// <summary>
        /// Gets and sets the MWSAuthToken property.
        /// </summary>
        public string MWSAuthToken
        {
            get { return _mwsAuthToken; }
            set { _mwsAuthToken = value; }
        }

        /// <summary>
        /// Sets the MWSAuthToken property.
        /// </summary>
        /// <param name="mwsAuthToken">MWSAuthToken property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithMWSAuthToken(string mwsAuthToken)
        {
            _mwsAuthToken = mwsAuthToken;
            return this;
        }

        /// <summary>
        /// Checks if MWSAuthToken property is set.
        /// </summary>
        /// <returns>true if MWSAuthToken property is set.</returns>
        public bool IsSetMWSAuthToken()
        {
            return _mwsAuthToken != null;
        }

        /// <summary>
        /// Gets and sets the CreatedAfter property.
        /// </summary>
        public DateTime CreatedAfter
        {
            get { return _createdAfter.GetValueOrDefault(); }
            set { _createdAfter = value; }
        }

        /// <summary>
        /// Sets the CreatedAfter property.
        /// </summary>
        /// <param name="createdAfter">CreatedAfter property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithCreatedAfter(DateTime createdAfter)
        {
            _createdAfter = createdAfter;
            return this;
        }

        /// <summary>
        /// Checks if CreatedAfter property is set.
        /// </summary>
        /// <returns>true if CreatedAfter property is set.</returns>
        public bool IsSetCreatedAfter()
        {
            return _createdAfter != null;
        }

        /// <summary>
        /// Gets and sets the CreatedBefore property.
        /// </summary>
        public DateTime CreatedBefore
        {
            get { return _createdBefore.GetValueOrDefault(); }
            set { _createdBefore = value; }
        }

        /// <summary>
        /// Sets the CreatedBefore property.
        /// </summary>
        /// <param name="createdBefore">CreatedBefore property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithCreatedBefore(DateTime createdBefore)
        {
            _createdBefore = createdBefore;
            return this;
        }

        /// <summary>
        /// Checks if CreatedBefore property is set.
        /// </summary>
        /// <returns>true if CreatedBefore property is set.</returns>
        public bool IsSetCreatedBefore()
        {
            return _createdBefore != null;
        }

        /// <summary>
        /// Gets and sets the LastUpdatedAfter property.
        /// </summary>
        public DateTime LastUpdatedAfter
        {
            get { return _lastUpdatedAfter.GetValueOrDefault(); }
            set { _lastUpdatedAfter = value; }
        }

        /// <summary>
        /// Sets the LastUpdatedAfter property.
        /// </summary>
        /// <param name="lastUpdatedAfter">LastUpdatedAfter property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithLastUpdatedAfter(DateTime lastUpdatedAfter)
        {
            _lastUpdatedAfter = lastUpdatedAfter;
            return this;
        }

        /// <summary>
        /// Checks if LastUpdatedAfter property is set.
        /// </summary>
        /// <returns>true if LastUpdatedAfter property is set.</returns>
        public bool IsSetLastUpdatedAfter()
        {
            return _lastUpdatedAfter != null;
        }

        /// <summary>
        /// Gets and sets the LastUpdatedBefore property.
        /// </summary>
        public DateTime LastUpdatedBefore
        {
            get { return _lastUpdatedBefore.GetValueOrDefault(); }
            set { _lastUpdatedBefore = value; }
        }

        /// <summary>
        /// Sets the LastUpdatedBefore property.
        /// </summary>
        /// <param name="lastUpdatedBefore">LastUpdatedBefore property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithLastUpdatedBefore(DateTime lastUpdatedBefore)
        {
            _lastUpdatedBefore = lastUpdatedBefore;
            return this;
        }

        /// <summary>
        /// Checks if LastUpdatedBefore property is set.
        /// </summary>
        /// <returns>true if LastUpdatedBefore property is set.</returns>
        public bool IsSetLastUpdatedBefore()
        {
            return _lastUpdatedBefore != null;
        }

        /// <summary>
        /// Gets and sets the OrderStatus property.
        /// </summary>
        public List<string> OrderStatus
        {
            get
            {
                if (_orderStatus == null)
                {
                    _orderStatus = new List<string>();
                }
                return _orderStatus;
            }
            set { _orderStatus = value; }
        }

        /// <summary>
        /// Sets the OrderStatus property.
        /// </summary>
        /// <param name="orderStatus">OrderStatus property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithOrderStatus(string[] orderStatus)
        {
            _orderStatus.AddRange(orderStatus);
            return this;
        }

        /// <summary>
        /// Checks if OrderStatus property is set.
        /// </summary>
        /// <returns>true if OrderStatus property is set.</returns>
        public bool IsSetOrderStatus()
        {
            return OrderStatus.Count > 0;
        }

        /// <summary>
        /// Gets and sets the MarketplaceId property.
        /// </summary>
        public List<string> MarketplaceId
        {
            get
            {
                if (_marketplaceId == null)
                {
                    _marketplaceId = new List<string>();
                }
                return _marketplaceId;
            }
            set { _marketplaceId = value; }
        }

        /// <summary>
        /// Sets the MarketplaceId property.
        /// </summary>
        /// <param name="marketplaceId">MarketplaceId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithMarketplaceId(string[] marketplaceId)
        {
            _marketplaceId.AddRange(marketplaceId);
            return this;
        }

        /// <summary>
        /// Checks if MarketplaceId property is set.
        /// </summary>
        /// <returns>true if MarketplaceId property is set.</returns>
        public bool IsSetMarketplaceId()
        {
            return MarketplaceId.Count > 0;
        }

        /// <summary>
        /// Gets and sets the FulfillmentChannel property.
        /// </summary>
        public List<string> FulfillmentChannel
        {
            get
            {
                if (_fulfillmentChannel == null)
                {
                    _fulfillmentChannel = new List<string>();
                }
                return _fulfillmentChannel;
            }
            set { _fulfillmentChannel = value; }
        }

        /// <summary>
        /// Sets the FulfillmentChannel property.
        /// </summary>
        /// <param name="fulfillmentChannel">FulfillmentChannel property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithFulfillmentChannel(string[] fulfillmentChannel)
        {
            _fulfillmentChannel.AddRange(fulfillmentChannel);
            return this;
        }

        /// <summary>
        /// Checks if FulfillmentChannel property is set.
        /// </summary>
        /// <returns>true if FulfillmentChannel property is set.</returns>
        public bool IsSetFulfillmentChannel()
        {
            return FulfillmentChannel.Count > 0;
        }

        /// <summary>
        /// Gets and sets the PaymentMethod property.
        /// </summary>
        public List<string> PaymentMethod
        {
            get
            {
                if (_paymentMethod == null)
                {
                    _paymentMethod = new List<string>();
                }
                return _paymentMethod;
            }
            set { _paymentMethod = value; }
        }

        /// <summary>
        /// Sets the PaymentMethod property.
        /// </summary>
        /// <param name="paymentMethod">PaymentMethod property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithPaymentMethod(string[] paymentMethod)
        {
            _paymentMethod.AddRange(paymentMethod);
            return this;
        }

        /// <summary>
        /// Checks if PaymentMethod property is set.
        /// </summary>
        /// <returns>true if PaymentMethod property is set.</returns>
        public bool IsSetPaymentMethod()
        {
            return PaymentMethod.Count > 0;
        }

        /// <summary>
        /// Gets and sets the BuyerEmail property.
        /// </summary>
        public string BuyerEmail
        {
            get { return _buyerEmail; }
            set { _buyerEmail = value; }
        }

        /// <summary>
        /// Sets the BuyerEmail property.
        /// </summary>
        /// <param name="buyerEmail">BuyerEmail property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithBuyerEmail(string buyerEmail)
        {
            _buyerEmail = buyerEmail;
            return this;
        }

        /// <summary>
        /// Checks if BuyerEmail property is set.
        /// </summary>
        /// <returns>true if BuyerEmail property is set.</returns>
        public bool IsSetBuyerEmail()
        {
            return _buyerEmail != null;
        }

        /// <summary>
        /// Gets and sets the SellerOrderId property.
        /// </summary>
        public string SellerOrderId
        {
            get { return _sellerOrderId; }
            set { _sellerOrderId = value; }
        }

        /// <summary>
        /// Sets the SellerOrderId property.
        /// </summary>
        /// <param name="sellerOrderId">SellerOrderId property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithSellerOrderId(string sellerOrderId)
        {
            _sellerOrderId = sellerOrderId;
            return this;
        }

        /// <summary>
        /// Checks if SellerOrderId property is set.
        /// </summary>
        /// <returns>true if SellerOrderId property is set.</returns>
        public bool IsSetSellerOrderId()
        {
            return _sellerOrderId != null;
        }

        /// <summary>
        /// Gets and sets the MaxResultsPerPage property.
        /// </summary>
        public decimal MaxResultsPerPage
        {
            get { return _maxResultsPerPage.GetValueOrDefault(); }
            set { _maxResultsPerPage = value; }
        }

        /// <summary>
        /// Sets the MaxResultsPerPage property.
        /// </summary>
        /// <param name="maxResultsPerPage">MaxResultsPerPage property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithMaxResultsPerPage(decimal maxResultsPerPage)
        {
            _maxResultsPerPage = maxResultsPerPage;
            return this;
        }

        /// <summary>
        /// Checks if MaxResultsPerPage property is set.
        /// </summary>
        /// <returns>true if MaxResultsPerPage property is set.</returns>
        public bool IsSetMaxResultsPerPage()
        {
            return _maxResultsPerPage != null;
        }

        /// <summary>
        /// Gets and sets the TFMShipmentStatus property.
        /// </summary>
        public List<string> TFMShipmentStatus
        {
            get
            {
                if (_tfmShipmentStatus == null)
                {
                    _tfmShipmentStatus = new List<string>();
                }
                return _tfmShipmentStatus;
            }
            set { _tfmShipmentStatus = value; }
        }

        /// <summary>
        /// Sets the TFMShipmentStatus property.
        /// </summary>
        /// <param name="tfmShipmentStatus">TFMShipmentStatus property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithTFMShipmentStatus(string[] tfmShipmentStatus)
        {
            _tfmShipmentStatus.AddRange(tfmShipmentStatus);
            return this;
        }

        /// <summary>
        /// Checks if TFMShipmentStatus property is set.
        /// </summary>
        /// <returns>true if TFMShipmentStatus property is set.</returns>
        public bool IsSetTFMShipmentStatus()
        {
            return TFMShipmentStatus.Count > 0;
        }

        /// <summary>
        /// Gets and sets the EasyShipShipmentStatus property.
        /// </summary>
        public List<string> EasyShipShipmentStatus
        {
            get
            {
                if (_easyShipShipmentStatus == null)
                {
                    _easyShipShipmentStatus = new List<string>();
                }
                return _easyShipShipmentStatus;
            }
            set { _easyShipShipmentStatus = value; }
        }

        /// <summary>
        /// Sets the EasyShipShipmentStatus property.
        /// </summary>
        /// <param name="easyShipShipmentStatus">EasyShipShipmentStatus property.</param>
        /// <returns>this instance.</returns>
        public ListOrdersRequest WithEasyShipShipmentStatus(string[] easyShipShipmentStatus)
        {
            _easyShipShipmentStatus.AddRange(easyShipShipmentStatus);
            return this;
        }

        /// <summary>
        /// Checks if EasyShipShipmentStatus property is set.
        /// </summary>
        /// <returns>true if EasyShipShipmentStatus property is set.</returns>
        public bool IsSetEasyShipShipmentStatus()
        {
            return EasyShipShipmentStatus.Count > 0;
        }

        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _sellerId = reader.Read<string>("SellerId");
            _mwsAuthToken = reader.Read<string>("MWSAuthToken");
            _createdAfter = reader.Read<DateTime?>("CreatedAfter");
            _createdBefore = reader.Read<DateTime?>("CreatedBefore");
            _lastUpdatedAfter = reader.Read<DateTime?>("LastUpdatedAfter");
            _lastUpdatedBefore = reader.Read<DateTime?>("LastUpdatedBefore");
            _orderStatus = reader.ReadList<string>("OrderStatus", "Status");
            _marketplaceId = reader.ReadList<string>("MarketplaceId", "Id");
            _fulfillmentChannel = reader.ReadList<string>("FulfillmentChannel", "Channel");
            _paymentMethod = reader.ReadList<string>("PaymentMethod", "Method");
            _buyerEmail = reader.Read<string>("BuyerEmail");
            _sellerOrderId = reader.Read<string>("SellerOrderId");
            _maxResultsPerPage = reader.Read<decimal?>("MaxResultsPerPage");
            _tfmShipmentStatus = reader.ReadList<string>("TFMShipmentStatus", "Status");
            _easyShipShipmentStatus = reader.ReadList<string>("EasyShipShipmentStatus", "Status");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("SellerId", _sellerId);
            writer.Write("MWSAuthToken", _mwsAuthToken);
            writer.Write("CreatedAfter", _createdAfter);
            writer.Write("CreatedBefore", _createdBefore);
            writer.Write("LastUpdatedAfter", _lastUpdatedAfter);
            writer.Write("LastUpdatedBefore", _lastUpdatedBefore);
            writer.WriteList("OrderStatus", "Status", _orderStatus);
            writer.WriteList("MarketplaceId", "Id", _marketplaceId);
            writer.WriteList("FulfillmentChannel", "Channel", _fulfillmentChannel);
            writer.WriteList("PaymentMethod", "Method", _paymentMethod);
            writer.Write("BuyerEmail", _buyerEmail);
            writer.Write("SellerOrderId", _sellerOrderId);
            writer.Write("MaxResultsPerPage", _maxResultsPerPage);
            writer.WriteList("TFMShipmentStatus", "Status", _tfmShipmentStatus);
            writer.WriteList("EasyShipShipmentStatus", "Status", _easyShipShipmentStatus);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "ListOrdersRequest", this);
        }

        public ListOrdersRequest(string sellerId, List<string> marketplaceId) : base()
        {
            _sellerId = sellerId;
            _marketplaceId = marketplaceId;
        }

        public ListOrdersRequest() : base()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(SellerId)}={SellerId}, {nameof(MWSAuthToken)}={MWSAuthToken}, {nameof(CreatedAfter)}={CreatedAfter.ToString()}, {nameof(CreatedBefore)}={CreatedBefore.ToString()}, {nameof(LastUpdatedAfter)}={LastUpdatedAfter.ToString()}, {nameof(LastUpdatedBefore)}={LastUpdatedBefore.ToString()}, {nameof(OrderStatus)}={OrderStatus}, {nameof(MarketplaceId)}={MarketplaceId}, {nameof(FulfillmentChannel)}={FulfillmentChannel}, {nameof(PaymentMethod)}={PaymentMethod}, {nameof(BuyerEmail)}={BuyerEmail}, {nameof(SellerOrderId)}={SellerOrderId}, {nameof(MaxResultsPerPage)}={MaxResultsPerPage.ToString()}, {nameof(TFMShipmentStatus)}={TFMShipmentStatus}, {nameof(EasyShipShipmentStatus)}={EasyShipShipmentStatus}}}";
        }
    }
}