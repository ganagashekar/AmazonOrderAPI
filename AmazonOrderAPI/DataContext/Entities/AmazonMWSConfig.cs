using System;

namespace AmazonOrderAPI.DataContext.Entities
{


    public class AmazonMWSConfig:Entity
    {
       

        public string ClientId { get; set; }

        public string AccessKey { get; set; }

        public string SecretKey { get; set; }

        public string SellerId { get; set; }

        public string AppName { get; set; }

        public string ServiceURL { get; set; }

        public string MWSAuthToken { get; set; }

        public string MarketplaceId { get; set; }

        public string Country { get; set; }

        public string CountryCode { get; set; }

        public string CurrencyCode { get; set; }

        public bool IsStage { get; set; }




    }
}
