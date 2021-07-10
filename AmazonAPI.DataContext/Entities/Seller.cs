using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmazonOrderAPI.DataContext.Entities
{
    [Table("Sellers", Schema = "amz")]
    public class Seller
    {
        [Key]
        public long Id { set; get; }

        

        public string ClientId { get; set; }

        public string AccessKey { get; set; }

        public string SecretKey { get; set; }

        public string SellerId { get; set; }

        public string SellerName { get; set; }

        public string AppName { get; set; }

        public string ServiceURL { get; set; }

        public string MWSAuthToken { get; set; }

        public string MarketplaceId { get; set; }

        public string Country { get; set; }

        public string CountryCode { get; set; }

        public string CurrencyCode { get; set; }

        public bool IsStage { get; set; }

        public bool IsActive { get; set; }

        public bool IsAutoManual { get; set; }

        public bool IsShouldbeGenConsNo { get; set; }

        public long CreatedBy { get; set; }

        public string CustomerCode { set; get; }

        #region SP Seller API

        public string LWA_ClientId { set; get; }
        public string LWA_ClientSecret { set; get; }
        public string LWA_RefreshToken { set; get; }
        public string AWS_AccessKey { set; get; }
        public string AWS_Secretkey { set; get; }
        public string AWS_RoleARN { set; get; }
        public string Region { set; get; }
        public string TokenEndPoint { set; get; }

        public string SellerAPIEndPoint { set; get; }

        #endregion
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