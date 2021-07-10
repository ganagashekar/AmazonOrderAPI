using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonOrderAPI.Migrations
{
    public partial class Tst852 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    AddressType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AmazonMWSConfig",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ClientId = table.Column<string>(nullable: true),
                    AccessKey = table.Column<string>(nullable: true),
                    SecretKey = table.Column<string>(nullable: true),
                    SellerId = table.Column<string>(nullable: true),
                    AppName = table.Column<string>(nullable: true),
                    ServiceURL = table.Column<string>(nullable: true),
                    MWSAuthToken = table.Column<string>(nullable: true),
                    MarketplaceId = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    CurrencyCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmazonMWSConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuyerCustomizedInfoDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomizedURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerCustomizedInfoDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuyerTaxInfo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyLegalName = table.Column<string>(nullable: true),
                    TaxingRegion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerTaxInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceData",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InvoiceRequirement = table.Column<string>(nullable: true),
                    BuyerSelectedInvoiceCategory = table.Column<string>(nullable: true),
                    InvoiceTitle = table.Column<string>(nullable: true),
                    InvoiceInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CurrencyCode = table.Column<string>(nullable: true),
                    Amount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductInfoDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NumberOfItems = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInfoDetail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxCollection",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: true),
                    ResponsibleParty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxCollection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxClassification",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    BuyerTaxInfoId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxClassification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxClassification_BuyerTaxInfo_BuyerTaxInfoId",
                        column: x => x.BuyerTaxInfoId,
                        principalTable: "BuyerTaxInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmazonOrderId = table.Column<string>(nullable: true),
                    SellerOrderId = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<string>(nullable: true),
                    FulfillmentChannel = table.Column<string>(nullable: true),
                    SalesChannel = table.Column<string>(nullable: true),
                    OrderChannel = table.Column<string>(nullable: true),
                    ShipServiceLevel = table.Column<string>(nullable: true),
                    ShippingAddressId = table.Column<long>(nullable: true),
                    OrderTotalId = table.Column<long>(nullable: true),
                    NumberOfItemsShipped = table.Column<decimal>(nullable: false),
                    NumberOfItemsUnshipped = table.Column<decimal>(nullable: false),
                    PaymentMethod = table.Column<string>(nullable: true),
                    MarketplaceId = table.Column<string>(nullable: true),
                    BuyerEmail = table.Column<string>(nullable: true),
                    BuyerName = table.Column<string>(nullable: true),
                    BuyerCounty = table.Column<string>(nullable: true),
                    BuyerTaxInfoId = table.Column<long>(nullable: true),
                    ShipmentServiceLevelCategory = table.Column<string>(nullable: true),
                    ShippedByAmazonTFM = table.Column<bool>(nullable: false),
                    TFMShipmentStatus = table.Column<string>(nullable: true),
                    EasyShipShipmentStatus = table.Column<string>(nullable: true),
                    CbaDisplayableShippingLabel = table.Column<string>(nullable: true),
                    OrderType = table.Column<string>(nullable: true),
                    EarliestShipDate = table.Column<DateTime>(nullable: false),
                    LatestShipDate = table.Column<DateTime>(nullable: false),
                    EarliestDeliveryDate = table.Column<DateTime>(nullable: false),
                    LatestDeliveryDate = table.Column<DateTime>(nullable: false),
                    IsBusinessOrder = table.Column<bool>(nullable: false),
                    PurchaseOrderNumber = table.Column<string>(nullable: true),
                    IsPrime = table.Column<bool>(nullable: false),
                    IsPremiumOrder = table.Column<bool>(nullable: false),
                    ReplacedOrderId = table.Column<string>(nullable: true),
                    IsReplacementOrder = table.Column<bool>(nullable: false),
                    PromiseResponseDueDate = table.Column<DateTime>(nullable: false),
                    IsEstimatedShipDateSet = table.Column<bool>(nullable: false),
                    ShippingAddressStatusId = table.Column<int>(nullable: true),
                    ListOrderItemStatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_BuyerTaxInfo_BuyerTaxInfoId",
                        column: x => x.BuyerTaxInfoId,
                        principalTable: "BuyerTaxInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Money_OrderTotalId",
                        column: x => x.OrderTotalId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Address_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PointsGrantedDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PointsNumber = table.Column<decimal>(nullable: false),
                    PointsMonetaryValueId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsGrantedDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointsGrantedDetail_Money_PointsMonetaryValueId",
                        column: x => x.PointsMonetaryValueId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentExecutionDetailItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PaymentId = table.Column<long>(nullable: true),
                    PaymentMethod = table.Column<string>(nullable: true),
                    OrderId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentExecutionDetailItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentExecutionDetailItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentExecutionDetailItem_Money_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<long>(nullable: false),
                    ASIN = table.Column<string>(nullable: true),
                    SellerSKU = table.Column<string>(nullable: true),
                    OrderItemId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    QuantityOrdered = table.Column<decimal>(nullable: false),
                    QuantityShipped = table.Column<decimal>(nullable: false),
                    ProductInfoId = table.Column<long>(nullable: true),
                    PointsGrantedId = table.Column<long>(nullable: true),
                    ItemPriceId = table.Column<long>(nullable: true),
                    ShippingPriceId = table.Column<long>(nullable: true),
                    GiftWrapPriceId = table.Column<long>(nullable: true),
                    ItemTaxId = table.Column<long>(nullable: true),
                    ShippingTaxId = table.Column<long>(nullable: true),
                    GiftWrapTaxId = table.Column<long>(nullable: true),
                    ShippingDiscountId = table.Column<long>(nullable: true),
                    ShippingDiscountTaxId = table.Column<long>(nullable: true),
                    PromotionDiscountId = table.Column<long>(nullable: true),
                    PromotionDiscountTaxId = table.Column<long>(nullable: true),
                    CODFeeId = table.Column<long>(nullable: true),
                    CODFeeDiscountId = table.Column<long>(nullable: true),
                    IsGift = table.Column<bool>(nullable: false),
                    GiftMessageText = table.Column<string>(nullable: true),
                    GiftWrapLevel = table.Column<string>(nullable: true),
                    InvoiceDataId = table.Column<long>(nullable: true),
                    ConditionNote = table.Column<string>(nullable: true),
                    ConditionId = table.Column<string>(nullable: true),
                    ConditionSubtypeId = table.Column<string>(nullable: true),
                    ScheduledDeliveryStartDate = table.Column<string>(nullable: true),
                    ScheduledDeliveryEndDate = table.Column<string>(nullable: true),
                    PriceDesignation = table.Column<string>(nullable: true),
                    BuyerCustomizedInfoId = table.Column<long>(nullable: true),
                    TaxCollectionId = table.Column<long>(nullable: true),
                    SerialNumberRequired = table.Column<bool>(nullable: false),
                    IsTransparency = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_BuyerCustomizedInfoDetail_BuyerCustomizedInfoId",
                        column: x => x.BuyerCustomizedInfoId,
                        principalTable: "BuyerCustomizedInfoDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_CODFeeDiscountId",
                        column: x => x.CODFeeDiscountId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_CODFeeId",
                        column: x => x.CODFeeId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_GiftWrapPriceId",
                        column: x => x.GiftWrapPriceId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_GiftWrapTaxId",
                        column: x => x.GiftWrapTaxId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_InvoiceData_InvoiceDataId",
                        column: x => x.InvoiceDataId,
                        principalTable: "InvoiceData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_ItemPriceId",
                        column: x => x.ItemPriceId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_ItemTaxId",
                        column: x => x.ItemTaxId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_PointsGrantedDetail_PointsGrantedId",
                        column: x => x.PointsGrantedId,
                        principalTable: "PointsGrantedDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductInfoDetail_ProductInfoId",
                        column: x => x.ProductInfoId,
                        principalTable: "ProductInfoDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_PromotionDiscountId",
                        column: x => x.PromotionDiscountId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_PromotionDiscountTaxId",
                        column: x => x.PromotionDiscountTaxId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_ShippingDiscountId",
                        column: x => x.ShippingDiscountId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_ShippingDiscountTaxId",
                        column: x => x.ShippingDiscountTaxId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_ShippingPriceId",
                        column: x => x.ShippingPriceId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_Money_ShippingTaxId",
                        column: x => x.ShippingTaxId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItems_TaxCollection_TaxCollectionId",
                        column: x => x.TaxCollectionId,
                        principalTable: "TaxCollection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BuyerCustomizedInfoId",
                table: "OrderItems",
                column: "BuyerCustomizedInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CODFeeDiscountId",
                table: "OrderItems",
                column: "CODFeeDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_CODFeeId",
                table: "OrderItems",
                column: "CODFeeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_GiftWrapPriceId",
                table: "OrderItems",
                column: "GiftWrapPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_GiftWrapTaxId",
                table: "OrderItems",
                column: "GiftWrapTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_InvoiceDataId",
                table: "OrderItems",
                column: "InvoiceDataId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemPriceId",
                table: "OrderItems",
                column: "ItemPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemTaxId",
                table: "OrderItems",
                column: "ItemTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PointsGrantedId",
                table: "OrderItems",
                column: "PointsGrantedId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductInfoId",
                table: "OrderItems",
                column: "ProductInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PromotionDiscountId",
                table: "OrderItems",
                column: "PromotionDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_PromotionDiscountTaxId",
                table: "OrderItems",
                column: "PromotionDiscountTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ShippingDiscountId",
                table: "OrderItems",
                column: "ShippingDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ShippingDiscountTaxId",
                table: "OrderItems",
                column: "ShippingDiscountTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ShippingPriceId",
                table: "OrderItems",
                column: "ShippingPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ShippingTaxId",
                table: "OrderItems",
                column: "ShippingTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_TaxCollectionId",
                table: "OrderItems",
                column: "TaxCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyerTaxInfoId",
                table: "Orders",
                column: "BuyerTaxInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderTotalId",
                table: "Orders",
                column: "OrderTotalId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentExecutionDetailItem_OrderId",
                table: "PaymentExecutionDetailItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentExecutionDetailItem_PaymentId",
                table: "PaymentExecutionDetailItem",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_PointsGrantedDetail_PointsMonetaryValueId",
                table: "PointsGrantedDetail",
                column: "PointsMonetaryValueId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxClassification_BuyerTaxInfoId",
                table: "TaxClassification",
                column: "BuyerTaxInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmazonMWSConfig");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "PaymentExecutionDetailItem");

            migrationBuilder.DropTable(
                name: "TaxClassification");

            migrationBuilder.DropTable(
                name: "BuyerCustomizedInfoDetail");

            migrationBuilder.DropTable(
                name: "InvoiceData");

            migrationBuilder.DropTable(
                name: "PointsGrantedDetail");

            migrationBuilder.DropTable(
                name: "ProductInfoDetail");

            migrationBuilder.DropTable(
                name: "TaxCollection");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "BuyerTaxInfo");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
