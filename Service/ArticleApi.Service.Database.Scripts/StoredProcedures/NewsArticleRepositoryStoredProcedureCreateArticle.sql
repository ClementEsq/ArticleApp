USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[CreateArticle]    Script Date: 16/06/2018 16:38:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateArticle]
(
	@ArticleTitle NVARCHAR(200),
	@ArticleBody NVARCHAR(MAX),
	@IsPublished BIT NULL,
	@ArticleHeroImagePath VARCHAR(100) NULL,
	@ArticleBodyImagePath VARCHAR(100) NULL,
	@ArticleAuthorId INT
)
AS
BEGIN

	DECLARE @ReturnValue INT = 1

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	DECLARE @CurrentDateTimeStamp DATETIME = GETDATE()
	DECLARE @ArticleId INT
	DECLARE @BodyImageId INT
	DECLARE @HeroImageId INT
	DECLARE @PublishDate DATETIME = NULL

	DECLARE @BodyTypeId INT = (SELECT ImageTypeId FROM [dbo].[ImageType] WHERE [Type] = 'BODY')
	DECLARE @HeroTypeId INT = (SELECT ImageTypeId FROM [dbo].[ImageType] WHERE [Type] = 'HERO')

	DECLARE	@OutputDataArticle TABLE
	(
		ArticleId INT NULL
	)

	DECLARE	@OutputDataHeroImage TABLE
	(
		HeroImageId INT NULL
	)

	DECLARE	@OutputDataBodyImage	TABLE
	(
		BodyImageId INT NULL
	)

	IF(@IsPublished = NULL)
	BEGIN
		SET @IsPublished = 0
	END
	ELSE IF(@IsPublished = 1)
	BEGIN
		SET @PublishDate = @CurrentDateTimeStamp
	END

	-------

	INSERT INTO [dbo].[Article]
	(
		Title,
		Body,
		IsPublished,
		PublishDate,
		CrDate
	)
	OUTPUT 
		inserted.ArticleId
	INTO 
		@OutputDataArticle (ArticleId)
	Values
	(
		@ArticleTitle,
		@ArticleBody,
		@IsPublished,
		@PublishDate,
		@CurrentDateTimeStamp
	)
	
	SET @ArticleId = (SELECT TOP 1 ArticleId FROM @OutputDataArticle)

	IF(@ArticleId IS NOT NULL)
	BEGIN

		INSERT INTO [dbo].[UserArticle]
		(
			UserId,
			ArticleId
		)
		Values
		(
			@ArticleAuthorId,
			@ArticleId
		)

		-----

		IF(@ArticleHeroImagePath IS NOT NULL OR @ArticleHeroImagePath != '')
		BEGIN
			INSERT INTO [dbo].[Image]
			(
				ImagePath
			)
			OUTPUT 
				inserted.ImageId
			INTO 
				@OutputDataHeroImage (HeroImageId)
			Values
			(
				@ArticleHeroImagePath
			)

			SET @HeroImageId = (SELECT TOP 1 HeroImageId FROM @OutputDataHeroImage)

			IF(@HeroImageId IS NOT NULL)
			BEGIN
				INSERT INTO [dbo].[ArticleImage]
				(
					ImageId,
					ArticleId,
					ImageTypeId
				)
				Values
				(
					@HeroImageId,
					@ArticleId,
					@BodyTypeId
				)
			END
		END

		-----

		IF(@ArticleBodyImagePath IS NOT NULL OR @ArticleBodyImagePath != '')
		BEGIN
			INSERT INTO [dbo].[Image]
			(
				ImagePath
			)
			OUTPUT 
				inserted.ImageId
			INTO 
				@OutputDataBodyImage (BodyImageId)
			Values
			(
				@ArticleBodyImagePath
			)

			SET @BodyImageId = (SELECT TOP 1 BodyImageId FROM @OutputDataBodyImage)

			IF(@BodyImageId IS NOT NULL)
			BEGIN
				INSERT INTO [dbo].[ArticleImage]
				(
					ImageId,
					ArticleId,
					ImageTypeId
				)
				Values
				(
					@BodyImageId,
					@ArticleId,
					@HeroTypeId
				)
			END
		END
	END

	IF(@@ERROR = 0)
	BEGIN
		SET @ReturnValue = 0
	END
	
	RETURN @ReturnValue
END
GO


