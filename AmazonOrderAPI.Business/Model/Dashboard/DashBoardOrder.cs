using System;
using System.Collections.Generic;

namespace AmazonOrderAPI.Business.Model.Dashboard
{
    public class DashBoardOrder
    {
        public DashBoardOrder()
        {
            ListCountCards = new List<CountCards>();
            OrderItemDetail = new List<OrderItemDetail>();
            PieCharValue = new List<int>();
        }

        public List<CountCards> ListCountCards { set; get; }
        public List<OrderItemDetail> OrderItemDetail { set; get; }
        public List<int> PieCharValue { set; get; }
    }

    public class CountCards
    {
        public string CardName { set; get; }
        public string CardValue { set; get; }
        public string CardInfoName { set; get; }
        public long? StatusId { set; get; }
        public string Class { set; get; }
    }

    public class OrderItemDetail
    {
        public string OrderId { set; get; }
        public int QuantityOrdered { set; get; }
        public int QuantityShipped { set; get; }
        public string Title { set; get; }
        public DateTime PurchaseDate { set; get; }
        public DateTime EarlyShipDate { set; get; }
        public string Status { set; get; }
    }
}