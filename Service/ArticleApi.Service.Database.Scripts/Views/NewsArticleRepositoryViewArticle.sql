USE [NewsArticleRepositoryDb]
GO

/****** Object:  View [dbo].[View_Article]    Script Date: 16/06/2018 16:48:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[View_Article]
AS
SELECT        dbo.Article.ArticleId, dbo.Article.Title, dbo.Article.Body, dbo.Article.PublishDate, dbo.Article.IsPublished, dbo.Article.CrDate, dbo.[User].FirstName AS AuthorFirstName, dbo.[User].LastName AS AuthorLastName,
                             (SELECT        TOP (1) I.ImagePath
                               FROM            dbo.ArticleImage AS AI INNER JOIN
                                                         dbo.Image AS I ON I.ImageId = AI.ImageId
                               WHERE        (AI.ArticleId = dbo.Article.ArticleId) AND (AI.ImageTypeId =
                                                             (SELECT        TOP (1) ImageTypeId
                                                               FROM            dbo.ImageType
                                                               WHERE        (Type = 'HERO')))) AS HeroImagePath,
                             (SELECT        TOP (1) I.ImagePath
                               FROM            dbo.ArticleImage AS AI INNER JOIN
                                                         dbo.Image AS I ON I.ImageId = AI.ImageId
                               WHERE        (AI.ArticleId = dbo.Article.ArticleId) AND (AI.ImageTypeId =
                                                             (SELECT        TOP (1) ImageTypeId
                                                               FROM            dbo.ImageType AS ImageType_1
                                                               WHERE        (Type = 'BODY')))) AS BodyImagePath,
                             (SELECT        COUNT(*) AS Expr1
                               FROM            dbo.ArticleLike AS AL
                               WHERE        (ArticleId = dbo.Article.ArticleId)) AS ArticleLikeCount
FROM            dbo.Article INNER JOIN
                         dbo.ArticleImage ON dbo.Article.ArticleId = dbo.ArticleImage.ArticleId INNER JOIN
                         dbo.UserArticle ON dbo.Article.ArticleId = dbo.UserArticle.ArticleId INNER JOIN
                         dbo.[User] ON dbo.UserArticle.UserId = dbo.[User].UserId
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Article"
            Begin Extent = 
               Top = 103
               Left = 495
               Bottom = 288
               Right = 665
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ArticleImage"
            Begin Extent = 
               Top = 74
               Left = 106
               Bottom = 187
               Right = 276
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserArticle"
            Begin Extent = 
               Top = 7
               Left = 731
               Bottom = 107
               Right = 901
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "User"
            Begin Extent = 
               Top = 192
               Left = 38
               Bottom = 322
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Article'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Article'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'View_Article'
GO


