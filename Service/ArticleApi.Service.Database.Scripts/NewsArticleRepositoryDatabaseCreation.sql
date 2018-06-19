:OUT $(DATABASE_CREATION_LOG)

SET NOCOUNT ON
GO

PRINT 'Attempting to create NewsArticleRepositoryDb database'

USE [master]
GO
/****** Object:  Database [NewRepository]    Script Date: 16/06/2018 16:18:36 ******/

:setvar IsDatabaseCreated 0

	IF NOT EXISTS (SELECT 1 FROM sys.databases d WHERE d.name = 'NewsArticleRepositoryDb')
	BEGIN
		CREATE DATABASE [NewsArticleRepositoryDb]
		 CONTAINMENT = NONE
		 ON  PRIMARY 
		( NAME = N'NewsArticleRepositoryDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\NewsArticleRepositoryDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
		 LOG ON 
		( NAME = N'NewsArticleRepositoryDb_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\NewsArticleRepositoryDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )

		:setvar IsDatabaseCreated 1
	END
	GO

--USE NewsArticleRepositoryDb
--GO

--:On Error exit

:r $(path)ArticleApi.Service.Database.Scripts\NewsArticleRepositoryDatabaseConfig.sql

PRINT 'Creating tables'

:r $(path)ArticleApi.Service.Database.Scripts\Tables\NewsArticleRepositoryTableArticle.sql
:r $(path)ArticleApi.Service.Database.Scripts\Tables\NewsArticleRepositoryTableImage.sql
:r $(path)ArticleApi.Service.Database.Scripts\Tables\NewsArticleRepositoryTableUser.sql
:r $(path)ArticleApi.Service.Database.Scripts\Tables\NewsArticleRepositoryTableUserArticle.sql
:r $(path)ArticleApi.Service.Database.Scripts\Tables\NewsArticleRepositoryTableUserCredentials.sql
:r $(path)ArticleApi.Service.Database.Scripts\Tables\NewsArticleRepositoryTableImageType.sql
:r $(path)ArticleApi.Service.Database.Scripts\Tables\NewsArticleRepositoryTableArticleImage.sql
:r $(path)ArticleApi.Service.Database.Scripts\Tables\NewsArticleRepositoryTableArticleLike.sql

PRINT 'Table creation complete'

PRINT 'Creating views'

:r $(path)ArticleApi.Service.Database.Scripts\Views\NewsArticleRepositoryViewArticle.sql
:r $(path)ArticleApi.Service.Database.Scripts\Views\NewsArticleRepositoryVIewUser.sql

PRINT 'View creation complete'

PRINT 'Creating stored procedures'

:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureGetUserByEmail.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureAddArticleLike.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureCreateArticle.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureCreateUser.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureDeleteArticle.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureGetAllArticleLikes.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureGetAllArticles.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureGetArticle.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureGetUser.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureRemoveArticleLike.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureUpdateArticle.sql
:r $(path)ArticleApi.Service.Database.Scripts\StoredProcedures\NewsArticleRepositoryStoredProcedureUpdateUser.sql

PRINT 'Stored procedure creation complete'



PRINT 'Inserting Seed Data'

:r $(path)ArticleApi.Service.Database.Scripts\SeedData\NewsArticleRepositoryImageType.sql

PRINT 'Seeding complete'


PRINT 'Creation is Completed'
GO