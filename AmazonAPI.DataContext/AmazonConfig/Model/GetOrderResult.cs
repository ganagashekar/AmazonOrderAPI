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
 * Get Order Result
 * API Version: 2013-09-01
 * Library Version: 2018-10-31
 * Generated: Mon Oct 22 22:40:35 UTC 2018
 */

using MWSClientCsRuntime;
using System.Collections.Generic;

namespace MarketplaceWebServiceOrders.Model
{
    public class GetOrderResult : AbstractMwsObject
    {
        private List<Order> _orders;

        /// <summary>
        /// Gets and sets the Orders property.
        /// </summary>
        public List<Order> Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new List<Order>();
                }
                return _orders;
            }
            set { _orders = value; }
        }

        /// <summary>
        /// Sets the Orders property.
        /// </summary>
        /// <param name="orders">Orders property.</param>
        /// <returns>this instance.</returns>
        public GetOrderResult WithOrders(Order[] orders)
        {
            _orders.AddRange(orders);
            return this;
        }

        /// <summary>
        /// Checks if Orders property is set.
        /// </summary>
        /// <returns>true if Orders property is set.</returns>
        public bool IsSetOrders()
        {
            return Orders.Count > 0;
        }

        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _orders = reader.ReadList<Order>("Orders", "Order");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.WriteList("Orders", "Order", _orders);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "GetOrderResult", this);
        }

        public GetOrderResult(List<Order> orders) : base()
        {
            _orders = orders;
        }

        public GetOrderResult() : base()
        {
        }
    }
}