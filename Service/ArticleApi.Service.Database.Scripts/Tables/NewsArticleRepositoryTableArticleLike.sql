USE [NewsArticleRepositoryDb]
GO

/****** Object:  Table [dbo].[ArticleLike]    Script Date: 16/06/2018 16:52:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticleLike](
	[ArticleLikeId] [int] IDENTITY(1,1) NOT NULL,
	[ArticleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[CrDate] [datetime] NULL,
 CONSTRAINT [PK_ArticleLike] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


