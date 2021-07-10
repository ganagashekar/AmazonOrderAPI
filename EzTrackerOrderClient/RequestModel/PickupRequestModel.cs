using System.Collections.Generic;

namespace eZTrackerOrderClient.RequestModel
{
    public class ListPickupRequestModel
    {
        public ListPickupRequestModel()
        {
            LstPickupRequestModel = new List<PickupRequestModel>();
        }

        public List<PickupRequestModel> LstPickupRequestModel { set; get; }
    }

    public class PickupRequestModel
    {
        public long Id { set; get; }

        [AutoMapper.IgnoreMap()]
        public string HostId { get; set; }

        [AutoMapper.IgnoreMap()]
        public string CompanyId { get; set; }

        public string PickupName { get; set; }
        public string PickupMobileNumber { get; set; }
        public string PickupAlternateMobileNumber { get; set; }
        public string PickupArea { get; set; }
        public string PickupBuildingNo { get; set; }
        public string PickupLandmark { get; set; }
        public string PickupStreetAddress { get; set; }
        public string PickupPincode { get; set; }
        public string PickupEmailId { get; set; }
        public string DropOffName { get; set; }
        public string DropOffMobileNumber { get; set; }
        public string DropOffAlternateMobileNumber { get; set; }
        public string DropOffArea { get; set; }
        public string DropOffPincode { get; set; }
        public string DropOffBuildingNo { get; set; }
        public string DropOffEmailId { get; set; }
        public string DropOffLandmark { get; set; }
        public string DropOffStreet { get; set; }
        public bool ShouldbeGenConsNo { get; set; }

        public long CreatedBy { get; set; }



        [AutoMapper.IgnoreMap()]
        public string Weight { get; set; }

        public string PickupDate { get; set; }
        public string PreferredPickupTime { get; set; }
        public string NoOfPieces { get; set; }

        [AutoMapper.IgnoreMap()]
        public string Length { get; set; }

        [AutoMapper.IgnoreMap()]
        public string Breadth { get; set; }

        [AutoMapper.IgnoreMap()]
        public string Height { get; set; }

        [AutoMapper.IgnoreMap()]
        public string ServiceId { get; set; }

        [AutoMapper.IgnoreMap()]
        public string ConsType { get; set; }

        [AutoMapper.IgnoreMap()]
        public string CarrierId { get; set; }

        [AutoMapper.IgnoreMap()]
        public string InvoiceValue { get; set; }

        [AutoMapper.IgnoreMap()]
        public string PaymentType { get; set; }

        public string PackageContent { get; set; }

        public bool IsEzShipOrder { get; set; }


        public string CustomerCode { get; set; }

        [AutoMapper.IgnoreMap()]
        public string IsAmountPaid { get; set; }

        [AutoMapper.IgnoreMap()]
        public string Status { get; set; }

        [AutoMapper.IgnoreMap()]
        public string SalesChannel { get; set; }

        [AutoMapper.IgnoreMap()]
        public string IsConfirm { get; set; }

        [AutoMapper.IgnoreMap()]
        public string PickUpRequestNo { get; set; }

        [AutoMapper.IgnoreMap()]
        public string PickUpRequestFrom { get; set; }

        public string OrderNumber { get; set; }

        [AutoMapper.IgnoreMap()]
        public bool IsSave { get; set; }

        [AutoMapper.IgnoreMap()]
        public string  Saved { set; get; }
    }
}