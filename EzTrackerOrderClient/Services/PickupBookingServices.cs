using AmazonOrderExtentions.CoreExtentions;
using eZTrackerOrderClient.RequestModel;
using eZTrackerOrderClient.ResponseModel;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace eZTrackerOrderClient.Services
{
    public class PickupBookingServices
    {
        private NLog.Logger _Logger;

        private readonly Ez_AppSetting appSetting;
        private readonly Ez_ProxySetting proxySetting;
        private readonly Ez_PickupRequestConstants Constants;

        public PickupBookingServices(Ez_AppSetting setting)

        {
            _Logger = NLog.LogManager.GetLogger("eZTrackerLogger");
            appSetting = setting;
            Constants = setting.PickupRequestConstants;
            proxySetting = setting.ProxySetting;
        }

        public async Task<PickupBookingResponse> BulkOrderBooking(PickupRequestModel PickupRequestModel)
        {
            try
            {
                WebProxy Myproxy = null;
                //  string ServiceURL = eZTrackerOrderClient.Constants.eZtrackerURL;
                string ServiceURL = string.Format("{0}/{1}/{2}", appSetting.ServiceURL.eZtrackerURL, appSetting.ServiceURL.ServiceVersion, appSetting.ServiceURL.ServiceAction);
                _Logger.Info("EzTrackerRequestInfoStart");
                PickupBookingResponse result = null;


                if (appSetting.ProxySetting.IsProxyEnabled)
                {
                    _Logger.Info("proxySetting.ProxyHost");
                    _Logger.Info(appSetting.ProxySetting.ProxyHost);
                    _Logger.Info(appSetting.ProxySetting.ProxyPortNumber);
                    Myproxy = new WebProxy(appSetting.ProxySetting.ProxyHost, appSetting.ProxySetting.ProxyPortNumber);
                    Myproxy.BypassProxyOnLocal = true;

                }

                //foreach (var items in Request.LstPickupRequestModel)
                //{
                var client = new RestClient(ServiceURL);
                var request = new RestRequest(Method.POST);
                if (Myproxy.IsNotNull())
                    client.Proxy = Myproxy;
                try
                {
                    request.AddHeader("Content-Type", "application/json");
                    var Jsonbody = GenerateRequestParameter(PickupRequestModel);
                    request.AddJsonBody(Jsonbody);
                    _Logger.Info(Jsonbody);
                    IRestResponse response = client.Execute(request);
                    _Logger.Info(response.Content);
                    result = new PickupBookingResponse();
                    result = response.Content.GetDeserialize<PickupBookingResponse>();
                    result.Id = PickupRequestModel.Id;

                }
                catch (Exception ex)
                {
                    _Logger.Info("Error");
                    _Logger.Error(ex);
                    result = null;
                    // continue;
                }
                finally
                {
                    client = null;
                    request = null;
                }
                //  }
                _Logger.Info("EzTrackerRequestInfoEnd");
                _Logger.Info("EzTrackerRequestInfoResponseStart");
                _Logger.Info(result.GetserializeJsonString());
                _Logger.Info("EzTrackerRequestInfoResponseEnd");
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex);
                return null;
            }
        }

        public string GenerateRequestParameter(PickupRequestModel pickupRequestModel)
        {
            pickupRequestModel.HostId = Constants.HostId.ToString();
            pickupRequestModel.CompanyId = Constants.CompanyId;
            pickupRequestModel.PickupPincode = pickupRequestModel.PickupPincode.Trim();
            pickupRequestModel.DropOffPincode = pickupRequestModel.DropOffPincode.Trim();
            pickupRequestModel.PickupMobileNumber = pickupRequestModel.PickupMobileNumber.Trim().Replace(" ", "");
            pickupRequestModel.DropOffMobileNumber = pickupRequestModel.DropOffMobileNumber.Trim().Replace(" ", "");
            pickupRequestModel.PickupAlternateMobileNumber = pickupRequestModel.PickupAlternateMobileNumber.Trim().Replace(" ", "");
            pickupRequestModel.DropOffAlternateMobileNumber = pickupRequestModel.DropOffAlternateMobileNumber.Trim().Replace(" ", "");
            pickupRequestModel.PickupDate = pickupRequestModel.PickupDate.Replace('-', '/');
            pickupRequestModel.Weight = pickupRequestModel.Weight ?? "1";
            pickupRequestModel.NoOfPieces = ((int)(Convert.ToDecimal(pickupRequestModel.NoOfPieces ?? "0"))).ToString();
            pickupRequestModel.Length = Constants.Length ?? "1";
            pickupRequestModel.Breadth = Constants.Breadth ?? "1";
            pickupRequestModel.Height = Constants.Height ?? "1";
            if(pickupRequestModel.IsEzShipOrder)
            {
                pickupRequestModel.ServiceId = Constants.ezShipServiceId ?? "116";
            }
            else
            {
                pickupRequestModel.ServiceId = Constants.ServiceId ?? "116";
            }
            pickupRequestModel.ConsType = Constants.ConsType ?? "1";
            pickupRequestModel.CarrierId = Constants.CarrierId ?? "1";
            pickupRequestModel.InvoiceValue = Constants.InvoiceValue ?? "0";
            pickupRequestModel.PaymentType = Constants.PaymentType ?? "0";
            pickupRequestModel.PackageContent = pickupRequestModel.PackageContent ?? "Demo";
            //  pickupRequestModel.CustomerCode = Constants.CustomerCode ?? "F123";
            pickupRequestModel.IsAmountPaid = Constants.IsAmountPaid ?? "0";
            pickupRequestModel.Status = Constants.Status ?? " 63 ";
            pickupRequestModel.SalesChannel = Constants.SalesChannel ?? "3000";
            pickupRequestModel.IsConfirm = Constants.IsConfirm ?? "1";
            pickupRequestModel.DropOffArea = pickupRequestModel.DropOffArea ?? "-";
            pickupRequestModel.DropOffBuildingNo = pickupRequestModel.DropOffBuildingNo ?? "-";
            pickupRequestModel.DropOffLandmark = pickupRequestModel.DropOffLandmark ?? "-";
            pickupRequestModel.DropOffStreet = pickupRequestModel.DropOffStreet ?? "-";

            pickupRequestModel.PickupArea = pickupRequestModel.PickupArea ?? "-";
            pickupRequestModel.PickupBuildingNo = pickupRequestModel.PickupBuildingNo ?? "-";
            pickupRequestModel.PickupLandmark = pickupRequestModel.PickupLandmark ?? "-";
            pickupRequestModel.PickupStreetAddress = pickupRequestModel.PickupStreetAddress ?? "-";

            pickupRequestModel.PickUpRequestNo = Constants.PickUpRequestNo ?? "0";
            pickupRequestModel.PickUpRequestFrom = Constants.PickUpRequestFrom ?? "0";
            pickupRequestModel.IsSave = Constants.IsSave;
            pickupRequestModel.Saved = "true";
            _Logger.Info(pickupRequestModel.GetserializeJsonString().ToString());
            return pickupRequestModel.GetserializeJsonString().ToString();
        }
    }
}