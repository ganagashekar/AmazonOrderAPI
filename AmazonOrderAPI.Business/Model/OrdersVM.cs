using System;
using System.ComponentModel.DataAnnotations;
namespace AmazonOrderAPI.Business.Model
{
    public class OrderVM
    {
        public long Id { get; set; }

        [Display(Name = "Amazon Order Id")]
        public string AmazonOrderId { get; set; }

        [Display(Name = "Seller Order Id")]
        public string SellerOrderId { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [AutoMapper.IgnoreMap()]
        public DateTime LastUpdateDate { get; set; }

        [Display(Name = "Order Status")]
        public string OrderStatus { get; set; }

        [AutoMapper.IgnoreMap()]
        public string FulfillmentChannel { get; set; }

        [AutoMapper.IgnoreMap()]
        public string SalesChannel { get; set; }

        [AutoMapper.IgnoreMap()]
        public string OrderChannel { get; set; }

        [AutoMapper.IgnoreMap()]
        public string ShipServiceLevel { get; set; }

       // public long? ShippingAddressId { get; set; }
        public virtual AddressVM ItemAddress { set; get; }

        [AutoMapper.IgnoreMap()]
        public long? OrderTotalId { get; set; }

        [AutoMapper.IgnoreMap()]
        public decimal NumberOfItemsShipped { get; set; }

        [Display(Name = "Number Of Items Unshipped")]
        public decimal NumberOfItemsUnshipped { get; set; }

        [AutoMapper.IgnoreMap()]
        public string PaymentMethod { get; set; }

        [AutoMapper.IgnoreMap()]
        public string MarketplaceId { get; set; }

        [AutoMapper.IgnoreMap()]
        public string BuyerEmail { get; set; }

        [AutoMapper.IgnoreMap()]
        public string BuyerName { get; set; }

        [AutoMapper.IgnoreMap()]
        public string BuyerCounty { get; set; }

        [AutoMapper.IgnoreMap()]
        public long? BuyerTaxInfoId { get; set; }

        [AutoMapper.IgnoreMap()]
        public string ShipmentServiceLevelCategory { get; set; }

        [AutoMapper.IgnoreMap()]
        public bool ShippedByAmazonTFM { get; set; }

        [AutoMapper.IgnoreMap()]
        public string TFMShipmentStatus { get; set; }

        [AutoMapper.IgnoreMap()]
        public string EasyShipShipmentStatus { get; set; }

        [AutoMapper.IgnoreMap()]
        public string CbaDisplayableShippingLabel { get; set; }

        [Display(Name = "Order Type")]
        public string OrderType { get; set; }

        [Display(Name = "Earliest Ship Date")]
        public DateTime EarliestShipDate { get; set; }

        public DateTime LatestShipDate { get; set; }

        public DateTime EarliestDeliveryDate { get; set; }

        public DateTime LatestDeliveryDate { get; set; }

        public bool IsBusinessOrder { get; set; }

        [AutoMapper.IgnoreMap()]
        public string PurchaseOrderNumber { get; set; }

        public bool IsPrime { get; set; }

        public bool IsPremiumOrder { get; set; }

        [AutoMapper.IgnoreMap()]
        public string ReplacedOrderId { get; set; }

        [AutoMapper.IgnoreMap()]
        public bool IsReplacementOrder { get; set; }

        [AutoMapper.IgnoreMap()]
        public DateTime PromiseResponseDueDate { get; set; }

        [AutoMapper.IgnoreMap()]
        public bool IsEstimatedShipDateSet { get; set; }

        [AutoMapper.IgnoreMap()]
        public int? ShippingAddressStatusId { get; set; }

        [AutoMapper.IgnoreMap()]
        public int? ListOrderItemStatusId { get; set; }

        public bool IsEzShipOrder { get; set; }
    }
}