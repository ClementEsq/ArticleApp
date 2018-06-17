USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[GetArticle]    Script Date: 16/06/2018 16:38:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetArticle]
(
	@ArticleId INT
)
AS
BEGIN

	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	SELECT 
		ArticleId,
		Title,
		Body,
		IsPublished,
		PublishDate,
		CrDate,
		AuthorFirstName,
		AuthorLastName,
		HeroImagePath,
		BodyImagePath,
		ArticleLikeCount
	FROM 
		[dbo].[View_Article]
	WHERE
		ArticleId = @ArticleId
END
GO


