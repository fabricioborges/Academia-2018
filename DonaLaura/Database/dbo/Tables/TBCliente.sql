CREATE TABLE [dbo].[TBCliente] (
    [Id_cliente]  INT           IDENTITY (1, 1) NOT NULL,
    [NomeCliente] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_cliente] ASC)
);

