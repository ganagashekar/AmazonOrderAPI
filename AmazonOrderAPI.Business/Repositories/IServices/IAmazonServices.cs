using System.Threading.Tasks;

namespace AmazonOrderAPI.Business.Repositories.IServices
{
    public interface IAmazonServices
    {
        Task<string> ImportAmazonOrders();

        Task<string> ImportAmazonOrderItems();

        Task<string> ArchiveOrders();

        Task<string> SendAcknowledgementFeed();

        Task<string> SendFulfillmentFeed();

        Task<string> ImportOrders();

    }
}