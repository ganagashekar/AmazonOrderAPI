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
 * Product Info Detail
 * API Version: 2013-09-01
 * Library Version: 2018-10-31
 * Generated: Mon Oct 22 22:40:35 UTC 2018
 */

using MWSClientCsRuntime;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketplaceWebServiceOrders.Model
{
    [NotMapped]
    public class ProductInfoDetail : AbstractMwsObject
    {
        [Key]
        public long Id { set; get; }

        private decimal? _numberOfItems;

        /// <summary>
        /// Gets and sets the NumberOfItems property.
        /// </summary>
        public decimal NumberOfItems
        {
            get { return _numberOfItems.GetValueOrDefault(); }
            set { _numberOfItems = value; }
        }

        /// <summary>
        /// Sets the NumberOfItems property.
        /// </summary>
        /// <param name="numberOfItems">NumberOfItems property.</param>
        /// <returns>this instance.</returns>
        public ProductInfoDetail WithNumberOfItems(decimal numberOfItems)
        {
            _numberOfItems = numberOfItems;
            return this;
        }

        /// <summary>
        /// Checks if NumberOfItems property is set.
        /// </summary>
        /// <returns>true if NumberOfItems property is set.</returns>
        public bool IsSetNumberOfItems()
        {
            return _numberOfItems != null;
        }

        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _numberOfItems = reader.Read<decimal?>("NumberOfItems");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("NumberOfItems", _numberOfItems);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "ProductInfoDetail", this);
        }

        public ProductInfoDetail() : base()
        {
        }
    }
}