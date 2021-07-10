using AmazonOrderAPI.Business.Mappers;
using AutoMapper;
using System;

namespace AmazonOrderAPI.AutoMapperConfig
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                AutoMapperBusinessMappingConfig.Configure(x);
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }

    public class AutoMapperBusinessMappingConfig
    {
        public static void Configure(IMapperConfigurationExpression mapperConfiguration)
        {
            Action<IMapperConfigurationExpression> profileMapper = (cfg) =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile(new OrdersModelProfile());
                cfg.AddProfile(new OrdersResponseProfile());
                cfg.AddProfile(new eZTrackerProfile());
                cfg.AddProfile(new DashBoardProfile());
                cfg.AddProfile(new SellerMapper());
            };
            profileMapper(mapperConfiguration);
        }

        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                // Configure the Business AutoMapper for Business Service.
                AutoMapperBusinessMappingConfig.Configure(cfg);
            });
        }
    }
}