using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.SellingPartnerAPIAA.Builders
{
    public class LWAAuthorizationCredentialsBuilder
    {
        LWAAuthorizationCredentials lWAAuthorizationCredentials = new LWAAuthorizationCredentials();

        public LWAAuthorizationCredentials Build() => lWAAuthorizationCredentials;
        public LWAAuthorizationCredentialsBuilder SetClientId(string ClientId)
        {
            lWAAuthorizationCredentials.ClientId = ClientId;
            return this;
        }
        public LWAAuthorizationCredentialsBuilder SetClientSecret(string ClientSecret)
        {
            lWAAuthorizationCredentials.ClientSecret = ClientSecret;
            return this;
        }
        public LWAAuthorizationCredentialsBuilder SetRefreshToken(string RefreshToken)
        {
            lWAAuthorizationCredentials.RefreshToken = RefreshToken;
            return this;
        }
        public LWAAuthorizationCredentialsBuilder SetScopes(List<string> Scopes)
        {
            lWAAuthorizationCredentials.Scopes = Scopes;
            return this;
        }
    }
}
