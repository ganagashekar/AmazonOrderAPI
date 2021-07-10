using System;

namespace AmazonOrderAPI.Business.Model
{
    public class FiltersModel
    {
        public DateTime? FromDate { set; get; }
        public DateTime? ToDate { set; get; }
    }
}