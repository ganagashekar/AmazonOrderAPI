using AmazonOrderAPI.Business.Common.EnumOps;
using AmazonOrderAPI.Business.Model.Dashboard;
using AmazonOrderAPI.Business.Model.Reports;
using AmazonOrderAPI.DataContext.Entities;
using AmazonOrderExtentions.CoreExtentions;
using AutoMapper;
using System;

namespace AmazonOrderAPI.Business.Mappers
{
    public class DashBoardProfile : Profile
    {
        public DashBoardProfile()
        {
            CreateMap<OrderItem, OrderItemDetail>()
                .ForMember(dest => dest.OrderId, src => src.MapFrom(x => x.OrderItemId))
                .ForMember(dest => dest.QuantityOrdered, src => src.MapFrom(x => x.QuantityOrdered))
                .ForMember(dest => dest.QuantityShipped, src => src.MapFrom(x => x.QuantityShipped))
                .ForMember(dest => dest.Status, src => src.MapFrom(x => x.ItemStatus.Displaytext))
                .ForMember(dest => dest.PurchaseDate, src => src.MapFrom(x => x.Orders.PurchaseDate))
                   .ForMember(dest => dest.EarlyShipDate, src => src.MapFrom(x => x.Orders.EarliestShipDate))
                .ForMember(dest => dest.Title, src => src.MapFrom(x => x.Title));

            CreateMap<OrderItem, OrderItemStatusDetail>()
              .ForMember(dest => dest.OrderId, src => src.MapFrom(x => x.OrderItemId))
               .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id))
              .ForMember(dest => dest.DropOffPincode, src => src.MapFrom(x => x.Orders.DefaultShipFromLocationAddress.PostalCode.Decrypt()))
              .ForMember(dest => dest.DropOffCity, src => src.MapFrom(x => x.Orders.DefaultShipFromLocationAddress.City.Decrypt()))
               .ForMember(dest => dest.PickupPincode, src => src.MapFrom(x => x.Warehouse.PostalCode))
               .ForMember(dest => dest.PickupCity, src => src.MapFrom(x => x.Warehouse.City))
                .ForMember(dest => dest.OrderDate, src => src.MapFrom(x => x.Orders.PurchaseDate))
                  .ForMember(dest => dest.PickupMobileNumber, src => src.MapFrom(x => x.Warehouse.Phone))
                   .ForMember(dest => dest.AmazonOrderId, src => src.MapFrom(x => x.Orders.AmazonOrderId))
                  .ForMember(dest => dest.DropMobileNumber, src => src.MapFrom(x => x.Orders.DefaultShipFromLocationAddress.Phone.Decrypt()))

                  .ForMember(dest => dest.IsPrime, src => src.MapFrom(x => x.Orders.IsPrime))
                  .ForMember(dest => dest.LastUpdatedDate, src => src.MapFrom(x => x.Orders.LastUpdateDate))
                  .ForMember(dest => dest.LatestShipDate, src => src.MapFrom(x => x.Orders.LatestShipDate))
                    .ForMember(dest => dest.IsGift, src => src.MapFrom(x => x.IsGift))
                    .ForMember(dest => dest.IsSerialNumberRequired, src => src.MapFrom(x => x.SerialNumberRequired))
                    .ForMember(dest => dest.ConditionSubTypeId, src => src.MapFrom(x => x.ConditionSubtypeId))
                    .ForMember(dest => dest.QuantityOrdered, src => src.MapFrom(x => x.QuantityOrdered))
                    .ForMember(dest => dest.QuantityShipped, src => src.MapFrom(x => x.QuantityShipped))
                    .ForMember(dest => dest.ConditionId, src => src.MapFrom(x => x.ConditionId))
                  
                   .ForMember(dest => dest.DropUserName, src => src.MapFrom(x => x.Orders.DefaultShipFromLocationAddress.Name.Decrypt()))
                   .ForMember(dest => dest.PickupUserName, src => src.MapFrom(x => x.Warehouse.Name))
                  .ForMember(dest => dest.DropAddress, src => src.MapFrom(x => string.Format("{0}{1}{2}", x.Orders.DefaultShipFromLocationAddress.AddressLine1.Decrypt(), x.Orders.DefaultShipFromLocationAddress.AddressLine2.Decrypt(), x.Orders.DefaultShipFromLocationAddress.AddressLine2.Decrypt())))

              .ForMember(dest => dest.PickupAddress, src => src.MapFrom(x => x.Warehouse.AddressLine1 + "" + x.Warehouse.AddressLine2 + " " + x.Warehouse.AddressLine3 + " " + x.Warehouse.PostalCode + " " + x.Warehouse.Name + " " + x.Warehouse.Phone))
              .ForMember(dest => dest.Status, src => src.MapFrom(x => x.ItemStatus.Displaytext))
              .ForMember(dest => dest.Reason, src => src.MapFrom(x => x.PickupFailureReason))
              .ForMember(dest => dest.ReferenceNumber, src => src.MapFrom(x => x.ItemStatusId == ((int)EnumReferenceRecords.InvalidSKU)
              ? String.Format("{0}", x.SellerSKU) : x.eZTrackReferenceNumber))
              .ForMember(dest => dest.Title, src => src.MapFrom(x => x.Title));
        }
    }
}