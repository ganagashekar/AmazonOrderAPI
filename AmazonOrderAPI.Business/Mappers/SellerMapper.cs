using AmazonOrderAPI.Business.Model.Seller;
using AmazonOrderAPI.DataContext.Entities;
using AmazonOrderExtentions.CoreExtentions;
using AutoMapper;

namespace AmazonOrderAPI.Business.Mappers
{
    public class SellerMapper : Profile
    {
        public SellerMapper()
        {
            CreateMap<Seller, SellerVM>()
                .ForMember(dest => dest.AccessKey, src => src.MapFrom(x => x.AccessKey))
                //.ForMember(dest => dest.AppName, src => src.MapFrom(x => x.AppName))
                .ForMember(dest => dest.ClientId, src => src.MapFrom(x => x.ClientId))
                .ForMember(dest => dest.Country, src => src.MapFrom(x => x.Country))
                .ForMember(dest => dest.CustomerCode, src => src.MapFrom(x => x.CustomerCode))
                .ForMember(dest => dest.IsAutoManual, src => src.MapFrom(x => x.IsAutoManual))
                .ForMember(dest => dest.IsShouldbeGenConsNo, src => src.MapFrom(x => x.IsShouldbeGenConsNo))
                .ForMember(dest => dest.CreatedBy, src => src.MapFrom(x => x.CreatedBy))

                .ForMember(dest => dest.CurrencyCode, src => src.MapFrom(x => x.CurrencyCode))
                   .ForMember(dest => dest.IsStage, src => src.MapFrom(x => x.IsStage))
                .ForMember(dest => dest.MarketplaceId, src => src.MapFrom(x => x.MarketplaceId))
                 .ForMember(dest => dest.IsActive, src => src.MapFrom(x => x.IsActive))
                 .ForMember(dest => dest.MWSAuthToken, src => src.MapFrom(x => x.MWSAuthToken))
                   .ForMember(dest => dest.SecretKey, src => src.MapFrom(x => x.SecretKey))
                .ForMember(dest => dest.SellerId, src => src.MapFrom(x => x.SellerId))

                  .ForMember(dest => dest.SellerName, src => src.MapFrom(x => x.SellerName))
                   .ForMember(dest => dest.ServiceURL, src => src.MapFrom(x => x.ServiceURL))
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.Id));

            CreateMap<PagedList<SellerVM>, SellersVM>()
                .ForMember(dest => dest.Sellers, src => src.MapFrom(x => x.Data))
                 .ForMember(dest => dest.TotalCount, src => src.MapFrom(x => x.TotalCount))
                 .ForMember(dest => dest.PageSize, src => src.MapFrom(x => x.PageSize));
        }
    }
}