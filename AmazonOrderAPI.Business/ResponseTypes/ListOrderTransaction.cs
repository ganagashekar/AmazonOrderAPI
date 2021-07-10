using System;
using System.Collections.Generic;

namespace AmazonOrderAPI.Business.ResponseTypes
{
    public class ListOrderTransaction
    {
        public ListOrderTransaction()
        {
            OrdersItems = new List<OrdersItemInfo>();
        }

        public List<OrdersItemInfo> OrdersItems { set; get; }
    }

    public class OrderTransaction
    {
        public DateTime PurchaseDate { set; get; }
        public string OrderStatus { set; get; }
        public string AmazonOrderId { set; get; }
        public string ShipServiceLevel { set; get; }
        public string NumberOfItemsShipped { set; get; }
        public string NumberOfItemsUnshipped { set; get; }

        public OrderItemAddress Address { set; get; }
    }

    public class OrdersItemInfo
    {
        public long Id { set; get; }
        public string Description { get; set; }
        public decimal NoOfPieces { set; get; }
        public string ReferenceNumber { set; get; }
        public string OrderType { get; set; }
        public DateTime EarliestShipDate { get; set; }
        public DateTime LatestShipDate { get; set; }
        public DateTime EarliestDeliveryDate { get; set; }
        public DateTime LatestDeliveryDate { get; set; }
        public bool IsBusinessOrder { get; set; }
        public bool IsPrime { get; set; }
        public bool IsPremiumOrder { get; set; }
        public OrderItemAddress DeliveryConsigneeAddress { set; get; }
        public PikcupAddress PickupAddress { set; get; }
        public string CustomerCode { set; get; }
        public bool IsAutoManual { get; set; }
        public bool IsShouldbeGenConsNo { get; set; }

        public long CreatedBy { get; set; }
        public string Title { get; set; }
        public bool IsEzShipOrder { get; set; }
    }

    public class OrderItemAddress
    {
        public string Name { set; get; }
        public string AddressLine1 { set; get; }
        public string AddressLine2 { set; get; }
        public string AddressLine3 { set; get; }
        public string City { get; set; }

        [AutoMapper.IgnoreMap()]
        public string Country { get; set; }

        public string District { get; set; }

        [AutoMapper.IgnoreMap()]
        public string StateOrRegion { get; set; }

        [AutoMapper.IgnoreMap()]
        public string Municipality { get; set; }

        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        public string AddressType { get; set; }
    }

    public class PikcupAddress
    {
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string County { get; set; }

        public string District { get; set; }

        public string StateOrRegion { get; set; }

        public string Municipality { get; set; }

        public string PostalCode { get; set; }

        public string CountryCode { get; set; }

        public string Phone { get; set; }
    }
}