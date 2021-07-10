
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;


namespace Amazon.APIEngine.Models
{
    /// <summary>
    /// Order information.
    /// </summary>
    [DataContract]
    public partial class Order : IEquatable<Order>, IValidatableObject
    {
        /// <summary>
        /// The current order status.
        /// </summary>
        /// <value>The current order status.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrderStatusEnum
        {
            /// <summary>
            /// Enum Pending for value: Pending
            /// </summary>
            [EnumMember(Value = "Pending")]
            Pending = 1,
            /// <summary>
            /// Enum Unshipped for value: Unshipped
            /// </summary>
            [EnumMember(Value = "Unshipped")]
            Unshipped = 2,
            /// <summary>
            /// Enum PartiallyShipped for value: PartiallyShipped
            /// </summary>
            [EnumMember(Value = "PartiallyShipped")]
            PartiallyShipped = 3,
            /// <summary>
            /// Enum Shipped for value: Shipped
            /// </summary>
            [EnumMember(Value = "Shipped")]
            Shipped = 4,
            /// <summary>
            /// Enum Canceled for value: Canceled
            /// </summary>
            [EnumMember(Value = "Canceled")]
            Canceled = 5,
            /// <summary>
            /// Enum Unfulfillable for value: Unfulfillable
            /// </summary>
            [EnumMember(Value = "Unfulfillable")]
            Unfulfillable = 6,
            /// <summary>
            /// Enum InvoiceUnconfirmed for value: InvoiceUnconfirmed
            /// </summary>
            [EnumMember(Value = "InvoiceUnconfirmed")]
            InvoiceUnconfirmed = 7,
            /// <summary>
            /// Enum PendingAvailability for value: PendingAvailability
            /// </summary>
            [EnumMember(Value = "PendingAvailability")]
            PendingAvailability = 8
        }
        /// <summary>
        /// The current order status.
        /// </summary>
        /// <value>The current order status.</value>
        [DataMember(Name = "OrderStatus", EmitDefaultValue = false)]
        public OrderStatusEnum OrderStatus { get; set; }
        /// <summary>
        /// Whether the order was fulfilled by Amazon (AFN) or by the seller (MFN).
        /// </summary>
        /// <value>Whether the order was fulfilled by Amazon (AFN) or by the seller (MFN).</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum FulfillmentChannelEnum
        {
            /// <summary>
            /// Enum MFN for value: MFN
            /// </summary>
            [EnumMember(Value = "MFN")]
            MFN = 1,
            /// <summary>
            /// Enum AFN for value: AFN
            /// </summary>
            [EnumMember(Value = "AFN")]
            AFN = 2
        }
        /// <summary>
        /// Whether the order was fulfilled by Amazon (AFN) or by the seller (MFN).
        /// </summary>
        /// <value>Whether the order was fulfilled by Amazon (AFN) or by the seller (MFN).</value>
        [DataMember(Name = "FulfillmentChannel", EmitDefaultValue = false)]
        public FulfillmentChannelEnum? FulfillmentChannel { get; set; }
        /// <summary>
        /// The payment method for the order. This property is limited to Cash On Delivery (COD) and Convenience Store (CVS) payment methods. Unless you need the specific COD payment information provided by the PaymentExecutionDetailItem object, we recommend using the PaymentMethodDetails property to get payment method information.
        /// </summary>
        /// <value>The payment method for the order. This property is limited to Cash On Delivery (COD) and Convenience Store (CVS) payment methods. Unless you need the specific COD payment information provided by the PaymentExecutionDetailItem object, we recommend using the PaymentMethodDetails property to get payment method information.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum PaymentMethodEnum
        {
            /// <summary>
            /// Enum COD for value: COD
            /// </summary>
            [EnumMember(Value = "COD")]
            COD = 1,
            /// <summary>
            /// Enum CVS for value: CVS
            /// </summary>
            [EnumMember(Value = "CVS")]
            CVS = 2,
            /// <summary>
            /// Enum Other for value: Other
            /// </summary>
            [EnumMember(Value = "Other")]
            Other = 3
        }
        /// <summary>
        /// The payment method for the order. This property is limited to Cash On Delivery (COD) and Convenience Store (CVS) payment methods. Unless you need the specific COD payment information provided by the PaymentExecutionDetailItem object, we recommend using the PaymentMethodDetails property to get payment method information.
        /// </summary>
        /// <value>The payment method for the order. This property is limited to Cash On Delivery (COD) and Convenience Store (CVS) payment methods. Unless you need the specific COD payment information provided by the PaymentExecutionDetailItem object, we recommend using the PaymentMethodDetails property to get payment method information.</value>
        [DataMember(Name = "PaymentMethod", EmitDefaultValue = false)]
        public PaymentMethodEnum? PaymentMethod { get; set; }
        /// <summary>
        /// The type of the order.
        /// </summary>
        /// <value>The type of the order.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrderTypeEnum
        {
            /// <summary>
            /// Enum StandardOrder for value: StandardOrder
            /// </summary>
            [EnumMember(Value = "StandardOrder")]
            StandardOrder = 1,
            /// <summary>
            /// Enum LongLeadTimeOrder for value: LongLeadTimeOrder
            /// </summary>
            [EnumMember(Value = "LongLeadTimeOrder")]
            LongLeadTimeOrder = 2,
            /// <summary>
            /// Enum Preorder for value: Preorder
            /// </summary>
            [EnumMember(Value = "Preorder")]
            Preorder = 3,
            /// <summary>
            /// Enum BackOrder for value: BackOrder
            /// </summary>
            [EnumMember(Value = "BackOrder")]
            BackOrder = 4,
            /// <summary>
            /// Enum SourcingOnDemandOrder for value: SourcingOnDemandOrder
            /// </summary>
            [EnumMember(Value = "SourcingOnDemandOrder")]
            SourcingOnDemandOrder = 5
        }
        /// <summary>
        /// The type of the order.
        /// </summary>
        /// <value>The type of the order.</value>
        [DataMember(Name = "OrderType", EmitDefaultValue = false)]
        public OrderTypeEnum? OrderType { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Order" /> class.
        /// </summary>
        /// <param name="amazonOrderId">An Amazon-defined order identifier, in 3-7-7 format. (required).</param>
        /// <param name="sellerOrderId">A seller-defined order identifier..</param>
        /// <param name="purchaseDate">The date when the order was created. (required).</param>
        /// <param name="lastUpdateDate">The date when the order was last updated.  Note: LastUpdateDate is returned with an incorrect date for orders that were last updated before 2009-04-01. (required).</param>
        /// <param name="orderStatus">The current order status. (required).</param>
        /// <param name="fulfillmentChannel">Whether the order was fulfilled by Amazon (AFN) or by the seller (MFN)..</param>
        /// <param name="salesChannel">The sales channel of the first item in the order..</param>
        /// <param name="orderChannel">The order channel of the first item in the order..</param>
        /// <param name="shipServiceLevel">The shipment service level of the order..</param>
        /// <param name="orderTotal">orderTotal.</param>
        /// <param name="numberOfItemsShipped">The number of items shipped..</param>
        /// <param name="numberOfItemsUnshipped">The number of items unshipped..</param>
        /// <param name="paymentExecutionDetail">paymentExecutionDetail.</param>
        /// <param name="paymentMethod">The payment method for the order. This property is limited to Cash On Delivery (COD) and Convenience Store (CVS) payment methods. Unless you need the specific COD payment information provided by the PaymentExecutionDetailItem object, we recommend using the PaymentMethodDetails property to get payment method information..</param>
        /// <param name="paymentMethodDetails">paymentMethodDetails.</param>
        /// <param name="marketplaceId">The identifier for the marketplace where the order was placed..</param>
        /// <param name="shipmentServiceLevelCategory">The shipment service level category of the order.  Possible values: Expedited, FreeEconomy, NextDay, SameDay, SecondDay, Scheduled, Standard..</param>
        /// <param name="easyShipShipmentStatus">The status of the Amazon Easy Ship order. This property is included only for Amazon Easy Ship orders.  Possible values: PendingPickUp, LabelCanceled, PickedUp, OutForDelivery, Damaged, Delivered, RejectedByBuyer, Undeliverable, ReturnedToSeller, ReturningToSeller..</param>
        /// <param name="cbaDisplayableShippingLabel">Custom ship label for Checkout by Amazon (CBA)..</param>
        /// <param name="orderType">The type of the order..</param>
        /// <param name="earliestShipDate">The start of the time period within which you have committed to ship the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders.  Note: EarliestShipDate might not be returned for orders placed before February 1, 2013..</param>
        /// <param name="latestShipDate">The end of the time period within which you have committed to ship the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders.  Note: LatestShipDate might not be returned for orders placed before February 1, 2013..</param>
        /// <param name="earliestDeliveryDate">The start of the time period within which you have committed to fulfill the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders..</param>
        /// <param name="latestDeliveryDate">The end of the time period within which you have committed to fulfill the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders that do not have a PendingAvailability, Pending, or Canceled status..</param>
        /// <param name="isBusinessOrder">When true, the order is an Amazon Business order. An Amazon Business order is an order where the buyer is a Verified Business Buyer..</param>
        /// <param name="isPrime">When true, the order is a seller-fulfilled Amazon Prime order..</param>
        /// <param name="isPremiumOrder">When true, the order has a Premium Shipping Service Level Agreement. For more information about Premium Shipping orders, see \&quot;Premium Shipping Options\&quot; in the Seller Central Help for your marketplace..</param>
        /// <param name="isGlobalExpressEnabled">When true, the order is a GlobalExpress order..</param>
        /// <param name="replacedOrderId">The order ID value for the order that is being replaced. Returned only if IsReplacementOrder &#x3D; true..</param>
        /// <param name="isReplacementOrder">When true, this is a replacement order..</param>
        /// <param name="promiseResponseDueDate">Indicates the date by which the seller must respond to the buyer with an estimated ship date. Returned only for Sourcing on Demand orders..</param>
        /// <param name="isEstimatedShipDateSet">When true, the estimated ship date is set for the order. Returned only for Sourcing on Demand orders..</param>
        /// <param name="isSoldByAB">When true, the item within this order was bought and re-sold by Amazon Business EU SARL (ABEU). By buying and instantly re-selling your items, ABEU becomes the seller of record, making your inventory available for sale to customers who would not otherwise purchase from a third-party seller..</param>
        /// <param name="defaultShipFromLocationAddress">defaultShipFromLocationAddress.</param>
        /// <param name="fulfillmentInstruction">fulfillmentInstruction.</param>
        /// <param name="isISPU">When true, this order is marked to be picked up from a store rather than delivered..</param>
        public Order(string amazonOrderId = default(string), string sellerOrderId = default(string), string purchaseDate = default(string), string lastUpdateDate = default(string), OrderStatusEnum orderStatus = default(OrderStatusEnum), FulfillmentChannelEnum? fulfillmentChannel = default(FulfillmentChannelEnum?), string salesChannel = default(string), string orderChannel = default(string), string shipServiceLevel = default(string), Money orderTotal = default(Money), int? numberOfItemsShipped = default(int?), int? numberOfItemsUnshipped = default(int?), PaymentExecutionDetailItemList paymentExecutionDetail = default(PaymentExecutionDetailItemList), PaymentMethodEnum? paymentMethod = default(PaymentMethodEnum?), PaymentMethodDetailItemList paymentMethodDetails = default(PaymentMethodDetailItemList), string marketplaceId = default(string), string shipmentServiceLevelCategory = default(string), string easyShipShipmentStatus = default(string), string cbaDisplayableShippingLabel = default(string), OrderTypeEnum? orderType = default(OrderTypeEnum?), string earliestShipDate = default(string), string latestShipDate = default(string), string earliestDeliveryDate = default(string), string latestDeliveryDate = default(string), bool? isBusinessOrder = default(bool?), bool? isPrime = default(bool?), bool? isPremiumOrder = default(bool?), bool? isGlobalExpressEnabled = default(bool?), string replacedOrderId = default(string), bool? isReplacementOrder = default(bool?), string promiseResponseDueDate = default(string), bool? isEstimatedShipDateSet = default(bool?), bool? isSoldByAB = default(bool?), Address defaultShipFromLocationAddress = default(Address), FulfillmentInstruction fulfillmentInstruction = default(FulfillmentInstruction), bool? isISPU = default(bool?))
        {
            // to ensure "amazonOrderId" is required (not null)
            if (amazonOrderId == null)
            {
                throw new InvalidDataException("amazonOrderId is a required property for Order and cannot be null");
            }
            else
            {
                this.AmazonOrderId = amazonOrderId;
            }
            // to ensure "purchaseDate" is required (not null)
            if (purchaseDate == null)
            {
                throw new InvalidDataException("purchaseDate is a required property for Order and cannot be null");
            }
            else
            {
                this.PurchaseDate = purchaseDate;
            }
            // to ensure "lastUpdateDate" is required (not null)
            if (lastUpdateDate == null)
            {
                throw new InvalidDataException("lastUpdateDate is a required property for Order and cannot be null");
            }
            else
            {
                this.LastUpdateDate = lastUpdateDate;
            }
            // to ensure "orderStatus" is required (not null)
            if (orderStatus == null)
            {
                throw new InvalidDataException("orderStatus is a required property for Order and cannot be null");
            }
            else
            {
                this.OrderStatus = orderStatus;
            }
            this.SellerOrderId = sellerOrderId;
            this.FulfillmentChannel = fulfillmentChannel;
            this.SalesChannel = salesChannel;
            this.OrderChannel = orderChannel;
            this.ShipServiceLevel = shipServiceLevel;
            this.OrderTotal = orderTotal;
            this.NumberOfItemsShipped = numberOfItemsShipped;
            this.NumberOfItemsUnshipped = numberOfItemsUnshipped;
            this.PaymentExecutionDetail = paymentExecutionDetail;
            this.PaymentMethod = paymentMethod;
            this.PaymentMethodDetails = paymentMethodDetails;
            this.MarketplaceId = marketplaceId;
            this.ShipmentServiceLevelCategory = shipmentServiceLevelCategory;
            this.EasyShipShipmentStatus = easyShipShipmentStatus;
            this.CbaDisplayableShippingLabel = cbaDisplayableShippingLabel;
            this.OrderType = orderType;
            this.EarliestShipDate = earliestShipDate;
            this.LatestShipDate = latestShipDate;
            this.EarliestDeliveryDate = earliestDeliveryDate;
            this.LatestDeliveryDate = latestDeliveryDate;
            this.IsBusinessOrder = isBusinessOrder;
            this.IsPrime = isPrime;
            this.IsPremiumOrder = isPremiumOrder;
            this.IsGlobalExpressEnabled = isGlobalExpressEnabled;
            this.ReplacedOrderId = replacedOrderId;
            this.IsReplacementOrder = isReplacementOrder;
            this.PromiseResponseDueDate = promiseResponseDueDate;
            this.IsEstimatedShipDateSet = isEstimatedShipDateSet;
            this.IsSoldByAB = isSoldByAB;
            this.DefaultShipFromLocationAddress = defaultShipFromLocationAddress;
            this.FulfillmentInstruction = fulfillmentInstruction;
            this.IsISPU = isISPU;
        }

        public Order()
        {
        }

        /// <summary>
        /// An Amazon-defined order identifier, in 3-7-7 format.
        /// </summary>
        /// <value>An Amazon-defined order identifier, in 3-7-7 format.</value>
        [DataMember(Name = "AmazonOrderId", EmitDefaultValue = false)]
        public string AmazonOrderId { get; set; }

        /// <summary>
        /// A seller-defined order identifier.
        /// </summary>
        /// <value>A seller-defined order identifier.</value>
        [DataMember(Name = "SellerOrderId", EmitDefaultValue = false)]
        public string SellerOrderId { get; set; }

        /// <summary>
        /// The date when the order was created.
        /// </summary>
        /// <value>The date when the order was created.</value>
        [DataMember(Name = "PurchaseDate", EmitDefaultValue = false)]
        public string PurchaseDate { get; set; }

        /// <summary>
        /// The date when the order was last updated.  Note: LastUpdateDate is returned with an incorrect date for orders that were last updated before 2009-04-01.
        /// </summary>
        /// <value>The date when the order was last updated.  Note: LastUpdateDate is returned with an incorrect date for orders that were last updated before 2009-04-01.</value>
        [DataMember(Name = "LastUpdateDate", EmitDefaultValue = false)]
        public string LastUpdateDate { get; set; }



        /// <summary>
        /// The sales channel of the first item in the order.
        /// </summary>
        /// <value>The sales channel of the first item in the order.</value>
        [DataMember(Name = "SalesChannel", EmitDefaultValue = false)]
        public string SalesChannel { get; set; }

        /// <summary>
        /// The order channel of the first item in the order.
        /// </summary>
        /// <value>The order channel of the first item in the order.</value>
        [DataMember(Name = "OrderChannel", EmitDefaultValue = false)]
        public string OrderChannel { get; set; }

        /// <summary>
        /// The shipment service level of the order.
        /// </summary>
        /// <value>The shipment service level of the order.</value>
        [DataMember(Name = "ShipServiceLevel", EmitDefaultValue = false)]
        public string ShipServiceLevel { get; set; }

        /// <summary>
        /// Gets or Sets OrderTotal
        /// </summary>
        [DataMember(Name = "OrderTotal", EmitDefaultValue = false)]
        public Money OrderTotal { get; set; }

        /// <summary>
        /// The number of items shipped.
        /// </summary>
        /// <value>The number of items shipped.</value>
        [DataMember(Name = "NumberOfItemsShipped", EmitDefaultValue = false)]
        public int? NumberOfItemsShipped { get; set; }

        /// <summary>
        /// The number of items unshipped.
        /// </summary>
        /// <value>The number of items unshipped.</value>
        [DataMember(Name = "NumberOfItemsUnshipped", EmitDefaultValue = false)]
        public int? NumberOfItemsUnshipped { get; set; }

        /// <summary>
        /// Gets or Sets PaymentExecutionDetail
        /// </summary>
        [DataMember(Name = "PaymentExecutionDetail", EmitDefaultValue = false)]
        public PaymentExecutionDetailItemList PaymentExecutionDetail { get; set; }


        /// <summary>
        /// Gets or Sets PaymentMethodDetails
        /// </summary>
        [DataMember(Name = "PaymentMethodDetails", EmitDefaultValue = false)]
        public PaymentMethodDetailItemList PaymentMethodDetails { get; set; }

        /// <summary>
        /// The identifier for the marketplace where the order was placed.
        /// </summary>
        /// <value>The identifier for the marketplace where the order was placed.</value>
        [DataMember(Name = "MarketplaceId", EmitDefaultValue = false)]
        public string MarketplaceId { get; set; }

        /// <summary>
        /// The shipment service level category of the order.  Possible values: Expedited, FreeEconomy, NextDay, SameDay, SecondDay, Scheduled, Standard.
        /// </summary>
        /// <value>The shipment service level category of the order.  Possible values: Expedited, FreeEconomy, NextDay, SameDay, SecondDay, Scheduled, Standard.</value>
        [DataMember(Name = "ShipmentServiceLevelCategory", EmitDefaultValue = false)]
        public string ShipmentServiceLevelCategory { get; set; }

        /// <summary>
        /// The status of the Amazon Easy Ship order. This property is included only for Amazon Easy Ship orders.  Possible values: PendingPickUp, LabelCanceled, PickedUp, OutForDelivery, Damaged, Delivered, RejectedByBuyer, Undeliverable, ReturnedToSeller, ReturningToSeller.
        /// </summary>
        /// <value>The status of the Amazon Easy Ship order. This property is included only for Amazon Easy Ship orders.  Possible values: PendingPickUp, LabelCanceled, PickedUp, OutForDelivery, Damaged, Delivered, RejectedByBuyer, Undeliverable, ReturnedToSeller, ReturningToSeller.</value>
        [DataMember(Name = "EasyShipShipmentStatus", EmitDefaultValue = false)]
        public string EasyShipShipmentStatus { get; set; }

        /// <summary>
        /// Custom ship label for Checkout by Amazon (CBA).
        /// </summary>
        /// <value>Custom ship label for Checkout by Amazon (CBA).</value>
        [DataMember(Name = "CbaDisplayableShippingLabel", EmitDefaultValue = false)]
        public string CbaDisplayableShippingLabel { get; set; }


        /// <summary>
        /// The start of the time period within which you have committed to ship the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders.  Note: EarliestShipDate might not be returned for orders placed before February 1, 2013.
        /// </summary>
        /// <value>The start of the time period within which you have committed to ship the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders.  Note: EarliestShipDate might not be returned for orders placed before February 1, 2013.</value>
        [DataMember(Name = "EarliestShipDate", EmitDefaultValue = false)]
        public string EarliestShipDate { get; set; }

        /// <summary>
        /// The end of the time period within which you have committed to ship the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders.  Note: LatestShipDate might not be returned for orders placed before February 1, 2013.
        /// </summary>
        /// <value>The end of the time period within which you have committed to ship the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders.  Note: LatestShipDate might not be returned for orders placed before February 1, 2013.</value>
        [DataMember(Name = "LatestShipDate", EmitDefaultValue = false)]
        public string LatestShipDate { get; set; }

        /// <summary>
        /// The start of the time period within which you have committed to fulfill the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders.
        /// </summary>
        /// <value>The start of the time period within which you have committed to fulfill the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders.</value>
        [DataMember(Name = "EarliestDeliveryDate", EmitDefaultValue = false)]
        public string EarliestDeliveryDate { get; set; }

        /// <summary>
        /// The end of the time period within which you have committed to fulfill the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders that do not have a PendingAvailability, Pending, or Canceled status.
        /// </summary>
        /// <value>The end of the time period within which you have committed to fulfill the order. In ISO 8601 date time format. Returned only for seller-fulfilled orders that do not have a PendingAvailability, Pending, or Canceled status.</value>
        [DataMember(Name = "LatestDeliveryDate", EmitDefaultValue = false)]
        public string LatestDeliveryDate { get; set; }

        /// <summary>
        /// When true, the order is an Amazon Business order. An Amazon Business order is an order where the buyer is a Verified Business Buyer.
        /// </summary>
        /// <value>When true, the order is an Amazon Business order. An Amazon Business order is an order where the buyer is a Verified Business Buyer.</value>
        [DataMember(Name = "IsBusinessOrder", EmitDefaultValue = false)]
        public bool? IsBusinessOrder { get; set; }

        /// <summary>
        /// When true, the order is a seller-fulfilled Amazon Prime order.
        /// </summary>
        /// <value>When true, the order is a seller-fulfilled Amazon Prime order.</value>
        [DataMember(Name = "IsPrime", EmitDefaultValue = false)]
        public bool? IsPrime { get; set; }

        /// <summary>
        /// When true, the order has a Premium Shipping Service Level Agreement. For more information about Premium Shipping orders, see \&quot;Premium Shipping Options\&quot; in the Seller Central Help for your marketplace.
        /// </summary>
        /// <value>When true, the order has a Premium Shipping Service Level Agreement. For more information about Premium Shipping orders, see \&quot;Premium Shipping Options\&quot; in the Seller Central Help for your marketplace.</value>
        [DataMember(Name = "IsPremiumOrder", EmitDefaultValue = false)]
        public bool? IsPremiumOrder { get; set; }

        /// <summary>
        /// When true, the order is a GlobalExpress order.
        /// </summary>
        /// <value>When true, the order is a GlobalExpress order.</value>
        [DataMember(Name = "IsGlobalExpressEnabled", EmitDefaultValue = false)]
        public bool? IsGlobalExpressEnabled { get; set; }

        /// <summary>
        /// The order ID value for the order that is being replaced. Returned only if IsReplacementOrder &#x3D; true.
        /// </summary>
        /// <value>The order ID value for the order that is being replaced. Returned only if IsReplacementOrder &#x3D; true.</value>
        [DataMember(Name = "ReplacedOrderId", EmitDefaultValue = false)]
        public string ReplacedOrderId { get; set; }

        /// <summary>
        /// When true, this is a replacement order.
        /// </summary>
        /// <value>When true, this is a replacement order.</value>
        [DataMember(Name = "IsReplacementOrder", EmitDefaultValue = false)]
        public bool? IsReplacementOrder { get; set; }

        /// <summary>
        /// Indicates the date by which the seller must respond to the buyer with an estimated ship date. Returned only for Sourcing on Demand orders.
        /// </summary>
        /// <value>Indicates the date by which the seller must respond to the buyer with an estimated ship date. Returned only for Sourcing on Demand orders.</value>
        [DataMember(Name = "PromiseResponseDueDate", EmitDefaultValue = false)]
        public string PromiseResponseDueDate { get; set; }

        /// <summary>
        /// When true, the estimated ship date is set for the order. Returned only for Sourcing on Demand orders.
        /// </summary>
        /// <value>When true, the estimated ship date is set for the order. Returned only for Sourcing on Demand orders.</value>
        [DataMember(Name = "IsEstimatedShipDateSet", EmitDefaultValue = false)]
        public bool? IsEstimatedShipDateSet { get; set; }

        /// <summary>
        /// When true, the item within this order was bought and re-sold by Amazon Business EU SARL (ABEU). By buying and instantly re-selling your items, ABEU becomes the seller of record, making your inventory available for sale to customers who would not otherwise purchase from a third-party seller.
        /// </summary>
        /// <value>When true, the item within this order was bought and re-sold by Amazon Business EU SARL (ABEU). By buying and instantly re-selling your items, ABEU becomes the seller of record, making your inventory available for sale to customers who would not otherwise purchase from a third-party seller.</value>
        [DataMember(Name = "IsSoldByAB", EmitDefaultValue = false)]
        public bool? IsSoldByAB { get; set; }

        /// <summary>
        /// Gets or Sets DefaultShipFromLocationAddress
        /// </summary>
        [DataMember(Name = "DefaultShipFromLocationAddress", EmitDefaultValue = false)]
        public Address DefaultShipFromLocationAddress { get; set; }

        /// <summary>
        /// Gets or Sets FulfillmentInstruction
        /// </summary>
        [DataMember(Name = "FulfillmentInstruction", EmitDefaultValue = false)]
        public FulfillmentInstruction FulfillmentInstruction { get; set; }

        /// <summary>
        /// When true, this order is marked to be picked up from a store rather than delivered.
        /// </summary>
        /// <value>When true, this order is marked to be picked up from a store rather than delivered.</value>
        [DataMember(Name = "IsISPU", EmitDefaultValue = false)]
        public bool? IsISPU { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Order {\n");
            sb.Append("  AmazonOrderId: ").Append(AmazonOrderId).Append("\n");
            sb.Append("  SellerOrderId: ").Append(SellerOrderId).Append("\n");
            sb.Append("  PurchaseDate: ").Append(PurchaseDate).Append("\n");
            sb.Append("  LastUpdateDate: ").Append(LastUpdateDate).Append("\n");
            sb.Append("  OrderStatus: ").Append(OrderStatus).Append("\n");
            sb.Append("  FulfillmentChannel: ").Append(FulfillmentChannel).Append("\n");
            sb.Append("  SalesChannel: ").Append(SalesChannel).Append("\n");
            sb.Append("  OrderChannel: ").Append(OrderChannel).Append("\n");
            sb.Append("  ShipServiceLevel: ").Append(ShipServiceLevel).Append("\n");
            sb.Append("  OrderTotal: ").Append(OrderTotal).Append("\n");
            sb.Append("  NumberOfItemsShipped: ").Append(NumberOfItemsShipped).Append("\n");
            sb.Append("  NumberOfItemsUnshipped: ").Append(NumberOfItemsUnshipped).Append("\n");
            sb.Append("  PaymentExecutionDetail: ").Append(PaymentExecutionDetail).Append("\n");
            sb.Append("  PaymentMethod: ").Append(PaymentMethod).Append("\n");
            sb.Append("  PaymentMethodDetails: ").Append(PaymentMethodDetails).Append("\n");
            sb.Append("  MarketplaceId: ").Append(MarketplaceId).Append("\n");
            sb.Append("  ShipmentServiceLevelCategory: ").Append(ShipmentServiceLevelCategory).Append("\n");
            sb.Append("  EasyShipShipmentStatus: ").Append(EasyShipShipmentStatus).Append("\n");
            sb.Append("  CbaDisplayableShippingLabel: ").Append(CbaDisplayableShippingLabel).Append("\n");
            sb.Append("  OrderType: ").Append(OrderType).Append("\n");
            sb.Append("  EarliestShipDate: ").Append(EarliestShipDate).Append("\n");
            sb.Append("  LatestShipDate: ").Append(LatestShipDate).Append("\n");
            sb.Append("  EarliestDeliveryDate: ").Append(EarliestDeliveryDate).Append("\n");
            sb.Append("  LatestDeliveryDate: ").Append(LatestDeliveryDate).Append("\n");
            sb.Append("  IsBusinessOrder: ").Append(IsBusinessOrder).Append("\n");
            sb.Append("  IsPrime: ").Append(IsPrime).Append("\n");
            sb.Append("  IsPremiumOrder: ").Append(IsPremiumOrder).Append("\n");
            sb.Append("  IsGlobalExpressEnabled: ").Append(IsGlobalExpressEnabled).Append("\n");
            sb.Append("  ReplacedOrderId: ").Append(ReplacedOrderId).Append("\n");
            sb.Append("  IsReplacementOrder: ").Append(IsReplacementOrder).Append("\n");
            sb.Append("  PromiseResponseDueDate: ").Append(PromiseResponseDueDate).Append("\n");
            sb.Append("  IsEstimatedShipDateSet: ").Append(IsEstimatedShipDateSet).Append("\n");
            sb.Append("  IsSoldByAB: ").Append(IsSoldByAB).Append("\n");
            sb.Append("  DefaultShipFromLocationAddress: ").Append(DefaultShipFromLocationAddress).Append("\n");
            sb.Append("  FulfillmentInstruction: ").Append(FulfillmentInstruction).Append("\n");
            sb.Append("  IsISPU: ").Append(IsISPU).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Order);
        }

        /// <summary>
        /// Returns true if Order instances are equal
        /// </summary>
        /// <param name="input">Instance of Order to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Order input)
        {
            if (input == null)
                return false;

            return
                (
                    this.AmazonOrderId == input.AmazonOrderId ||
                    (this.AmazonOrderId != null &&
                    this.AmazonOrderId.Equals(input.AmazonOrderId))
                ) &&
                (
                    this.SellerOrderId == input.SellerOrderId ||
                    (this.SellerOrderId != null &&
                    this.SellerOrderId.Equals(input.SellerOrderId))
                ) &&
                (
                    this.PurchaseDate == input.PurchaseDate ||
                    (this.PurchaseDate != null &&
                    this.PurchaseDate.Equals(input.PurchaseDate))
                ) &&
                (
                    this.LastUpdateDate == input.LastUpdateDate ||
                    (this.LastUpdateDate != null &&
                    this.LastUpdateDate.Equals(input.LastUpdateDate))
                ) &&
                (
                    this.OrderStatus == input.OrderStatus ||
                    (this.OrderStatus != null &&
                    this.OrderStatus.Equals(input.OrderStatus))
                ) &&
                (
                    this.FulfillmentChannel == input.FulfillmentChannel ||
                    (this.FulfillmentChannel != null &&
                    this.FulfillmentChannel.Equals(input.FulfillmentChannel))
                ) &&
                (
                    this.SalesChannel == input.SalesChannel ||
                    (this.SalesChannel != null &&
                    this.SalesChannel.Equals(input.SalesChannel))
                ) &&
                (
                    this.OrderChannel == input.OrderChannel ||
                    (this.OrderChannel != null &&
                    this.OrderChannel.Equals(input.OrderChannel))
                ) &&
                (
                    this.ShipServiceLevel == input.ShipServiceLevel ||
                    (this.ShipServiceLevel != null &&
                    this.ShipServiceLevel.Equals(input.ShipServiceLevel))
                ) &&
                (
                    this.OrderTotal == input.OrderTotal ||
                    (this.OrderTotal != null &&
                    this.OrderTotal.Equals(input.OrderTotal))
                ) &&
                (
                    this.NumberOfItemsShipped == input.NumberOfItemsShipped ||
                    (this.NumberOfItemsShipped != null &&
                    this.NumberOfItemsShipped.Equals(input.NumberOfItemsShipped))
                ) &&
                (
                    this.NumberOfItemsUnshipped == input.NumberOfItemsUnshipped ||
                    (this.NumberOfItemsUnshipped != null &&
                    this.NumberOfItemsUnshipped.Equals(input.NumberOfItemsUnshipped))
                ) &&
                (
                    this.PaymentExecutionDetail == input.PaymentExecutionDetail ||
                    (this.PaymentExecutionDetail != null &&
                    this.PaymentExecutionDetail.Equals(input.PaymentExecutionDetail))
                ) &&
                (
                    this.PaymentMethod == input.PaymentMethod ||
                    (this.PaymentMethod != null &&
                    this.PaymentMethod.Equals(input.PaymentMethod))
                ) &&
                (
                    this.PaymentMethodDetails == input.PaymentMethodDetails ||
                    (this.PaymentMethodDetails != null &&
                    this.PaymentMethodDetails.Equals(input.PaymentMethodDetails))
                ) &&
                (
                    this.MarketplaceId == input.MarketplaceId ||
                    (this.MarketplaceId != null &&
                    this.MarketplaceId.Equals(input.MarketplaceId))
                ) &&
                (
                    this.ShipmentServiceLevelCategory == input.ShipmentServiceLevelCategory ||
                    (this.ShipmentServiceLevelCategory != null &&
                    this.ShipmentServiceLevelCategory.Equals(input.ShipmentServiceLevelCategory))
                ) &&
                (
                    this.EasyShipShipmentStatus == input.EasyShipShipmentStatus ||
                    (this.EasyShipShipmentStatus != null &&
                    this.EasyShipShipmentStatus.Equals(input.EasyShipShipmentStatus))
                ) &&
                (
                    this.CbaDisplayableShippingLabel == input.CbaDisplayableShippingLabel ||
                    (this.CbaDisplayableShippingLabel != null &&
                    this.CbaDisplayableShippingLabel.Equals(input.CbaDisplayableShippingLabel))
                ) &&
                (
                    this.OrderType == input.OrderType ||
                    (this.OrderType != null &&
                    this.OrderType.Equals(input.OrderType))
                ) &&
                (
                    this.EarliestShipDate == input.EarliestShipDate ||
                    (this.EarliestShipDate != null &&
                    this.EarliestShipDate.Equals(input.EarliestShipDate))
                ) &&
                (
                    this.LatestShipDate == input.LatestShipDate ||
                    (this.LatestShipDate != null &&
                    this.LatestShipDate.Equals(input.LatestShipDate))
                ) &&
                (
                    this.EarliestDeliveryDate == input.EarliestDeliveryDate ||
                    (this.EarliestDeliveryDate != null &&
                    this.EarliestDeliveryDate.Equals(input.EarliestDeliveryDate))
                ) &&
                (
                    this.LatestDeliveryDate == input.LatestDeliveryDate ||
                    (this.LatestDeliveryDate != null &&
                    this.LatestDeliveryDate.Equals(input.LatestDeliveryDate))
                ) &&
                (
                    this.IsBusinessOrder == input.IsBusinessOrder ||
                    (this.IsBusinessOrder != null &&
                    this.IsBusinessOrder.Equals(input.IsBusinessOrder))
                ) &&
                (
                    this.IsPrime == input.IsPrime ||
                    (this.IsPrime != null &&
                    this.IsPrime.Equals(input.IsPrime))
                ) &&
                (
                    this.IsPremiumOrder == input.IsPremiumOrder ||
                    (this.IsPremiumOrder != null &&
                    this.IsPremiumOrder.Equals(input.IsPremiumOrder))
                ) &&
                (
                    this.IsGlobalExpressEnabled == input.IsGlobalExpressEnabled ||
                    (this.IsGlobalExpressEnabled != null &&
                    this.IsGlobalExpressEnabled.Equals(input.IsGlobalExpressEnabled))
                ) &&
                (
                    this.ReplacedOrderId == input.ReplacedOrderId ||
                    (this.ReplacedOrderId != null &&
                    this.ReplacedOrderId.Equals(input.ReplacedOrderId))
                ) &&
                (
                    this.IsReplacementOrder == input.IsReplacementOrder ||
                    (this.IsReplacementOrder != null &&
                    this.IsReplacementOrder.Equals(input.IsReplacementOrder))
                ) &&
                (
                    this.PromiseResponseDueDate == input.PromiseResponseDueDate ||
                    (this.PromiseResponseDueDate != null &&
                    this.PromiseResponseDueDate.Equals(input.PromiseResponseDueDate))
                ) &&
                (
                    this.IsEstimatedShipDateSet == input.IsEstimatedShipDateSet ||
                    (this.IsEstimatedShipDateSet != null &&
                    this.IsEstimatedShipDateSet.Equals(input.IsEstimatedShipDateSet))
                ) &&
                (
                    this.IsSoldByAB == input.IsSoldByAB ||
                    (this.IsSoldByAB != null &&
                    this.IsSoldByAB.Equals(input.IsSoldByAB))
                ) &&
                (
                    this.DefaultShipFromLocationAddress == input.DefaultShipFromLocationAddress ||
                    (this.DefaultShipFromLocationAddress != null &&
                    this.DefaultShipFromLocationAddress.Equals(input.DefaultShipFromLocationAddress))
                ) &&
                (
                    this.FulfillmentInstruction == input.FulfillmentInstruction ||
                    (this.FulfillmentInstruction != null &&
                    this.FulfillmentInstruction.Equals(input.FulfillmentInstruction))
                ) &&
                (
                    this.IsISPU == input.IsISPU ||
                    (this.IsISPU != null &&
                    this.IsISPU.Equals(input.IsISPU))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.AmazonOrderId != null)
                    hashCode = hashCode * 59 + this.AmazonOrderId.GetHashCode();
                if (this.SellerOrderId != null)
                    hashCode = hashCode * 59 + this.SellerOrderId.GetHashCode();
                if (this.PurchaseDate != null)
                    hashCode = hashCode * 59 + this.PurchaseDate.GetHashCode();
                if (this.LastUpdateDate != null)
                    hashCode = hashCode * 59 + this.LastUpdateDate.GetHashCode();
                if (this.OrderStatus != null)
                    hashCode = hashCode * 59 + this.OrderStatus.GetHashCode();
                if (this.FulfillmentChannel != null)
                    hashCode = hashCode * 59 + this.FulfillmentChannel.GetHashCode();
                if (this.SalesChannel != null)
                    hashCode = hashCode * 59 + this.SalesChannel.GetHashCode();
                if (this.OrderChannel != null)
                    hashCode = hashCode * 59 + this.OrderChannel.GetHashCode();
                if (this.ShipServiceLevel != null)
                    hashCode = hashCode * 59 + this.ShipServiceLevel.GetHashCode();
                if (this.OrderTotal != null)
                    hashCode = hashCode * 59 + this.OrderTotal.GetHashCode();
                if (this.NumberOfItemsShipped != null)
                    hashCode = hashCode * 59 + this.NumberOfItemsShipped.GetHashCode();
                if (this.NumberOfItemsUnshipped != null)
                    hashCode = hashCode * 59 + this.NumberOfItemsUnshipped.GetHashCode();
                if (this.PaymentExecutionDetail != null)
                    hashCode = hashCode * 59 + this.PaymentExecutionDetail.GetHashCode();
                if (this.PaymentMethod != null)
                    hashCode = hashCode * 59 + this.PaymentMethod.GetHashCode();
                if (this.PaymentMethodDetails != null)
                    hashCode = hashCode * 59 + this.PaymentMethodDetails.GetHashCode();
                if (this.MarketplaceId != null)
                    hashCode = hashCode * 59 + this.MarketplaceId.GetHashCode();
                if (this.ShipmentServiceLevelCategory != null)
                    hashCode = hashCode * 59 + this.ShipmentServiceLevelCategory.GetHashCode();
                if (this.EasyShipShipmentStatus != null)
                    hashCode = hashCode * 59 + this.EasyShipShipmentStatus.GetHashCode();
                if (this.CbaDisplayableShippingLabel != null)
                    hashCode = hashCode * 59 + this.CbaDisplayableShippingLabel.GetHashCode();
                if (this.OrderType != null)
                    hashCode = hashCode * 59 + this.OrderType.GetHashCode();
                if (this.EarliestShipDate != null)
                    hashCode = hashCode * 59 + this.EarliestShipDate.GetHashCode();
                if (this.LatestShipDate != null)
                    hashCode = hashCode * 59 + this.LatestShipDate.GetHashCode();
                if (this.EarliestDeliveryDate != null)
                    hashCode = hashCode * 59 + this.EarliestDeliveryDate.GetHashCode();
                if (this.LatestDeliveryDate != null)
                    hashCode = hashCode * 59 + this.LatestDeliveryDate.GetHashCode();
                if (this.IsBusinessOrder != null)
                    hashCode = hashCode * 59 + this.IsBusinessOrder.GetHashCode();
                if (this.IsPrime != null)
                    hashCode = hashCode * 59 + this.IsPrime.GetHashCode();
                if (this.IsPremiumOrder != null)
                    hashCode = hashCode * 59 + this.IsPremiumOrder.GetHashCode();
                if (this.IsGlobalExpressEnabled != null)
                    hashCode = hashCode * 59 + this.IsGlobalExpressEnabled.GetHashCode();
                if (this.ReplacedOrderId != null)
                    hashCode = hashCode * 59 + this.ReplacedOrderId.GetHashCode();
                if (this.IsReplacementOrder != null)
                    hashCode = hashCode * 59 + this.IsReplacementOrder.GetHashCode();
                if (this.PromiseResponseDueDate != null)
                    hashCode = hashCode * 59 + this.PromiseResponseDueDate.GetHashCode();
                if (this.IsEstimatedShipDateSet != null)
                    hashCode = hashCode * 59 + this.IsEstimatedShipDateSet.GetHashCode();
                if (this.IsSoldByAB != null)
                    hashCode = hashCode * 59 + this.IsSoldByAB.GetHashCode();
                if (this.DefaultShipFromLocationAddress != null)
                    hashCode = hashCode * 59 + this.DefaultShipFromLocationAddress.GetHashCode();
                if (this.FulfillmentInstruction != null)
                    hashCode = hashCode * 59 + this.FulfillmentInstruction.GetHashCode();
                if (this.IsISPU != null)
                    hashCode = hashCode * 59 + this.IsISPU.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}
