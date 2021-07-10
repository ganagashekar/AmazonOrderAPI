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
 * Payment Execution Detail Item
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
    public class PaymentExecutionDetailItem : AbstractMwsObject
    {
        [Key]
        public long Id { set; get; }

        private Money _payment;
        private string _paymentMethod;

        /// <summary>
        /// Gets and sets the Payment property.
        /// </summary>
        public virtual Money Payment
        {
            get { return _payment; }
            set { _payment = value; }
        }

        /// <summary>
        /// Sets the Payment property.
        /// </summary>
        /// <param name="payment">Payment property.</param>
        /// <returns>this instance.</returns>
        public PaymentExecutionDetailItem WithPayment(Money payment)
        {
            _payment = payment;
            return this;
        }

        /// <summary>
        /// Checks if Payment property is set.
        /// </summary>
        /// <returns>true if Payment property is set.</returns>
        public bool IsSetPayment()
        {
            return _payment != null;
        }

        /// <summary>
        /// Gets and sets the PaymentMethod property.
        /// </summary>
        public string PaymentMethod
        {
            get { return _paymentMethod; }
            set { _paymentMethod = value; }
        }

        /// <summary>
        /// Sets the PaymentMethod property.
        /// </summary>
        /// <param name="paymentMethod">PaymentMethod property.</param>
        /// <returns>this instance.</returns>
        public PaymentExecutionDetailItem WithPaymentMethod(string paymentMethod)
        {
            _paymentMethod = paymentMethod;
            return this;
        }

        /// <summary>
        /// Checks if PaymentMethod property is set.
        /// </summary>
        /// <returns>true if PaymentMethod property is set.</returns>
        public bool IsSetPaymentMethod()
        {
            return _paymentMethod != null;
        }

        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _payment = reader.Read<Money>("Payment");
            _paymentMethod = reader.Read<string>("PaymentMethod");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("Payment", _payment);
            writer.Write("PaymentMethod", _paymentMethod);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "PaymentExecutionDetailItem", this);
        }

        public PaymentExecutionDetailItem(Money payment, string paymentMethod) : base()
        {
            _payment = payment;
            _paymentMethod = paymentMethod;
        }

        public PaymentExecutionDetailItem() : base()
        {
        }
    }
}