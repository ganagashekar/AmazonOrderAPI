DROP DATABASE [Amazon]
GO

Create database [Amazon]

GO


USE [Amazon]
GO

/****** Object:  Schema [amz]    Script Date: 19/04/2019 14:47:54 ******/
CREATE SCHEMA [amz]
GO
/****** Object:  Schema [Master]    Script Date: 19/04/2019 14:47:54 ******/
CREATE SCHEMA [Master]
GO
/****** Object:  Table [amz].[Address]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[Address](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[AddressLine1] [nvarchar](max) NULL,
	[AddressLine2] [nvarchar](max) NULL,
	[AddressLine3] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[District] [nvarchar](max) NULL,
	[StateOrRegion] [nvarchar](max) NULL,
	[Municipality] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[CountryCode] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[AddressType] [nvarchar](max) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [amz].[AmazonMWSConfig]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[AmazonMWSConfig](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ClientId] [nvarchar](max) NULL,
	[AccessKey] [nvarchar](max) NULL,
	[SecretKey] [nvarchar](max) NULL,
	[SellerId] [nvarchar](max) NULL,
	[AppName] [nvarchar](max) NULL,
	[ServiceURL] [nvarchar](max) NULL,
	[MWSAuthToken] [nvarchar](max) NULL,
	[MarketplaceId] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[CountryCode] [nvarchar](max) NULL,
	[CurrencyCode] [nvarchar](max) NULL,
	[IsStage] [bit] NOT NULL,
 CONSTRAINT [PK_AmazonMWSConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [amz].[OrderException]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[OrderException](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[AmazonOrderId] [nvarchar](max) NULL,
	[Response] [nvarchar](max) NULL,
	[Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderException] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [amz].[OrderItemException]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[OrderItemException](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[OrderItemId] [nvarchar](max) NULL,
	[Response] [nvarchar](max) NULL,
	[Exception] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderItemException] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [amz].[OrderItemResponse]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[OrderItemResponse](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Response] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderItemResponse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [amz].[OrderItems]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[OrderItems](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[OrderId] [bigint] NOT NULL,
	[ASIN] [nvarchar](max) NULL,
	[SellerSKU] [nvarchar](max) NULL,
	[OrderItemId] [nvarchar](max) NULL,
	[Title] [nvarchar](max) NULL,
	[QuantityOrdered] [decimal](18, 2) NOT NULL,
	[QuantityShipped] [decimal](18, 2) NOT NULL,
	[IsGift] [bit] NOT NULL,
	[GiftMessageText] [nvarchar](max) NULL,
	[GiftWrapLevel] [nvarchar](max) NULL,
	[ConditionNote] [nvarchar](max) NULL,
	[ConditionId] [nvarchar](max) NULL,
	[ConditionSubtypeId] [nvarchar](max) NULL,
	[ScheduledDeliveryStartDate] [nvarchar](max) NULL,
	[ScheduledDeliveryEndDate] [nvarchar](max) NULL,
	[PriceDesignation] [nvarchar](max) NULL,
	[SerialNumberRequired] [bit] NOT NULL,
	[IsTransparency] [bit] NOT NULL,
	[WarehouseId] [bigint] NULL,
	[ItemStatusId] [bigint] NOT NULL,
	[eZTrackReferenceNumber] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[PickupFailureReason] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [amz].[OrderResponse]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[OrderResponse](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Response] [nvarchar](max) NULL,
 CONSTRAINT [PK_OrderResponse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [amz].[Orders]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[Orders](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AmazonOrderId] [nvarchar](max) NULL,
	[SellerOrderId] [nvarchar](max) NULL,
	[PurchaseDate] [datetime2](7) NOT NULL,
	[LastUpdateDate] [datetime2](7) NOT NULL,
	[OrderStatus] [nvarchar](max) NULL,
	[FulfillmentChannel] [nvarchar](max) NULL,
	[SalesChannel] [nvarchar](max) NULL,
	[OrderChannel] [nvarchar](max) NULL,
	[ShipServiceLevel] [nvarchar](max) NULL,
	[ShippingAddressId] [bigint] NULL,
	[NumberOfItemsShipped] [decimal](18, 2) NOT NULL,
	[NumberOfItemsUnshipped] [decimal](18, 2) NOT NULL,
	[PaymentMethod] [nvarchar](max) NULL,
	[MarketplaceId] [nvarchar](max) NULL,
	[BuyerEmail] [nvarchar](max) NULL,
	[BuyerName] [nvarchar](max) NULL,
	[BuyerCounty] [nvarchar](max) NULL,
	[ShipmentServiceLevelCategory] [nvarchar](max) NULL,
	[ShippedByAmazonTFM] [bit] NOT NULL,
	[TFMShipmentStatus] [nvarchar](max) NULL,
	[EasyShipShipmentStatus] [nvarchar](max) NULL,
	[CbaDisplayableShippingLabel] [nvarchar](max) NULL,
	[OrderType] [nvarchar](max) NULL,
	[EarliestShipDate] [datetime2](7) NOT NULL,
	[LatestShipDate] [datetime2](7) NOT NULL,
	[EarliestDeliveryDate] [datetime2](7) NOT NULL,
	[LatestDeliveryDate] [datetime2](7) NOT NULL,
	[IsBusinessOrder] [bit] NOT NULL,
	[PurchaseOrderNumber] [nvarchar](max) NULL,
	[IsPrime] [bit] NOT NULL,
	[IsPremiumOrder] [bit] NOT NULL,
	[ReplacedOrderId] [nvarchar](max) NULL,
	[IsReplacementOrder] [bit] NOT NULL,
	[PromiseResponseDueDate] [datetime2](7) NOT NULL,
	[IsEstimatedShipDateSet] [bit] NOT NULL,
	[ShippingAddressStatusId] [int] NULL,
	[ListOrderItemStatusId] [int] NULL,
	[CreatedDate] [datetime2](7) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [amz].[ReferenceRecords]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[ReferenceRecords](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[ReferenceRecordTypeId] [bigint] NOT NULL,
	[Displaytext] [nvarchar](max) NULL,
 CONSTRAINT [PK_ReferenceRecords] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [amz].[ReferenceRecordTypes]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[ReferenceRecordTypes](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ReferenceRecordTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [amz].[Warehouse]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [amz].[Warehouse](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[WarehouseLocationName] [nvarchar](max) NULL,
	[WarehouseLocationCode] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[AddressLine1] [nvarchar](max) NULL,
	[AddressLine2] [nvarchar](max) NULL,
	[AddressLine3] [nvarchar](max) NULL,
	[City] [nvarchar](max) NULL,
	[Country] [nvarchar](max) NULL,
	[District] [nvarchar](max) NULL,
	[StateOrRegion] [nvarchar](max) NULL,
	[Municipality] [nvarchar](max) NULL,
	[PostalCode] [nvarchar](max) NULL,
	[CountryCode] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[AddressType] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Warehouse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 19/04/2019 14:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [amz].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Orders_OrderId] FOREIGN KEY([OrderId])
REFERENCES [amz].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [amz].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Orders_OrderId]
GO
ALTER TABLE [amz].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Warehouse_WarehouseId] FOREIGN KEY([WarehouseId])
REFERENCES [amz].[Warehouse] ([Id])
GO
ALTER TABLE [amz].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Warehouse_WarehouseId]
GO
ALTER TABLE [amz].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Address_ShippingAddressId] FOREIGN KEY([ShippingAddressId])
REFERENCES [amz].[Address] ([Id])
GO
ALTER TABLE [amz].[Orders] CHECK CONSTRAINT [FK_Orders_Address_ShippingAddressId]
GO
ALTER TABLE [amz].[ReferenceRecords]  WITH CHECK ADD  CONSTRAINT [FK_ReferenceRecords_ReferenceRecordTypes_ReferenceRecordTypeId] FOREIGN KEY([ReferenceRecordTypeId])
REFERENCES [amz].[ReferenceRecordTypes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [amz].[ReferenceRecords] CHECK CONSTRAINT [FK_ReferenceRecords_ReferenceRecordTypes_ReferenceRecordTypeId]
GO
