USE [master]
GO
CREATE LOGIN [tenanta] WITH PASSWORD=N'ten4ntA123$'
GO
CREATE USER [tenanta] FOR LOGIN [tenanta] WITH DEFAULT_SCHEMA=[dbo]
GO

USE [db-shared]
GO
CREATE USER tenanta FOR LOGIN tenanta WITH DEFAULT_SCHEMA = dbo
GO
EXEC sp_addrolemember N'db_owner', N'tenanta'
GO


USE [master]
GO
CREATE LOGIN [tenantb] WITH PASSWORD=N'ten4ntB123$'
GO
CREATE USER [tenantb] FOR LOGIN [tenantb] WITH DEFAULT_SCHEMA=[dbo]
GO

USE [db-shared]
GO
CREATE USER tenantb FOR LOGIN tenantb WITH DEFAULT_SCHEMA = dbo
GO
EXEC sp_addrolemember N'db_owner', N'tenantb'
GO


USE [master]
GO
CREATE LOGIN [tenantc] WITH PASSWORD=N'ten4ntC123$'
GO
CREATE USER [tenantc] FOR LOGIN [tenantc] WITH DEFAULT_SCHEMA=[dbo]
GO

USE [db-tenantc]
GO
CREATE USER tenantc FOR LOGIN tenantc WITH DEFAULT_SCHEMA = dbo
GO
EXEC sp_addrolemember N'db_owner', N'tenantc'
GO
