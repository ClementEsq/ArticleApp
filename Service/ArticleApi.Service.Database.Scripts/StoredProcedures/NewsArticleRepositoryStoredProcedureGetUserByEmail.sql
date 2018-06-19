USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[GetUserByEmail]    Script Date: 18/06/2018 02:37:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetUserByEmail]
(
	@EmailAddress NVARCHAR(200)
)
AS
BEGIN
	
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	SELECT TOP 1
		vu.UserId,
		vu.FirstName,
		vu.LastName,
		vu.IsPublisher,
		vu.UserEmail,
		uc.[Password]
	FROM 
		[dbo].[View_User] vu
	INNER JOIN
		[dbo].[UserCredentials] uc
	ON
		vu.UserId = uc.UserId
	WHERE 
		vu.UserEmail = @EmailAddress

END
GO


