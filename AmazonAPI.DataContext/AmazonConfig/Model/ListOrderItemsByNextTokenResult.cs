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
 * List Order Items By Next Token Result
 * API Version: 2013-09-01
 * Library Version: 2018-10-31
 * Generated: Mon Oct 22 22:40:35 UTC 2018
 */

using MWSClientCsRuntime;
using System.Collections.Generic;

namespace MarketplaceWebServiceOrders.Model
{
    public class ListOrderItemsByNextTokenResult : AbstractMwsObject
    {
        private string _nextToken;
        private string _amazonOrderId;
        private List<OrderItem> _orderItems;

        /// <summary>
        /// Gets and sets the NextToken property.
        /// </summary>
        public string NextToken
        {
            get { return _nextToken; }
            set { _nextToken = value; }
        }

        /// <summary>
        /// Sets the NextToken property.
        /// </summary>
        /// <param name="nextToken">NextToken property.</param>
        /// <returns>this instance.</returns>
        public ListOrderItemsByNextTokenResult WithNextToken(string nextToken)
        {
            _nextToken = nextToken;
            return this;
        }

        /// <summary>
        /// Checks if NextToken property is set.
        /// </summary>
        /// <returns>true if NextToken property is set.</returns>
        public bool IsSetNextToken()
        {
            return _nextToken != null;
        }

        /// <summary>
        /// Gets and sets the AmazonOrderId property.
        /// </summary>
        public string AmazonOrderId
        {
            get { return _amazonOrderId; }
            set { _amazonOrderId = value; }
        }

        /// <summary>
        /// Sets the AmazonOrderId property.
        /// </summary>
        /// <param name="amazonOrderId">AmazonOrderId property.</param>
        /// <returns>this instance.</returns>
        public ListOrderItemsByNextTokenResult WithAmazonOrderId(string amazonOrderId)
        {
            _amazonOrderId = amazonOrderId;
            return this;
        }

        /// <summary>
        /// Checks if AmazonOrderId property is set.
        /// </summary>
        /// <returns>true if AmazonOrderId property is set.</returns>
        public bool IsSetAmazonOrderId()
        {
            return _amazonOrderId != null;
        }

        /// <summary>
        /// Gets and sets the OrderItems property.
        /// </summary>
        public List<OrderItem> OrderItems
        {
            get
            {
                if (_orderItems == null)
                {
                    _orderItems = new List<OrderItem>();
                }
                return _orderItems;
            }
            set { _orderItems = value; }
        }

        /// <summary>
        /// Sets the OrderItems property.
        /// </summary>
        /// <param name="orderItems">OrderItems property.</param>
        /// <returns>this instance.</returns>
        public ListOrderItemsByNextTokenResult WithOrderItems(OrderItem[] orderItems)
        {
            _orderItems.AddRange(orderItems);
            return this;
        }

        /// <summary>
        /// Checks if OrderItems property is set.
        /// </summary>
        /// <returns>true if OrderItems property is set.</returns>
        public bool IsSetOrderItems()
        {
            return OrderItems.Count > 0;
        }

        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _nextToken = reader.Read<string>("NextToken");
            _amazonOrderId = reader.Read<string>("AmazonOrderId");
            _orderItems = reader.ReadList<OrderItem>("OrderItems", "OrderItem");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("NextToken", _nextToken);
            writer.Write("AmazonOrderId", _amazonOrderId);
            writer.WriteList("OrderItems", "OrderItem", _orderItems);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "ListOrderItemsByNextTokenResult", this);
        }

        public ListOrderItemsByNextTokenResult(string amazonOrderId) : base()
        {
            _amazonOrderId = amazonOrderId;
        }

        public ListOrderItemsByNextTokenResult() : base()
        {
        }
    }
}