

/****** Object:  Table [amz].[OrderItemsHistry]    Script Date: 05/08/2019 03:40:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [amz].[OrderItemsHistry](
	[Id] [BIGINT] NOT NULL,
	[OrderId] [BIGINT] NOT NULL,
	[ASIN] [NVARCHAR](MAX) NULL,
	[SellerSKU] [NVARCHAR](MAX) NULL,
	[OrderItemId] [NVARCHAR](MAX) NULL,
	[Title] [NVARCHAR](MAX) NULL,
	[QuantityOrdered] [DECIMAL](18, 2) NOT NULL,
	[QuantityShipped] [DECIMAL](18, 2) NOT NULL,
	[IsGift] [BIT] NOT NULL,
	[GiftMessageText] [NVARCHAR](MAX) NULL,
	[GiftWrapLevel] [NVARCHAR](MAX) NULL,
	[ConditionNote] [NVARCHAR](MAX) NULL,
	[ConditionId] [NVARCHAR](MAX) NULL,
	[ConditionSubtypeId] [NVARCHAR](MAX) NULL,
	[ScheduledDeliveryStartDate] [NVARCHAR](MAX) NULL,
	[ScheduledDeliveryEndDate] [NVARCHAR](MAX) NULL,
	[PriceDesignation] [NVARCHAR](MAX) NULL,
	[SerialNumberRequired] [BIT] NOT NULL,
	[IsTransparency] [BIT] NOT NULL,
	[WarehouseId] [BIGINT] NULL,
	[ItemStatusId] [BIGINT] NOT NULL,
	[eZTrackReferenceNumber] [NVARCHAR](MAX) NULL,
	[CreatedDate] [DATETIME2](7) NULL,
	[PickupFailureReason] [NVARCHAR](MAX) NULL,
	[SellerId] BIGINT  NULL
) ON [PRIMARY]

GO




/****** Object:  Table [amz].[OrdersHistry]    Script Date: 05/08/2019 03:40:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [amz].[OrdersHistry](
	[Id] [BIGINT] NOT NULL,
	[AmazonOrderId] [NVARCHAR](MAX) NULL,
	[SellerOrderId] [NVARCHAR](MAX) NULL,
	[PurchaseDate] [DATETIME2](7) NOT NULL,
	[LastUpdateDate] [DATETIME2](7) NOT NULL,
	[OrderStatus] [NVARCHAR](MAX) NULL,
	[FulfillmentChannel] [NVARCHAR](MAX) NULL,
	[SalesChannel] [NVARCHAR](MAX) NULL,
	[OrderChannel] [NVARCHAR](MAX) NULL,
	[ShipServiceLevel] [NVARCHAR](MAX) NULL,
	[ShippingAddressId] [BIGINT] NULL,
	[NumberOfItemsShipped] [DECIMAL](18, 2) NOT NULL,
	[NumberOfItemsUnshipped] [DECIMAL](18, 2) NOT NULL,
	[PaymentMethod] [NVARCHAR](MAX) NULL,
	[MarketplaceId] [NVARCHAR](MAX) NULL,
	[BuyerEmail] [NVARCHAR](MAX) NULL,
	[BuyerName] [NVARCHAR](MAX) NULL,
	[BuyerCounty] [NVARCHAR](MAX) NULL,
	[ShipmentServiceLevelCategory] [NVARCHAR](MAX) NULL,
	[ShippedByAmazonTFM] [BIT] NOT NULL,
	[TFMShipmentStatus] [NVARCHAR](MAX) NULL,
	[EasyShipShipmentStatus] [NVARCHAR](MAX) NULL,
	[CbaDisplayableShippingLabel] [NVARCHAR](MAX) NULL,
	[OrderType] [NVARCHAR](MAX) NULL,
	[EarliestShipDate] [DATETIME2](7) NOT NULL,
	[LatestShipDate] [DATETIME2](7) NOT NULL,
	[EarliestDeliveryDate] [DATETIME2](7) NOT NULL,
	[LatestDeliveryDate] [DATETIME2](7) NOT NULL,
	[IsBusinessOrder] [BIT] NOT NULL,
	[PurchaseOrderNumber] [NVARCHAR](MAX) NULL,
	[IsPrime] [BIT] NOT NULL,
	[IsPremiumOrder] [BIT] NOT NULL,
	[ReplacedOrderId] [NVARCHAR](MAX) NULL,
	[IsReplacementOrder] [BIT] NOT NULL,
	[PromiseResponseDueDate] [DATETIME2](7) NOT NULL,
	[IsEstimatedShipDateSet] [BIT] NOT NULL,
	[ShippingAddressStatusId] [INT] NULL,
	[ListOrderItemStatusId] [INT] NULL,
	[CreatedDate] [DATETIME2](7) NULL,
	[SellerId] BIGINT  NULL
) ON [PRIMARY]

GO




/****** Object:  Table [amz].[AddressHistry]    Script Date: 05/08/2019 03:41:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [amz].[AddressHistry](
	[Id] [BIGINT] NOT NULL,
	[Name] [NVARCHAR](MAX) NULL,
	[AddressLine1] [NVARCHAR](MAX) NULL,
	[AddressLine2] [NVARCHAR](MAX) NULL,
	[AddressLine3] [NVARCHAR](MAX) NULL,
	[City] [NVARCHAR](MAX) NULL,
	[Country] [NVARCHAR](MAX) NULL,
	[District] [NVARCHAR](MAX) NULL,
	[StateOrRegion] [NVARCHAR](MAX) NULL,
	[Municipality] [NVARCHAR](MAX) NULL,
	[PostalCode] [NVARCHAR](MAX) NULL,
	[CountryCode] [NVARCHAR](MAX) NULL,
	[Phone] [NVARCHAR](MAX) NULL,
	[AddressType] [NVARCHAR](MAX) NULL,
	[CreatedDate] [DATETIME] NULL
) ON [PRIMARY]

GO


