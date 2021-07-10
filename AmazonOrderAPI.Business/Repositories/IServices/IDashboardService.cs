using AmazonOrderAPI.Business.Model.Dashboard;
using AmazonOrderAPI.Business.Model.Reports;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Business.Repositories.IServices
{
    public interface IDashboardService
    {
        
        DashBoardOrder GetDashboardCards(OrderStatusReport model);

        OrderStatusReport GetOrderReport(OrderStatusReport Model);

        Task<List<string>> SearchReferenceRecord(string referenceRecord, int limit);

        Task<OrderStatusReport> BuildReportViewModel(string ClientId, string SellerId, OrderStatusReport model = null);
    }
}