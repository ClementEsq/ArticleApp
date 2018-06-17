USE [NewsArticleRepositoryDb]
GO

/****** Object:  Table [dbo].[Image]    Script Date: 16/06/2018 16:52:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Image](
	[ImageId] [int] IDENTITY(1,1) NOT NULL,
	[ImagePath] [varchar](100) NULL
) ON [PRIMARY]
GO


