IF OBJECT_ID(N'[exmt].[__EFMigrationsHistory]') IS NULL
BEGIN
    IF SCHEMA_ID(N'exmt') IS NULL EXEC(N'CREATE SCHEMA [exmt];');
    CREATE TABLE [exmt].[__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF SCHEMA_ID(N'exmt') IS NULL EXEC(N'CREATE SCHEMA [exmt];');
GO

CREATE TABLE [exmt].[ReferenceEntity] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_ReferenceEntity] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [exmt].[SegregatedEntity] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Date] datetime2 NOT NULL,
    [ReferenceEntityId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_SegregatedEntity] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SegregatedEntity_ReferenceEntity_ReferenceEntityId] FOREIGN KEY ([ReferenceEntityId]) REFERENCES [exmt].[ReferenceEntity] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_SegregatedEntity_ReferenceEntityId] ON [exmt].[SegregatedEntity] ([ReferenceEntityId]);
GO

INSERT INTO [exmt].[__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240628140724_InitialCreate', N'8.0.3');
GO

COMMIT;
GO

