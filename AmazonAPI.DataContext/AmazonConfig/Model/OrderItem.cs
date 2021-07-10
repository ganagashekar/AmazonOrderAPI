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
 * Order Item
 * API Version: 2013-09-01
 * Library Version: 2018-10-31
 * Generated: Mon Oct 22 22:40:35 UTC 2018
 */

using AmazonOrderAPI.DataContext.Entities;
using MWSClientCsRuntime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketplaceWebServiceOrders.Model
{
    [Obsolete]
    [Table("OrderItems", Schema = "amz")]
    public class OrderItem : AbstractMwsObject
    {
        [Key]
        public long Id { set; get; }

        public long OrderId { set; get; }
        public virtual Order Orders { set; get; }
        private string _asin;
        private string _sellerSKU;
        private string _orderItemId;
        private string _title;
        private decimal _quantityOrdered;
        private decimal? _quantityShipped;
        private ProductInfoDetail _productInfo;
        private PointsGrantedDetail _pointsGranted;
        private Money _itemPrice;
        private Money _shippingPrice;
        private Money _giftWrapPrice;
        private Money _itemTax;
        private Money _shippingTax;
        private Money _giftWrapTax;
        private Money _shippingDiscount;
        private Money _shippingDiscountTax;
        private Money _promotionDiscount;
        private Money _promotionDiscountTax;

        private List<string> _promotionIds;
        private Money _codFee;
        private Money _codFeeDiscount;
        private bool? _isGift;
        private string _giftMessageText;
        private string _giftWrapLevel;
        private InvoiceData _invoiceData;
        private string _conditionNote;
        private string _conditionId;
        private string _conditionSubtypeId;
        private string _scheduledDeliveryStartDate;
        private string _scheduledDeliveryEndDate;
        private string _priceDesignation;
        private BuyerCustomizedInfoDetail _buyerCustomizedInfo;
        private TaxCollection _taxCollection;
        private bool? _serialNumberRequired;
        private bool? _isTransparency;
        private long? _WarehouseId { set; get; }

        public long ItemStatusId { set; get; }
        public long SellerId { set; get; }
        [ForeignKey("SellerId")]
        public virtual Seller Seller { set; get; }

        [ForeignKey("ItemStatusId")]
        public virtual ReferenceRecord ItemStatus { set; get; }

        public string eZTrackReferenceNumber { set; get; }
        public string PickupFailureReason { set; get; }
        public string ConsignmentNo { set; get; }
        private DateTime? dateCreated { set; get; }
        // public bool IsFailedAteZTracker { set; get; }

        public DateTime? CreatedDate
        {
            get
            {
                return dateCreated.HasValue
                   ? dateCreated.Value
                   : DateTime.Now;
            }

            set { dateCreated = value; }
        }

        /// <summary>
        /// Gets and sets the ASIN property.
        /// </summary>
        public string ASIN
        {
            get { return _asin; }
            set { _asin = value; }
        }

        /// <summary>
        /// Sets the ASIN property.
        /// </summary>
        /// <param name="asin">ASIN property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithASIN(string asin)
        {
            _asin = asin;
            return this;
        }

        /// <summary>
        /// Checks if ASIN property is set.
        /// </summary>
        /// <returns>true if ASIN property is set.</returns>
        public bool IsSetASIN()
        {
            return _asin != null;
        }

        /// <summary>
        /// Gets and sets the SellerSKU property.
        /// </summary>
        public string SellerSKU
        {
            get { return _sellerSKU; }
            set { _sellerSKU = value; }
        }

        /// <summary>
        /// Sets the SellerSKU property.
        /// </summary>
        /// <param name="sellerSKU">SellerSKU property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithSellerSKU(string sellerSKU)
        {
            _sellerSKU = sellerSKU;
            return this;
        }

        /// <summary>
        /// Checks if SellerSKU property is set.
        /// </summary>
        /// <returns>true if SellerSKU property is set.</returns>
        public bool IsSetSellerSKU()
        {
            return _sellerSKU != null;
        }

        /// <summary>
        /// Gets and sets the OrderItemId property.
        /// </summary>
        public string OrderItemId
        {
            get { return _orderItemId; }
            set { _orderItemId = value; }
        }

        /// <summary>
        /// Sets the OrderItemId property.
        /// </summary>
        /// <param name="orderItemId">OrderItemId property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithOrderItemId(string orderItemId)
        {
            _orderItemId = orderItemId;
            return this;
        }

        /// <summary>
        /// Checks if OrderItemId property is set.
        /// </summary>
        /// <returns>true if OrderItemId property is set.</returns>
        public bool IsSetOrderItemId()
        {
            return _orderItemId != null;
        }

        /// <summary>
        /// Gets and sets the Title property.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Sets the Title property.
        /// </summary>
        /// <param name="title">Title property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithTitle(string title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        /// Checks if Title property is set.
        /// </summary>
        /// <returns>true if Title property is set.</returns>
        public bool IsSetTitle()
        {
            return _title != null;
        }

        /// <summary>
        /// Gets and sets the QuantityOrdered property.
        /// </summary>
        public decimal QuantityOrdered
        {
            get { return _quantityOrdered; }
            set { _quantityOrdered = value; }
        }

        /// <summary>
        /// Sets the QuantityOrdered property.
        /// </summary>
        /// <param name="quantityOrdered">QuantityOrdered property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithQuantityOrdered(decimal quantityOrdered)
        {
            _quantityOrdered = quantityOrdered;
            return this;
        }

        /// <summary>
        /// Checks if QuantityOrdered property is set.
        /// </summary>
        /// <returns>true if QuantityOrdered property is set.</returns>
        public bool IsSetQuantityOrdered()
        {
            return _quantityOrdered != null;
        }

        /// <summary>
        /// Gets and sets the QuantityShipped property.
        /// </summary>
        public decimal QuantityShipped
        {
            get { return _quantityShipped.GetValueOrDefault(); }
            set { _quantityShipped = value; }
        }

        /// <summary>
        /// Sets the QuantityShipped property.
        /// </summary>
        /// <param name="quantityShipped">QuantityShipped property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithQuantityShipped(decimal quantityShipped)
        {
            _quantityShipped = quantityShipped;
            return this;
        }

        /// <summary>
        /// Checks if QuantityShipped property is set.
        /// </summary>
        /// <returns>true if QuantityShipped property is set.</returns>
        public bool IsSetQuantityShipped()
        {
            return _quantityShipped != null;
        }

        /// <summary>
        /// Gets and sets the ProductInfo property.
        /// </summary>
        public virtual ProductInfoDetail ProductInfo
        {
            get { return _productInfo; }
            set { _productInfo = value; }
        }

        /// <summary>
        /// Sets the ProductInfo property.
        /// </summary>
        /// <param name="productInfo">ProductInfo property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithProductInfo(ProductInfoDetail productInfo)
        {
            _productInfo = productInfo;
            return this;
        }

        /// <summary>
        /// Checks if ProductInfo property is set.
        /// </summary>
        /// <returns>true if ProductInfo property is set.</returns>
        public bool IsSetProductInfo()
        {
            return _productInfo != null;
        }

        /// <summary>
        /// Gets and sets the PointsGranted property.
        /// </summary>
        public virtual PointsGrantedDetail PointsGranted
        {
            get { return _pointsGranted; }
            set { _pointsGranted = value; }
        }

        /// <summary>
        /// Sets the PointsGranted property.
        /// </summary>
        /// <param name="pointsGranted">PointsGranted property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithPointsGranted(PointsGrantedDetail pointsGranted)
        {
            _pointsGranted = pointsGranted;
            return this;
        }

        /// <summary>
        /// Checks if PointsGranted property is set.
        /// </summary>
        /// <returns>true if PointsGranted property is set.</returns>
        public bool IsSetPointsGranted()
        {
            return _pointsGranted != null;
        }

        /// <summary>
        /// Gets and sets the ItemPrice property.
        /// </summary>
        public virtual Money ItemPrice
        {
            get { return _itemPrice; }
            set { _itemPrice = value; }
        }

        /// <summary>
        /// Sets the ItemPrice property.
        /// </summary>
        /// <param name="itemPrice">ItemPrice property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithItemPrice(Money itemPrice)
        {
            _itemPrice = itemPrice;
            return this;
        }

        /// <summary>
        /// Checks if ItemPrice property is set.
        /// </summary>
        /// <returns>true if ItemPrice property is set.</returns>
        public bool IsSetItemPrice()
        {
            return _itemPrice != null;
        }

        /// <summary>
        /// Gets and sets the ShippingPrice property.
        /// </summary>
        public virtual Money ShippingPrice
        {
            get { return _shippingPrice; }
            set { _shippingPrice = value; }
        }

        /// <summary>
        /// Sets the ShippingPrice property.
        /// </summary>
        /// <param name="shippingPrice">ShippingPrice property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithShippingPrice(Money shippingPrice)
        {
            _shippingPrice = shippingPrice;
            return this;
        }

        /// <summary>
        /// Checks if ShippingPrice property is set.
        /// </summary>
        /// <returns>true if ShippingPrice property is set.</returns>
        public bool IsSetShippingPrice()
        {
            return _shippingPrice != null;
        }

        /// <summary>
        /// Gets and sets the GiftWrapPrice property.
        /// </summary>
        public virtual Money GiftWrapPrice
        {
            get { return _giftWrapPrice; }
            set { _giftWrapPrice = value; }
        }

        /// <summary>
        /// Sets the GiftWrapPrice property.
        /// </summary>
        /// <param name="giftWrapPrice">GiftWrapPrice property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithGiftWrapPrice(Money giftWrapPrice)
        {
            _giftWrapPrice = giftWrapPrice;
            return this;
        }

        /// <summary>
        /// Checks if GiftWrapPrice property is set.
        /// </summary>
        /// <returns>true if GiftWrapPrice property is set.</returns>
        public bool IsSetGiftWrapPrice()
        {
            return _giftWrapPrice != null;
        }

        /// <summary>
        /// Gets and sets the ItemTax property.
        /// </summary>
        public virtual Money ItemTax
        {
            get { return _itemTax; }
            set { _itemTax = value; }
        }

        /// <summary>
        /// Sets the ItemTax property.
        /// </summary>
        /// <param name="itemTax">ItemTax property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithItemTax(Money itemTax)
        {
            _itemTax = itemTax;
            return this;
        }

        /// <summary>
        /// Checks if ItemTax property is set.
        /// </summary>
        /// <returns>true if ItemTax property is set.</returns>
        public bool IsSetItemTax()
        {
            return _itemTax != null;
        }

        /// <summary>
        /// Gets and sets the ShippingTax property.
        /// </summary>
        public virtual Money ShippingTax
        {
            get { return _shippingTax; }
            set { _shippingTax = value; }
        }

        /// <summary>
        /// Sets the ShippingTax property.
        /// </summary>
        /// <param name="shippingTax">ShippingTax property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithShippingTax(Money shippingTax)
        {
            _shippingTax = shippingTax;
            return this;
        }

        /// <summary>
        /// Checks if ShippingTax property is set.
        /// </summary>
        /// <returns>true if ShippingTax property is set.</returns>
        public bool IsSetShippingTax()
        {
            return _shippingTax != null;
        }

        /// <summary>
        /// Gets and sets the GiftWrapTax property.
        /// </summary>
        public virtual Money GiftWrapTax
        {
            get { return _giftWrapTax; }
            set { _giftWrapTax = value; }
        }

        /// <summary>
        /// Sets the GiftWrapTax property.
        /// </summary>
        /// <param name="giftWrapTax">GiftWrapTax property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithGiftWrapTax(Money giftWrapTax)
        {
            _giftWrapTax = giftWrapTax;
            return this;
        }

        /// <summary>
        /// Checks if GiftWrapTax property is set.
        /// </summary>
        /// <returns>true if GiftWrapTax property is set.</returns>
        public bool IsSetGiftWrapTax()
        {
            return _giftWrapTax != null;
        }

        /// <summary>
        /// Gets and sets the ShippingDiscount property.
        /// </summary>
        public virtual Money ShippingDiscount
        {
            get { return _shippingDiscount; }
            set { _shippingDiscount = value; }
        }

        /// <summary>
        /// Sets the ShippingDiscount property.
        /// </summary>
        /// <param name="shippingDiscount">ShippingDiscount property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithShippingDiscount(Money shippingDiscount)
        {
            _shippingDiscount = shippingDiscount;
            return this;
        }

        /// <summary>
        /// Checks if ShippingDiscount property is set.
        /// </summary>
        /// <returns>true if ShippingDiscount property is set.</returns>
        public bool IsSetShippingDiscount()
        {
            return _shippingDiscount != null;
        }

        /// <summary>
        /// Gets and sets the ShippingDiscountTax property.
        /// </summary>
        public virtual Money ShippingDiscountTax
        {
            get { return _shippingDiscountTax; }
            set { _shippingDiscountTax = value; }
        }

        /// <summary>
        /// Sets the ShippingDiscountTax property.
        /// </summary>
        /// <param name="shippingDiscountTax">ShippingDiscountTax property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithShippingDiscountTax(Money shippingDiscountTax)
        {
            _shippingDiscountTax = shippingDiscountTax;
            return this;
        }

        /// <summary>
        /// Checks if ShippingDiscountTax property is set.
        /// </summary>
        /// <returns>true if ShippingDiscountTax property is set.</returns>
        public bool IsSetShippingDiscountTax()
        {
            return _shippingDiscountTax != null;
        }

        /// <summary>
        /// Gets and sets the PromotionDiscount property.
        /// </summary>
        public virtual Money PromotionDiscount
        {
            get { return _promotionDiscount; }
            set { _promotionDiscount = value; }
        }

        /// <summary>
        /// Sets the PromotionDiscount property.
        /// </summary>
        /// <param name="promotionDiscount">PromotionDiscount property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithPromotionDiscount(Money promotionDiscount)
        {
            _promotionDiscount = promotionDiscount;
            return this;
        }

        /// <summary>
        /// Checks if PromotionDiscount property is set.
        /// </summary>
        /// <returns>true if PromotionDiscount property is set.</returns>
        public bool IsSetPromotionDiscount()
        {
            return _promotionDiscount != null;
        }

        /// <summary>
        /// Gets and sets the PromotionDiscountTax property.
        /// </summary>
        public virtual Money PromotionDiscountTax
        {
            get { return _promotionDiscountTax; }
            set { _promotionDiscountTax = value; }
        }

        /// <summary>
        /// Sets the PromotionDiscountTax property.
        /// </summary>
        /// <param name="promotionDiscountTax">PromotionDiscountTax property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithPromotionDiscountTax(Money promotionDiscountTax)
        {
            _promotionDiscountTax = promotionDiscountTax;
            return this;
        }

        /// <summary>
        /// Checks if PromotionDiscountTax property is set.
        /// </summary>
        /// <returns>true if PromotionDiscountTax property is set.</returns>
        public bool IsSetPromotionDiscountTax()
        {
            return _promotionDiscountTax != null;
        }

        /// <summary>
        /// Gets and sets the PromotionIds property.
        /// </summary>
        [NotMapped]
        public List<string> PromotionIds
        {
            get
            {
                if (_promotionIds == null)
                {
                    _promotionIds = new List<string>();
                }
                return _promotionIds;
            }
            set { _promotionIds = value; }
        }

        /// <summary>
        /// Sets the PromotionIds property.
        /// </summary>
        /// <param name="promotionIds">PromotionIds property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithPromotionIds(string[] promotionIds)
        {
            _promotionIds.AddRange(promotionIds);
            return this;
        }

        /// <summary>
        /// Checks if PromotionIds property is set.
        /// </summary>
        /// <returns>true if PromotionIds property is set.</returns>
        public bool IsSetPromotionIds()
        {
            return PromotionIds.Count > 0;
        }

        /// <summary>
        /// Gets and sets the CODFee property.
        /// </summary>
        ///
        [NotMapped]
        public virtual Money CODFee
        {
            get { return _codFee; }
            set { _codFee = value; }
        }

        /// <summary>
        /// Sets the CODFee property.
        /// </summary>
        /// <param name="codFee">CODFee property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithCODFee(Money codFee)
        {
            _codFee = codFee;
            return this;
        }

        /// <summary>
        /// Checks if CODFee property is set.
        /// </summary>
        /// <returns>true if CODFee property is set.</returns>
        public bool IsSetCODFee()
        {
            return _codFee != null;
        }

        /// <summary>
        /// Gets and sets the CODFeeDiscount property.
        /// </summary>
        ///
        [NotMapped]
        public virtual Money CODFeeDiscount
        {
            get { return _codFeeDiscount; }
            set { _codFeeDiscount = value; }
        }

        /// <summary>
        /// Sets the CODFeeDiscount property.
        /// </summary>
        /// <param name="codFeeDiscount">CODFeeDiscount property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithCODFeeDiscount(Money codFeeDiscount)
        {
            _codFeeDiscount = codFeeDiscount;
            return this;
        }

        /// <summary>
        /// Checks if CODFeeDiscount property is set.
        /// </summary>
        /// <returns>true if CODFeeDiscount property is set.</returns>
        public bool IsSetCODFeeDiscount()
        {
            return _codFeeDiscount != null;
        }

        /// <summary>
        /// Gets and sets the IsGift property.
        /// </summary>
        public bool IsGift
        {
            get { return _isGift.GetValueOrDefault(); }
            set { _isGift = value; }
        }

        /// <summary>
        /// Sets the IsGift property.
        /// </summary>
        /// <param name="isGift">IsGift property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithIsGift(bool isGift)
        {
            _isGift = isGift;
            return this;
        }

        /// <summary>
        /// Checks if IsGift property is set.
        /// </summary>
        /// <returns>true if IsGift property is set.</returns>
        public bool IsSetIsGift()
        {
            return _isGift != null;
        }

        /// <summary>
        /// Gets and sets the GiftMessageText property.
        /// </summary>
        public string GiftMessageText
        {
            get { return _giftMessageText; }
            set { _giftMessageText = value; }
        }

        /// <summary>
        /// Sets the GiftMessageText property.
        /// </summary>
        /// <param name="giftMessageText">GiftMessageText property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithGiftMessageText(string giftMessageText)
        {
            _giftMessageText = giftMessageText;
            return this;
        }

        /// <summary>
        /// Checks if GiftMessageText property is set.
        /// </summary>
        /// <returns>true if GiftMessageText property is set.</returns>
        public bool IsSetGiftMessageText()
        {
            return _giftMessageText != null;
        }

        /// <summary>
        /// Gets and sets the GiftWrapLevel property.
        /// </summary>
        public string GiftWrapLevel
        {
            get { return _giftWrapLevel; }
            set { _giftWrapLevel = value; }
        }

        /// <summary>
        /// Sets the GiftWrapLevel property.
        /// </summary>
        /// <param name="giftWrapLevel">GiftWrapLevel property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithGiftWrapLevel(string giftWrapLevel)
        {
            _giftWrapLevel = giftWrapLevel;
            return this;
        }

        /// <summary>
        /// Checks if GiftWrapLevel property is set.
        /// </summary>
        /// <returns>true if GiftWrapLevel property is set.</returns>
        public bool IsSetGiftWrapLevel()
        {
            return _giftWrapLevel != null;
        }

        /// <summary>
        /// Gets and sets the InvoiceData property.
        /// </summary>
        public virtual InvoiceData InvoiceData
        {
            get { return _invoiceData; }
            set { _invoiceData = value; }
        }

        /// <summary>
        /// Sets the InvoiceData property.
        /// </summary>
        /// <param name="invoiceData">InvoiceData property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithInvoiceData(InvoiceData invoiceData)
        {
            _invoiceData = invoiceData;
            return this;
        }

        /// <summary>
        /// Checks if InvoiceData property is set.
        /// </summary>
        /// <returns>true if InvoiceData property is set.</returns>
        public bool IsSetInvoiceData()
        {
            return _invoiceData != null;
        }

        /// <summary>
        /// Gets and sets the ConditionNote property.
        /// </summary>
        public string ConditionNote
        {
            get { return _conditionNote; }
            set { _conditionNote = value; }
        }

        /// <summary>
        /// Sets the ConditionNote property.
        /// </summary>
        /// <param name="conditionNote">ConditionNote property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithConditionNote(string conditionNote)
        {
            _conditionNote = conditionNote;
            return this;
        }

        /// <summary>
        /// Checks if ConditionNote property is set.
        /// </summary>
        /// <returns>true if ConditionNote property is set.</returns>
        public bool IsSetConditionNote()
        {
            return _conditionNote != null;
        }

        /// <summary>
        /// Gets and sets the ConditionId property.
        /// </summary>
        public string ConditionId
        {
            get { return _conditionId; }
            set { _conditionId = value; }
        }

        /// <summary>
        /// Sets the ConditionId property.
        /// </summary>
        /// <param name="conditionId">ConditionId property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithConditionId(string conditionId)
        {
            _conditionId = conditionId;
            return this;
        }

        /// <summary>
        /// Checks if ConditionId property is set.
        /// </summary>
        /// <returns>true if ConditionId property is set.</returns>
        public bool IsSetConditionId()
        {
            return _conditionId != null;
        }

        /// <summary>
        /// Gets and sets the ConditionSubtypeId property.
        /// </summary>
        public string ConditionSubtypeId
        {
            get { return _conditionSubtypeId; }
            set { _conditionSubtypeId = value; }
        }

        /// <summary>
        /// Sets the ConditionSubtypeId property.
        /// </summary>
        /// <param name="conditionSubtypeId">ConditionSubtypeId property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithConditionSubtypeId(string conditionSubtypeId)
        {
            _conditionSubtypeId = conditionSubtypeId;
            return this;
        }

        /// <summary>
        /// Checks if ConditionSubtypeId property is set.
        /// </summary>
        /// <returns>true if ConditionSubtypeId property is set.</returns>
        public bool IsSetConditionSubtypeId()
        {
            return _conditionSubtypeId != null;
        }

        /// <summary>
        /// Gets and sets the ScheduledDeliveryStartDate property.
        /// </summary>
        public string ScheduledDeliveryStartDate
        {
            get { return _scheduledDeliveryStartDate; }
            set { _scheduledDeliveryStartDate = value; }
        }

        /// <summary>
        /// Sets the ScheduledDeliveryStartDate property.
        /// </summary>
        /// <param name="scheduledDeliveryStartDate">ScheduledDeliveryStartDate property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithScheduledDeliveryStartDate(string scheduledDeliveryStartDate)
        {
            _scheduledDeliveryStartDate = scheduledDeliveryStartDate;
            return this;
        }

        /// <summary>
        /// Checks if ScheduledDeliveryStartDate property is set.
        /// </summary>
        /// <returns>true if ScheduledDeliveryStartDate property is set.</returns>
        public bool IsSetScheduledDeliveryStartDate()
        {
            return _scheduledDeliveryStartDate != null;
        }

        /// <summary>
        /// Gets and sets the ScheduledDeliveryEndDate property.
        /// </summary>
        public string ScheduledDeliveryEndDate
        {
            get { return _scheduledDeliveryEndDate; }
            set { _scheduledDeliveryEndDate = value; }
        }

        /// <summary>
        /// Sets the ScheduledDeliveryEndDate property.
        /// </summary>
        /// <param name="scheduledDeliveryEndDate">ScheduledDeliveryEndDate property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithScheduledDeliveryEndDate(string scheduledDeliveryEndDate)
        {
            _scheduledDeliveryEndDate = scheduledDeliveryEndDate;
            return this;
        }

        /// <summary>
        /// Checks if ScheduledDeliveryEndDate property is set.
        /// </summary>
        /// <returns>true if ScheduledDeliveryEndDate property is set.</returns>
        public bool IsSetScheduledDeliveryEndDate()
        {
            return _scheduledDeliveryEndDate != null;
        }

        /// <summary>
        /// Gets and sets the PriceDesignation property.
        /// </summary>
        public string PriceDesignation
        {
            get { return _priceDesignation; }
            set { _priceDesignation = value; }
        }

        /// <summary>
        /// Sets the PriceDesignation property.
        /// </summary>
        /// <param name="priceDesignation">PriceDesignation property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithPriceDesignation(string priceDesignation)
        {
            _priceDesignation = priceDesignation;
            return this;
        }

        /// <summary>
        /// Checks if PriceDesignation property is set.
        /// </summary>
        /// <returns>true if PriceDesignation property is set.</returns>
        public bool IsSetPriceDesignation()
        {
            return _priceDesignation != null;
        }

        /// <summary>
        /// Gets and sets the BuyerCustomizedInfo property.
        /// </summary>
        public virtual BuyerCustomizedInfoDetail BuyerCustomizedInfo
        {
            get { return _buyerCustomizedInfo; }
            set { _buyerCustomizedInfo = value; }
        }

        /// <summary>
        /// Sets the BuyerCustomizedInfo property.
        /// </summary>
        /// <param name="buyerCustomizedInfo">BuyerCustomizedInfo property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithBuyerCustomizedInfo(BuyerCustomizedInfoDetail buyerCustomizedInfo)
        {
            _buyerCustomizedInfo = buyerCustomizedInfo;
            return this;
        }

        /// <summary>
        /// Checks if BuyerCustomizedInfo property is set.
        /// </summary>
        /// <returns>true if BuyerCustomizedInfo property is set.</returns>
        public bool IsSetBuyerCustomizedInfo()
        {
            return _buyerCustomizedInfo != null;
        }

        /// <summary>
        /// Gets and sets the TaxCollection property.
        /// </summary>
        public virtual TaxCollection TaxCollection
        {
            get { return _taxCollection; }
            set { _taxCollection = value; }
        }

        /// <summary>
        /// Sets the TaxCollection property.
        /// </summary>
        /// <param name="taxCollection">TaxCollection property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithTaxCollection(TaxCollection taxCollection)
        {
            _taxCollection = taxCollection;
            return this;
        }

        /// <summary>
        /// Checks if TaxCollection property is set.
        /// </summary>
        /// <returns>true if TaxCollection property is set.</returns>
        public bool IsSetTaxCollection()
        {
            return _taxCollection != null;
        }

        /// <summary>
        /// Gets and sets the SerialNumberRequired property.
        /// </summary>
        public bool SerialNumberRequired
        {
            get { return _serialNumberRequired.GetValueOrDefault(); }
            set { _serialNumberRequired = value; }
        }

        /// <summary>
        /// Sets the SerialNumberRequired property.
        /// </summary>
        /// <param name="serialNumberRequired">SerialNumberRequired property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithSerialNumberRequired(bool serialNumberRequired)
        {
            _serialNumberRequired = serialNumberRequired;
            return this;
        }

        /// <summary>
        /// Checks if SerialNumberRequired property is set.
        /// </summary>
        /// <returns>true if SerialNumberRequired property is set.</returns>
        public bool IsSetSerialNumberRequired()
        {
            return _serialNumberRequired != null;
        }

        /// <summary>
        /// Gets and sets the IsTransparency property.
        /// </summary>
        public bool IsTransparency
        {
            get { return _isTransparency.GetValueOrDefault(); }
            set { _isTransparency = value; }
        }

        /// <summary>
        /// Gets and sets the WarehouseId property.
        /// </summary>
        public long? WarehouseId
        {
            get { return _WarehouseId; }
            set { _WarehouseId = value; }
        }

        public virtual Warehouse Warehouse { set; get; }

        [DefaultValue(2)]
        //  public int RecordStatus { set; get; }

        /// <summary>
        /// Sets the IsTransparency property.
        /// </summary>
        /// <param name="isTransparency">IsTransparency property.</param>
        /// <returns>this instance.</returns>
        public OrderItem WithIsTransparency(bool isTransparency)
        {
            _isTransparency = isTransparency;
            return this;
        }

        /// <summary>
        /// Checks if IsTransparency property is set.
        /// </summary>
        /// <returns>true if IsTransparency property is set.</returns>
        public bool IsSetIsTransparency()
        {
            return _isTransparency != null;
        }

        public override void ReadFragmentFrom(IMwsReader reader)
        {
            _asin = reader.Read<string>("ASIN");
            _sellerSKU = reader.Read<string>("SellerSKU");
            _orderItemId = reader.Read<string>("OrderItemId");
            _title = reader.Read<string>("Title");
            _quantityOrdered = reader.Read<decimal>("QuantityOrdered");
            _quantityShipped = reader.Read<decimal?>("QuantityShipped");
            _productInfo = reader.Read<ProductInfoDetail>("ProductInfo");
            _pointsGranted = reader.Read<PointsGrantedDetail>("PointsGranted");
            _itemPrice = reader.Read<Money>("ItemPrice");
            _shippingPrice = reader.Read<Money>("ShippingPrice");
            _giftWrapPrice = reader.Read<Money>("GiftWrapPrice");
            _itemTax = reader.Read<Money>("ItemTax");
            _shippingTax = reader.Read<Money>("ShippingTax");
            _giftWrapTax = reader.Read<Money>("GiftWrapTax");
            _shippingDiscount = reader.Read<Money>("ShippingDiscount");
            _shippingDiscountTax = reader.Read<Money>("ShippingDiscountTax");
            _promotionDiscount = reader.Read<Money>("PromotionDiscount");
            _promotionDiscountTax = reader.Read<Money>("PromotionDiscountTax");
            _promotionIds = reader.ReadList<string>("PromotionIds", "PromotionId");
            _codFee = reader.Read<Money>("CODFee");
            _codFeeDiscount = reader.Read<Money>("CODFeeDiscount");
            _isGift = reader.Read<bool?>("IsGift");
            _giftMessageText = reader.Read<string>("GiftMessageText");
            _giftWrapLevel = reader.Read<string>("GiftWrapLevel");
            _invoiceData = reader.Read<InvoiceData>("InvoiceData");
            _conditionNote = reader.Read<string>("ConditionNote");
            _conditionId = reader.Read<string>("ConditionId");
            _conditionSubtypeId = reader.Read<string>("ConditionSubtypeId");
            _scheduledDeliveryStartDate = reader.Read<string>("ScheduledDeliveryStartDate");
            _scheduledDeliveryEndDate = reader.Read<string>("ScheduledDeliveryEndDate");
            _priceDesignation = reader.Read<string>("PriceDesignation");
            _buyerCustomizedInfo = reader.Read<BuyerCustomizedInfoDetail>("BuyerCustomizedInfo");
            _taxCollection = reader.Read<TaxCollection>("TaxCollection");
            _serialNumberRequired = reader.Read<bool?>("SerialNumberRequired");
            _isTransparency = reader.Read<bool?>("IsTransparency");
        }

        public override void WriteFragmentTo(IMwsWriter writer)
        {
            writer.Write("ASIN", _asin);
            writer.Write("SellerSKU", _sellerSKU);
            writer.Write("OrderItemId", _orderItemId);
            writer.Write("Title", _title);
            writer.Write("QuantityOrdered", _quantityOrdered);
            writer.Write("QuantityShipped", _quantityShipped);
            writer.Write("ProductInfo", _productInfo);
            writer.Write("PointsGranted", _pointsGranted);
            writer.Write("ItemPrice", _itemPrice);
            writer.Write("ShippingPrice", _shippingPrice);
            writer.Write("GiftWrapPrice", _giftWrapPrice);
            writer.Write("ItemTax", _itemTax);
            writer.Write("ShippingTax", _shippingTax);
            writer.Write("GiftWrapTax", _giftWrapTax);
            writer.Write("ShippingDiscount", _shippingDiscount);
            writer.Write("ShippingDiscountTax", _shippingDiscountTax);
            writer.Write("PromotionDiscount", _promotionDiscount);
            writer.Write("PromotionDiscountTax", _promotionDiscountTax);
            writer.WriteList("PromotionIds", "PromotionId", _promotionIds);
            writer.Write("CODFee", _codFee);
            writer.Write("CODFeeDiscount", _codFeeDiscount);
            writer.Write("IsGift", _isGift);
            writer.Write("GiftMessageText", _giftMessageText);
            writer.Write("GiftWrapLevel", _giftWrapLevel);
            writer.Write("InvoiceData", _invoiceData);
            writer.Write("ConditionNote", _conditionNote);
            writer.Write("ConditionId", _conditionId);
            writer.Write("ConditionSubtypeId", _conditionSubtypeId);
            writer.Write("ScheduledDeliveryStartDate", _scheduledDeliveryStartDate);
            writer.Write("ScheduledDeliveryEndDate", _scheduledDeliveryEndDate);
            writer.Write("PriceDesignation", _priceDesignation);
            writer.Write("BuyerCustomizedInfo", _buyerCustomizedInfo);
            writer.Write("TaxCollection", _taxCollection);
            writer.Write("SerialNumberRequired", _serialNumberRequired);
            writer.Write("IsTransparency", _isTransparency);
        }

        public override void WriteTo(IMwsWriter writer)
        {
            writer.Write("https://mws.amazonservices.com/Orders/2013-09-01", "OrderItem", this);
        }

        public OrderItem(string asin, string orderItemId, decimal quantityOrdered) : base()
        {
            _asin = asin;
            _orderItemId = orderItemId;
            _quantityOrdered = quantityOrdered;
        }

        public OrderItem() : base()
        {
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(OrderId)}={OrderId.ToString()}, {nameof(Orders)}={Orders}, {nameof(ItemStatusId)}={ItemStatusId.ToString()}, {nameof(SellerId)}={SellerId.ToString()}, {nameof(Seller)}={Seller}, {nameof(ItemStatus)}={ItemStatus}, {nameof(eZTrackReferenceNumber)}={eZTrackReferenceNumber}, {nameof(PickupFailureReason)}={PickupFailureReason}, {nameof(ConsignmentNo)}={ConsignmentNo}, {nameof(CreatedDate)}={CreatedDate.ToString()}, {nameof(ASIN)}={ASIN}, {nameof(SellerSKU)}={SellerSKU}, {nameof(OrderItemId)}={OrderItemId}, {nameof(Title)}={Title}, {nameof(QuantityOrdered)}={QuantityOrdered.ToString()}, {nameof(QuantityShipped)}={QuantityShipped.ToString()}, {nameof(ProductInfo)}={ProductInfo}, {nameof(PointsGranted)}={PointsGranted}, {nameof(ItemPrice)}={ItemPrice}, {nameof(ShippingPrice)}={ShippingPrice}, {nameof(GiftWrapPrice)}={GiftWrapPrice}, {nameof(ItemTax)}={ItemTax}, {nameof(ShippingTax)}={ShippingTax}, {nameof(GiftWrapTax)}={GiftWrapTax}, {nameof(ShippingDiscount)}={ShippingDiscount}, {nameof(ShippingDiscountTax)}={ShippingDiscountTax}, {nameof(PromotionDiscount)}={PromotionDiscount}, {nameof(PromotionDiscountTax)}={PromotionDiscountTax}, {nameof(PromotionIds)}={PromotionIds}, {nameof(CODFee)}={CODFee}, {nameof(CODFeeDiscount)}={CODFeeDiscount}, {nameof(IsGift)}={IsGift.ToString()}, {nameof(GiftMessageText)}={GiftMessageText}, {nameof(GiftWrapLevel)}={GiftWrapLevel}, {nameof(InvoiceData)}={InvoiceData}, {nameof(ConditionNote)}={ConditionNote}, {nameof(ConditionId)}={ConditionId}, {nameof(ConditionSubtypeId)}={ConditionSubtypeId}, {nameof(ScheduledDeliveryStartDate)}={ScheduledDeliveryStartDate}, {nameof(ScheduledDeliveryEndDate)}={ScheduledDeliveryEndDate}, {nameof(PriceDesignation)}={PriceDesignation}, {nameof(BuyerCustomizedInfo)}={BuyerCustomizedInfo}, {nameof(TaxCollection)}={TaxCollection}, {nameof(SerialNumberRequired)}={SerialNumberRequired.ToString()}, {nameof(IsTransparency)}={IsTransparency.ToString()}, {nameof(WarehouseId)}={WarehouseId.ToString()}, {nameof(Warehouse)}={Warehouse}}}";
        }
    }
}