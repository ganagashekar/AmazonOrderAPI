using System.ComponentModel.DataAnnotations;
namespace AmazonOrderAPI.Business.Model.Seller
{
    public class SellerVM
    {
        [Display(Name = "Client Id")]
        public string ClientId { get; set; }

        [Display(Name = "Access Key")]
        public string AccessKey { get; set; }

        [Display(Name = "Secret Key")]
        public string SecretKey { get; set; }

        [Display(Name = "Seller Id")]
        public string SellerId { get; set; }

        [Display(Name = "Seller Name")]
        public string SellerName { get; set; }

        //public string AppName { get; set; }
        [Display(Name = "Service URL")]
        public string ServiceURL { get; set; }

        [Display(Name = "MWS Authorization Token")]
        public string MWSAuthToken { get; set; }

        [Display(Name = "Marketplace Id")]
        public string MarketplaceId { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [AutoMapper.IgnoreMap]
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Display(Name = "Currency Code")]
        public string CurrencyCode { get; set; }

        [Display(Name = "Is Stage")]
        public bool IsStage { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        public long Id { set; get; }

        [Display(Name = "Generate Auto Pickup")]
        public bool IsAutoManual { get; set; }

        [Display(Name = "Should Generate Consignment Number")]
        public bool IsShouldbeGenConsNo { get; set; }

        [Display(Name = "Created By")]
        public long CreatedBy { get; set; }

        [Display(Name = "Customer Code")]
        public string CustomerCode { set; get; }
    }
}