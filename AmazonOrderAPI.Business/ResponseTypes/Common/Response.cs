using System.Runtime.Serialization;

namespace AmazonOrderAPI.Business.ResponseTypes.Common
{
    [DataContract]
    public class Response
    {
        [DataMember]
        public string Message { set; get; }

        [DataMember]
        public string StatusCode { set; get; }

        [DataMember]
        public string Status { set; get; }

        [DataMember]
        public object Data { set; get; }
    }
}