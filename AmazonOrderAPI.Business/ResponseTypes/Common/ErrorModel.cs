using System.Collections.Generic;

namespace AmazonOrderAPI.Business.ResponseTypes.Common
{
    public class ErrorDetail
    {
        public string Field { get; set; }
        public string Issue { get; set; }
    }

    public class ErrorModel
    {
        public string Name { get; set; }
        public List<ErrorDetail> Details { get; set; }
        public string Message { get; set; }
        public string Debug_id { get; set; }
    }
}