using AmazonOrderAPI.Business.Common;
using AmazonOrderAPI.Business.ResponseTypes;
using AutoMapper;
using eZTrackerOrderClient;
using eZTrackerOrderClient.RequestModel;

namespace AmazonOrderAPI.Business.Mappers
{
    public class eZTrackerProfile : Profile
    {
        public eZTrackerProfile()
        {
            CreateMap<OrdersItemInfo, PickupRequestModel>()
                .ForMember(dest => dest.DropOffAlternateMobileNumber, src => src.MapFrom(x => x.DeliveryConsigneeAddress.Phone ?? ""))
             .ForMember(dest => dest.DropOffMobileNumber, src => src.MapFrom(x => x.DeliveryConsigneeAddress.Phone ?? ""))
             .ForMember(dest => dest.DropOffArea, src => src.MapFrom(x => x.DeliveryConsigneeAddress.AddressLine3 ?? ""))
             .ForMember(dest => dest.DropOffBuildingNo, src => src.MapFrom(x => x.DeliveryConsigneeAddress.AddressLine2 ?? ""))
              .ForMember(dest => dest.DropOffLandmark, src => src.MapFrom(x => x.DeliveryConsigneeAddress.AddressLine1 ?? ""))
                .ForMember(dest => dest.DropOffName, src => src.MapFrom(x => x.DeliveryConsigneeAddress.Name ?? ""))
                .ForMember(dest => dest.DropOffEmailId, src => src.Ignore())
                 .ForMember(dest => dest.DropOffPincode, src => src.MapFrom(x => x.DeliveryConsigneeAddress.PostalCode ?? ""))
                  .ForMember(dest => dest.DropOffStreet, src => src.MapFrom(x => x.DeliveryConsigneeAddress.AddressLine2 ?? ""))
                    .ForMember(dest => dest.NoOfPieces, src => src.MapFrom(x => x.NoOfPieces))
                    .ForMember(dest => dest.PackageContent, src => src.MapFrom(x => x.Title))
                    .ForMember(dest => dest.IsEzShipOrder, src => src.MapFrom(x => x.IsEzShipOrder))
                     .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))

                      .ForMember(dest => dest.CreatedBy, src => src.MapFrom(x => x.CreatedBy))
                       .ForMember(dest => dest.ShouldbeGenConsNo, src => src.MapFrom(x => x.IsShouldbeGenConsNo))

                      .ForMember(dest => dest.OrderNumber, src => src.MapFrom(x => x.ReferenceNumber ?? ""))
                        .ForMember(dest => dest.PickupPincode, src => src.MapFrom(x => x.PickupAddress.PostalCode ?? ""))
                         .ForMember(dest => dest.PickupAlternateMobileNumber, src => src.MapFrom(x => x.PickupAddress.Phone ?? ""))
                         .ForMember(dest => dest.PickupArea, src => src.MapFrom(x => x.PickupAddress.AddressLine3 ?? ""))
                          .ForMember(dest => dest.PickupBuildingNo, src => src.MapFrom(x => x.PickupAddress.AddressLine2 ?? ""))
                          .ForMember(dest => dest.PickupLandmark, src => src.MapFrom(x => x.PickupAddress.AddressLine2 + "" + x.PickupAddress.AddressLine3 ?? ""))
                           .ForMember(dest => dest.PickupMobileNumber, src => src.MapFrom(x => x.PickupAddress.Phone ?? ""))
                            .ForMember(dest => dest.PickupName, src => src.MapFrom(x => x.PickupAddress.Name ?? ""))
                             .ForMember(dest => dest.PickupStreetAddress, src => src.MapFrom(x => x.PickupAddress.AddressLine1 + "" + x.PickupAddress.AddressLine2))
                             .ForMember(dest => dest.PreferredPickupTime, src => src.MapFrom(x => x.LatestShipDate.ToString("HH:mm:ss")))//Changed by Sid from EarliestShipDate to LatestShipDate
                             .ForMember(dest => dest.PickupDate, src => src.MapFrom(x => (x.LatestShipDate).ToString("dd/MM/yyyy")))//Changed by Sid from EarliestShipDate to LatestShipDate
                             .ForMember(dest => dest.PickupEmailId, src => src.Ignore())
                             .ForMember(dest => dest.CustomerCode, src => src.MapFrom(x => x.CustomerCode)
                             );

            CreateMap<AppSetting, Ez_AppSetting>().
                ForMember(x => x.PickupRequestConstants, src => src.MapFrom(sr => sr.PickupRequestConstants))
                .ForMember(x => x.GlobalConstants, src => src.MapFrom(sr => sr.GlobalConstants))
                .ForMember(x => x.ServiceURL, src => src.MapFrom(sr => sr.ServiceURL))
                .ForMember(x => x.ProxySetting, src => src.MapFrom(sr => sr.ProxySetting))
                .ForMember(x => x.NewSellerDefaults, src => src.MapFrom(sr => sr.NewSellerDefaults))
                .ForMember(x => x.AppConstants, src => src.MapFrom(sr => sr.AppConstants))
                .ForMember(x => x.Ez_Default, src => src.MapFrom(sr => sr.Default));

            CreateMap<NewSellerDefaults, Ez_NewSellerDefaults>().
               ForMember(x => x.MarketplaceURL, src => src.MapFrom(sr => sr.MarketplaceURL))
               .ForMember(x => x.Country, src => src.MapFrom(sr => sr.Country))
               .ForMember(x => x.MarketplaceId, src => src.MapFrom(sr => sr.MarketplaceId));

            CreateMap<AppConstants, Ez_AppConstants>().
               ForMember(x => x.AccessKey, src => src.MapFrom(sr => sr.AccessKey))
               .ForMember(x => x.ClientId, src => src.MapFrom(sr => sr.ClientId))
               .ForMember(x => x.SecretKey, src => src.MapFrom(sr => sr.SecretKey))
               .ForMember(x => x.CourierCompanyName, src => src.MapFrom(sr => sr.CourierCompanyName));

            CreateMap<Default, Ez_Default>().
               ForMember(x => x.WarehouseLocationCode, src => src.MapFrom(sr => sr.WarehouseLocationCode));

            CreateMap<GlobalConstants, Ez_GlobalConstants>().
               ForMember(x => x.ArchiveDaysbefore, src => src.MapFrom(sr => sr.ArchiveDaysbefore))
               .ForMember(x => x.InitialDate, src => src.MapFrom(sr => sr.InitialDate))
               .ForMember(x => x.RetryDaysBefore, src => src.MapFrom(sr => sr.RetryDaysBefore))
               .ForMember(x => x.SellerOrderStartDateBefore, src => src.MapFrom(sr => sr.SellerOrderStartDateBefore))
               .ForMember(x => x.AcknowledgeOrdersBefore, src => src.MapFrom(sr => sr.AcknowledgeOrdersBefore))
               .ForMember(x => x.FulfillOrdersBefore, src => src.MapFrom(sr => sr.FulfillOrdersBefore));

            CreateMap<ServiceURL, Ez_ServiceURL>().
               ForMember(x => x.eZtrackerURL, src => src.MapFrom(sr => sr.eZtrackerURL))
               .ForMember(x => x.ServiceAction, src => src.MapFrom(sr => sr.ServiceAction))
               .ForMember(x => x.ServiceVersion, src => src.MapFrom(sr => sr.ServiceVersion));

            CreateMap<ProxySetting, Ez_ProxySetting>().
                ForMember(x => x.IsProxyEnabled, src => src.MapFrom(sr => sr.IsProxyEnabled))
                .ForMember(x => x.ProxyHost, src => src.MapFrom(sr => sr.ProxyHost))
                .ForMember(x => x.ProxyPortNumber, src => src.MapFrom(sr => sr.ProxyPortNumber));

            CreateMap<PickupRequestConstants, Ez_PickupRequestConstants>()
                .ForMember(des => des.Breadth, src => src.MapFrom(x => x.Breadth))
                .ForMember(des => des.CarrierId, src => src.MapFrom(x => x.CarrierId))
                .ForMember(des => des.ConsType, src => src.MapFrom(x => x.ConsType))
                .ForMember(des => des.Height, src => src.MapFrom(x => x.Height))
                .ForMember(des => des.HostId, src => src.MapFrom(x => x.HostId))
                .ForMember(des => des.InvoiceValue, src => src.MapFrom(x => x.InvoiceValue))

                .ForMember(des => des.IsAmountPaid, src => src.MapFrom(x => x.IsAmountPaid))
                .ForMember(des => des.IsConfirm, src => src.MapFrom(x => x.IsConfirm))
                .ForMember(des => des.Length, src => src.MapFrom(x => x.Length))
                 .ForMember(des => des.PaymentType, src => src.MapFrom(x => x.PaymentType))
                .ForMember(des => des.PickUpRequestFrom, src => src.MapFrom(x => x.PickUpRequestFrom))
                .ForMember(des => des.PickUpRequestNo, src => src.MapFrom(x => x.PickUpRequestNo))
                .ForMember(des => des.SalesChannel, src => src.MapFrom(x => x.SalesChannel))
                .ForMember(des => des.CompanyId, src => src.MapFrom(x => x.CompanyId))
                 .ForMember(des => des.ServiceId, src => src.MapFrom(x => x.ServiceId))
                 .ForMember(des => des.ServiceName, src => src.MapFrom(x => x.ServiceName))
                 .ForMember(des => des.ezShipServiceId, src => src.MapFrom(x => x.ezShipServiceId))
                .ForMember(des => des.Status, src => src.MapFrom(x => x.Status))
                .ForMember(des => des.IsSave, src => src.MapFrom(x => x.IsSave))
                ;
        }
    }
}