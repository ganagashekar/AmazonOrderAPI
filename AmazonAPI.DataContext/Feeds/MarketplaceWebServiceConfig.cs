/******************************************************************************* 
 *  Copyright 2008 Amazon Services.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Marketplace Web Service CSharp Library
 *  API Version: 2009-01-01
 *  Generated: Mon Mar 16 15:13:52 PDT 2009 
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using MWSClientCsRuntime;

namespace AmazonAPI.Feeds.MarketplaceWebService
{

    /// <summary>
    /// Configuration for accessing Marketplace Web Service  service
    /// </summary>
    public class MarketplaceWebServiceConfig
    {
    
        private String serviceVersion = "2009-01-01";
        private String serviceURL = null;
        private int requestTimeout = 50000;
        private MwsConnection cc = new MwsConnection();

        /// <summary>
        /// Get a clone of the configured connection
        /// </summary>
        /// <returns>A clone of the configured connection</returns>
        internal MwsConnection CopyConnection()
        {
            return (MwsConnection)cc.Clone();
        }

        /// <summary>
        /// Gets and sets the request time-out value in milliseconds.
        /// </summary>
        public int RequestTimeout
        {
            get { return this.requestTimeout; }
            set { this.requestTimeout = value; }
        }

        /// <summary>
        /// Gets Service Version
        /// </summary>
        public String ServiceVersion
        {
            get { return this.serviceVersion ; }
        }
        /// <summary>
        /// Gets and sets of the signatureMethod property.
        /// </summary>
        public String SignatureMethod
        {
            get { return cc.SignatureMethod; }
            set { cc.SignatureMethod = value; }
        }

        /// <summary>
        /// Sets the SignatureMethod property
        /// </summary>
        /// <param name="signatureMethod">SignatureMethod property</param>
        /// <returns>this instance</returns>
        public MarketplaceWebServiceConfig WithSignatureMethod(String signatureMethod)
        {
            cc.SignatureMethod = signatureMethod;
            return this;
        }


        /// <summary>
        /// Checks if SignatureMethod property is set
        /// </summary>
        /// <returns>true if SignatureMethod property is set</returns>
        public Boolean IsSetSignatureMethod()
        {
            return cc.SignatureMethod != null;
        }
        /// <summary>
        /// Gets and sets of the SignatureVersion property.
        /// </summary>
        public String SignatureVersion
        {
            get { return cc.SignatureMethod; }
            set { cc.SignatureMethod = value; }
        }

        /// <summary>
        /// Sets the SignatureVersion property
        /// </summary>
        /// <param name="signatureVersion">SignatureVersion property</param>
        /// <returns>this instance</returns>
        public MarketplaceWebServiceConfig WithSignatureVersion(String signatureVersion)
        {
            cc.SignatureVersion = signatureVersion;
            return this;
        }

        /// <summary>
        /// Checks if SignatureVersion property is set
        /// </summary>
        /// <returns>true if SignatureVersion property is set</returns>
        public Boolean IsSetSignatureVersion()
        {
            return cc.SignatureVersion != null;
        }
    
        /// <summary>
        /// Gets and sets of the UserAgent property.
        /// </summary>
        public String UserAgent
        {
            get { return cc.UserAgent; }
        }

        /// <summary>
        /// Sets the UserAgent
        /// </summary>
        /// <param name="applicationName">Your application's name, e.g. "MyMWSApp"</param>
        /// <param name="applicationVersion">Your application's version, e.g. "1.0"</param>
        /// <returns>this instance</returns>
        public MarketplaceWebServiceConfig WithUserAgent(string applicationName, string applicationVersion)
        {
            SetUserAgent(applicationName, applicationVersion);
            return this;
        }

        public void SetUserAgent(string applicationName, string applicationVersion)
        {
            cc.ApplicationName = applicationName;
            cc.ApplicationVersion = applicationVersion;
        }

        public void SetUserAgentHeader(
            string applicationName,
            string applicationVersion,
            string programmingLanguage,
            params string[] additionalNameValuePairs)
        {
            cc.SetUserAgent(applicationName, applicationVersion, programmingLanguage, additionalNameValuePairs);
        }

        /// <summary>
        /// Checks if UserAgent property is set
        /// </summary>
        /// <returns>true if UserAgent property is set</returns>
        public Boolean IsSetUserAgent()
        {
            return cc.UserAgent != null;
        }

        /// <summary>
        /// Gets the ServiceURL property.
        /// </summary>
        public String ServiceURL
        {
            get { return this.serviceURL ; }
            set {
                Uri fullUri = new Uri(value);
                try
                {
                    cc.Endpoint = new Uri(fullUri.Scheme + "://" + fullUri.Authority);
                    this.serviceURL = value;
                }
                catch (Exception e)
                {
                    throw MwsUtil.Wrap(e);
                }
                finally
                {
                    fullUri = null;
                }
            }
        }

        /// <summary>
        /// Sets the ServiceURL property
        /// </summary>
        /// <param name="serviceURL">ServiceURL property</param>
        /// <returns>this instance</returns>
        public MarketplaceWebServiceConfig WithServiceURL(String serviceURL)
        {
            this.serviceURL = serviceURL;
            return this;
        }

        /// <summary>
        /// Checks if ServiceURL property is set
        /// </summary>
        /// <returns>true if ServiceURL property is set</returns>
        public Boolean IsSetServiceURL()
        {
            return this.serviceURL != null;
        }

        /// <summary>
        /// Gets and sets of the ProxyHost property.
        /// </summary>
        public String ProxyHost
        {
            get { return cc.ProxyHost; }
            set { cc.ProxyHost = value; }
        }

        /// <summary>
        /// Sets the ProxyHost property
        /// </summary>
        /// <param name="proxyHost">ProxyHost property</param>
        /// <returns>this instance</returns>
        public MarketplaceWebServiceConfig WithProxyHost(String proxyHost)
        {
            cc.ProxyHost = proxyHost;
            return this;
        }

        /// <summary>
        /// Checks if ProxyHost property is set
        /// </summary>
        /// <returns>true if ProxyHost property is set</returns>
        public Boolean IsSetProxyHost()
        {
            return cc.ProxyPort != -1;
        }

        /// <summary>
        /// Gets and sets of the ProxyPort property.
        /// </summary>
        public int ProxyPort
        {
            get { return cc.ProxyPort; }
            set { cc.ProxyPort = value; }
        }

        /// <summary>
        /// Sets the ProxyPort property
        /// </summary>
        /// <param name="proxyPort">ProxyPort property</param>
        /// <returns>this instance</returns>
        public MarketplaceWebServiceConfig WithProxyPort(int proxyPort)
        {
            cc.ProxyPort = proxyPort;
            return this;
        }

        /// <summary>
        /// Checks if ProxyPort property is set
        /// </summary>
        /// <returns>true if ProxyPort property is set</returns>
        public Boolean IsSetProxyPort()
        {
            return cc.ProxyPort != -1;
        }

        /// <summary>
        /// Gets and sets the username to use with your proxy server
        /// </summary>
        public string ProxyUsername
        {
            get { return cc.ProxyUsername; }
            set { cc.ProxyUsername = value; }
        }

        /// <summary>
        /// Sets the username to use with your proxy server
        /// </summary>
        /// <param name="proxyUsername">proxy username</param>
        /// <returns>this instance</returns>
        public MarketplaceWebServiceConfig WithProxyUsername(string proxyUsername)
        {
            ProxyUsername = proxyUsername;
            return this;
        }

        /// <summary>
        /// Checks if proxy username is set
        /// </summary>
        /// <returns>true if proxy username is set</returns>
        public bool IsSetProxyUsername()
        {
            return ProxyUsername != null;
        }

        /// <summary>
        /// Gets and sets the password to use with your proxy server
        /// </summary>
        public string ProxyPassword
        {
            get { return cc.ProxyPassword; }
            set { cc.ProxyPassword = value; }
        }

        /// <summary>
        /// Sets the password to use with your proxy server
        /// </summary>
        /// <param name="proxyPassword">proxy password</param>
        /// <returns>this instance</returns>
        public MarketplaceWebServiceConfig WithProxyPassword(string proxyPassword)
        {
            ProxyPassword = proxyPassword;
            return this;
        }

        /// <summary>
        /// Checks if proxy password is set
        /// </summary>
        /// <returns>true if proxy password is set</returns>
        public bool IsSetProxyPassword()
        {
            return ProxyPassword != null;
        }

        /// <summary>
        /// Gets and sets of the MaxErrorRetry property.
        /// </summary>
        public int MaxErrorRetry
        {
            get { return cc.MaxErrorRetry; }
            set { cc.MaxErrorRetry = value; }
        }

        /// <summary>
        /// Sets the MaxErrorRetry property
        /// </summary>
        /// <param name="maxErrorRetry">MaxErrorRetry property</param>
        /// <returns>this instance</returns>
        public MarketplaceWebServiceConfig WithMaxErrorRetry(int maxErrorRetry)
        {
            cc.MaxErrorRetry = maxErrorRetry;
            return this;
        }

        /// <summary>
        /// Checks if MaxErrorRetry property is set
        /// </summary>
        /// <returns>true if MaxErrorRetry property is set</returns>
        public Boolean IsSetMaxErrorRetry()
        {
            return cc.MaxErrorRetry != -1;
        }

        /// <summary>
        /// Sets the value of a request header to be included on every request
        /// </summary>
        /// <param name="name">the name of the header to set</param>
        /// <param name="value">value to send with header</param>
        public void IncludeRequestHeader(string name, string value)
        {
            cc.IncludeRequestHeader(name, value);
        }

        /// <summary>
        /// Sets the value of a request header to be included on every request
        /// </summary>
        /// <param name="name">the name of the header to set</param>
        /// <param name="value">value to send with header</param>
        /// <returns>the current config object</returns>
        public MarketplaceWebServiceConfig WithRequestHeader(string name, string value)
        {
            cc.IncludeRequestHeader(name, value);
            return this;
        }

        /// <summary>
        /// Gets the currently set value of a request header
        /// </summary>
        /// <param name="name">name the name of the header to get</param>
        /// <returns>value of specified header, or null if not defined</returns>
        public string GetRequestHeader(string name)
        {
            return cc.GetRequestHeader(name);
        }

        /// <summary>
        /// Checks if a request header is set
        /// </summary>
        /// <param name="name">the name of the header to check</param>
        /// <returns>true, if the header is set</returns>
        public bool IsSetRequestHeader(string name)
        {
            return cc.GetRequestHeader(name) != null;
        }

        /// <summary>
        /// Replace all whitespace characters by a single space.
        /// </summary>
        public static string Clean(string s)
        {
            // matched character sequences are passed to a MatchEvaluator
            // delegate. The returned string from the delegate replaces
            // the matched sequence.
            return Regex.Replace(s, @" {2,}|\s", delegate(Match m)
            {
                return  " ";
            });
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// '\', and '/'.
        /// </summary>
        public static string QuoteApplicationName(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace("@/", @"\/");
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// '\', and '('.
        /// </summary>
        public static string QuoteApplicationVersion(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@"(", @"\(");
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// '\', and '='.
        /// </summary>
        public static string QuoteAttributeName(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@"=", @"\=");
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// ')', '\', and ';'.
        /// </summary>
        public static string QuoteAttributeValue(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@";", @"\;").Replace(@")", @"\)");
        }
    }
}
