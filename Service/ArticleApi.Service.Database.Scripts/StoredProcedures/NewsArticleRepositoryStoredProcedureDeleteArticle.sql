USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[DeleteArticle]    Script Date: 16/06/2018 16:38:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteArticle]
(
	@ArticleId INT
)
AS
BEGIN
	DECLARE @ReturnValue INT = 1

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	DECLARE @HeroImageId INT = (SELECT ImageId FROM [dbo].ArticleImage WHERE ArticleId = @ArticleId AND ImageTypeId = (SELECT TOP 1 ImageTypeId FROM [dbo].[ImageType] WHERE [Type] = 'HERO'))
	DECLARE @BodyImageId INT = (SELECT ImageId FROM [dbo].ArticleImage WHERE ArticleId = @ArticleId AND ImageTypeId = (SELECT TOP 1 ImageTypeId FROM [dbo].[ImageType] WHERE [Type] = 'BODY'))

	-----

	DELETE
		[dbo].[Image]
	WHERE 
		ImageId = @HeroImageId

	-----

	DELETE
		[dbo].[Image]
	WHERE 
		ImageId = @BodyImageId

	-----

	DELETE
		[dbo].[ArticleImage]
	WHERE 
		ArticleId = @ArticleId

	-----

	DELETE
		[dbo].[UserArticle]
	WHERE 
		ArticleId = @ArticleId

	------

	DELETE 
		[dbo].[Article] 
	WHERE 
		ArticleId = @ArticleId


	IF(@@ERROR = 0)
	BEGIN
		SET @ReturnValue = 0
	END
	
	RETURN @ReturnValue
END
GO


