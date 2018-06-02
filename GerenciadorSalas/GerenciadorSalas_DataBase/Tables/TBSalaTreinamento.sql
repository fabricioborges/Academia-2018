CREATE TABLE [dbo].[TBSalaTreinamento]
(
	[Id_treinamento] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QuantidadeLugar] INT NOT NULL, 
    [Usuario_id] INT NOT NULL, 
	[Data_ocupada] DATETIME NOT NULL, 
    CONSTRAINT [FK_usuario_treinamento] FOREIGN KEY ([Usuario_id]) REFERENCES TBUsuario(Id_usuario)
)
