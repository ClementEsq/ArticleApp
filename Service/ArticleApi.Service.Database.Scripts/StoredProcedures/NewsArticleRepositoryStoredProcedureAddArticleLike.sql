USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[AddArticleLike]    Script Date: 16/06/2018 16:37:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddArticleLike]
(
	@ArticleId INT,
	@UserId INT
)
AS
BEGIN
	
	DECLARE @ReturnValue INT = 1

	-------

	INSERT INTO [dbo].[ArticleLike]
	(
		ArticleId,
		UserId,
		CrDate
	)
	Values
	(
		@ArticleId,
		@UserId,
		GetDate()
	)

	------

	
	IF(@@ERROR = 0)
	BEGIN
		SET @ReturnValue = 0
	END
	
	RETURN @ReturnValue
END
GO


