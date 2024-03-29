﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using AmazonOrderAPI.DataContext;

namespace AmazonAPI
{
    public abstract class IPipeline<TConfig, TClient>
    {
        internal IPipeline(Delegates.GetAmazonCredentialDelegate GetCredentialDelegate, Delegates.ThrottleRequestDelegate ThrottleDelegate)
        {
            this._ThrottleRequest = ThrottleDelegate;
            this._GetCredential = GetCredentialDelegate;
        }


        internal protected AmazonCredential GetCredential() => this._GetCredential();


        private Delegates.ThrottleRequestDelegate _ThrottleRequest;
        private Delegates.GetAmazonCredentialDelegate _GetCredential;

        internal protected TClient GetClient(AmazonCredential Credentials) => (TClient)Activator.CreateInstance(typeof(TClient), Credentials.AccessKeyID, Credentials.SecretAccessKey, this.GetConfig());
        internal protected TConfig GetConfig()
        {
            dynamic Config = (dynamic)Activator.CreateInstance(typeof(TConfig));
            Config.ServiceURL = Definitions.ServiceUrl;
            Config.SetUserAgentHeader(Constants.AppName, Constants.AppVersion, Definitions.ProgrammingLanguage, new string[] { Definitions.ApplicationAbbreviation, Definitions.IntegrationName });
            return (TConfig)Config;
        }



        protected void Throttle()
        {
            MethodBase Method = new StackTrace().GetFrame(1).GetMethod();
            AmazonCallAttribute AmazonAttribute = Method.GetCustomAttribute<AmazonCallAttribute>();
            if (AmazonAttribute == default(AmazonCallAttribute))
                throw new NotImplementedException($"Error the method [{Method.Name}] is not properly implemented and cannot be called!");
            else
                this.Throttle(AmazonAttribute.RequestType);
        }
        protected void Throttle(ERequestType RequestType)
        {
            this._ThrottleRequest(RequestType);
        }
    }
}
