USE [NewsArticleRepositoryDb]
GO

/****** Object:  Table [dbo].[UserArticle]    Script Date: 16/06/2018 16:52:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserArticle](
	[UserId] [int] NOT NULL,
	[ArticleId] [int] NOT NULL,
 CONSTRAINT [PK_UserArticle] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[ArticleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


