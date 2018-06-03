CREATE TABLE [dbo].[TBSala]
(
	[Id_sala] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome_sala] VARCHAR(50) NOT NULL, 
    [Quantidade_lugar] VARCHAR(50) NOT NULL, 
    [Data_inicio] DATETIME NOT NULL, 
    [Data_final] DATETIME NOT NULL, 
    [Usuario_id] INT NOT NULL,
	CONSTRAINT [FK_usuario] FOREIGN KEY ([Usuario_id]) REFERENCES TBUsuario(Id_usuario)
)
