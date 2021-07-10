/****** Object:  StoredProcedure [dbo].[InsertFiger]    Script Date: 6/8/2019 13:33:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertFiger]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertFiger] AS' 
END
GO

ALTER proc  [dbo].[InsertFiger] (@ISOTemplate Image,@ANSITemplate image,@UserID int,@UserName varchar(500) )
as
begin
INSERT INTO [dbo].[FingerPrints]
           ([ISOTemplate]
           ,[ANSITemplate],
		   UserID,
		   UserName,Date
           )
     VALUES
           (@ISOTemplate,
          @ANSITemplate,
		    @UserID,
		   @UserName,
		   GETDATE()
           )
		   end 
GO
