CREATE TABLE [dbo].[TBProduto] (
    [Id_produto]      INT           IDENTITY (1, 1) NOT NULL,
    [Nome]            VARCHAR (250) NOT NULL,
    [PrecoCusto]      DECIMAL (18)  NOT NULL,
    [PrecoVenda]      DECIMAL (18)  NOT NULL,
    [DataFabricacao]  DATETIME      NOT NULL,
    [DataValidade]    DATETIME      NOT NULL,
    [Disponibilidade] BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id_produto] ASC)
);

