using Amazon.APIEngine.ApiClient;
using Amazon.APIEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Amazon.APIEngine.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IOrdersV0Api : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>GetOrderResponse</returns>
        GetOrderResponse GetOrder(string orderId);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>ApiResponse of GetOrderResponse</returns>
        ApiResponse<GetOrderResponse> GetOrderWithHttpInfo(string orderId);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns the shipping address for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>GetOrderAddressResponse</returns>
        GetOrderAddressResponse GetOrderAddress(string orderId);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns the shipping address for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>ApiResponse of GetOrderAddressResponse</returns>
        ApiResponse<GetOrderAddressResponse> GetOrderAddressWithHttpInfo(string orderId);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns buyer information for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>GetOrderBuyerInfoResponse</returns>
        GetOrderBuyerInfoResponse GetOrderBuyerInfo(string orderId);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns buyer information for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>ApiResponse of GetOrderBuyerInfoResponse</returns>
        ApiResponse<GetOrderBuyerInfoResponse> GetOrderBuyerInfoWithHttpInfo(string orderId);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns detailed order item information for the order indicated by the specified order ID. If NextToken is provided, it&#x27;s used to retrieve the next page of order items.  Note: When an order is in the Pending state (the order has been placed but payment has not been authorized), the getOrderItems operation does not return information about pricing, taxes, shipping charges, gift status or promotions for the order items in the order. After an order leaves the Pending state (this occurs when payment has been authorized) and enters the Unshipped, Partially Shipped, or Shipped state, the getOrderItems operation returns information about pricing, taxes, shipping charges, gift status and promotions for the order items in the order.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>GetOrderItemsResponse</returns>
        GetOrderItemsResponse GetOrderItems(string orderId, string nextToken = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns detailed order item information for the order indicated by the specified order ID. If NextToken is provided, it&#x27;s used to retrieve the next page of order items.  Note: When an order is in the Pending state (the order has been placed but payment has not been authorized), the getOrderItems operation does not return information about pricing, taxes, shipping charges, gift status or promotions for the order items in the order. After an order leaves the Pending state (this occurs when payment has been authorized) and enters the Unshipped, Partially Shipped, or Shipped state, the getOrderItems operation returns information about pricing, taxes, shipping charges, gift status and promotions for the order items in the order.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>ApiResponse of GetOrderItemsResponse</returns>
        ApiResponse<GetOrderItemsResponse> GetOrderItemsWithHttpInfo(string orderId, string nextToken = null);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns buyer information in the order items of the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>GetOrderItemsBuyerInfoResponse</returns>
        GetOrderItemsBuyerInfoResponse GetOrderItemsBuyerInfo(string orderId, string nextToken = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns buyer information in the order items of the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>ApiResponse of GetOrderItemsBuyerInfoResponse</returns>
        ApiResponse<GetOrderItemsBuyerInfoResponse> GetOrderItemsBuyerInfoWithHttpInfo(string orderId, string nextToken = null);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns orders created or updated during the time frame indicated by the specified parameters. You can also apply a range of filtering criteria to narrow the list of orders returned. If NextToken is present, that will be used to retrieve the orders instead of other criteria.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
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
        GetOrdersResponse GetOrders(List<string> marketplaceIds, string createdAfter = null, string createdBefore = null, string lastUpdatedAfter = null, string lastUpdatedBefore = null, List<string> orderStatuses = null, List<string> fulfillmentChannels = null, List<string> paymentMethods = null, string buyerEmail = null, string sellerOrderId = null, int? maxResultsPerPage = null, List<string> easyShipShipmentStatuses = null, string nextToken = null, List<string> amazonOrderIds = null, string actualFulfillmentSupplySourceId = null, bool? isISPU = null, string storeChainStoreId = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns orders created or updated during the time frame indicated by the specified parameters. You can also apply a range of filtering criteria to narrow the list of orders returned. If NextToken is present, that will be used to retrieve the orders instead of other criteria.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
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
        ApiResponse<GetOrdersResponse> GetOrdersWithHttpInfo(List<string> marketplaceIds, string createdAfter = null, string createdBefore = null, string lastUpdatedAfter = null, string lastUpdatedBefore = null, List<string> orderStatuses = null, List<string> fulfillmentChannels = null, List<string> paymentMethods = null, string buyerEmail = null, string sellerOrderId = null, int? maxResultsPerPage = null, List<string> easyShipShipmentStatuses = null, string nextToken = null, List<string> amazonOrderIds = null, string actualFulfillmentSupplySourceId = null, bool? isISPU = null, string storeChainStoreId = null);
        #endregion Synchronous Operations
        #region Asynchronous Operations
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of GetOrderResponse</returns>
        System.Threading.Tasks.Task<GetOrderResponse> GetOrderAsync(string orderId);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of ApiResponse (GetOrderResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOrderResponse>> GetOrderAsyncWithHttpInfo(string orderId);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns the shipping address for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of GetOrderAddressResponse</returns>
        System.Threading.Tasks.Task<GetOrderAddressResponse> GetOrderAddressAsync(string orderId);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns the shipping address for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of ApiResponse (GetOrderAddressResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOrderAddressResponse>> GetOrderAddressAsyncWithHttpInfo(string orderId);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns buyer information for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of GetOrderBuyerInfoResponse</returns>
        System.Threading.Tasks.Task<GetOrderBuyerInfoResponse> GetOrderBuyerInfoAsync(string orderId);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns buyer information for the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An orderId is an Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <returns>Task of ApiResponse (GetOrderBuyerInfoResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOrderBuyerInfoResponse>> GetOrderBuyerInfoAsyncWithHttpInfo(string orderId);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns detailed order item information for the order indicated by the specified order ID. If NextToken is provided, it&#x27;s used to retrieve the next page of order items.  Note: When an order is in the Pending state (the order has been placed but payment has not been authorized), the getOrderItems operation does not return information about pricing, taxes, shipping charges, gift status or promotions for the order items in the order. After an order leaves the Pending state (this occurs when payment has been authorized) and enters the Unshipped, Partially Shipped, or Shipped state, the getOrderItems operation returns information about pricing, taxes, shipping charges, gift status and promotions for the order items in the order.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>Task of GetOrderItemsResponse</returns>
        System.Threading.Tasks.Task<GetOrderItemsResponse> GetOrderItemsAsync(string orderId, string nextToken = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns detailed order item information for the order indicated by the specified order ID. If NextToken is provided, it&#x27;s used to retrieve the next page of order items.  Note: When an order is in the Pending state (the order has been placed but payment has not been authorized), the getOrderItems operation does not return information about pricing, taxes, shipping charges, gift status or promotions for the order items in the order. After an order leaves the Pending state (this occurs when payment has been authorized) and enters the Unshipped, Partially Shipped, or Shipped state, the getOrderItems operation returns information about pricing, taxes, shipping charges, gift status and promotions for the order items in the order.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>Task of ApiResponse (GetOrderItemsResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOrderItemsResponse>> GetOrderItemsAsyncWithHttpInfo(string orderId, string nextToken = null);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns buyer information in the order items of the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>Task of GetOrderItemsBuyerInfoResponse</returns>
        System.Threading.Tasks.Task<GetOrderItemsBuyerInfoResponse> GetOrderItemsBuyerInfoAsync(string orderId, string nextToken = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns buyer information in the order items of the order indicated by the specified order ID.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
        /// <exception cref="ApiException">Thrown when fails to make API call</exception>
        /// <param name="orderId">An Amazon-defined order identifier, in 3-7-7 format.</param>
        /// <param name="nextToken">A string token returned in the response of your previous request. (optional)</param>
        /// <returns>Task of ApiResponse (GetOrderItemsBuyerInfoResponse)</returns>
        System.Threading.Tasks.Task<ApiResponse<GetOrderItemsBuyerInfoResponse>> GetOrderItemsBuyerInfoAsyncWithHttpInfo(string orderId, string nextToken = null);
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns orders created or updated during the time frame indicated by the specified parameters. You can also apply a range of filtering criteria to narrow the list of orders returned. If NextToken is present, that will be used to retrieve the orders instead of other criteria.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
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
        System.Threading.Tasks.Task<GetOrdersResponse> GetOrdersAsync(List<string> marketplaceIds, string createdAfter = null, string createdBefore = null, string lastUpdatedAfter = null, string lastUpdatedBefore = null, List<string> orderStatuses = null, List<string> fulfillmentChannels = null, List<string> paymentMethods = null, string buyerEmail = null, string sellerOrderId = null, int? maxResultsPerPage = null, List<string> easyShipShipmentStatuses = null, string nextToken = null, List<string> amazonOrderIds = null, string actualFulfillmentSupplySourceId = null, bool? isISPU = null, string storeChainStoreId = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns orders created or updated during the time frame indicated by the specified parameters. You can also apply a range of filtering criteria to narrow the list of orders returned. If NextToken is present, that will be used to retrieve the orders instead of other criteria.  **Usage Plans:**  | Plan type | Rate (requests per second) | Burst | | - -- - | - -- - | - -- - | |Default| 0.0055 | 20 | |Selling partner specific| Variable | Variable |  The x-amzn-RateLimit-Limit response header returns the usage plan rate limits that were applied to the requested operation. Rate limits for some selling partners will vary from the default rate and burst shown in the table above. For more information, see \&quot;Usage Plans and Rate Limits\&quot; in the Selling Partner API documentation.
        /// </remarks>
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
        System.Threading.Tasks.Task<ApiResponse<GetOrdersResponse>> GetOrdersAsyncWithHttpInfo(List<string> marketplaceIds, string createdAfter = null, string createdBefore = null, string lastUpdatedAfter = null, string lastUpdatedBefore = null, List<string> orderStatuses = null, List<string> fulfillmentChannels = null, List<string> paymentMethods = null, string buyerEmail = null, string sellerOrderId = null, int? maxResultsPerPage = null, List<string> easyShipShipmentStatuses = null, string nextToken = null, List<string> amazonOrderIds = null, string actualFulfillmentSupplySourceId = null, bool? isISPU = null, string storeChainStoreId = null);
        #endregion Asynchronous Operations


      
    }
}
