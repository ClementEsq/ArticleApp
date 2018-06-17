USE [NewsArticleRepositoryDb]
GO

/****** Object:  Table [dbo].[User]    Script Date: 16/06/2018 16:52:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[IsPublisher] [bit] NULL
) ON [PRIMARY]
GO


