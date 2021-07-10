using AmazonOrderAPI.Business.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AmazonOrderAPI.Business.Model.Reports
{
    public class OrderStatusReport
    {
        public OrderStatusReport()
        {
            StatusReport = new List<OrderItemStatusDetail>();
            Status = new List<SelectItem>();
        }

        public List<OrderItemStatusDetail> StatusReport { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { set; get; }

        public List<SelectItem> Status { get; set; }
        public string StatusItems { get; set; }

        public List<SelectItem> Sellers { get; set; }
        public string SellerId { get; set; }

        public string MulChkJOBID { get; set; }
    }

    public class OrderItemStatusDetail
    {
        public long sellerId { get; set; }
        public string ConsignmentNo { get; set; }
        public string AmazonOrderId { set; get; }
        public string OrderId { set; get; }
        public string DropOffPincode { set; get; }
        public string DropOffCity { set; get; }
        public string PickupPincode { set; get; }
        public string PickupCity { set; get; }
        public string ASIN { set; get; }
        public string ConditionId { set; get; }
        public string ConditionSubTypeId { set; get; }
        public string OrderItemId { set; get; }
        public decimal QuantityOrdered { set; get; }
        public decimal QuantityShipped { set; get; }
        public bool IsGift { set; get; }
        public bool IsSerialNumberRequired { set; get; }
        public string Title { set; get; }
        public string Status { set; get; }
        public string Reason { set; get; }
        public string ReferenceNumber { set; get; }
        public string DropUserName { set; get; }
        public string DropMobileNumber { set; get; }
        public string DropAddress { set; get; }
        public string SellerSKU { set; get; }
        public string PickupUserName { set; get; }
        public string PickupMobileNumber { set; get; }
        public string PickupAddress { set; get; }
        public long Id { set; get; }
        public DateTime OrderDate { set; get; }
        public bool IsPrime { set; get; }
        public DateTime LatestShipDate { set; get; }
        public DateTime LastUpdatedDate { set; get; }

        public List<SelectItem> WareHouse { get; set; }
        public long? WarehouseId { get; set; }
        [AutoMapper.IgnoreMap]
        public bool DisablSaving  {get;set;}

    }
}