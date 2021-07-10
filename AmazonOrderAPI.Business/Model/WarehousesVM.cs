using AmazonOrderAPI.Business.Model.Seller;
using System.ComponentModel.DataAnnotations;

namespace AmazonOrderAPI.Business.Model
{
    public class WarehouseVM
    {
        public long Id { set; get; }

        public string WarehouseLocationName { get; set; }

        [Display(Name = "Code")]
        public string WarehouseLocationCode { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string District { get; set; }

        public string StateOrRegion { get; set; }

        public string Municipality { get; set; }

        public string PostalCode { get; set; }

        public string CountryCode { get; set; }

        public string Phone { get; set; }

        public string AddressType { get; set; }

        public bool IsActive { get; set; }

        public long SellerId { set; get; }
        public virtual SellerVM Seller { set; get; }
    }
}