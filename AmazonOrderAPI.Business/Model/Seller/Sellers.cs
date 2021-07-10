using System.Collections.Generic;

namespace AmazonOrderAPI.Business.Model.Seller
{
    public class SellersVM
    {
        public SellersVM()
        {
            Sellers = new List<SellerVM>();
        }

        public List<SellerVM> Sellers { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}