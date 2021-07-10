using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonOrderAPI.Migrations
{
    public partial class SP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "amz");

            migrationBuilder.CreateTable(
                name: "Address",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressType = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    StateOrRegion = table.Column<string>(nullable: true),
                    Municipality = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedException",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderItemId = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true),
                    FeedTypeId = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedException", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedResponse",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    FeedTypeId = table.Column<int>(nullable: false),
                    FeedProcessingStatusId = table.Column<int>(nullable: false),
                    FeedSubmissionId = table.Column<string>(nullable: true),
                    OrderItemId = table.Column<string>(nullable: true),
                    CompletedProcessingDate = table.Column<DateTime>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FulfillmentInstruction",
                schema: "amz",
                columns: table => new
                {
                    FulfillmentSupplySourceId = table.Column<string>(nullable: true),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    AmazonOrderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FulfillmentInstruction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Money",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyCode = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    AmazonOrderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderException",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderException", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemException",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderItemId = table.Column<string>(nullable: true),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    Exception = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemException", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItemResponse",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Response = table.Column<string>(nullable: true),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderResponse",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    Response = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfo",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    NumberOfItems = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceRecordTypes",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceRecordTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sellers",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<string>(nullable: true),
                    AccessKey = table.Column<string>(nullable: true),
                    SecretKey = table.Column<string>(nullable: true),
                    SellerId = table.Column<string>(nullable: true),
                    SellerName = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(nullable: true),
                    ServiceURL = table.Column<string>(nullable: true),
                    MWSAuthToken = table.Column<string>(nullable: true),
                    MarketplaceId = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    CurrencyCode = table.Column<string>(nullable: true),
                    IsStage = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsAutoManual = table.Column<bool>(nullable: false),
                    IsShouldbeGenConsNo = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<long>(nullable: false),
                    CustomerCode = table.Column<string>(nullable: true),
                    LWA_ClientId = table.Column<string>(nullable: true),
                    LWA_ClientSecret = table.Column<string>(nullable: true),
                    LWA_RefreshToken = table.Column<string>(nullable: true),
                    AWS_AccessKey = table.Column<string>(nullable: true),
                    AWS_Secretkey = table.Column<string>(nullable: true),
                    AWS_RoleARN = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    TokenEndPoint = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCollection",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Model = table.Column<int>(nullable: true),
                    ResponsibleParty = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointsGranted",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    PointsNumber = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    PointsMonetaryValueId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsGranted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointsGranted_Money_PointsMonetaryValueId",
                        column: x => x.PointsMonetaryValueId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReferenceRecords",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ReferenceRecordTypeId = table.Column<long>(nullable: false),
                    Displaytext = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReferenceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReferenceRecords_ReferenceRecordTypes_ReferenceRecordTypeId",
                        column: x => x.ReferenceRecordTypeId,
                        principalSchema: "amz",
                        principalTable: "ReferenceRecordTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SellerId = table.Column<long>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false),
                    FulfillmentChannelId = table.Column<long>(nullable: false),
                    FulfillmentChannel = table.Column<int>(nullable: true),
                    PaymentMethod = table.Column<int>(nullable: true),
                    OrderType = table.Column<int>(nullable: true),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    SellerOrderId = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<string>(nullable: true),
                    LastUpdateDate = table.Column<string>(nullable: true),
                    SalesChannel = table.Column<string>(nullable: true),
                    OrderChannel = table.Column<string>(nullable: true),
                    ShipServiceLevel = table.Column<string>(nullable: true),
                    OrderTotalId = table.Column<long>(nullable: false),
                    NumberOfItemsShipped = table.Column<int>(nullable: true),
                    NumberOfItemsUnshipped = table.Column<int>(nullable: true),
                    PaymentMethodDetails = table.Column<string>(nullable: true),
                    PaymentExecutionDetailId = table.Column<long>(nullable: false),
                    MarketplaceId = table.Column<string>(nullable: true),
                    ShipmentServiceLevelCategory = table.Column<string>(nullable: true),
                    EasyShipShipmentStatus = table.Column<string>(nullable: true),
                    CbaDisplayableShippingLabel = table.Column<string>(nullable: true),
                    EarliestShipDate = table.Column<string>(nullable: true),
                    LatestShipDate = table.Column<string>(nullable: true),
                    EarliestDeliveryDate = table.Column<string>(nullable: true),
                    LatestDeliveryDate = table.Column<string>(nullable: true),
                    IsBusinessOrder = table.Column<bool>(nullable: true),
                    IsPrime = table.Column<bool>(nullable: true),
                    IsPremiumOrder = table.Column<bool>(nullable: true),
                    IsGlobalExpressEnabled = table.Column<bool>(nullable: true),
                    ReplacedOrderId = table.Column<string>(nullable: true),
                    IsReplacementOrder = table.Column<bool>(nullable: true),
                    PromiseResponseDueDate = table.Column<string>(nullable: true),
                    IsEstimatedShipDateSet = table.Column<bool>(nullable: true),
                    IsSoldByAB = table.Column<bool>(nullable: true),
                    DefaultShipFromLocationAddressId = table.Column<long>(nullable: false),
                    FulfillmentInstructionId = table.Column<long>(nullable: false),
                    IsISPU = table.Column<bool>(nullable: true),
                    ShippingAddressStatusId = table.Column<int>(nullable: true),
                    ListOrderItemStatusId = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Address_DefaultShipFromLocationAddressId",
                        column: x => x.DefaultShipFromLocationAddressId,
                        principalSchema: "amz",
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_FulfillmentInstruction_FulfillmentInstructionId",
                        column: x => x.FulfillmentInstructionId,
                        principalSchema: "amz",
                        principalTable: "FulfillmentInstruction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Money_OrderTotalId",
                        column: x => x.OrderTotalId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "amz",
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WarehouseLocationName = table.Column<string>(nullable: true),
                    WarehouseLocationCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    StateOrRegion = table.Column<string>(nullable: true),
                    Municipality = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    AddressType = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    SellerId = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouse_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "amz",
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentExecutionDetailItem",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    PaymentId = table.Column<long>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    PaymentExecutionDetailId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentExecutionDetailItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentExecutionDetailItem_Orders_PaymentExecutionDetailId",
                        column: x => x.PaymentExecutionDetailId,
                        principalSchema: "amz",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentExecutionDetailItem_Money_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                schema: "amz",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmazonOrderId = table.Column<long>(nullable: false),
                    OrdersId = table.Column<long>(nullable: true),
                    DeemedResellerCategory = table.Column<int>(nullable: true),
                    ASIN = table.Column<string>(nullable: true),
                    SellerSKU = table.Column<string>(nullable: true),
                    OrderItemId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    QuantityOrdered = table.Column<int>(nullable: true),
                    QuantityShipped = table.Column<int>(nullable: true),
                    ProductInfoId = table.Column<long>(nullable: true),
                    PointsGrantedId = table.Column<long>(nullable: true),
                    ItemPriceId = table.Column<long>(nullable: true),
                    ShippingPriceId = table.Column<long>(nullable: true),
                    ItemTaxId = table.Column<long>(nullable: true),
                    ShippingTaxId = table.Column<long>(nullable: true),
                    ShippingDiscountId = table.Column<long>(nullable: true),
                    ShippingDiscountTaxId = table.Column<long>(nullable: true),
                    PromotionDiscountId = table.Column<long>(nullable: true),
                    PromotionDiscountTaxId = table.Column<long>(nullable: true),
                    CODFeeId = table.Column<long>(nullable: true),
                    CODFeeDiscountId = table.Column<long>(nullable: true),
                    IsGift = table.Column<bool>(nullable: true),
                    ConditionNote = table.Column<string>(nullable: true),
                    ConditionId = table.Column<string>(nullable: true),
                    ConditionSubtypeId = table.Column<string>(nullable: true),
                    ScheduledDeliveryStartDate = table.Column<string>(nullable: true),
                    ScheduledDeliveryEndDate = table.Column<string>(nullable: true),
                    PriceDesignation = table.Column<string>(nullable: true),
                    TaxCollectionId = table.Column<long>(nullable: true),
                    SerialNumberRequired = table.Column<bool>(nullable: true),
                    IsTransparency = table.Column<bool>(nullable: true),
                    IossNumber = table.Column<string>(nullable: true),
                    StoreChainStoreId = table.Column<string>(nullable: true),
                    ItemStatusId = table.Column<long>(nullable: false),
                    SellerId = table.Column<long>(nullable: false),
                    eZTrackReferenceNumber = table.Column<string>(nullable: true),
                    PickupFailureReason = table.Column<string>(nullable: true),
                    ConsignmentNo = table.Column<string>(nullable: true),
                    WarehouseId = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Money_CODFeeDiscountId",
                        column: x => x.CODFeeDiscountId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Money_CODFeeId",
                        column: x => x.CODFeeId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Money_ItemPriceId",
                        column: x => x.ItemPriceId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_ReferenceRecords_ItemStatusId",
                        column: x => x.ItemStatusId,
                        principalSchema: "amz",
                        principalTable: "ReferenceRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Money_ItemTaxId",
                        column: x => x.ItemTaxId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalSchema: "amz",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_PointsGranted_PointsGrantedId",
                        column: x => x.PointsGrantedId,
                        principalSchema: "amz",
                        principalTable: "PointsGranted",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_ProductInfo_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalSchema: "amz",
                        principalTable: "ProductInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Money_PromotionDiscountId",
                        column: x => x.PromotionDiscountId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Money_PromotionDiscountTaxId",
                        column: x => x.PromotionDiscountTaxId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalSchema: "amz",
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Money_ShippingDiscountId",
                        column: x => x.ShippingDiscountId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Money_ShippingDiscountTaxId",
                        column: x => x.ShippingDiscountTaxId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Money_ShippingPriceId",
                        column: x => x.ShippingPriceId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Money_ShippingTaxId",
                        column: x => x.ShippingTaxId,
                        principalSchema: "amz",
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_TaxCollection_TaxCollectionId",
                        column: x => x.TaxCollectionId,
                        principalSchema: "amz",
                        principalTable: "TaxCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Warehouse_WarehouseId",
                        column: x => x.WarehouseId,
                        principalSchema: "amz",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PromotionIds",
                schema: "amz",
                columns: table => new
                {
                    Capacity = table.Column<int>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    OrderItemId = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    AmazonOrderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionIds_OrderItem_Id",
                        column: x => x.Id,
                        principalSchema: "amz",
                        principalTable: "OrderItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CODFeeDiscountId",
                schema: "amz",
                table: "OrderItem",
                column: "CODFeeDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CODFeeId",
                schema: "amz",
                table: "OrderItem",
                column: "CODFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemPriceId",
                schema: "amz",
                table: "OrderItem",
                column: "ItemPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemStatusId",
                schema: "amz",
                table: "OrderItem",
                column: "ItemStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemTaxId",
                schema: "amz",
                table: "OrderItem",
                column: "ItemTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrdersId",
                schema: "amz",
                table: "OrderItem",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_PointsGrantedId",
                schema: "amz",
                table: "OrderItem",
                column: "PointsGrantedId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductInfoId",
                schema: "amz",
                table: "OrderItem",
                column: "ProductInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_PromotionDiscountId",
                schema: "amz",
                table: "OrderItem",
                column: "PromotionDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_PromotionDiscountTaxId",
                schema: "amz",
                table: "OrderItem",
                column: "PromotionDiscountTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_SellerId",
                schema: "amz",
                table: "OrderItem",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ShippingDiscountId",
                schema: "amz",
                table: "OrderItem",
                column: "ShippingDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ShippingDiscountTaxId",
                schema: "amz",
                table: "OrderItem",
                column: "ShippingDiscountTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ShippingPriceId",
                schema: "amz",
                table: "OrderItem",
                column: "ShippingPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ShippingTaxId",
                schema: "amz",
                table: "OrderItem",
                column: "ShippingTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_TaxCollectionId",
                schema: "amz",
                table: "OrderItem",
                column: "TaxCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_WarehouseId",
                schema: "amz",
                table: "OrderItem",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DefaultShipFromLocationAddressId",
                schema: "amz",
                table: "Orders",
                column: "DefaultShipFromLocationAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FulfillmentInstructionId",
                schema: "amz",
                table: "Orders",
                column: "FulfillmentInstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderTotalId",
                schema: "amz",
                table: "Orders",
                column: "OrderTotalId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SellerId",
                schema: "amz",
                table: "Orders",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentExecutionDetailItem_PaymentExecutionDetailId",
                schema: "amz",
                table: "PaymentExecutionDetailItem",
                column: "PaymentExecutionDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentExecutionDetailItem_PaymentId",
                schema: "amz",
                table: "PaymentExecutionDetailItem",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PointsGranted_PointsMonetaryValueId",
                schema: "amz",
                table: "PointsGranted",
                column: "PointsMonetaryValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ReferenceRecords_ReferenceRecordTypeId",
                schema: "amz",
                table: "ReferenceRecords",
                column: "ReferenceRecordTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouse_SellerId",
                schema: "amz",
                table: "Warehouse",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedException",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "FeedResponse",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "OrderException",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "OrderItemException",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "OrderItemResponse",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "OrderResponse",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "PaymentExecutionDetailItem",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "PromotionIds",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "OrderItem",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "ReferenceRecords",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "PointsGranted",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "ProductInfo",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "TaxCollection",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "Warehouse",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "ReferenceRecordTypes",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "Address",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "FulfillmentInstruction",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "Money",
                schema: "amz");

            migrationBuilder.DropTable(
                name: "Sellers",
                schema: "amz");
        }
    }
}
