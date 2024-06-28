USE [db-shared]
GO

CREATE SCHEMA Security;
GO
  
CREATE FUNCTION Security.tvf_securitypredicate(@TenantId AS nvarchar(50))
    RETURNS TABLE
WITH SCHEMABINDING
AS
    RETURN SELECT 1 AS tvf_securitypredicate_result
    WHERE @TenantId = USER_NAME() OR USER_NAME() = 'dbo';
GO

USE [db-tenantc]
GO

CREATE SCHEMA Security;
GO
  
CREATE FUNCTION Security.tvf_securitypredicate(@TenantId AS nvarchar(50))
    RETURNS TABLE
WITH SCHEMABINDING
AS
    RETURN SELECT 1 AS tvf_securitypredicate_result
    WHERE @TenantId = USER_NAME() OR USER_NAME() = 'dbo';
GO
