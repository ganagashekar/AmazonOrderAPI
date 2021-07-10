using AmazonOrderAPI.Business.Model.Seller;
using System.ComponentModel.DataAnnotations;
namespace AmazonOrderAPI.Business.Model
{
    public class OrderItemVM
    {
        public long Id { get; set; }

        [Display(Name = "Order Id")]
        public long AmazonOrderId { get; set; }

        public OrderVM Orders { set; get; }

        public string ASIN { get; set; }

        [Display(Name = "Seller SKU")]
        public string SellerSKU { get; set; }

        [Display(Name = "Order Item Id")]
        public string OrderItemId { get; set; }

        public string Title { get; set; }

        [Display(Name = "Quantity Ordered")]
        public decimal QuantityOrdered { get; set; }

        [Display(Name = "Quantity Shipped")]
        public decimal QuantityShipped { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? ProductInfoId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? PointsGrantedId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? ItemPriceId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? ShippingPriceId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? GiftWrapPriceId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? ItemTaxId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? ShippingTaxId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? GiftWrapTaxId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? ShippingDiscountId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? ShippingDiscountTaxId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? PromotionDiscountId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? PromotionDiscountTaxId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? CODFeeId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? CODFeeDiscountId { get; set; }

        [Display(Name = "Is Gift")]
        public bool IsGift { get; set; }

        [AutoMapper.IgnoreMap()]
        public string GiftMessageText { get; set; }

        [AutoMapper.IgnoreMap()]
        public string GiftWrapLevel { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? InvoiceDataId { get; set; }

        [AutoMapper.IgnoreMap()]
        public string ConditionNote { get; set; }

        [Display(Name = "Condition Id")]
        public string ConditionId { get; set; }

        [Display(Name = "Condition Subtype Id")]
        public string ConditionSubtypeId { get; set; }

        [AutoMapper.IgnoreMap()]
        [Display(Name = "Scheduled Delivery Start Date")]
        public string ScheduledDeliveryStartDate { get; set; }

        [AutoMapper.IgnoreMap()]
        [Display(Name = "Scheduled Delivery End Date")]
        public string ScheduledDeliveryEndDate { get; set; }

        [AutoMapper.IgnoreMap()]
        public string PriceDesignation { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? BuyerCustomizedInfoId { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? TaxCollectionId { get; set; }

        [Display(Name = "Serial Number Required")]
        public bool SerialNumberRequired { get; set; }

        [AutoMapper.IgnoreMap()]
        public bool IsTransparency { get; set; }

        [AutoMapper.IgnoreMap()]
        public string eZTrackReferenceNumber { set; get; }

        [Display(Name = "Warehouse Id")]
        public long? Warehouseid { get; set; }
        public virtual WarehouseVM PickupAddress { set; get; }

        [Display(Name = "Consignment Number")]
        public string ConsignmentNo { set; get; }

        [Display(Name = "Seller Id")]
        public long SellerId { get; set; }
        public virtual SellerVM Seller { set; get; }

        [Display(Name = "Pickup Failure Reason")]
        public string PickupFailureReason { set; get; }
    }
}