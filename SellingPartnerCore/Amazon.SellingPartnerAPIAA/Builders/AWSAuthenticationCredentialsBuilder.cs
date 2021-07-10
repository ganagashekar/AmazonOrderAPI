using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.SellingPartnerAPIAA.Builders
{
   public class AWSAuthenticationCredentialsBuilder
    {

        private AWSAuthenticationCredentials _aWSAuthenticationCredentials = new AWSAuthenticationCredentials();
        public AWSAuthenticationCredentials Build() => _aWSAuthenticationCredentials;
        public AWSAuthenticationCredentialsBuilder SetAccessKeyId(string accessKeyId)
        {
            _aWSAuthenticationCredentials.AccessKeyId = accessKeyId;
            return this;
        }
        public AWSAuthenticationCredentialsBuilder SetSecretKey(string secretKey)
        {
            _aWSAuthenticationCredentials.SecretKey = secretKey;
            return this;
        }
        public AWSAuthenticationCredentialsBuilder SetRegion(string region)
        {
            _aWSAuthenticationCredentials.Region = region;
            return this;
        }
    }
}
