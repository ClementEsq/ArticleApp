USE [NewsArticleRepositoryDb]
GO

/****** Object:  Table [dbo].[UserCredentials]    Script Date: 16/06/2018 16:52:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[UserCredentials](
	[UserId] [int] NOT NULL,
	[UserEmail] [nvarchar](200) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_UserCredentials] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[UserEmail] ASC,
	[Password] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


