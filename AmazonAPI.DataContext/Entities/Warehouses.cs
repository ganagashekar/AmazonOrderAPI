using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonOrderAPI.DataContext.Entities
{
    [Table("Warehouse", Schema = "amz")]
    public class Warehouse 
    {
        [Key]
        public long Id { set; get; }
        public string WarehouseLocationName { get; set; }

        public string WarehouseLocationCode { get; set; }

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

        public bool? IsActive { get; set; }

        public long SellerId { set; get; }

        [ForeignKey("SellerId")]
        public virtual Seller Seller { set; get; }

        [AutoMapper.IgnoreMap()]
        private DateTime? dateCreated { set; get; }

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
    }
}