--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
---- =============================================
---- Author:		<JAM_PROGRAMMER>
---- Create date: <2023-10-10>
---- RUN:         EXEC [dbo].[SP_GetScopes]
---- =============================================
--CREATE OR ALTER PROCEDURE [dbo].[SP_GetScopes]
--   @page INT=1,@pageSize INT =10,@search NVARCHAR(300)='',@delete BIT=0
--AS
--BEGIN
--  SET @page=(@page -1) * @pageSize 
--	DECLARE @SQL NVARCHAR(2000)
--	SET @SQL=' SELECT * FROM DY.ScopeWork AS S WITH(NOLOCK) WHERE'

--	    IF @delete=1
--			SET @SQL+= ' S.IsDeleted=1 '
--		ELSE
--			SET @SQL+= ' S.IsDeleted=0 '

--		IF @search IS NOT NULL AND @search <> ''
--			SET @SQL= @SQL + ' AND S.Title LIKE N''%' + @search + '%'' '
        
--		SET @SQL= @SQL + ' ORDER BY S.CreateTime '
--		SET @SQL= @SQL + ' OFFSET '+ CAST(@page AS NVARCHAR(10)) + ' ROWS FETCH NEXT '+ CAST(@pageSize AS NVARCHAR(10)) +' ROWS ONLY  '

--EXEC sp_executesql @SQL
----PRINT @SQL
--END
--GO
-------------------------------------------------------------
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
---- =============================================
---- Author:		<JAM_PROGRAMMER>
---- Create date: <2023-10-10>
---- RUN:         EXEC [dbo].[SP_GetCompanies]
---- =============================================
--CREATE OR ALTER PROCEDURE [dbo].[SP_GetCompanies]
--   @page INT=1,@pageSize INT =10,@search NVARCHAR(300)='',@delete BIT=0
--AS
--BEGIN
--  SET @page=(@page -1) * @pageSize 
--	DECLARE @SQL NVARCHAR(2000)
--	SET @SQL=' SELECT * FROM DY.Company AS C WITH(NOLOCK) WHERE'

--	    IF @delete=1
--			SET @SQL+= ' C.IsDeleted=1 '
--		ELSE
--			SET @SQL+= ' C.IsDeleted=0 '

--		IF @search IS NOT NULL AND @search <> ''
--			SET @SQL= @SQL + ' AND C.[Name] LIKE N''%' + @search + '%'' '
        
--		SET @SQL= @SQL + ' ORDER BY C.CreateTime '
--		SET @SQL= @SQL + ' OFFSET '+ CAST(@page AS NVARCHAR(10)) + ' ROWS FETCH NEXT '+ CAST(@pageSize AS NVARCHAR(10)) +' ROWS ONLY  '

--EXEC sp_executesql @SQL
----PRINT @SQL
--END
--GO

-------------------------------------------------------------
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
---- =============================================
---- Author:		<JAM_PROGRAMMER>
---- Create date: <2023-10-10>
---- RUN:         EXEC [dbo].[SP_GetService]
---- =============================================
--CREATE OR ALTER PROCEDURE [dbo].[SP_GetService]
--   @page INT=1,@pageSize INT =10,@search NVARCHAR(300)='',@delete BIT=0
--AS
--BEGIN
--  SET @page=(@page -1) * @pageSize 
--	DECLARE @SQL NVARCHAR(2000)
--	SET @SQL=' SELECT * FROM DY.Service AS S WITH(NOLOCK) WHERE'

--	    IF @delete=1
--			SET @SQL+= ' S.IsDeleted=1 '
--		ELSE
--			SET @SQL+= ' S.IsDeleted=0 '

--		IF @search IS NOT NULL AND @search <> ''
--			SET @SQL= @SQL + ' AND S.Title LIKE N''%' + @search + '%'' '
        
--		SET @SQL= @SQL + ' ORDER BY S.CreateTime '
--		SET @SQL= @SQL + ' OFFSET '+ CAST(@page AS NVARCHAR(10)) + ' ROWS FETCH NEXT '+ CAST(@pageSize AS NVARCHAR(10)) +' ROWS ONLY  '

--EXEC sp_executesql @SQL
----PRINT @SQL
--END
--GO


-------------------------------------------------------------
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO 
---- =============================================
---- Author:		<JAM_PROGRAMMER>
---- Create date: <2023-10-10>
---- RUN:         EXEC [dbo].[SP_GetStatuses]
---- =============================================
--CREATE OR ALTER PROCEDURE [dbo].[SP_GetStatuses]
--   @page INT=1,@pageSize INT =10,@search NVARCHAR(300)='',@delete BIT=0
--AS
--BEGIN
--  SET @page=(@page -1) * @pageSize 
--	DECLARE @SQL NVARCHAR(2000)
--	SET @SQL=' SELECT * FROM DY.Status AS S WITH(NOLOCK) WHERE'

--	    IF @delete=1
--			SET @SQL+= ' S.IsDeleted=1 '
--		ELSE
--			SET @SQL+= ' S.IsDeleted=0 '

--		IF @search IS NOT NULL AND @search <> ''
--			SET @SQL= @SQL + ' AND S.Status LIKE N''%' + @search + '%'' '
        
--		SET @SQL= @SQL + ' ORDER BY S.CreateTime '
--		SET @SQL= @SQL + ' OFFSET '+ CAST(@page AS NVARCHAR(10)) + ' ROWS FETCH NEXT '+ CAST(@pageSize AS NVARCHAR(10)) +' ROWS ONLY  '

--EXEC sp_executesql @SQL
----PRINT @SQL
--END
--GO


-------------------------------------------------------------
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO 
---- =============================================
---- Author:		<JAM_PROGRAMMER>
---- Create date: <2023-10-10>
---- RUN:         EXEC [dbo].[SP_GetTeams]
---- =============================================
--CREATE OR ALTER PROCEDURE [dbo].[SP_GetTeams]
--   @page INT=1,@pageSize INT =10,@search NVARCHAR(300)='',@delete BIT=0
--AS
--BEGIN
--  SET @page=(@page -1) * @pageSize 
--	DECLARE @SQL NVARCHAR(2000)
--	SET @SQL=' SELECT * FROM DY.Team AS T WITH(NOLOCK) WHERE'

--	    IF @delete=1
--			SET @SQL+= ' T.IsDeleted=1 '
--		ELSE
--			SET @SQL+= ' T.IsDeleted=0 '

--		IF @search IS NOT NULL AND @search <> ''
--			SET @SQL= @SQL + ' AND T.FullName LIKE N''%' + @search + '%'' '
        
--		SET @SQL= @SQL + ' ORDER BY T.CreateTime '
--		SET @SQL= @SQL + ' OFFSET '+ CAST(@page AS NVARCHAR(10)) + ' ROWS FETCH NEXT '+ CAST(@pageSize AS NVARCHAR(10)) +' ROWS ONLY  '

--EXEC sp_executesql @SQL
----PRINT @SQL
--END
--GO


-------------------------------------------------------------
--USE [DonyshDB]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_GetLastProject]    Script Date: 26/08/1402 10:15:10 ق.ظ ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
---- =============================================
---- Author:		<JAM_PROGRAMMER>
---- Create date: <2023-10-10>
---- RUN:         EXEC [dbo].[SP_GetLastProject]
---- =============================================
--ALTER   PROCEDURE [dbo].[SP_GetLastProject]
	
--AS
--BEGIN
--CREATE TABLE #LastProject(
--    [Id] [nvarchar](450) NOT NULL,
--	[ProjectName] [nvarchar](300) NOT NULL,
--	[ProjectImage] [nvarchar](max) NULL,
--	ServiceId NVARCHAR(500)  NULL,
--	[ServiceTitle] [nvarchar](max) NULL
--)
--INSERT INTO #LastProject
--(Id,
--[ProjectName] ,
--[ProjectImage]
--)

--SELECT TOP(15) Id,
--[ProjectName] ,
--[ProjectImage]
-- FROM DY.Project AS P WITH(NOLOCK) ORDER BY P.CreateTime DESC

--UPDATE #LastProject
--SET ServiceId = PS.ServiceId, ServiceTitle = S.Title
--FROM #LastProject AS LP
--INNER JOIN (
--    SELECT ProjectsId, MAX(ServiceId) AS ServiceId
--    FROM DY.ProjectEntityServiceEntity WITH(NOLOCK)
--    GROUP BY ProjectsId
--) AS PS ON LP.Id = PS.ProjectsId
--INNER JOIN DY.[Service] AS S WITH(NOLOCK) ON PS.ServiceId = S.Id;

--SELECT * FROM #LastProject

--DROP TABLE #LastProject
--END

-------------------------------------------------------------
-------------------------------------------------------------
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
---- =============================================
---- Author:		<JAM_PROGRAMMER>
---- Create date: <2023-10-10>
---- RUN:         EXEC [dbo].[SP_GetContact]
---- =============================================
--CREATE OR ALTER PROCEDURE SP_GetContact
--	 @page INT=1,@pageSize INT =10,@search NVARCHAR(300)='',@delete BIT=0
--AS
--BEGIN
--  SET @page=(@page -1) * @pageSize 
--	DECLARE @SQL NVARCHAR(2000)
--	SET @SQL=' SELECT * FROM DY.Contact AS C WITH(NOLOCK) WHERE'

--	    IF @delete=1
--			SET @SQL+= ' C.IsDeleted=1 '
--		ELSE
--			SET @SQL+= ' C.IsDeleted=0 '

--		IF @search IS NOT NULL AND @search <> ''
--			SET @SQL= @SQL + ' AND C.FullName LIKE N''%' + @search + '%'' '
        
--		SET @SQL= @SQL + ' ORDER BY C.CreateTime '
--		SET @SQL= @SQL + ' OFFSET '+ CAST(@page AS NVARCHAR(10)) + ' ROWS FETCH NEXT '+ CAST(@pageSize AS NVARCHAR(10)) +' ROWS ONLY  '

--EXEC sp_executesql @SQL
----PRINT @SQL
--END
--GO


-------------------------------------------------------------
---------------------------------------------------------------
--USE [DonyshDB]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_GetRequest]    Script Date: 30/08/1402 08:50:08 ب.ظ ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
---- =============================================
---- Author:		<JAM_PROGRAMMER>
---- Create date: <2023-10-10>
---- RUN:         EXEC [dbo].[SP_GetRequest]
---- =============================================
--ALTER   PROCEDURE [dbo].[SP_GetRequest]
--	 @page INT=1,@pageSize INT =10,@search NVARCHAR(300)='',@delete BIT=0
--AS
--BEGIN
--  SET @page=(@page -1) * @pageSize 
--	DECLARE @SQL NVARCHAR(2000)
--	SET @SQL=' SELECT * FROM DY.Request AS R WITH(NOLOCK) WHERE'

--	    IF @delete=1
--			SET @SQL+= ' R.IsDeleted=1 '
--		ELSE
--			SET @SQL+= ' R.IsDeleted=0 '

--		IF @search IS NOT NULL AND @search <> ''
--			SET @SQL= @SQL + ' AND R.Email LIKE N''%' + @search + '%'' '
        
--		SET @SQL= @SQL + ' ORDER BY R.CreateTime '
--		SET @SQL= @SQL + ' OFFSET '+ CAST(@page AS NVARCHAR(10)) + ' ROWS FETCH NEXT '+ CAST(@pageSize AS NVARCHAR(10)) +' ROWS ONLY  '

--EXEC sp_executesql @SQL
----PRINT @SQL
--END

---------------------------------------------------------------
---------------------------------------------------------------
---------------------------------------------------------------

--USE [DonyshDB]
--GO
--/****** Object:  StoredProcedure [dbo].[SP_GetLastProject]    Script Date: 27/08/1402 08:49:52 ب.ظ ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
---- =============================================
---- Author:		<JAM_PROGRAMMER>
---- Create date: <2023-10-10>
---- RUN:         EXEC [dbo].[SP_GetLastProject] 0
---- =============================================
--ALTER   PROCEDURE [dbo].[SP_GetLastProject] 
--	@Home Bit =1
--AS
--BEGIN

--DECLARE @SQL NVARCHAR(900)

--SET @SQL='
--CREATE TABLE #LastProject(
--    [Id] [nvarchar](450) NOT NULL,
--	[ProjectName] [nvarchar](300) NOT NULL,
--	[ProjectImage] [nvarchar](max) NULL,
--	ServiceId NVARCHAR(500)  NULL,
--	[ServiceTitle] [nvarchar](max) NULL
--)
--INSERT INTO #LastProject
--(Id,
--[ProjectName] ,
--[ProjectImage]
--)'

	
	
--IF @Home=1
--   SET @SQL+='SELECT TOP(15) Id,
--	[ProjectName] ,
--	[ProjectImage]
--	 FROM DY.Project AS P WITH(NOLOCK) ORDER BY P.CreateTime DESC'
--ELSE
--  SET @SQL+='SELECT  Id,
--	[ProjectName] ,
--	[ProjectImage]
--	 FROM DY.Project AS P WITH(NOLOCK) ORDER BY P.CreateTime DESC'





--SET @SQL+='
--UPDATE #LastProject
--SET ServiceId = PS.ServiceId, ServiceTitle = S.Title
--FROM #LastProject AS LP
--INNER JOIN (
--    SELECT ProjectsId, MAX(ServiceId) AS ServiceId
--    FROM DY.ProjectEntityServiceEntity WITH(NOLOCK)
--    GROUP BY ProjectsId
--) AS PS ON LP.Id = PS.ProjectsId
--INNER JOIN DY.[Service] AS S WITH(NOLOCK) ON PS.ServiceId = S.Id;

--SELECT * FROM #LastProject

--DROP TABLE #LastProject'
--EXEC sp_executesql @SQL
--END


