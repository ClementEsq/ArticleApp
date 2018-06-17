USE [NewsArticleRepositoryDb]
GO

/****** Object:  Table [dbo].[ArticleImage]    Script Date: 16/06/2018 16:51:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ArticleImage](
	[ArticleId] [int] NOT NULL,
	[ImageId] [int] NOT NULL,
	[ImageTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ArticleImage] PRIMARY KEY CLUSTERED 
(
	[ArticleId] ASC,
	[ImageId] ASC,
	[ImageTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


