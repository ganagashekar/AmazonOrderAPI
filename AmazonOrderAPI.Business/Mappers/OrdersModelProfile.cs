using AmazonOrderAPI.Business.Model;
using AmazonOrderAPI.DataContext.Entities;
using AmazonOrderExtentions.CoreExtentions;
using AutoMapper;
using AmazonOrderAPI.Business.Common;


namespace AmazonOrderAPI.Business.Mappers
{
    public class OrdersModelProfile : Profile
    {
        public OrdersModelProfile()
        {
            CreateMap<OrderItem, OrderItemVM>().ForMember(dest => dest.Id, src => src.MapFrom(s => s.Id))
            .ForMember(dest => dest.ASIN, src => src.MapFrom(s => s.ASIN))
               .ForMember(dest => dest.Id, src => src.MapFrom(s => s.Id))
                  .ForMember(dest => dest.AmazonOrderId, src => src.MapFrom(s => s.AmazonOrderId))
            .ForMember(dest => dest.SellerSKU, src => src.MapFrom(s => s.SellerSKU))
            .ForMember(dest => dest.QuantityOrdered, src => src.MapFrom(s => s.QuantityOrdered))
            .ForMember(dest => dest.OrderItemId, src => src.MapFrom(s => s.OrderItemId))
            .ForMember(dest => dest.Orders, src => src.MapFrom(s => s.Orders))
             .ForMember(dest => dest.PickupAddress, src => src.MapFrom(s => s.Warehouse))
              .ForMember(dest => dest.Seller, src => src.MapFrom(s => s.Seller))
                 .ForMember(dest => dest.IsGift, src => src.MapFrom(s => s.IsGift))
                  .ForMember(dest => dest.ConsignmentNo, src => src.MapFrom(s => s.ConsignmentNo))
                  .ForMember(dest => dest.SerialNumberRequired, src => src.MapFrom(s => s.SerialNumberRequired))
                   .ForMember(dest => dest.ConditionId, src => src.MapFrom(s => s.ConditionId))
                     .ForMember(dest => dest.ConditionSubtypeId, src => src.MapFrom(s => s.ConditionSubtypeId))
             .ForMember(dest => dest.PickupFailureReason, src => src.MapFrom(s => s.PickupFailureReason))
              .ForMember(dest => dest.QuantityShipped, src => src.MapFrom(s => s.QuantityShipped))
            .ForMember(dest => dest.Title, src => src.MapFrom(s => s.Title));

            CreateMap<Order, OrderVM>().ForMember(dest => dest.Id, src => src.MapFrom(s => s.Id))
              .ForMember(dest => dest.AmazonOrderId, src => src.MapFrom(s => s.AmazonOrderId))
               .ForMember(dest => dest.ItemAddress, src => src.MapFrom(s => s.DefaultShipFromLocationAddress))

               .ForMember(dest => dest.OrderType, src => src.MapFrom(s => s.OrderType))
               .ForMember(dest => dest.EarliestShipDate, src => src.MapFrom(s => s.EarliestShipDate))

               .ForMember(dest => dest.LatestShipDate, src => src.MapFrom(s => s.LatestShipDate))
               .ForMember(dest => dest.EarliestDeliveryDate, src => src.MapFrom(s => s.EarliestDeliveryDate))

               .ForMember(dest => dest.LatestDeliveryDate, src => src.MapFrom(s => s.LatestDeliveryDate))
               .ForMember(dest => dest.IsBusinessOrder, src => src.MapFrom(s => s.IsBusinessOrder))

               .ForMember(dest => dest.IsPrime, src => src.MapFrom(s => s.IsPrime))
               .ForMember(dest => dest.IsPremiumOrder, src => src.MapFrom(s => s.IsPremiumOrder))

                .ForMember(dest => dest.NumberOfItemsUnshipped, src => src.MapFrom(s => s.NumberOfItemsUnshipped))
                .ForMember(dest => dest.IsEzShipOrder, src => src.Ignore())
              .ForMember(dest => dest.OrderStatus, src => src.MapFrom(s => s.OrderStatus))
              .ForMember(dest => dest.PurchaseDate, src => src.MapFrom(s => s.PurchaseDate));

            CreateMap<OrderItem, ReferenceRecord>().ForMember(dest => dest.Id, src => src.MapFrom(s => s.Id))
           .ForMember(dest => dest.Name, src => src.MapFrom(s => s.ItemStatus.Name))
           .ForMember(dest => dest.IsActive, src => src.MapFrom(s => s.ItemStatus.IsActive))
           .ForMember(dest => dest.Id, src => src.MapFrom(s => s.ItemStatus.Id))
           .ForMember(dest => dest.ReferenceRecordTypeId, src => src.MapFrom(s => s.ItemStatus.ReferenceRecordTypeId))
           .ForMember(dest => dest.CreatedDate, src => src.MapFrom(s => s.ItemStatus.CreatedDate))
           .ForMember(dest => dest.Displaytext, src => src.MapFrom(s => s.ItemStatus.Displaytext))
             .ForMember(dest => dest.ReferenceRecordTypes, src => src.Ignore());

            CreateMap<Address, AddressVM>().ForMember(dest => dest.Id, src => src.MapFrom(s => s.Id))
             .ForMember(dest => dest.AddressLine1, src => src.MapFrom(s => s.AddressLine1.Decrypt()))
             .ForMember(dest => dest.AddressLine2, src => src.MapFrom(s => s.AddressLine2.Decrypt()))
             .ForMember(dest => dest.AddressLine3, src => src.MapFrom(s => s.AddressLine3.Decrypt()))
             .ForMember(dest => dest.AddressType, src => src.MapFrom(s => (s.AddressType).Decrypt()))
               .ForMember(dest => dest.District, src => src.MapFrom(s => s.District.Decrypt()))
               .ForMember(dest => dest.Phone, src => src.MapFrom(s => s.Phone.Decrypt()))
                .ForMember(dest => dest.PostalCode, src => src.MapFrom(s => s.PostalCode.Decrypt()))
                 .ForMember(dest => dest.Name, src => src.MapFrom(s => s.Name.Decrypt()))
                  .ForMember(dest => dest.CountryCode, src => src.MapFrom(s => s.CountryCode.Decrypt()))
               .ForMember(dest => dest.City, src => src.MapFrom(s => s.City.Decrypt()))
                .ForMember(dest => dest.Municipality, src => src.MapFrom(s => s.Municipality.Decrypt()))
                  .ForMember(dest => dest.StateOrRegion, src => src.MapFrom(s => s.StateOrRegion.Decrypt()))
             .ForMember(dest => dest.Country, src => src.MapFrom(s => s.County.Decrypt()));

            CreateMap<Warehouse, WarehouseVM>()
           .ForMember(dest => dest.AddressLine1, src => src.MapFrom(s => s.AddressLine1))
           .ForMember(dest => dest.AddressLine2, src => src.MapFrom(s => s.AddressLine2))
              .ForMember(dest => dest.AddressLine3, src => src.MapFrom(s => s.AddressLine3))
                 .ForMember(dest => dest.WarehouseLocationCode, src => src.MapFrom(s => s.WarehouseLocationCode))
           .ForMember(dest => dest.WarehouseLocationName, src => src.MapFrom(s => s.WarehouseLocationName))
           .ForMember(dest => dest.IsActive, src => src.MapFrom(x => x.IsActive))
           .ForMember(dest => dest.AddressType, src => src.MapFrom(s => s.AddressType))
           .ForMember(dest => dest.City, src => src.MapFrom(s => s.City))
              .ForMember(dest => dest.CountryCode, src => src.MapFrom(s => s.CountryCode))
                 .ForMember(dest => dest.Country, src => src.MapFrom(s => s.Country))
           .ForMember(dest => dest.District, src => src.MapFrom(s => s.District))
            .ForMember(dest => dest.SellerId, src => src.MapFrom(s => s.SellerId))
            .ForMember(dest => dest.SellerId, src => src.MapFrom(s => s.SellerId))
           .ForMember(dest => dest.IsActive, src => src.MapFrom(s => s.IsActive))
           .ForMember(dest => dest.Municipality, src => src.MapFrom(s => s.Municipality))
              .ForMember(dest => dest.Name, src => src.MapFrom(s => s.Name))
                 .ForMember(dest => dest.Phone, src => src.MapFrom(s => s.Phone.Replace(" ", "")))
           .ForMember(dest => dest.PostalCode, src => src.MapFrom(s => s.PostalCode))
            .ForMember(dest => dest.StateOrRegion, src => src.MapFrom(s => s.StateOrRegion)).ReverseMap();

            CreateMap<Warehouse, SelectItem>()
                .ForMember(dest => dest.Text, src => src.MapFrom(s => s.WarehouseLocationCode))
                .ForMember(dest => dest.Id, src => src.MapFrom(s => s.Id))
                .ReverseMap();

            #region SPOrderS To DB Orders

            CreateMap<Amazon.APIEngine.Models.FulfillmentInstruction, FulfillmentInstruction>()
                .ForMember(dest => dest.AmazonOrderId, src => src.Ignore())
                 .ForMember(dest => dest.FulfillmentSupplySourceId, src => src.MapFrom(s => s.FulfillmentSupplySourceId))
                  .ForMember(dest => dest.CreatedDate, src => src.Ignore())
                  .ForMember(dest => dest.Id, src => src.Ignore()).ReverseMap();

            CreateMap<Amazon.APIEngine.Models.Money, Money>()
               .ForMember(dest => dest.AmazonOrderId, src => src.Ignore())
                .ForMember(dest => dest.Amount, src => src.MapFrom(s => s.Amount))
                 .ForMember(dest => dest.CurrencyCode, src => src.MapFrom(s => s.CurrencyCode))
                 .ForMember(dest => dest.CreatedDate, src => src.Ignore())
                 .ForMember(dest => dest.Id, src => src.Ignore()).ReverseMap();

            CreateMap<Amazon.APIEngine.Models.PaymentExecutionDetailItem, PaymentExecutionDetailItem>()
               .ForMember(dest => dest.AmazonOrderId, src => src.Ignore())
                .ForMember(dest => dest.PaymentMethod, src => src.MapFrom(s => s.PaymentMethod))
                 .ForMember(dest => dest.Payment, src => src.MapFrom(s => s.Payment))
                 .ForMember(dest => dest.CreatedDate, src => src.Ignore())
                 .ForMember(dest => dest.Id, src => src.Ignore()).ReverseMap();



            CreateMap<Amazon.APIEngine.Models.Order, FulfillmentInstruction>()
                 .ForMember(dest => dest.AmazonOrderId, src => src.MapFrom(s => s.AmazonOrderId))
                 .ForMember(dest => dest.Id, src => src.Ignore())
                 .ForMember(dest => dest.FulfillmentSupplySourceId, src => src.Ignore())
                 .ForMember(dest => dest.CreatedDate, src => src.Ignore());


            CreateMap<Amazon.APIEngine.Models.Order, Money>()
                .ForMember(dest => dest.AmazonOrderId, src => src.MapFrom(s => s.AmazonOrderId))
                 .ForMember(dest => dest.Id, src => src.Ignore())
                  .ForMember(dest => dest.CurrencyCode, src => src.Ignore())
                   .ForMember(dest => dest.Amount, src => src.Ignore())
                 .ForMember(dest => dest.CreatedDate, src => src.Ignore());


            //CreateMap<Amazon.APIEngine.Models.PaymentExecutionDetailItemList, PaymentExecutionDetailItem>();

            ////.ForMember(dest => dest,
            ////   opt => opt.MapFrom(s => Mapper.Map<Amazon.APIEngine.Models.PaymentExecutionDetailItem, PaymentExecutionDetailItem>(s[])));



            CreateMap<Amazon.APIEngine.Models.Order, Order>()
              .ForMember(dest => dest.Id, src => src.Ignore())
              .ForMember(dest => dest.AmazonOrderId, src => src.MapFrom(s => s.AmazonOrderId))
              .ForMember(dest => dest.PurchaseDate, src => src.MapFrom(s => s.PurchaseDate))
              .ForMember(dest => dest.LastUpdateDate, src => src.MapFrom(s => s.LastUpdateDate))
              .ForMember(dest => dest.OrderStatus, src => src.MapFrom(s => s.OrderStatus))
              .ForMember(dest => dest.SellerOrderId, src => src.MapFrom(s => s.SellerOrderId))
              .ForMember(dest => dest.FulfillmentChannel, src => src.MapFrom(s => s.FulfillmentChannel))
              .ForMember(dest => dest.SalesChannel, src => src.MapFrom(s => s.SalesChannel))
              .ForMember(dest => dest.OrderChannel, src => src.MapFrom(s => s.OrderChannel))
              .ForMember(dest => dest.ShipServiceLevel, src => src.MapFrom(s => s.ShipServiceLevel))
              .ForMember(dest => dest.NumberOfItemsUnshipped, src => src.MapFrom(s => s.NumberOfItemsUnshipped))
              .ForMember(dest => dest.NumberOfItemsShipped, src => src.MapFrom(s => s.NumberOfItemsShipped))
              .ForMember(dest => dest.PaymentMethod, src => src.MapFrom(s => s.PaymentMethod))
              .ForMember(dest => dest.MarketplaceId, src => src.MapFrom(s => s.MarketplaceId))
              .ForMember(dest => dest.ShipmentServiceLevelCategory, src => src.MapFrom(s => s.ShipmentServiceLevelCategory))
              .ForMember(dest => dest.EasyShipShipmentStatus, src => src.MapFrom(s => s.EasyShipShipmentStatus))
              .ForMember(dest => dest.OrderType, src => src.MapFrom(s => s.OrderType))
              .ForMember(dest => dest.CbaDisplayableShippingLabel, src => src.MapFrom(s => s.CbaDisplayableShippingLabel))
              .ForMember(dest => dest.EarliestShipDate, src => src.MapFrom(s => s.EarliestShipDate))
              .ForMember(dest => dest.LatestShipDate, src => src.MapFrom(s => s.LatestShipDate))
              .ForMember(dest => dest.EarliestDeliveryDate, src => src.MapFrom(s => s.EarliestDeliveryDate))
              .ForMember(dest => dest.LatestDeliveryDate, src => src.MapFrom(s => s.LatestDeliveryDate))
              .ForMember(dest => dest.EarliestShipDate, src => src.MapFrom(s => s.EarliestShipDate))
              .ForMember(dest => dest.IsBusinessOrder, src => src.MapFrom(s => s.IsBusinessOrder))
              .ForMember(dest => dest.IsPrime, src => src.MapFrom(s => s.IsPrime))
              .ForMember(dest => dest.IsPremiumOrder, src => src.MapFrom(s => s.IsPremiumOrder))
              .ForMember(dest => dest.IsGlobalExpressEnabled, src => src.MapFrom(s => s.IsGlobalExpressEnabled))
              .ForMember(dest => dest.ReplacedOrderId, src => src.MapFrom(s => s.ReplacedOrderId))
              .ForMember(dest => dest.IsReplacementOrder, src => src.MapFrom(s => s.IsReplacementOrder))
              .ForMember(dest => dest.PromiseResponseDueDate, src => src.MapFrom(s => s.PromiseResponseDueDate))
              .ForMember(dest => dest.IsEstimatedShipDateSet, src => src.MapFrom(s => s.IsEstimatedShipDateSet))
              .ForMember(dest => dest.IsSoldByAB, src => src.MapFrom(s => s.IsSoldByAB))
              .ForMember(dest => dest.IsSoldByAB, src => src.MapFrom(s => s.IsSoldByAB))


              .ForMember(dest => dest.PaymentExecutionDetailId, src => src.Ignore())
              .ForMember(dest => dest.DefaultShipFromLocationAddressId, src => src.Ignore())
              .ForMember(dest => dest.FulfillmentChannelId, src => src.Ignore())
              .ForMember(dest => dest.FulfillmentInstructionId, src => src.Ignore())
              .ForMember(dest => dest.SellerOrderId, src => src.MapFrom(s => s.SellerOrderId))
              .ForMember(dest => dest.SellerId, src => src.Ignore())
              .ForMember(dest => dest.ShippingAddressStatusId, src => src.Ignore())
              .ForMember(dest => dest.ListOrderItemStatusId, src => src.Ignore())
              .ForMember(dest => dest.OrderTotalId, src => src.Ignore())
              .ForMember(dest => dest.CreatedDate, src => src.Ignore())
               .ForMember(dest => dest.Seller, src => src.Ignore())

               .ForMember(dest => dest.DefaultShipFromLocationAddress, src => src.Ignore())
              .ForMember(dest => dest.PaymentExecutionDetail,
                opt => opt.Ignore())
              .ForMember(dest => dest.PaymentMethodDetails,
                  opt => opt.Ignore())
              .ForMember(dest => dest.FulfillmentInstruction,
                 opt => opt.Ignore())
              .ForMember(dest => dest.OrderTotal,
                 opt => opt.Ignore());

            //.ForMember(dest => dest.PaymentExecutionDetail,
            //   opt => opt.MapFrom(s => Mapper.Map<Amazon.APIEngine.Models.PaymentExecutionDetailItemList, PaymentExecutionDetailItem>(s.PaymentExecutionDetail)));

            //.ForMember(dest => dest.FulfillmentInstruction, src => src.MapFrom(s => s.FulfillmentInstruction ?? null))
            //.ForMember(dest => dest.PaymentMethodDetails, src => src.MapFrom(s => s.PaymentMethodDetails ?? null))
            // .ForMember(dest => dest.OrderTotal, src => src.MapFrom(s => s.OrderTotal ?? null))
            //.ForMember(dest => dest.PaymentExecutionDetail, src => src.MapFrom(s => s.PaymentExecutionDetail ?? null))

            //.ForMember(dest => dest.PaymentExecutionDetail,
            //   opt => opt.MapFrom(s => Mapper.Map<Amazon.APIEngine.Models.Order, PaymentExecutionDetailItem>(s)))
            //.ForMember(dest => dest.PaymentMethodDetails,
            //   opt => opt.MapFrom(s => Mapper.Map<Amazon.APIEngine.Models.Order, Money>(s)))
            //.ForMember(dest => dest.FulfillmentInstruction,
            //   opt => opt.MapFrom(s => Mapper.Map<Amazon.APIEngine.Models.Order, FulfillmentInstruction>(s)))
            //.ForMember(dest => dest.OrderTotal,
            //   opt => opt.MapFrom(s => Mapper.Map<Amazon.APIEngine.Models.Order, Money>(s)));





            #endregion
        }
    }
}