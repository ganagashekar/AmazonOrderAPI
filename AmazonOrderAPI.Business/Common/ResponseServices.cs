using AmazonOrderAPI.Business.ResponseTypes.Common;

namespace AmazonOrderAPI.Business.Common
{
    public static class ResponseServices
    {
        public static Response CreateResponse(string Message, string ReferenceNumber, object Data, string StatusCode)
        {
            return new Response
            {
                Message = Message,
                Data = Data,
                StatusCode = StatusCode,
            };
        }

        public static Response CreateErrorResponse(string ErrorMessage, string ReferenceNumber, object Data, string StatusCode)
        {
            return new Response
            {
                Message = ErrorMessage,

                Data = Data,
                StatusCode = Codes.ErrorCode,
            };
        }

        public static Response CreateValidationErrorResponse(string ErrorMessage, string ReferenceNumber, object Data, string StatusCode)
        {
            return new Response
            {
                Message = ErrorMessage,

                Data = Data,
                StatusCode = Codes.ErrorCode,
            };
        }
    }
}