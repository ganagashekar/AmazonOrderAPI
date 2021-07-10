using AmazonOrderAPI.Business.Model.Reports;
using AmazonOrderAPI.Business.RequestTypes;
using AmazonOrderAPI.Business.ResponseTypes.Common;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Business.Repositories.IServices
{
    public interface IOrderFetchServices
    {
        Task<Response> GetOrders(OrderRequest OrderRequest);

        Task<Response> RetryOrder(long orderId);

        //Task<Response> AcknowledgeOrder(long orderId);

        //Task<Response> FulfillOrder(long orderId);

        Task<Response> PickupOrder(long orderId, long WarehouseId);

        Task<OrderItemStatusDetail> GetOrderById(long OrderId);

        Task<bool> SaveOrUpdateOrderDetails(OrderItemStatusDetail orderItems);

        Task<Response> RetryOrders(OrderStatusReport model);
    }
}