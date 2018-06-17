USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[RemoveArticleLike]    Script Date: 16/06/2018 16:38:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RemoveArticleLike]
(
	@ArticleId INT,
	@UserId INT
)
AS
BEGIN
	
	DECLARE @ReturnValue INT = 1

	-------

	DELETE 
		[dbo].[ArticleLike]
	WHERE
		ArticleId = @ArticleId
	AND
		UserId = @UserId

	------
	
	IF(@@ERROR = 0)
	BEGIN
		SET @ReturnValue = 0
	END
	
	RETURN @ReturnValue
END
GO


