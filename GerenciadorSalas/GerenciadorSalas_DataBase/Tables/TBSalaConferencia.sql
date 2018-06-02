CREATE TABLE [dbo].[TBSalaConferencia]
(
	[Id_conferencia] INT NOT NULL PRIMARY KEY IDENTITY, 
    [QuantidadeLugar] INT NOT NULL, 
    [Usuario_id] INT NOT NULL, 
	CONSTRAINT [FK_usuario_conferencia] FOREIGN KEY ([Usuario_id]) REFERENCES TBUsuario(Id_usuario)
	
)
