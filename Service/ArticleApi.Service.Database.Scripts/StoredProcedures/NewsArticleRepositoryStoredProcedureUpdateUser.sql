USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 16/06/2018 16:38:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateUser]
(
	@UserId INT,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@IsPublisher BIT NULL,
	@UserEmail NVARCHAR(200),
	@Password NVARCHAR(100)
)
AS
BEGIN

	DECLARE @ReturnValue INT = 1

	IF(@IsPublisher IS NULL)
	BEGIN
		SET @IsPublisher = 0
	END

	-------

	UPDATE 
		[dbo].[User]
	SET
		FirstName = @FirstName,
		LastName = @LastName,
		IsPublisher = @IsPublisher
	WHERE
		UserId = @UserId

	-------
	
	IF(@@ERROR = 0)
	BEGIN
		SET @ReturnValue = 0
	END
	
	RETURN @ReturnValue
END
GO


