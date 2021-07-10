using Amazon.SellingPartnerAPIAA;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonOrderAPI.Business.Builders
{
    public class SellerAPICredentials
    {

        #region Static 

        //public string LWA_App_ClientId = "amzn1.application-oa2-client.392bc1a9330f4ff08f29e29022a17020"; //amzn...
        //public string LWA_App_ClientSecret = "3509d4a3dc2a2d4cb3f616494026e12a72d76ebea121e9d491efb5dbbf268117";
        //public string RefreshToken = "Atzr|IwEBICp51f3m4eUk6llLfMJ9JCHWaBlJtue_Tf44UOCDTXFTv5MSPdt8FBHKwu9u4eTiUj1-wVxKTr4hU7i0iK8hYmZ_G15kzFjvo33eWzShDyc_gGBaq8TbOmYw1jftB2Q_yRJTbDw0__Kh5_Ul71-SQEOC4TcabRkG_ze3FvHL3Yq8Pf-5kukOzScrGIM3oACCnUyCO6rmQgeMQb4u5a9ROAeU81WG-5CXTN5K35EdCX_9GxrLJXw2A22l7Qofrir4Ie1ri8eiboDQEpjsh68wqYtXUZlWlCe4qZ4ZXe2W-w3mYItE1Y7iJgNkngQXy8oeyN0";
        //public string AWSKey = "AKIA3EHQ4L5SZESAVLUX";
        //public string AWSSecret = "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";
        //public string RoleARN = "arn:aws:iam::765009354597:role/SellingPartnerAPI"; //arn...
        //public string Region = "eu-west-1";
        //public string TokenEndPoint = "https://api.amazon.com/auth/o2/token";

        #endregion
        #region OldOne
        //// public string LWA_App_ClientId = "AKIAJHZH6T24LVVHH3DA"; //amzn...
        ////  public string LWA_App_ClientSecret = "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";
        //public string LWA_App_ClientId = "amzn1.application-oa2-client.6ec78d0b49764ccdaa80590fc479c6db"; //amzn...
        //public string LWA_App_ClientSecret = "cd1d3c9d9616901999115de2836324db3e411ae03ea5c09fca80676d22ff5623";
        //public string RefreshToken = "Atzr|IwEBIK4iJFaSFh5lZCck-Umbq8Vm60rFWRslkmhr75-uMBsZ419AJsob-5mbcVsA8w-zFwtpS4vAQZTX84-A8fNOaCGvj7JU02ZKPwx_vL2EDs79A2RIWdSx9lZXlxS1UqtT2qzCut9_vqO43wPnnO_jF_q7CxcT3qXcybTDBOc6dpL3ootfyboZvxI1rO02GajYBsM-Pkv-iLak7sSgIgJmez2WjYivkCdqkFuPvV9gZ1hkEcFXPwdg139a1O10YypdPh1Uae6y2bVOdk_T_Q4SXpEQmZQGufM_gJf_VHckPA-7hvrz36nOSDFZqiY9udURelQ";
        ////public string AWSKey = "AKIA3EHQ4L5S4TZLUWFA";
        ////public string AWSSecret = "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";
        //public string Region = "eu-west-1";
        //public string AWSKey = "AKIA3EHQ4L5SZESAVLUX";
        //public string AWSSecret = "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";
        //public string RoleARN = "arn:aws:iam::765009354597:role/SellingPartnerAPI"; //arn...
        //public string TokenEndPoint = "https://api.amazon.com/auth/o2/token";

        #endregion
    }
    public class TokenAPI
    {
        // TokenAPI _sellerAPI;
        //public TokenAPI()
        //{
        //    _sellerAPI = new TokenAPI();
        //}

        private AWSAuthenticationCredentials _aWSCredentials;
        private LWAAuthorizationCredentials _lWAAuthorizationCredentials;
       // public TokenAPI Build() => _sellerAPI;
        public TokenAPI awsAuthenticationCredentials(AWSAuthenticationCredentials aWSAuthenticationCredentials)
        {
            _aWSCredentials = aWSAuthenticationCredentials;
            return this;
        }
        public TokenAPI lwaAuthorizationCredentials(LWAAuthorizationCredentials lWAAuthorizationCredentials)
        {
            _lWAAuthorizationCredentials = lWAAuthorizationCredentials;
            return this;
        }

        public LWAAuthorizationCredentials GetLWAAuthorizationCredentials()
        {
            return _lWAAuthorizationCredentials;

        }
        public AWSAuthenticationCredentials GetAWSAuthenticationCredentials()
        {
            return _aWSCredentials;

        }

        public TokenAPI endpoint(string endpointURL)
        {
            _lWAAuthorizationCredentials.Endpoint = new Uri(endpointURL);
            return this;
        }



    }
}
