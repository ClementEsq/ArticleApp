USE [NewsArticleRepositoryDb]
GO

/****** Object:  Table [dbo].[Article]    Script Date: 16/06/2018 16:51:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Article](
	[ArticleId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Body] [nvarchar](max) NULL,
	[PublishDate] [datetime] NULL,
	[IsPublished] [bit] NULL,
	[CrDate] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


