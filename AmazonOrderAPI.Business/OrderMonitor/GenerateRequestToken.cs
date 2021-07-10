using Amazon.SellingPartnerAPIAA;
using Amazon.SellingPartnerAPIAA.Builders;
using AmazonOrderAPI.Business.Builders;
using AmazonOrderAPI.DataContext.Entities;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonOrderAPI.Business.OrderMonitor
{
    public static class GenerateRequestToken
    {
        static TokenAPI tokenAPI;
        static GenerateRequestToken()
        {
            tokenAPI = new TokenAPI();
        }

        public static string GetAccessTokenForSeller(Seller sellerAPICredentials)
        {

            tokenAPI.awsAuthenticationCredentials(new AWSAuthenticationCredentialsBuilder()
            .SetAccessKeyId(sellerAPICredentials.AWS_AccessKey)
            .SetRegion(sellerAPICredentials.Region)
            .SetSecretKey(sellerAPICredentials.AWS_Secretkey).Build())
            .lwaAuthorizationCredentials(new LWAAuthorizationCredentialsBuilder()
            .SetClientId(sellerAPICredentials.LWA_ClientId)
            .SetRefreshToken(sellerAPICredentials.LWA_RefreshToken)
            .SetClientSecret(sellerAPICredentials.LWA_ClientSecret)
            .Build())
            .endpoint(sellerAPICredentials.TokenEndPoint);
            //.Build();
            return new LWAAuthorizationSigner(tokenAPI.GetLWAAuthorizationCredentials()).Sign();
        }
        //public static string GetAccessTokenForSeller(SellerAPICredentials sellerAPICredentials)
        //{

        //    tokenAPI.awsAuthenticationCredentials(new AWSAuthenticationCredentialsBuilder()
        //    .SetAccessKeyId(sellerAPICredentials.AWSKey)
        //    .SetRegion(sellerAPICredentials.Region)
        //    .SetSecretKey(sellerAPICredentials.AWSSecret).Build())
        //    .lwaAuthorizationCredentials(new LWAAuthorizationCredentialsBuilder()
        //    .SetClientId(sellerAPICredentials.LWA_App_ClientId)
        //    .SetRefreshToken(sellerAPICredentials.RefreshToken)
        //    .SetClientSecret(sellerAPICredentials.LWA_App_ClientSecret)
        //    .Build())
        //    .endpoint(sellerAPICredentials.TokenEndPoint);
        //    //.Build();
        //    return new LWAAuthorizationSigner(tokenAPI.GetLWAAuthorizationCredentials()).Sign();
        //}
        public static TokenAPI Build()
        {
            return tokenAPI;


        }
    }
}
