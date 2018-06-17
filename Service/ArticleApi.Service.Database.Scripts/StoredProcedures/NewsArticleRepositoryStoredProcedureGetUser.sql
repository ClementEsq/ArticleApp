USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[GetUser]    Script Date: 16/06/2018 16:38:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUser]
(
	@UserId INT
)
AS
BEGIN
	
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	SELECT TOP 1
		UserId,
		FirstName,
		LastName,
		IsPublisher,
		UserEmail
	FROM 
		[dbo].[View_User]
	WHERE 
		UserId = @UserId

END
GO


