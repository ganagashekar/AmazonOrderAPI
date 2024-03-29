USE [Amazon]
GO
/****** Object:  Index [UQ__Warehous__1500E4C1CBCF7A09]    Script Date: 04/07/2019 10:38:38 AM ******/
ALTER TABLE [Master].[Warehouses] DROP CONSTRAINT [UQ__Warehous__1500E4C1CBCF7A09]
GO
/****** Object:  Table [Master].[Warehouses]    Script Date: 04/07/2019 10:38:38 AM ******/
DROP TABLE [Master].[Warehouses]
GO
/****** Object:  Schema [Master]    Script Date: 04/07/2019 10:38:38 AM ******/
DROP SCHEMA [Master]
GO
/****** Object:  Schema [Master]    Script Date: 04/07/2019 10:38:38 AM ******/
CREATE SCHEMA [Master]
GO
/****** Object:  Table [Master].[Warehouses]    Script Date: 04/07/2019 10:38:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Master].[Warehouses](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[WarehouseName] [nvarchar](100) NULL,
	[WarehouseLocationName] [nvarchar](100) NOT NULL,
	[WarehouseLocationCode] [nvarchar](50) NOT NULL,
	[WarehouseLocationAddress] [nvarchar](500) NOT NULL,
	[WarehouseDescription] [nvarchar](100) NULL,
	[IsActive] [bit] NOT NULL DEFAULT ((1)),
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_Warehouses_CreatedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK_Warehouses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [Master].[Warehouses] ON 

GO
INSERT [Master].[Warehouses] ([Id], [WarehouseName], [WarehouseLocationName], [WarehouseLocationCode], [WarehouseLocationAddress], [WarehouseDescription], [IsActive], [CreatedDate]) VALUES (4, N'Mumbai', N'Mumbai', N'MUM', N'A 11 , 122 Harihar Industrial Estate
Mankoli Naka - Bhiwandi
Thane 421302
Contact - Suhel - +91 97943 42367', N'Mumbai location', 1, CAST(N'2019-04-07 10:01:17.663' AS DateTime))
GO
INSERT [Master].[Warehouses] ([Id], [WarehouseName], [WarehouseLocationName], [WarehouseLocationCode], [WarehouseLocationAddress], [WarehouseDescription], [IsActive], [CreatedDate]) VALUES (5, N'GURGAON', N'GURGAON', N'GUR', N'Plot no 32 , sector 34 ,
near Harpreet ford showroom,
Hero Honda chowk,
Gurugram - 122001
Haryana, IN,
Contact Mr Abrar - +91 77850 61638', N'GURGAON location', 1, CAST(N'2019-04-07 10:02:09.010' AS DateTime))
GO
INSERT [Master].[Warehouses] ([Id], [WarehouseName], [WarehouseLocationName], [WarehouseLocationCode], [WarehouseLocationAddress], [WarehouseDescription], [IsActive], [CreatedDate]) VALUES (6, N'BANGALORE', N'BANGALORE', N'BAN', N'House No.8, Ground Floor Baba Nagar,1st Main Road, Near Dwarka Nagar Bus Stop, Bagalur Main Road, 
Yelahanka, Bengaluru – 560086    
Contact Mr Fuzel - +91 97943 17693

 

 ', N'BANGALORE', 1, CAST(N'2019-04-07 10:02:56.290' AS DateTime))
GO
INSERT [Master].[Warehouses] ([Id], [WarehouseName], [WarehouseLocationName], [WarehouseLocationCode], [WarehouseLocationAddress], [WarehouseDescription], [IsActive], [CreatedDate]) VALUES (7, N'HYDERABAD', N'HYDERABAD', N'HYD', N'Mondelez 

Sy. No. 52 A & B, Kandlakoi (V), Medchal (M), R.R. (D), Telangana (S) - 501 401', N'HYDERABAD', 1, CAST(N'2019-04-07 10:03:46.823' AS DateTime))
GO
SET IDENTITY_INSERT [Master].[Warehouses] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__Warehous__1500E4C1CBCF7A09]    Script Date: 04/07/2019 10:38:38 AM ******/
ALTER TABLE [Master].[Warehouses] ADD UNIQUE NONCLUSTERED 
(
	[WarehouseLocationCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
