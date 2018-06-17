USE [NewsArticleRepositoryDb]
GO

/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 16/06/2018 16:38:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateUser]
(
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@IsPublisher BIT NULL,
	@UserEmail NVARCHAR(200),
	@Password NVARCHAR(100)
)
AS
BEGIN

	DECLARE @ReturnValue INT = 1
	DECLARE @UserId INT

	DECLARE	@OutputDataUser TABLE
	(
		UserId INT NULL
	)

	IF(@IsPublisher IS NULL)
	BEGIN
		SET @IsPublisher = 0
	END

	-------

	INSERT INTO [dbo].[User]
	(
		FirstName,
		LastName,
		IsPublisher
	)
	OUTPUT 
		inserted.UserId
	INTO 
		@OutputDataUser (UserId)
	Values
	(
		@FirstName,
		@LastName,
		@IsPublisher
	)

	--------

	SET @UserId = (SELECT TOP 1 UserId FROM @OutputDataUser)

	IF(@UserId IS NOT NULL)
	BEGIN

		INSERT INTO [dbo].[UserCredentials]
		(
			UserId,
			UserEmail,
			Password
		)
		Values
		(
			@UserId,
			@UserEmail,
			@Password
		)
	END
	
	IF(@@ERROR = 0)
	BEGIN
		SET @ReturnValue = 0
	END
	
	RETURN @ReturnValue
END

GO


