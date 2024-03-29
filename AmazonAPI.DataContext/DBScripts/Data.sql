USE [Amazon]
GO
SET IDENTITY_INSERT [amz].[ReferenceRecordTypes] ON 

GO
INSERT [amz].[ReferenceRecordTypes] ([Id], [CreatedDate], [Name], [IsActive]) VALUES (1, CAST(N'2019-12-01 00:00:00.0000000' AS DateTime2), N'OrderStatus', 1)
GO
INSERT [amz].[ReferenceRecordTypes] ([Id], [CreatedDate], [Name], [IsActive]) VALUES (2, CAST(N'2019-12-01 00:00:00.0000000' AS DateTime2), N'OrderItemStatus', 1)
GO
INSERT [amz].[ReferenceRecordTypes] ([Id], [CreatedDate], [Name], [IsActive]) VALUES (3, CAST(N'2019-12-01 00:00:00.0000000' AS DateTime2), N'MWSOrderStatus', 1)
GO
INSERT [amz].[ReferenceRecordTypes] ([Id], [CreatedDate], [Name], [IsActive]) VALUES (4, CAST(N'2019-12-01 00:00:00.0000000' AS DateTime2), N'MWSPaymentMethod', 1)
GO
INSERT [amz].[ReferenceRecordTypes] ([Id], [CreatedDate], [Name], [IsActive]) VALUES (5, CAST(N'2019-12-01 00:00:00.0000000' AS DateTime2), N'MWSFFMC', 1)
GO
INSERT [amz].[ReferenceRecordTypes] ([Id], [CreatedDate], [Name], [IsActive]) VALUES (6, CAST(N'2019-12-01 00:00:00.0000000' AS DateTime2), N'MWSMaxResultsPerPage', 1)
GO
SET IDENTITY_INSERT [amz].[ReferenceRecordTypes] OFF
GO
SET IDENTITY_INSERT [amz].[ReferenceRecords] ON 

GO
INSERT [amz].[ReferenceRecords] ([Id], [CreatedDate], [Name], [IsActive], [ReferenceRecordTypeId], [Displaytext]) VALUES (1, CAST(N'2019-04-04 00:00:00.0000000' AS DateTime2), N'OrderCreated', 1, 1, N'Order Created')
GO
INSERT [amz].[ReferenceRecords] ([Id], [CreatedDate], [Name], [IsActive], [ReferenceRecordTypeId], [Displaytext]) VALUES (2, CAST(N'2019-04-04 00:00:00.0000000' AS DateTime2), N'OrderItemsCreated', 1, 1, N'Pending')
GO
INSERT [amz].[ReferenceRecords] ([Id], [CreatedDate], [Name], [IsActive], [ReferenceRecordTypeId], [Displaytext]) VALUES (3, CAST(N'2019-04-04 00:00:00.0000000' AS DateTime2), N'OrderItemsRead', 1, 2, N'Processed')
GO
INSERT [amz].[ReferenceRecords] ([Id], [CreatedDate], [Name], [IsActive], [ReferenceRecordTypeId], [Displaytext]) VALUES (4, CAST(N'2019-04-04 00:00:00.0000000' AS DateTime2), N'InvalidSKU', 1, 2, N'Invalid SKU')
GO
INSERT [amz].[ReferenceRecords] ([Id], [CreatedDate], [Name], [IsActive], [ReferenceRecordTypeId], [Displaytext]) VALUES (5, CAST(N'2019-04-01 00:00:00.0000000' AS DateTime2), N'Unshipped', 1, 3, N'Unshipped')
GO
INSERT [amz].[ReferenceRecords] ([Id], [CreatedDate], [Name], [IsActive], [ReferenceRecordTypeId], [Displaytext]) VALUES (6, CAST(N'2019-04-01 00:00:00.0000000' AS DateTime2), N'PartiallyShipped', 1, 3, N'PartiallyShipped')
GO
INSERT [amz].[ReferenceRecords] ([Id], [CreatedDate], [Name], [IsActive], [ReferenceRecordTypeId], [Displaytext]) VALUES (7, CAST(N'2019-04-01 00:00:00.0000000' AS DateTime2), N'Other', 1, 4, N'Other')
GO
INSERT [amz].[ReferenceRecords] ([Id], [CreatedDate], [Name], [IsActive], [ReferenceRecordTypeId], [Displaytext]) VALUES (8, CAST(N'2019-01-01 00:00:00.0000000' AS DateTime2), N'MFN', 1, 5, N'MFN')
GO
INSERT [amz].[ReferenceRecords] ([Id], [CreatedDate], [Name], [IsActive], [ReferenceRecordTypeId], [Displaytext]) VALUES (9, CAST(N'2019-01-01 00:00:00.0000000' AS DateTime2), N'100', 1, 6, N'100')
GO
INSERT [amz].[ReferenceRecords] ([Id], [CreatedDate], [Name], [IsActive], [ReferenceRecordTypeId], [Displaytext]) VALUES (10, CAST(N'2019-01-01 00:00:00.0000000' AS DateTime2), N'PickupRequestFailed', 1, 2, N'Failed')
GO
SET IDENTITY_INSERT [amz].[ReferenceRecords] OFF
GO
SET IDENTITY_INSERT [amz].[AmazonMWSConfig] ON 

GO
INSERT [amz].[AmazonMWSConfig] ([Id], [CreatedDate], [ClientId], [AccessKey], [SecretKey], [SellerId], [AppName], [ServiceURL], [MWSAuthToken], [MarketplaceId], [Country], [CountryCode], [CurrencyCode], [IsStage]) VALUES (2, CAST(N'2019-04-06 14:03:30.8100000' AS DateTime2), N'SP_Courier', N'AKIAIUAKUK3XHTZ3MATQ', N'09hbQ6YPPEEX45Y74KhhSbxZfIlD+fzL8Xe2t8Ze', N'A1STPAVLLJY9UF', N'OrderHistoryApp', N'https://mws.amazonservices.in', N'amzn.mws.beb02c89-e362-46cc-f16c-af67e9ed1d1c', N'A21TJRUUN4KGV', NULL, NULL, NULL, 1)
GO
INSERT [amz].[AmazonMWSConfig] ([Id], [CreatedDate], [ClientId], [AccessKey], [SecretKey], [SellerId], [AppName], [ServiceURL], [MWSAuthToken], [MarketplaceId], [Country], [CountryCode], [CurrencyCode], [IsStage]) VALUES (3, CAST(N'2019-04-06 14:03:30.8100000' AS DateTime2), N'SP_Courier', N'AKIAJHZH6T24LVVHH3DA', N'vYmBWO7B/sMCNgxnIL0bGJH59b5lSm0rE7y7NSUq', N'A4LVP28KCWLSZ', N'OrderHistoryApp', N'https://mws.amazonservices.in', N'amzn.mws.8cb4ee58-95aa-25a7-576e-4d16a53d9524', N'A21TJRUUN4KGV', NULL, NULL, NULL, 0)
GO
SET IDENTITY_INSERT [amz].[AmazonMWSConfig] OFF
GO
SET IDENTITY_INSERT [amz].[Warehouse] ON 

GO
INSERT [amz].[Warehouse] ([Id], [CreatedDate], [WarehouseLocationName], [WarehouseLocationCode], [Name], [AddressLine1], [AddressLine2], [AddressLine3], [City], [Country], [District], [StateOrRegion], [Municipality], [PostalCode], [CountryCode], [Phone], [AddressType], [IsActive]) VALUES (1, CAST(N'2019-04-12 00:59:27.0570000' AS DateTime2), N'MUMBAI', N'MUM', N'Suhel ', N'A 11 , 122 Harihar Industrial Estate', N'Mankoli Naka - Bhiwandi', NULL, N'Thane 421302', N'India', NULL, NULL, NULL, N'421302', N'IN', N'9794342367', NULL, 1)
GO
INSERT [amz].[Warehouse] ([Id], [CreatedDate], [WarehouseLocationName], [WarehouseLocationCode], [Name], [AddressLine1], [AddressLine2], [AddressLine3], [City], [Country], [District], [StateOrRegion], [Municipality], [PostalCode], [CountryCode], [Phone], [AddressType], [IsActive]) VALUES (2, CAST(N'2019-04-12 01:01:30.8800000' AS DateTime2), N'GURGAON', N'GUR', N'Abrar', N'Plot no 32 , sector 34 ,
near Harpreet ford showroom,', N'Hero Honda chowk,', N'Gurugram ', N'Gurugram ', N'India', N'', N'Haryana', NULL, N'122001', N'IN', N'7785061638', NULL, 1)
GO
INSERT [amz].[Warehouse] ([Id], [CreatedDate], [WarehouseLocationName], [WarehouseLocationCode], [Name], [AddressLine1], [AddressLine2], [AddressLine3], [City], [Country], [District], [StateOrRegion], [Municipality], [PostalCode], [CountryCode], [Phone], [AddressType], [IsActive]) VALUES (3, CAST(N'2019-04-12 01:06:08.1630000' AS DateTime2), N'BANGALORE', N'BAN', N'Fuzel ', N'House No.8, Ground Floor Baba Nagar,1st Main Road, Near Dwarka Nagar Bus Stop, Bagalur Main Road, ', N'Yelahanka, Bengaluru', N'Yelahanka, Bengaluru', NULL, NULL, NULL, NULL, NULL, N'560086    ', N'IN', N'9794317693', NULL, 1)
GO
INSERT [amz].[Warehouse] ([Id], [CreatedDate], [WarehouseLocationName], [WarehouseLocationCode], [Name], [AddressLine1], [AddressLine2], [AddressLine3], [City], [Country], [District], [StateOrRegion], [Municipality], [PostalCode], [CountryCode], [Phone], [AddressType], [IsActive]) VALUES (4, CAST(N'2019-04-12 01:06:34.4470000' AS DateTime2), N'HYDERABAD ', N'HYD', N'Mondelez ', N'Sy. No. 52 A & B, Kandlakoi (V), Medchal (M), R.R. (D), Telangana (S)', N'Sy. No. 52 A & B, Kandlakoi (V), Medchal (M), R.R. (D), Telangana (S)', N'Sy. No. 52 A & B, Kandlakoi (V), Medchal (M), R.R. (D), Telangana (S)', NULL, N'India', NULL, N'Telangana', NULL, N'501401', N'IN', N'123456', NULL, 1)
GO
SET IDENTITY_INSERT [amz].[Warehouse] OFF
GO
