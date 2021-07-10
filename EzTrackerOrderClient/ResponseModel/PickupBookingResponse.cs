using System.Collections.Generic;

namespace eZTrackerOrderClient.ResponseModel
{
    public class PickupBookingResponse
    {
        public object Result { get; set; }
        public string ErrorMessage { get; set; }
        public string PickupRequestNumber { get; set; }
        public string Message { get; set; }
        public string IsError { get; set; }
        public long Id { set; get; }
        public string ConsignmentNo { set; get; }
    }

    public class ListPickupBookingResponse
    {
        public ListPickupBookingResponse()
        {
            LstPickupBookingResponse = new List<PickupBookingResponse>();
        }

        public List<PickupBookingResponse> LstPickupBookingResponse { set; get; }
    }
}