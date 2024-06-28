BEGIN TRANSACTION;
GO

ALTER TABLE [exmt].[SegregatedEntity] ADD [TenantId] nvarchar(50) NOT NULL DEFAULT N'';
GO

CREATE SECURITY POLICY [exmt].[TenantSegregatedEntityFilter]
ADD FILTER PREDICATE Security.tvf_securitypredicate(TenantId)
ON [exmt].[SegregatedEntity]
WITH (STATE = ON);
GO

INSERT INTO [exmt].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240628140937_AddMultiTenancy', N'8.0.3');
GO

COMMIT;
GO

