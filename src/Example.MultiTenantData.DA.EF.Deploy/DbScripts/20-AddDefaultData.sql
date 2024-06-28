BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[exmt].[ReferenceEntity]'))
    SET IDENTITY_INSERT [exmt].[ReferenceEntity] ON;
INSERT INTO [exmt].[ReferenceEntity] ([Id], [Name])
VALUES ('1429f2ed-05ee-465c-a37a-e77537d98b21', N'Reference Item 2'),
('e065b699-0e9c-493a-80dd-c8efec0eb2ca', N'Reference Item 1');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name') AND [object_id] = OBJECT_ID(N'[exmt].[ReferenceEntity]'))
    SET IDENTITY_INSERT [exmt].[ReferenceEntity] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Name', N'ReferenceEntityId', N'TenantId') AND [object_id] = OBJECT_ID(N'[exmt].[SegregatedEntity]'))
    SET IDENTITY_INSERT [exmt].[SegregatedEntity] ON;
INSERT INTO [exmt].[SegregatedEntity] ([Id], [Date], [Name], [ReferenceEntityId], [TenantId])
VALUES ('361976b4-2542-49c6-988f-49de24b64ac9', '2024-01-01T00:00:00.0000000', N'Segregated Entity 4', '1429f2ed-05ee-465c-a37a-e77537d98b21', N'tenantc'),
('408ecb1e-fed7-4b37-977a-97f1709bb3f5', '2024-01-01T00:00:00.0000000', N'Segregated Entity 1', 'e065b699-0e9c-493a-80dd-c8efec0eb2ca', N'tenanta'),
('816d9651-cb1f-44d3-adb7-d8372451bbb7', '2024-01-01T00:00:00.0000000', N'Segregated Entity 2', '1429f2ed-05ee-465c-a37a-e77537d98b21', N'tenanta'),
('9d6bffc6-7afa-43f7-8d40-1fd8679fe046', '2024-01-01T00:00:00.0000000', N'Segregated Entity 3', 'e065b699-0e9c-493a-80dd-c8efec0eb2ca', N'tenantb');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Date', N'Name', N'ReferenceEntityId', N'TenantId') AND [object_id] = OBJECT_ID(N'[exmt].[SegregatedEntity]'))
    SET IDENTITY_INSERT [exmt].[SegregatedEntity] OFF;
GO

INSERT INTO [exmt].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240628145212_AddDefaultData', N'8.0.3');
GO

COMMIT;
GO

