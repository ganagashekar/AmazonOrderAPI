﻿// <auto-generated />
using System;
using AmazonOrderAPI.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AmazonOrderAPI.Migrations
{
    [DbContext(typeof(OrderContext))]
    [Migration("20210709181722_Tes")]
    partial class Tes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<string>("AddressType");

                    b.Property<string>("AmazonOrderId");

                    b.Property<string>("City");

                    b.Property<string>("CountryCode");

                    b.Property<string>("County");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("District");

                    b.Property<string>("Municipality");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("PostalCode");

                    b.Property<string>("StateOrRegion");

                    b.HasKey("Id");

                    b.ToTable("Address","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.FeedException", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Exception");

                    b.Property<int>("FeedTypeId");

                    b.Property<string>("OrderItemId");

                    b.Property<string>("Response");

                    b.HasKey("Id");

                    b.ToTable("FeedException","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.FeedResponse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CompletedProcessingDate");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int>("FeedProcessingStatusId");

                    b.Property<string>("FeedSubmissionId");

                    b.Property<int>("FeedTypeId");

                    b.Property<string>("OrderItemId");

                    b.Property<string>("Response");

                    b.HasKey("Id");

                    b.ToTable("FeedResponse","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.FulfillmentInstruction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("FulfillmentSupplySourceId");

                    b.HasKey("Id");

                    b.ToTable("FulfillmentInstruction","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.Money", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<string>("Amount");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CurrencyCode");

                    b.HasKey("Id");

                    b.ToTable("Money","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<string>("CbaDisplayableShippingLabel");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<long>("DefaultShipFromLocationAddressId");

                    b.Property<string>("EarliestDeliveryDate");

                    b.Property<string>("EarliestShipDate");

                    b.Property<string>("EasyShipShipmentStatus");

                    b.Property<int?>("FulfillmentChannel");

                    b.Property<long>("FulfillmentChannelId");

                    b.Property<long>("FulfillmentInstructionId");

                    b.Property<bool?>("IsBusinessOrder");

                    b.Property<bool?>("IsEstimatedShipDateSet");

                    b.Property<bool?>("IsGlobalExpressEnabled");

                    b.Property<bool?>("IsISPU");

                    b.Property<bool?>("IsPremiumOrder");

                    b.Property<bool?>("IsPrime");

                    b.Property<bool?>("IsReplacementOrder");

                    b.Property<bool?>("IsSoldByAB");

                    b.Property<string>("LastUpdateDate");

                    b.Property<string>("LatestDeliveryDate");

                    b.Property<string>("LatestShipDate");

                    b.Property<long?>("ListOrderItemStatusId");

                    b.Property<string>("MarketplaceId");

                    b.Property<int?>("NumberOfItemsShipped");

                    b.Property<int?>("NumberOfItemsUnshipped");

                    b.Property<string>("OrderChannel");

                    b.Property<int>("OrderStatus");

                    b.Property<long>("OrderTotalId");

                    b.Property<int?>("OrderType");

                    b.Property<long>("PaymentExecutionDetailId");

                    b.Property<int?>("PaymentMethod");

                    b.Property<string>("PaymentMethodDetails");

                    b.Property<string>("PromiseResponseDueDate");

                    b.Property<string>("PurchaseDate");

                    b.Property<string>("ReplacedOrderId");

                    b.Property<string>("SalesChannel");

                    b.Property<long>("SellerId");

                    b.Property<string>("SellerOrderId");

                    b.Property<string>("ShipServiceLevel");

                    b.Property<string>("ShipmentServiceLevelCategory");

                    b.Property<int?>("ShippingAddressStatusId");

                    b.HasKey("Id");

                    b.HasIndex("DefaultShipFromLocationAddressId");

                    b.HasIndex("FulfillmentInstructionId");

                    b.HasIndex("OrderTotalId");

                    b.HasIndex("SellerId");

                    b.ToTable("Orders","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.OrderException", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Exception");

                    b.Property<string>("Response");

                    b.HasKey("Id");

                    b.ToTable("OrderException","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ASIN");

                    b.Property<long>("AmazonOrderId");

                    b.Property<long?>("CODFeeDiscountId");

                    b.Property<long?>("CODFeeId");

                    b.Property<string>("ConditionId");

                    b.Property<string>("ConditionNote");

                    b.Property<string>("ConditionSubtypeId");

                    b.Property<string>("ConsignmentNo");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("DeemedResellerCategory");

                    b.Property<string>("IossNumber");

                    b.Property<bool?>("IsGift");

                    b.Property<bool?>("IsTransparency");

                    b.Property<long?>("ItemPriceId");

                    b.Property<long>("ItemStatusId");

                    b.Property<long?>("ItemTaxId");

                    b.Property<string>("OrderItemId");

                    b.Property<long?>("OrdersId");

                    b.Property<string>("PickupFailureReason");

                    b.Property<long?>("PointsGrantedId");

                    b.Property<string>("PriceDesignation");

                    b.Property<long?>("ProductInfoId");

                    b.Property<long?>("PromotionDiscountId");

                    b.Property<long?>("PromotionDiscountTaxId");

                    b.Property<int?>("QuantityOrdered");

                    b.Property<int?>("QuantityShipped");

                    b.Property<string>("ScheduledDeliveryEndDate");

                    b.Property<string>("ScheduledDeliveryStartDate");

                    b.Property<long>("SellerId");

                    b.Property<string>("SellerSKU");

                    b.Property<bool?>("SerialNumberRequired");

                    b.Property<long?>("ShippingDiscountId");

                    b.Property<long?>("ShippingDiscountTaxId");

                    b.Property<long?>("ShippingPriceId");

                    b.Property<long?>("ShippingTaxId");

                    b.Property<string>("StoreChainStoreId");

                    b.Property<long?>("TaxCollectionId");

                    b.Property<string>("Title");

                    b.Property<long?>("WarehouseId");

                    b.Property<string>("eZTrackReferenceNumber");

                    b.HasKey("Id");

                    b.HasIndex("CODFeeDiscountId");

                    b.HasIndex("CODFeeId");

                    b.HasIndex("ItemPriceId");

                    b.HasIndex("ItemStatusId");

                    b.HasIndex("ItemTaxId");

                    b.HasIndex("OrdersId");

                    b.HasIndex("PointsGrantedId");

                    b.HasIndex("ProductInfoId");

                    b.HasIndex("PromotionDiscountId");

                    b.HasIndex("PromotionDiscountTaxId");

                    b.HasIndex("SellerId");

                    b.HasIndex("ShippingDiscountId");

                    b.HasIndex("ShippingDiscountTaxId");

                    b.HasIndex("ShippingPriceId");

                    b.HasIndex("ShippingTaxId");

                    b.HasIndex("TaxCollectionId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("OrderItem","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.OrderItemException", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Exception");

                    b.Property<string>("OrderItemId");

                    b.Property<string>("Response");

                    b.HasKey("Id");

                    b.ToTable("OrderItemException","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.OrderItemResponse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Response");

                    b.HasKey("Id");

                    b.ToTable("OrderItemResponse","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.OrderResponse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Response");

                    b.HasKey("Id");

                    b.ToTable("OrderResponse","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.PaymentExecutionDetailItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<long?>("PaymentExecutionDetailId");

                    b.Property<long?>("PaymentId");

                    b.Property<string>("PaymentMethod");

                    b.HasKey("Id");

                    b.HasIndex("PaymentExecutionDetailId");

                    b.HasIndex("PaymentId");

                    b.ToTable("PaymentExecutionDetailItem","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.PointsGrantedDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<long>("PointsMonetaryValueId");

                    b.Property<int?>("PointsNumber");

                    b.HasKey("Id");

                    b.HasIndex("PointsMonetaryValueId");

                    b.ToTable("PointsGranted","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.ProductInfoDetail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("NumberOfItems");

                    b.HasKey("Id");

                    b.ToTable("ProductInfo","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.PromotionIdList", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("AmazonOrderId");

                    b.Property<int>("Capacity");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("OrderItemId");

                    b.HasKey("Id");

                    b.ToTable("PromotionIds","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.ReferenceRecord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("Displaytext");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<long>("ReferenceRecordTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ReferenceRecordTypeId");

                    b.ToTable("ReferenceRecords","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.ReferenceRecordType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ReferenceRecordTypes","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.Seller", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AWS_AccessKey");

                    b.Property<string>("AWS_RoleARN");

                    b.Property<string>("AWS_Secretkey");

                    b.Property<string>("AccessKey");

                    b.Property<string>("AppName");

                    b.Property<string>("ClientId");

                    b.Property<string>("Country");

                    b.Property<string>("CountryCode");

                    b.Property<long>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CurrencyCode");

                    b.Property<string>("CustomerCode");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsAutoManual");

                    b.Property<bool>("IsShouldbeGenConsNo");

                    b.Property<bool>("IsStage");

                    b.Property<string>("LWA_ClientId");

                    b.Property<string>("LWA_ClientSecret");

                    b.Property<string>("LWA_RefreshToken");

                    b.Property<string>("MWSAuthToken");

                    b.Property<string>("MarketplaceId");

                    b.Property<string>("Region");

                    b.Property<string>("SecretKey");

                    b.Property<string>("SellerAPIEndPoint");

                    b.Property<string>("SellerId");

                    b.Property<string>("SellerName");

                    b.Property<string>("ServiceURL");

                    b.Property<string>("TokenEndPoint");

                    b.HasKey("Id");

                    b.ToTable("Sellers","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.TaxCollection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AmazonOrderId");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<int?>("Model");

                    b.Property<int?>("ResponsibleParty");

                    b.HasKey("Id");

                    b.ToTable("TaxCollection","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.Warehouse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<string>("AddressType");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("CountryCode");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("District");

                    b.Property<bool?>("IsActive");

                    b.Property<string>("Municipality");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("PostalCode");

                    b.Property<long>("SellerId");

                    b.Property<string>("StateOrRegion");

                    b.Property<string>("WarehouseLocationCode");

                    b.Property<string>("WarehouseLocationName");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Warehouse","amz");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.Order", b =>
                {
                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Address", "DefaultShipFromLocationAddress")
                        .WithMany()
                        .HasForeignKey("DefaultShipFromLocationAddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.FulfillmentInstruction", "FulfillmentInstruction")
                        .WithMany()
                        .HasForeignKey("FulfillmentInstructionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "OrderTotal")
                        .WithMany()
                        .HasForeignKey("OrderTotalId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.OrderItem", b =>
                {
                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "CODFeeDiscount")
                        .WithMany()
                        .HasForeignKey("CODFeeDiscountId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "CODFee")
                        .WithMany()
                        .HasForeignKey("CODFeeId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "ItemPrice")
                        .WithMany()
                        .HasForeignKey("ItemPriceId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.ReferenceRecord", "ItemStatus")
                        .WithMany()
                        .HasForeignKey("ItemStatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "ItemTax")
                        .WithMany()
                        .HasForeignKey("ItemTaxId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Order", "Orders")
                        .WithMany()
                        .HasForeignKey("OrdersId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.PointsGrantedDetail", "PointsGranted")
                        .WithMany()
                        .HasForeignKey("PointsGrantedId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.ProductInfoDetail", "ProductInfo")
                        .WithMany()
                        .HasForeignKey("ProductInfoId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "PromotionDiscount")
                        .WithMany()
                        .HasForeignKey("PromotionDiscountId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "PromotionDiscountTax")
                        .WithMany()
                        .HasForeignKey("PromotionDiscountTaxId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "ShippingDiscount")
                        .WithMany()
                        .HasForeignKey("ShippingDiscountId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "ShippingDiscountTax")
                        .WithMany()
                        .HasForeignKey("ShippingDiscountTaxId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "ShippingPrice")
                        .WithMany()
                        .HasForeignKey("ShippingPriceId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "ShippingTax")
                        .WithMany()
                        .HasForeignKey("ShippingTaxId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.TaxCollection", "TaxCollection")
                        .WithMany()
                        .HasForeignKey("TaxCollectionId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Warehouse", "Warehouse")
                        .WithMany()
                        .HasForeignKey("WarehouseId");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.PaymentExecutionDetailItem", b =>
                {
                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Order")
                        .WithMany("PaymentExecutionDetail")
                        .HasForeignKey("PaymentExecutionDetailId");

                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.PointsGrantedDetail", b =>
                {
                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Money", "PointsMonetaryValue")
                        .WithMany()
                        .HasForeignKey("PointsMonetaryValueId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.PromotionIdList", b =>
                {
                    b.HasOne("AmazonOrderAPI.DataContext.Entities.OrderItem")
                        .WithMany("PromotionIds")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.ReferenceRecord", b =>
                {
                    b.HasOne("AmazonOrderAPI.DataContext.Entities.ReferenceRecordType", "ReferenceRecordTypes")
                        .WithMany()
                        .HasForeignKey("ReferenceRecordTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AmazonOrderAPI.DataContext.Entities.Warehouse", b =>
                {
                    b.HasOne("AmazonOrderAPI.DataContext.Entities.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
