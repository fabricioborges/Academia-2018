CREATE TABLE [dbo].[TBVenda] (
    [Id_venda]   INT          IDENTITY (1, 1) NOT NULL,
    [Quantidade] INT          NOT NULL,
    [Lucro]      DECIMAL (18) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_venda] ASC)
);

