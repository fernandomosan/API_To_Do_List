IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Tb_Tarefa] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] Varchar(max) NOT NULL,
    [Descricao] Varchar(max) NULL,
    [DataCriacao] Datetime NULL,
    [DataFinalizacao] Datetime NULL,
    [StatusTarefa] int NOT NULL,
    CONSTRAINT [PK_Tb_Tarefa] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240328191333_inicial', N'6.0.28');
GO

COMMIT;
GO

