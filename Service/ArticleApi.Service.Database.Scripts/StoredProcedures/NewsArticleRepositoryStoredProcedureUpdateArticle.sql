USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[UpdateArticle]    Script Date: 16/06/2018 16:38:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateArticle]
(
	@ArticleId INT,
	@ArticleTitle NVARCHAR(200),
	@ArticleBody NVARCHAR(MAX),
	@IsPublished BIT NULL,
	@ArticleHeroImagePath VARCHAR(100) NULL,
	@ArticleBodyImagePath VARCHAR(100) NULL
)
AS
BEGIN
	
	DECLARE @ReturnValue INT = 1

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	DECLARE @CurrentDateTimeStamp DATETIME = GETDATE()
	DECLARE @PublishDate DATETIME = NULL

	DECLARE @HeroImageId INT = (SELECT ImageId FROM [dbo].ArticleImage WHERE ArticleId = @ArticleId AND ImageTypeId = (SELECT TOP 1 ImageTypeId FROM [dbo].[ImageType] WHERE [Type] = 'HERO'))
	DECLARE @BodyImageId INT = (SELECT ImageId FROM [dbo].ArticleImage WHERE ArticleId = @ArticleId AND ImageTypeId = (SELECT TOP 1 ImageTypeId FROM [dbo].[ImageType] WHERE [Type] = 'BODY'))

	IF(@IsPublished = NULL)
	BEGIN
		SET @IsPublished = 0
	END
	ELSE IF(@IsPublished = 1)
	BEGIN
		SET @PublishDate = @CurrentDateTimeStamp
	END

	-------

	UPDATE 
		[dbo].[Article] 
	SET 
		Title = @ArticleTitle, 
		Body = @ArticleBody,
		PublishDate = @PublishDate
	WHERE 
		ArticleId = @ArticleId

	-----

	UPDATE
		[dbo].[Image]
	SET
		ImagePath = @ArticleHeroImagePath
	WHERE 
		ImageId = @HeroImageId

	-----

	UPDATE
		[dbo].[Image]
	SET
		ImagePath = @ArticleHeroImagePath
	WHERE 
		ImageId = @BodyImageId

	
	IF(@@ERROR = 0)
	BEGIN
		SET @ReturnValue = 0
	END
	
	RETURN @ReturnValue
END
GO


