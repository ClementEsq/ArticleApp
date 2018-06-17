USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[GetAllArticles]    Script Date: 16/06/2018 16:38:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllArticles]
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

END
GO


