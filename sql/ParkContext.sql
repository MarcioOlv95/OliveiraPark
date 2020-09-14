IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [TbAvulsos] (
    [Id] uniqueidentifier NOT NULL,
    [Placa] varchar(10) NOT NULL,
    [HrEntrada] datetime2 NOT NULL,
    [HrSaida] datetime2 NOT NULL,
    [PrecoFinal] float NOT NULL,
	[DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_TbAvulsos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TbMensais] (
    [Id] uniqueidentifier NOT NULL,
    [ValidadeContrato] datetime2 NOT NULL,
    [ValorPrecoMensal] float NOT NULL,
    [DataPagamento] datetime2 NOT NULL,
    [ValorMulta] float NOT NULL,
	[DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_TbMensais] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TbPrecos] (
    [Id] uniqueidentifier NOT NULL,
    [NomeTipoPreco] varchar(100) NOT NULL,
    [Valor] float NOT NULL,
    [Descricao] varchar(100) NULL,
	[DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_TbPrecos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [TbCarros] (
    [Id] uniqueidentifier NOT NULL,
    [MensalId] uniqueidentifier NOT NULL,
    [Modelo] varchar(100) NOT NULL,
    [Placa] varchar(10) NOT NULL,
    [Cor] nvarchar(max) NULL,
    [TipoVeiculo] int NOT NULL,
    [Tamanho] nvarchar(max) NULL,
	[DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_TbCarros] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TbCarros_TbMensais_MensalId] FOREIGN KEY ([MensalId]) REFERENCES [TbMensais] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [TbClientes] (
    [Id] uniqueidentifier NOT NULL,
    [MensalId] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Endereco] varchar(100) NOT NULL,
    [Cpf] varchar(15) NOT NULL,
	[DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_TbClientes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TbClientes_TbMensais_MensalId] FOREIGN KEY ([MensalId]) REFERENCES [TbMensais] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [TbPagamentos] (
    [Id] uniqueidentifier NOT NULL,
    [MensalId] uniqueidentifier NOT NULL,
    [MesPagamento] int NOT NULL,
    [PagamentoRealizado] bit NOT NULL,
	[DataCadastro] datetime2 NOT NULL,
    [DataAlteracao] datetime2 NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_TbPagamentos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_TbPagamentos_TbMensais_MensalId] FOREIGN KEY ([MensalId]) REFERENCES [TbMensais] ([Id]) ON DELETE NO ACTION
);

GO

CREATE UNIQUE INDEX [IX_TbCarros_MensalId] ON [TbCarros] ([MensalId]);

GO

CREATE UNIQUE INDEX [IX_TbClientes_MensalId] ON [TbClientes] ([MensalId]);

GO

CREATE INDEX [IX_TbPagamentos_MensalId] ON [TbPagamentos] ([MensalId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200521231400_Initial', N'3.1.4');

GO

