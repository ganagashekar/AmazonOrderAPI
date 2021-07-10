﻿
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Amazon.APIEngine.Api;
using Amazon.APIEngine.ApiClient;
using Amazon.APIEngine.Models;
using RestSharp;


namespace Amazon.APIEngine.Api
{



    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class OrdersV0Api : IOrdersV0Api
    {
        private ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersV0Api"/> class.
        /// </summary>
        /// <returns></returns>
        public OrdersV0Api(String basePath)
        {
            this.Configuration = new Configuration { BasePath = basePath };

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersV0Api"/> class
        /// </summary>
        /// <returns></returns>
        public OrdersV0Api()
        {
            this.Configuration = Configuration.Default;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersV0Api"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public OrdersV0Api(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default;
            else
                this.Configuration = configuration;

            ExceptionFactory = Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuration.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }



        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public IDictionary<String, String> DefaultHeader()
        {
            return new ReadOnlyDictionary<string, string>(this.Configuration.DefaultHeader);
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }

        /// <summary>
        ///  Returns the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>GetOrderResponse</returns>
        public GetOrderResponse GetOrder(string orderId)
        {
            ApiResponse<GetOrderResponse> localVarResponse = GetOrderWithHttpInfo(orderId);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Returns the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>ApiResponse of GetOrderResponse</returns>
        public ApiResponse<GetOrderResponse> GetOrderWithHttpInfo(string orderId)
        {
            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersV0Api->GetOrder");

            var localVarPath = "/orders/v0/orders/{orderId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (orderId != null) localVarPathParams.Add("orderId", this.Configuration.ApiClient.ParameterToString(orderId)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetOrder", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetOrderResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrderResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrderResponse)));
        }

        /// <summary>
        ///  Returns the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of GetOrderResponse</returns>
        public async System.Threading.Tasks.Task<GetOrderResponse> GetOrderAsync(string orderId)
        {
            ApiResponse<GetOrderResponse> localVarResponse = await GetOrderAsyncWithHttpInfo(orderId);
            return localVarResponse.Data;

        }

        /// <summary>
        ///  Returns the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of ApiResponse (GetOrderResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GetOrderResponse>> GetOrderAsyncWithHttpInfo(string orderId)
        {
            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersV0Api->GetOrder");

            var localVarPath = "/orders/v0/orders/{orderId}";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (orderId != null) localVarPathParams.Add("orderId", this.Configuration.ApiClient.ParameterToString(orderId)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetOrder", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetOrderResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrderResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrderResponse)));
        }

        /// <summary>
        ///  Returns the shipping address for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>GetOrderAddressResponse</returns>
        public GetOrderAddressResponse GetOrderAddress(string orderId)
        {
            ApiResponse<GetOrderAddressResponse> localVarResponse = GetOrderAddressWithHttpInfo(orderId);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Returns the shipping address for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>ApiResponse of GetOrderAddressResponse</returns>
        public ApiResponse<GetOrderAddressResponse> GetOrderAddressWithHttpInfo(string orderId)
        {
            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersV0Api->GetOrderAddress");

            var localVarPath = "/orders/v0/orders/{orderId}/address";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (orderId != null) localVarPathParams.Add("orderId", this.Configuration.ApiClient.ParameterToString(orderId)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetOrderAddress", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetOrderAddressResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrderAddressResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrderAddressResponse)));
        }

        /// <summary>
        ///  Returns the shipping address for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of GetOrderAddressResponse</returns>
        public async System.Threading.Tasks.Task<GetOrderAddressResponse> GetOrderAddressAsync(string orderId)
        {
            ApiResponse<GetOrderAddressResponse> localVarResponse = await GetOrderAddressAsyncWithHttpInfo(orderId);
            return localVarResponse.Data;

        }

        /// <summary>
        ///  Returns the shipping address for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of ApiResponse (GetOrderAddressResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GetOrderAddressResponse>> GetOrderAddressAsyncWithHttpInfo(string orderId)
        {
            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersV0Api->GetOrderAddress");

            var localVarPath = "/orders/v0/orders/{orderId}/address";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (orderId != null) localVarPathParams.Add("orderId", this.Configuration.ApiClient.ParameterToString(orderId)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetOrderAddress", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetOrderAddressResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrderAddressResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrderAddressResponse)));
        }

        /// <summary>
        ///  Returns buyer information for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>GetOrderBuyerInfoResponse</returns>
        public GetOrderBuyerInfoResponse GetOrderBuyerInfo(string orderId)
        {
            ApiResponse<GetOrderBuyerInfoResponse> localVarResponse = GetOrderBuyerInfoWithHttpInfo(orderId);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Returns buyer information for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>ApiResponse of GetOrderBuyerInfoResponse</returns>
        public ApiResponse<GetOrderBuyerInfoResponse> GetOrderBuyerInfoWithHttpInfo(string orderId)
        {
            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersV0Api->GetOrderBuyerInfo");

            var localVarPath = "/orders/v0/orders/{orderId}/buyerInfo";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (orderId != null) localVarPathParams.Add("orderId", this.Configuration.ApiClient.ParameterToString(orderId)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetOrderBuyerInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetOrderBuyerInfoResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrderBuyerInfoResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrderBuyerInfoResponse)));
        }

        /// <summary>
        ///  Returns buyer information for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of GetOrderBuyerInfoResponse</returns>
        public async System.Threading.Tasks.Task<GetOrderBuyerInfoResponse> GetOrderBuyerInfoAsync(string orderId)
        {
            ApiResponse<GetOrderBuyerInfoResponse> localVarResponse = await GetOrderBuyerInfoAsyncWithHttpInfo(orderId);
            return localVarResponse.Data;

        }

        /// <summary>
        ///  Returns buyer information for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of ApiResponse (GetOrderBuyerInfoResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GetOrderBuyerInfoResponse>> GetOrderBuyerInfoAsyncWithHttpInfo(string orderId)
        {
            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersV0Api->GetOrderBuyerInfo");

            var localVarPath = "/orders/v0/orders/{orderId}/buyerInfo";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (orderId != null) localVarPathParams.Add("orderId", this.Configuration.ApiClient.ParameterToString(orderId)); // path parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetOrderBuyerInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetOrderBuyerInfoResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrderBuyerInfoResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrderBuyerInfoResponse)));
        }

        /// <summary>
        ///  Returns detailed order item information for the order indicated by the specified order ID. If NextToken is provided, it&#x27;s used to retrieve the next page of order items.  Note: When an order is in the Pending state (the order has been placed but payment has not been authorized), the getOrderItems operation does not return information about pricing, taxes, shipping charges, gift status or promotions for the order items in the order. After an order leaves the Pending state (this occurs when payment has been authorized) and enters the Unshipped, Partially Shipped, or Shipped state, the getOrderItems operation returns information about pricing, taxes, shipping charges, gift status and promotions for the order items in the order.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>GetOrderItemsResponse</returns>
        public GetOrderItemsResponse GetOrderItems(string orderId, string nextToken = null)
        {
            ApiResponse<GetOrderItemsResponse> localVarResponse = GetOrderItemsWithHttpInfo(orderId, nextToken);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Returns detailed order item information for the order indicated by the specified order ID. If NextToken is provided, it&#x27;s used to retrieve the next page of order items.  Note: When an order is in the Pending state (the order has been placed but payment has not been authorized), the getOrderItems operation does not return information about pricing, taxes, shipping charges, gift status or promotions for the order items in the order. After an order leaves the Pending state (this occurs when payment has been authorized) and enters the Unshipped, Partially Shipped, or Shipped state, the getOrderItems operation returns information about pricing, taxes, shipping charges, gift status and promotions for the order items in the order.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>ApiResponse of GetOrderItemsResponse</returns>
        public ApiResponse<GetOrderItemsResponse> GetOrderItemsWithHttpInfo(string orderId, string nextToken = null)
        {
            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersV0Api->GetOrderItems");

            var localVarPath = "/orders/v0/orders/{orderId}/orderItems";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (orderId != null) localVarPathParams.Add("orderId", this.Configuration.ApiClient.ParameterToString(orderId)); // path parameter
            if (nextToken != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "NextToken", nextToken)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetOrderItems", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetOrderItemsResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrderItemsResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrderItemsResponse)));
        }

        /// <summary>
        ///  Returns detailed order item information for the order indicated by the specified order ID. If NextToken is provided, it&#x27;s used to retrieve the next page of order items.  Note: When an order is in the Pending state (the order has been placed but payment has not been authorized), the getOrderItems operation does not return information about pricing, taxes, shipping charges, gift status or promotions for the order items in the order. After an order leaves the Pending state (this occurs when payment has been authorized) and enters the Unshipped, Partially Shipped, or Shipped state, the getOrderItems operation returns information about pricing, taxes, shipping charges, gift status and promotions for the order items in the order.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>Task of GetOrderItemsResponse</returns>
        public async System.Threading.Tasks.Task<GetOrderItemsResponse> GetOrderItemsAsync(string orderId, string nextToken = null)
        {
            ApiResponse<GetOrderItemsResponse> localVarResponse = await GetOrderItemsAsyncWithHttpInfo(orderId, nextToken);
            return localVarResponse.Data;

        }

        /// <summary>
        ///  Returns detailed order item information for the order indicated by the specified order ID. If NextToken is provided, it&#x27;s used to retrieve the next page of order items.  Note: When an order is in the Pending state (the order has been placed but payment has not been authorized), the getOrderItems operation does not return information about pricing, taxes, shipping charges, gift status or promotions for the order items in the order. After an order leaves the Pending state (this occurs when payment has been authorized) and enters the Unshipped, Partially Shipped, or Shipped state, the getOrderItems operation returns information about pricing, taxes, shipping charges, gift status and promotions for the order items in the order.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>Task of ApiResponse (GetOrderItemsResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GetOrderItemsResponse>> GetOrderItemsAsyncWithHttpInfo(string orderId, string nextToken = null)
        {
            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersV0Api->GetOrderItems");

            var localVarPath = string.Format("/orders/v0/orders/{0}/orderItems",orderId);
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            //if (localVarHttpHeaderAccept != null)
            //    localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            //if (orderId != null) localVarPathParams.Add("orderId", this.Configuration.ApiClient.ParameterToString(orderId)); // path parameter
            if (nextToken != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "NextToken", nextToken)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            //if (ExceptionFactory != null)
            //{
            //    Exception exception = ExceptionFactory("GetOrderItems", localVarResponse);
            //    if (exception != null) throw exception;
            //}

            return new ApiResponse<GetOrderItemsResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrderItemsResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrderItemsResponse)));
        }

        /// <summary>
        ///  Returns buyer information in the order items of the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>GetOrderItemsBuyerInfoResponse</returns>
        public GetOrderItemsBuyerInfoResponse GetOrderItemsBuyerInfo(string orderId, string nextToken = null)
        {
            ApiResponse<GetOrderItemsBuyerInfoResponse> localVarResponse = GetOrderItemsBuyerInfoWithHttpInfo(orderId, nextToken);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Returns buyer information in the order items of the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>ApiResponse of GetOrderItemsBuyerInfoResponse</returns>
        public ApiResponse<GetOrderItemsBuyerInfoResponse> GetOrderItemsBuyerInfoWithHttpInfo(string orderId, string nextToken = null)
        {
            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersV0Api->GetOrderItemsBuyerInfo");

            var localVarPath = "/orders/v0/orders/{orderId}/orderItems/buyerInfo";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (orderId != null) localVarPathParams.Add("orderId", this.Configuration.ApiClient.ParameterToString(orderId)); // path parameter
            if (nextToken != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "NextToken", nextToken)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetOrderItemsBuyerInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetOrderItemsBuyerInfoResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrderItemsBuyerInfoResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrderItemsBuyerInfoResponse)));
        }

        /// <summary>
        ///  Returns buyer information in the order items of the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>Task of GetOrderItemsBuyerInfoResponse</returns>
        public async System.Threading.Tasks.Task<GetOrderItemsBuyerInfoResponse> GetOrderItemsBuyerInfoAsync(string orderId, string nextToken = null)
        {
            ApiResponse<GetOrderItemsBuyerInfoResponse> localVarResponse = await GetOrderItemsBuyerInfoAsyncWithHttpInfo(orderId, nextToken);
            return localVarResponse.Data;

        }

        /// <summary>
        ///  Returns buyer information in the order items of the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>Task of ApiResponse (GetOrderItemsBuyerInfoResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GetOrderItemsBuyerInfoResponse>> GetOrderItemsBuyerInfoAsyncWithHttpInfo(string orderId, string nextToken = null)
        {
            // verify the required parameter 'orderId' is set
            if (orderId == null)
                throw new ApiException(400, "Missing required parameter 'orderId' when calling OrdersV0Api->GetOrderItemsBuyerInfo");

            var localVarPath = "/orders/v0/orders/{orderId}/orderItems/buyerInfo";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (orderId != null) localVarPathParams.Add("orderId", this.Configuration.ApiClient.ParameterToString(orderId)); // path parameter
            if (nextToken != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "NextToken", nextToken)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetOrderItemsBuyerInfo", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetOrderItemsBuyerInfoResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrderItemsBuyerInfoResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrderItemsBuyerInfoResponse)));
        }

        /// <summary>
        ///  Returns orders created or updated during the time frame indicated by the specified parameters. You can also apply a range of filtering criteria to narrow the list of orders returned. If NextToken is present, that will be used to retrieve the orders instead of other criteria.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="marketplaceIds">A list of MarketplaceId values. Used to select orders that were placed in the specified marketplaces.</param>
        /// <param name="createdAfter">A date used for selecting orders created after (or at) a specified time. Only orders placed after the specified time are returned. Either the CreatedAfter parameter or the LastUpdatedAfter parameter is required. Both cannot be empty. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="createdBefore">A date used for selecting orders created before (or at) a specified time. Only orders placed before the specified time are returned. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="lastUpdatedAfter">A date used for selecting orders that were last updated after (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="lastUpdatedBefore">A date used for selecting orders that were last updated before (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="orderStatuses">A list of OrderStatus values used to filter the results. Possible values: PendingAvailability (This status is available for pre-orders only. The order has been placed, payment has not been authorized, and the release date of the item is in the future.); Pending (The order has been placed but payment has not been authorized); Unshipped (Payment has been authorized and the order is ready for shipment, but no items in the order have been shipped); PartiallyShipped (One or more, but not all, items in the order have been shipped); Shipped (All items in the order have been shipped); InvoiceUnconfirmed (All items in the order have been shipped. The seller has not yet given confirmation to Amazon that the invoice has been shipped to the buyer.); Canceled (The order has been canceled); and Unfulfillable (The order cannot be fulfilled. This state applies only to Multi-Channel Fulfillment orders.). (optional)</param>
        /// <param name="fulfillmentChannels">A list that indicates how an order was fulfilled. Filters the results by fulfillment channel. Possible values: FBA (Fulfillment by Amazon); SellerFulfilled (Fulfilled by the seller). (optional)</param>
        /// <param name="paymentMethods">A list of payment method values. Used to select orders paid using the specified payment methods. Possible values: COD (Cash on delivery); CVS (Convenience store payment); Other (Any payment method other than COD or CVS). (optional)</param>
        /// <param name="buyerEmail">The email address of a buyer. Used to select orders that contain the specified email address. (optional)</param>
        /// <param name="sellerOrderId">An order identifier that is specified by the seller. Used to select only the orders that match the order identifier. If SellerOrderId is specified, then FulfillmentChannels, OrderStatuses, PaymentMethod, LastUpdatedAfter, LastUpdatedBefore, and BuyerEmail cannot be specified. (optional)</param>
        /// <param name="maxResultsPerPage">A number that indicates the maximum number of orders that can be returned per page. Value must be 1 - 100. Default 100. (optional)</param>
        /// <param name="easyShipShipmentStatuses">A list of EasyShipShipmentStatus values. Used to select Easy Ship orders with statuses that match the specified  values. If EasyShipShipmentStatus is specified, only Amazon Easy Ship orders are returned.Possible values: PendingPickUp (Amazon has not yet picked up the package from the seller). LabelCanceled (The seller canceled the pickup). PickedUp (Amazon has picked up the package from the seller). AtOriginFC (The packaged is at the origin fulfillment center). AtDestinationFC (The package is at the destination fulfillment center). OutForDelivery (The package is out for delivery). Damaged (The package was damaged by the carrier). Delivered (The package has been delivered to the buyer). RejectedByBuyer (The package has been rejected by the buyer). Undeliverable (The package cannot be delivered). ReturnedToSeller (The package was not delivered to the buyer and was returned to the seller). ReturningToSeller (The package was not delivered to the buyer and is being returned to the seller). (optional)</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <param name="amazonOrderIds">A list of AmazonOrderId values. An AmazonOrderId is an Amazon-defined order identifier, in 3-7-7 format. (optional)</param>
        /// <param name="actualFulfillmentSupplySourceId">Denotes the recommended sourceId where the order should be fulfilled from. (optional)</param>
        /// <param name="isISPU">When true, this order is marked to be picked up from a store rather than delivered. (optional)</param>
        /// <param name="storeChainStoreId">The store chain store identifier. Linked to a specific store in a store chain. (optional)</param>
        /// <returns>GetOrdersResponse</returns>
        public GetOrdersResponse GetOrders(List<string> marketplaceIds, string createdAfter = null, string createdBefore = null, string lastUpdatedAfter = null, string lastUpdatedBefore = null, List<string> orderStatuses = null, List<string> fulfillmentChannels = null, List<string> paymentMethods = null, string buyerEmail = null, string sellerOrderId = null, int? maxResultsPerPage = null, List<string> easyShipShipmentStatuses = null, string nextToken = null, List<string> amazonOrderIds = null, string actualFulfillmentSupplySourceId = null, bool? isISPU = null, string storeChainStoreId = null)
        {
            ApiResponse<GetOrdersResponse> localVarResponse = GetOrdersWithHttpInfo(marketplaceIds, createdAfter, createdBefore, lastUpdatedAfter, lastUpdatedBefore, orderStatuses, fulfillmentChannels, paymentMethods, buyerEmail, sellerOrderId, maxResultsPerPage, easyShipShipmentStatuses, nextToken, amazonOrderIds, actualFulfillmentSupplySourceId, isISPU, storeChainStoreId);
            return localVarResponse.Data;
        }

        /// <summary>
        ///  Returns orders created or updated during the time frame indicated by the specified parameters. You can also apply a range of filtering criteria to narrow the list of orders returned. If NextToken is present, that will be used to retrieve the orders instead of other criteria.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="marketplaceIds">A list of MarketplaceId values. Used to select orders that were placed in the specified marketplaces.</param>
        /// <param name="createdAfter">A date used for selecting orders created after (or at) a specified time. Only orders placed after the specified time are returned. Either the CreatedAfter parameter or the LastUpdatedAfter parameter is required. Both cannot be empty. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="createdBefore">A date used for selecting orders created before (or at) a specified time. Only orders placed before the specified time are returned. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="lastUpdatedAfter">A date used for selecting orders that were last updated after (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="lastUpdatedBefore">A date used for selecting orders that were last updated before (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="orderStatuses">A list of OrderStatus values used to filter the results. Possible values: PendingAvailability (This status is available for pre-orders only. The order has been placed, payment has not been authorized, and the release date of the item is in the future.); Pending (The order has been placed but payment has not been authorized); Unshipped (Payment has been authorized and the order is ready for shipment, but no items in the order have been shipped); PartiallyShipped (One or more, but not all, items in the order have been shipped); Shipped (All items in the order have been shipped); InvoiceUnconfirmed (All items in the order have been shipped. The seller has not yet given confirmation to Amazon that the invoice has been shipped to the buyer.); Canceled (The order has been canceled); and Unfulfillable (The order cannot be fulfilled. This state applies only to Multi-Channel Fulfillment orders.). (optional)</param>
        /// <param name="fulfillmentChannels">A list that indicates how an order was fulfilled. Filters the results by fulfillment channel. Possible values: FBA (Fulfillment by Amazon); SellerFulfilled (Fulfilled by the seller). (optional)</param>
        /// <param name="paymentMethods">A list of payment method values. Used to select orders paid using the specified payment methods. Possible values: COD (Cash on delivery); CVS (Convenience store payment); Other (Any payment method other than COD or CVS). (optional)</param>
        /// <param name="buyerEmail">The email address of a buyer. Used to select orders that contain the specified email address. (optional)</param>
        /// <param name="sellerOrderId">An order identifier that is specified by the seller. Used to select only the orders that match the order identifier. If SellerOrderId is specified, then FulfillmentChannels, OrderStatuses, PaymentMethod, LastUpdatedAfter, LastUpdatedBefore, and BuyerEmail cannot be specified. (optional)</param>
        /// <param name="maxResultsPerPage">A number that indicates the maximum number of orders that can be returned per page. Value must be 1 - 100. Default 100. (optional)</param>
        /// <param name="easyShipShipmentStatuses">A list of EasyShipShipmentStatus values. Used to select Easy Ship orders with statuses that match the specified  values. If EasyShipShipmentStatus is specified, only Amazon Easy Ship orders are returned.Possible values: PendingPickUp (Amazon has not yet picked up the package from the seller). LabelCanceled (The seller canceled the pickup). PickedUp (Amazon has picked up the package from the seller). AtOriginFC (The packaged is at the origin fulfillment center). AtDestinationFC (The package is at the destination fulfillment center). OutForDelivery (The package is out for delivery). Damaged (The package was damaged by the carrier). Delivered (The package has been delivered to the buyer). RejectedByBuyer (The package has been rejected by the buyer). Undeliverable (The package cannot be delivered). ReturnedToSeller (The package was not delivered to the buyer and was returned to the seller). ReturningToSeller (The package was not delivered to the buyer and is being returned to the seller). (optional)</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <param name="amazonOrderIds">A list of AmazonOrderId values. An AmazonOrderId is an Amazon-defined order identifier, in 3-7-7 format. (optional)</param>
        /// <param name="actualFulfillmentSupplySourceId">Denotes the recommended sourceId where the order should be fulfilled from. (optional)</param>
        /// <param name="isISPU">When true, this order is marked to be picked up from a store rather than delivered. (optional)</param>
        /// <param name="storeChainStoreId">The store chain store identifier. Linked to a specific store in a store chain. (optional)</param>
        /// <returns>ApiResponse of GetOrdersResponse</returns>
        public ApiResponse<GetOrdersResponse> GetOrdersWithHttpInfo(List<string> marketplaceIds, string createdAfter = null, string createdBefore = null, string lastUpdatedAfter = null, string lastUpdatedBefore = null, List<string> orderStatuses = null, List<string> fulfillmentChannels = null, List<string> paymentMethods = null, string buyerEmail = null, string sellerOrderId = null, int? maxResultsPerPage = null, List<string> easyShipShipmentStatuses = null, string nextToken = null, List<string> amazonOrderIds = null, string actualFulfillmentSupplySourceId = null, bool? isISPU = null, string storeChainStoreId = null)
        {
            // verify the required parameter 'marketplaceIds' is set
            if (marketplaceIds == null)
                throw new ApiException(400, "Missing required parameter 'marketplaceIds' when calling OrdersV0Api->GetOrders");

            var localVarPath = "/orders/v0/orders";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            if (localVarHttpHeaderAccept != null)
                localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (createdAfter != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "CreatedAfter", createdAfter)); // query parameter
            if (createdBefore != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "CreatedBefore", createdBefore)); // query parameter
            if (lastUpdatedAfter != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "LastUpdatedAfter", lastUpdatedAfter)); // query parameter
            if (lastUpdatedBefore != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "LastUpdatedBefore", lastUpdatedBefore)); // query parameter
            if (orderStatuses != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "OrderStatuses", orderStatuses)); // query parameter
            if (marketplaceIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "MarketplaceIds", marketplaceIds)); // query parameter
            if (fulfillmentChannels != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "FulfillmentChannels", fulfillmentChannels)); // query parameter
            if (paymentMethods != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "PaymentMethods", paymentMethods)); // query parameter
            if (buyerEmail != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "BuyerEmail", buyerEmail)); // query parameter
            if (sellerOrderId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "SellerOrderId", sellerOrderId)); // query parameter
            if (maxResultsPerPage != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "MaxResultsPerPage", maxResultsPerPage)); // query parameter
            if (easyShipShipmentStatuses != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "EasyShipShipmentStatuses", easyShipShipmentStatuses)); // query parameter
            if (nextToken != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "NextToken", nextToken)); // query parameter
            if (amazonOrderIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "AmazonOrderIds", amazonOrderIds)); // query parameter
            if (actualFulfillmentSupplySourceId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "ActualFulfillmentSupplySourceId", actualFulfillmentSupplySourceId)); // query parameter
            if (isISPU != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "IsISPU", isISPU)); // query parameter
            if (storeChainStoreId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "StoreChainStoreId", storeChainStoreId)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)this.Configuration.ApiClient.CallApi(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            if (ExceptionFactory != null)
            {
                Exception exception = ExceptionFactory("GetOrders", localVarResponse);
                if (exception != null) throw exception;
            }

            return new ApiResponse<GetOrdersResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrdersResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrdersResponse)));
        }

        /// <summary>
        ///  Returns orders created or updated during the time frame indicated by the specified parameters. You can also apply a range of filtering criteria to narrow the list of orders returned. If NextToken is present, that will be used to retrieve the orders instead of other criteria.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="marketplaceIds">A list of MarketplaceId values. Used to select orders that were placed in the specified marketplaces.</param>
        /// <param name="createdAfter">A date used for selecting orders created after (or at) a specified time. Only orders placed after the specified time are returned. Either the CreatedAfter parameter or the LastUpdatedAfter parameter is required. Both cannot be empty. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="createdBefore">A date used for selecting orders created before (or at) a specified time. Only orders placed before the specified time are returned. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="lastUpdatedAfter">A date used for selecting orders that were last updated after (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="lastUpdatedBefore">A date used for selecting orders that were last updated before (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="orderStatuses">A list of OrderStatus values used to filter the results. Possible values: PendingAvailability (This status is available for pre-orders only. The order has been placed, payment has not been authorized, and the release date of the item is in the future.); Pending (The order has been placed but payment has not been authorized); Unshipped (Payment has been authorized and the order is ready for shipment, but no items in the order have been shipped); PartiallyShipped (One or more, but not all, items in the order have been shipped); Shipped (All items in the order have been shipped); InvoiceUnconfirmed (All items in the order have been shipped. The seller has not yet given confirmation to Amazon that the invoice has been shipped to the buyer.); Canceled (The order has been canceled); and Unfulfillable (The order cannot be fulfilled. This state applies only to Multi-Channel Fulfillment orders.). (optional)</param>
        /// <param name="fulfillmentChannels">A list that indicates how an order was fulfilled. Filters the results by fulfillment channel. Possible values: FBA (Fulfillment by Amazon); SellerFulfilled (Fulfilled by the seller). (optional)</param>
        /// <param name="paymentMethods">A list of payment method values. Used to select orders paid using the specified payment methods. Possible values: COD (Cash on delivery); CVS (Convenience store payment); Other (Any payment method other than COD or CVS). (optional)</param>
        /// <param name="buyerEmail">The email address of a buyer. Used to select orders that contain the specified email address. (optional)</param>
        /// <param name="sellerOrderId">An order identifier that is specified by the seller. Used to select only the orders that match the order identifier. If SellerOrderId is specified, then FulfillmentChannels, OrderStatuses, PaymentMethod, LastUpdatedAfter, LastUpdatedBefore, and BuyerEmail cannot be specified. (optional)</param>
        /// <param name="maxResultsPerPage">A number that indicates the maximum number of orders that can be returned per page. Value must be 1 - 100. Default 100. (optional)</param>
        /// <param name="easyShipShipmentStatuses">A list of EasyShipShipmentStatus values. Used to select Easy Ship orders with statuses that match the specified  values. If EasyShipShipmentStatus is specified, only Amazon Easy Ship orders are returned.Possible values: PendingPickUp (Amazon has not yet picked up the package from the seller). LabelCanceled (The seller canceled the pickup). PickedUp (Amazon has picked up the package from the seller). AtOriginFC (The packaged is at the origin fulfillment center). AtDestinationFC (The package is at the destination fulfillment center). OutForDelivery (The package is out for delivery). Damaged (The package was damaged by the carrier). Delivered (The package has been delivered to the buyer). RejectedByBuyer (The package has been rejected by the buyer). Undeliverable (The package cannot be delivered). ReturnedToSeller (The package was not delivered to the buyer and was returned to the seller). ReturningToSeller (The package was not delivered to the buyer and is being returned to the seller). (optional)</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <param name="amazonOrderIds">A list of AmazonOrderId values. An AmazonOrderId is an Amazon-defined order identifier, in 3-7-7 format. (optional)</param>
        /// <param name="actualFulfillmentSupplySourceId">Denotes the recommended sourceId where the order should be fulfilled from. (optional)</param>
        /// <param name="isISPU">When true, this order is marked to be picked up from a store rather than delivered. (optional)</param>
        /// <param name="storeChainStoreId">The store chain store identifier. Linked to a specific store in a store chain. (optional)</param>
        /// <returns>Task of GetOrdersResponse</returns>
        public async System.Threading.Tasks.Task<GetOrdersResponse> GetOrdersAsync(List<string> marketplaceIds, string createdAfter = null, string createdBefore = null, string lastUpdatedAfter = null, string lastUpdatedBefore = null, List<string> orderStatuses = null, List<string> fulfillmentChannels = null, List<string> paymentMethods = null, string buyerEmail = null, string sellerOrderId = null, int? maxResultsPerPage = null, List<string> easyShipShipmentStatuses = null, string nextToken = null, List<string> amazonOrderIds = null, string actualFulfillmentSupplySourceId = null, bool? isISPU = null, string storeChainStoreId = null)
        {
            ApiResponse<GetOrdersResponse> localVarResponse = await GetOrdersAsyncWithHttpInfo(marketplaceIds, createdAfter, createdBefore, lastUpdatedAfter, lastUpdatedBefore, orderStatuses, fulfillmentChannels, paymentMethods, buyerEmail, sellerOrderId, maxResultsPerPage, easyShipShipmentStatuses, nextToken, amazonOrderIds, actualFulfillmentSupplySourceId, isISPU, storeChainStoreId);
            return localVarResponse.Data;

        }

        /// <summary>
        ///  Returns orders created or updated during the time frame indicated by the specified parameters. You can also apply a range of filtering criteria to narrow the list of orders returned. If NextToken is present, that will be used to retrieve the orders instead of other criteria.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </summary>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="marketplaceIds">A list of MarketplaceId values. Used to select orders that were placed in the specified marketplaces.</param>
        /// <param name="createdAfter">A date used for selecting orders created after (or at) a specified time. Only orders placed after the specified time are returned. Either the CreatedAfter parameter or the LastUpdatedAfter parameter is required. Both cannot be empty. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="createdBefore">A date used for selecting orders created before (or at) a specified time. Only orders placed before the specified time are returned. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="lastUpdatedAfter">A date used for selecting orders that were last updated after (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="lastUpdatedBefore">A date used for selecting orders that were last updated before (or at) a specified time. An update is defined as any change in order status, including the creation of a new order. Includes updates made by Amazon and by the seller. The date must be in ISO 8601 format. (optional)</param>
        /// <param name="orderStatuses">A list of OrderStatus values used to filter the results. Possible values: PendingAvailability (This status is available for pre-orders only. The order has been placed, payment has not been authorized, and the release date of the item is in the future.); Pending (The order has been placed but payment has not been authorized); Unshipped (Payment has been authorized and the order is ready for shipment, but no items in the order have been shipped); PartiallyShipped (One or more, but not all, items in the order have been shipped); Shipped (All items in the order have been shipped); InvoiceUnconfirmed (All items in the order have been shipped. The seller has not yet given confirmation to Amazon that the invoice has been shipped to the buyer.); Canceled (The order has been canceled); and Unfulfillable (The order cannot be fulfilled. This state applies only to Multi-Channel Fulfillment orders.). (optional)</param>
        /// <param name="fulfillmentChannels">A list that indicates how an order was fulfilled. Filters the results by fulfillment channel. Possible values: FBA (Fulfillment by Amazon); SellerFulfilled (Fulfilled by the seller). (optional)</param>
        /// <param name="paymentMethods">A list of payment method values. Used to select orders paid using the specified payment methods. Possible values: COD (Cash on delivery); CVS (Convenience store payment); Other (Any payment method other than COD or CVS). (optional)</param>
        /// <param name="buyerEmail">The email address of a buyer. Used to select orders that contain the specified email address. (optional)</param>
        /// <param name="sellerOrderId">An order identifier that is specified by the seller. Used to select only the orders that match the order identifier. If SellerOrderId is specified, then FulfillmentChannels, OrderStatuses, PaymentMethod, LastUpdatedAfter, LastUpdatedBefore, and BuyerEmail cannot be specified. (optional)</param>
        /// <param name="maxResultsPerPage">A number that indicates the maximum number of orders that can be returned per page. Value must be 1 - 100. Default 100. (optional)</param>
        /// <param name="easyShipShipmentStatuses">A list of EasyShipShipmentStatus values. Used to select Easy Ship orders with statuses that match the specified  values. If EasyShipShipmentStatus is specified, only Amazon Easy Ship orders are returned.Possible values: PendingPickUp (Amazon has not yet picked up the package from the seller). LabelCanceled (The seller canceled the pickup). PickedUp (Amazon has picked up the package from the seller). AtOriginFC (The packaged is at the origin fulfillment center). AtDestinationFC (The package is at the destination fulfillment center). OutForDelivery (The package is out for delivery). Damaged (The package was damaged by the carrier). Delivered (The package has been delivered to the buyer). RejectedByBuyer (The package has been rejected by the buyer). Undeliverable (The package cannot be delivered). ReturnedToSeller (The package was not delivered to the buyer and was returned to the seller). ReturningToSeller (The package was not delivered to the buyer and is being returned to the seller). (optional)</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <param name="amazonOrderIds">A list of AmazonOrderId values. An AmazonOrderId is an Amazon-defined order identifier, in 3-7-7 format. (optional)</param>
        /// <param name="actualFulfillmentSupplySourceId">Denotes the recommended sourceId where the order should be fulfilled from. (optional)</param>
        /// <param name="isISPU">When true, this order is marked to be picked up from a store rather than delivered. (optional)</param>
        /// <param name="storeChainStoreId">The store chain store identifier. Linked to a specific store in a store chain. (optional)</param>
        /// <returns>Task of ApiResponse (GetOrdersResponse)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<GetOrdersResponse>> GetOrdersAsyncWithHttpInfo(List<string> marketplaceIds, string createdAfter = null, string createdBefore = null, string lastUpdatedAfter = null, string lastUpdatedBefore = null, List<string> orderStatuses = null, List<string> fulfillmentChannels = null, List<string> paymentMethods = null, string buyerEmail = null, string sellerOrderId = null, int? maxResultsPerPage = null, List<string> easyShipShipmentStatuses = null, string nextToken = null, List<string> amazonOrderIds = null, string actualFulfillmentSupplySourceId = null, bool? isISPU = null, string storeChainStoreId = null)
        {
            // verify the required parameter 'marketplaceIds' is set
            if (marketplaceIds == null)
                throw new ApiException(400, "Missing required parameter 'marketplaceIds' when calling OrdersV0Api->GetOrders");

            var localVarPath = "/orders/v0/orders";
            var localVarPathParams = new Dictionary<String, String>();
            var localVarQueryParams = new List<KeyValuePair<String, String>>();
            var localVarHeaderParams = new Dictionary<String, String>(this.Configuration.DefaultHeader);
            var localVarFormParams = new Dictionary<String, String>();
            var localVarFileParams = new Dictionary<String, FileParameter>();
            Object localVarPostBody = null;

            // to determine the Content-Type header
            String[] localVarHttpContentTypes = new String[] {
            };
            String localVarHttpContentType = this.Configuration.ApiClient.SelectHeaderContentType(localVarHttpContentTypes);

            // to determine the Accept header
            String[] localVarHttpHeaderAccepts = new String[] {
                "application/json"
            };
            String localVarHttpHeaderAccept = this.Configuration.ApiClient.SelectHeaderAccept(localVarHttpHeaderAccepts);
            //if (localVarHttpHeaderAccept != null)
            //    localVarHeaderParams.Add("Accept", localVarHttpHeaderAccept);

            if (createdAfter != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "CreatedAfter", createdAfter)); // query parameter
            if (createdBefore != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "CreatedBefore", createdBefore)); // query parameter
            if (lastUpdatedAfter != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "LastUpdatedAfter", lastUpdatedAfter)); // query parameter
            if (lastUpdatedBefore != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "LastUpdatedBefore", lastUpdatedBefore)); // query parameter
            if (orderStatuses != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "OrderStatuses", orderStatuses)); // query parameter
            if (marketplaceIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "MarketplaceIds", marketplaceIds)); // query parameter
            if (fulfillmentChannels != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "FulfillmentChannels", fulfillmentChannels)); // query parameter
            if (paymentMethods != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "PaymentMethods", paymentMethods)); // query parameter
            if (buyerEmail != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "BuyerEmail", buyerEmail)); // query parameter
            if (sellerOrderId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "SellerOrderId", sellerOrderId)); // query parameter
            if (maxResultsPerPage != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "MaxResultsPerPage", maxResultsPerPage)); // query parameter
            if (easyShipShipmentStatuses != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "EasyShipShipmentStatuses", easyShipShipmentStatuses)); // query parameter
            if (nextToken != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "NextToken", nextToken)); // query parameter
            if (amazonOrderIds != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("csv", "AmazonOrderIds", amazonOrderIds)); // query parameter
            if (actualFulfillmentSupplySourceId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "ActualFulfillmentSupplySourceId", actualFulfillmentSupplySourceId)); // query parameter
            if (isISPU != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "IsISPU", isISPU)); // query parameter
            if (storeChainStoreId != null) localVarQueryParams.AddRange(this.Configuration.ApiClient.ParameterToKeyValuePairs("", "StoreChainStoreId", storeChainStoreId)); // query parameter

            // make the HTTP request
            IRestResponse localVarResponse = (IRestResponse)await this.Configuration.ApiClient.CallApiAsync(localVarPath,
                Method.GET, localVarQueryParams, localVarPostBody, localVarHeaderParams, localVarFormParams, localVarFileParams,
                localVarPathParams, localVarHttpContentType);

            int localVarStatusCode = (int)localVarResponse.StatusCode;

            //if (ExceptionFactory != null)
            //{
            //    Exception exception = ExceptionFactory("GetOrders", localVarResponse);
            //    if (exception != null) throw exception;
            //}

            return new ApiResponse<GetOrdersResponse>(localVarStatusCode,
                localVarResponse.Headers.ToDictionary(x => x.Name, x => string.Join(",", x.Value)),
                (GetOrdersResponse)this.Configuration.ApiClient.Deserialize(localVarResponse, typeof(GetOrdersResponse)));
        }

    }
}
