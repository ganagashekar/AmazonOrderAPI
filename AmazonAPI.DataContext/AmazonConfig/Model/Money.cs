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
 * Money
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
    public class Money : AbstractMwsObject
    {
        [Key]
        public long Id { set; get; }

        private string _currencyCode;
        private string _amount;

        /// <summary>
        /// Gets and sets the CurrencyCode property.
        /// </summary>
        public string CurrencyCode
        {
            get { return _currencyCode; }
            set { _currencyCode = value; }
        }

        /// <summary>
        /// Sets the CurrencyCode property.
        /// </summary>
        /// <param name="currencyCode">CurrencyCode property.</param>
        /// <returns>this instance.</returns>
        public Money WithCurrencyCode(string currencyCode)
        {
            _currencyCode = currencyCode;
            return this;
        }

        /// <summary>
        /// Checks if CurrencyCode property is set.
        /// </summary>
        /// <returns>true if CurrencyCode property is set.</returns>
        public bool IsSetCurrencyCode()
        {
            return _currencyCode != null;
        }

        /// <summary>
        /// Gets and sets the Amount property.
        /// </summary>
        public string Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        /// <summary>
        /// Sets the Amount property.
        /// </summary>
        /// <param name="amount">Amount property.</param>
        /// <returns>this instance.</returns>
        public Money WithAmount(string amount)
        {
            _amount = amount;
            return this;
        }

        /// <summary>
        /// Checks if Amount property is set.
        /// </summary>
        /// <returns>true if Amount property is set.</returns>
        public bool IsSetAmount()
        {
            return _amount != null;
        }

        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _currencyCode = reader.Read<string>("CurrencyCode");
            _amount = reader.Read<string>("Amount");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("CurrencyCode", _currencyCode);
            writer.Write("Amount", _amount);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "Money", this);
        }

        public Money() : base()
        {
        }
    }
}