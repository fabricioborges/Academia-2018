CREATE TABLE [dbo].[TBCliente_Venda] (
    [Id_cliente_venda] INT IDENTITY (1, 1) NOT NULL,
    [Cliente_id]       INT NULL,
    [Venda_id]         INT NULL,
    PRIMARY KEY CLUSTERED ([Id_cliente_venda] ASC),
    CONSTRAINT [FK_TBCliente] FOREIGN KEY ([Cliente_id]) REFERENCES [dbo].[TBCliente] ([Id_cliente]),
    CONSTRAINT [FK_TBVenda_cliente] FOREIGN KEY ([Venda_id]) REFERENCES [dbo].[TBVenda] ([Id_venda])
);

