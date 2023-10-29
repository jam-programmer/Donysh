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
-------------------------------------------------------------
-------------------------------------------------------------
-------------------------------------------------------------
-------------------------------------------------------------
-------------------------------------------------------------
-------------------------------------------------------------
-------------------------------------------------------------



