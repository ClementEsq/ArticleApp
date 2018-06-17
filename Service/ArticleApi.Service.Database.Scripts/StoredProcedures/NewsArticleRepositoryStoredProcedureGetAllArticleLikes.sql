USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[GetAllArticleLikes]    Script Date: 16/06/2018 16:38:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllArticleLikes]
(
	@ArticleId INT
)
AS
BEGIN
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	-------

	SELECT 
		ArticleLikeId,
		CrDate
	FROM
		[dbo].[ArticleLike]
	WHERE
		ArticleId = @ArticleId
	
END
GO


