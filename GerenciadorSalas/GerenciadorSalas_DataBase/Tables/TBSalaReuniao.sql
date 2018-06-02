CREATE TABLE [dbo].[TBSalaReuniao]
(
	[Id_reuniao] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QuantidadeLugar] INT NOT NULL, 
    [Usuario_id] INT NOT NULL, 
	CONSTRAINT [FK_usuario_reuniao] FOREIGN KEY ([Usuario_id]) REFERENCES TBUsuario(Id_usuario)
)
