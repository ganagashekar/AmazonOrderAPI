using AmazonOrderAPI.Business.Model;
using AmazonOrderAPI.Business.ResponseTypes;
using AutoMapper;

namespace AmazonOrderAPI.Business.Mappers
{
    public class OrdersResponseProfile : Profile
    {
        public OrdersResponseProfile()
        {
            CreateMap<OrderVM, OrderTransaction>()
               .ForMember(dest => dest.AmazonOrderId, src => src.MapFrom(s => s.AmazonOrderId))
               .ForMember(dest => dest.Address, src => src.MapFrom(s => s.ItemAddress))
               .ForMember(dest => dest.NumberOfItemsShipped, src => src.MapFrom(s => s.NumberOfItemsShipped))
               .ForMember(dest => dest.NumberOfItemsUnshipped, src => src.MapFrom(s => s.NumberOfItemsUnshipped))
                .ForMember(dest => dest.OrderStatus, src => src.MapFrom(s => s.OrderStatus))
                .ForMember(dest => dest.PurchaseDate, src => src.MapFrom(s => s.PurchaseDate))
                .ForMember(dest => dest.ShipServiceLevel, src => src.MapFrom(s => s.ShipServiceLevel));

            CreateMap<AddressVM, OrderItemAddress>()
               .ForMember(dest => dest.AddressLine1, src => src.MapFrom(s => s.AddressLine1))
                 .ForMember(dest => dest.AddressLine2, src => src.MapFrom(s => s.AddressLine2))
                   .ForMember(dest => dest.AddressLine3, src => src.MapFrom(s => s.AddressLine3))
                     .ForMember(dest => dest.AddressType, src => src.MapFrom(s => s.AddressType))
                       .ForMember(dest => dest.City, src => src.MapFrom(s => s.City))
                     .ForMember(dest => dest.CountryCode, src => src.MapFrom(s => s.CountryCode))
                     .ForMember(dest => dest.Country, src => src.MapFrom(x => x.Country))
                      .ForMember(dest => dest.District, src => src.MapFrom(x => x.AddressLine3))
                       .ForMember(dest => dest.Municipality, src => src.MapFrom(x => x.AddressLine3))
                        .ForMember(dest => dest.Phone, src => src.MapFrom(x => x.Phone))
                         .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.StateOrRegion, src => src.MapFrom(x => x.StateOrRegion));

            CreateMap<WarehouseVM, PikcupAddress>()
               .ForMember(dest => dest.AddressLine1, src => src.MapFrom(s => s.AddressLine1))
                 .ForMember(dest => dest.AddressLine2, src => src.MapFrom(s => s.AddressLine2))
                   .ForMember(dest => dest.AddressLine3, src => src.MapFrom(s => s.AddressLine3))
                       .ForMember(dest => dest.City, src => src.MapFrom(s => s.City))
                     .ForMember(dest => dest.CountryCode, src => src.MapFrom(s => s.CountryCode))
                     .ForMember(dest => dest.County, src => src.MapFrom(x => x.Country))
                      .ForMember(dest => dest.District, src => src.MapFrom(x => x.AddressLine3))
                       .ForMember(dest => dest.Municipality, src => src.MapFrom(x => x.AddressLine3))
                        .ForMember(dest => dest.Phone, src => src.MapFrom(x => x.Phone))
                         .ForMember(dest => dest.Name, src => src.MapFrom(x => x.Name))
                       .ForMember(dest => dest.StateOrRegion, src => src.MapFrom(x => x.StateOrRegion));

            CreateMap<OrderItemVM, OrdersItemInfo>()

                 .ForMember(dest => dest.Id, src => src.MapFrom(s => s.Id))
                 .ForMember(dest => dest.OrderType, src => src.MapFrom(s => s.Orders.OrderType))
               .ForMember(dest => dest.EarliestShipDate, src => src.MapFrom(s => s.Orders.EarliestShipDate))

               .ForMember(dest => dest.LatestShipDate, src => src.MapFrom(s => s.Orders.LatestShipDate))
               .ForMember(dest => dest.EarliestDeliveryDate, src => src.MapFrom(s => s.Orders.EarliestDeliveryDate))

               .ForMember(dest => dest.LatestDeliveryDate, src => src.MapFrom(s => s.Orders.LatestDeliveryDate))
               .ForMember(dest => dest.IsBusinessOrder, src => src.MapFrom(s => s.Orders.IsBusinessOrder))
                 .ForMember(dest => dest.CustomerCode, src => src.MapFrom(s => s.Seller.CustomerCode))
                 .ForMember(dest => dest.CreatedBy, src => src.MapFrom(s => s.Seller.CreatedBy))
                 .ForMember(dest => dest.IsAutoManual, src => src.MapFrom(s => s.Seller.IsAutoManual))
                 .ForMember(dest => dest.IsShouldbeGenConsNo, src => src.MapFrom(s => s.Seller.IsShouldbeGenConsNo))
               .ForMember(dest => dest.IsPrime, src => src.MapFrom(s => s.Orders.IsPrime))
               .ForMember(dest => dest.IsPremiumOrder, src => src.MapFrom(s => s.Orders.IsPremiumOrder))

                  .ForMember(dest => dest.Description, src => src.MapFrom(s => s.Title))
                   .ForMember(dest => dest.NoOfPieces, src => src.MapFrom(s => s.Orders.NumberOfItemsUnshipped))
                   .ForMember(dest => dest.Title, src => src.MapFrom(s => s.Title))
                   .ForMember(dest => dest.IsEzShipOrder, src => src.MapFrom(s => s.Orders.IsEzShipOrder))
               .ForMember(dest => dest.ReferenceNumber, src => src.MapFrom(s => s.Orders.AmazonOrderId))
               .ForMember(dest => dest.DeliveryConsigneeAddress, src => src.MapFrom(s => s.Orders.ItemAddress))
                .ForMember(dest => dest.PickupAddress, src => src.MapFrom(s => s.PickupAddress));
        }
    }
}