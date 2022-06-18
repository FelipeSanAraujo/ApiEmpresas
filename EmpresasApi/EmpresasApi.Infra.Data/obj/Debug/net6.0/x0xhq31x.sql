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

CREATE TABLE [EMPRESA] (
    [IDEMPRESA] uniqueidentifier NOT NULL,
    [NOMEFANTASIA] nvarchar(150) NOT NULL,
    [RAZAOSOCIAL] nvarchar(150) NOT NULL,
    [CNPJ] nvarchar(25) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    [DataUltimaAlteracao] datetime2 NOT NULL,
    CONSTRAINT [PK_EMPRESA] PRIMARY KEY ([IDEMPRESA])
);
GO

CREATE TABLE [USUARIO] (
    [IDUSUARIO] uniqueidentifier NOT NULL,
    [NOME] nvarchar(150) NOT NULL,
    [LOGIN] nvarchar(100) NOT NULL,
    [SENHA] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_USUARIO] PRIMARY KEY ([IDUSUARIO])
);
GO

CREATE UNIQUE INDEX [IX_EMPRESA_CNPJ] ON [EMPRESA] ([CNPJ]);
GO

CREATE UNIQUE INDEX [IX_USUARIO_LOGIN] ON [USUARIO] ([LOGIN]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220419004526_Initial', N'6.0.4');
GO

COMMIT;
GO

