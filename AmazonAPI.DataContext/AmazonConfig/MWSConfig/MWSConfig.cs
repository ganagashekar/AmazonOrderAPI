using AmazonOrderAPI.DataContext;
using System.Collections.Generic;
using System.Linq;

namespace AmazonOrderAPI.AmazonConfig.MWSConfig
{
    public class MWSConfig
    {
        public static string AccessKey;
        public static string SecretKey;
        public static string SellerId;
        public static string appName;
        public static string appVersion;
        public static string serviceURL;
        public static string mwsAuthToken;
        public static string MarketplaceId;
        public OrderContext _dbContext;

        public MWSConfig(OrderContext dbContext, string SellerId)
        {
            _dbContext = dbContext;
            SetConfig(SellerId);
        }

        public Dictionary<string, string> GetConfig()
        {
            return new Dictionary<string, string>() {
                { "AccessKey",AccessKey},
                 { "SecretKey",SecretKey},
                 { "SellerId",SellerId},
                 { "AppName",appName},
                 { "AppVersion",appVersion},
                 { "ServiceURL",serviceURL},
                 { "MWSAuthToken",mwsAuthToken },
                { "MarketplaceId",MarketplaceId}
            };
        }

        private void SetConfig(string SellerId = "SP_Courier")
        {
            var Configuration = _dbContext.Sellers.FirstOrDefault(x => x.SellerId == SellerId);// && x.IsStage == false);

            AccessKey = Configuration.AccessKey;
            SecretKey = Configuration.SecretKey;
            SellerId = Configuration.SellerId;
            appName = Constants.AppName;
            appVersion = "1.0";
            serviceURL = Configuration.ServiceURL;
            mwsAuthToken = Configuration.MWSAuthToken;
            MarketplaceId = Configuration.MarketplaceId;
        }
    }
}