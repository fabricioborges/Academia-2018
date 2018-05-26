CREATE TABLE [dbo].[TB_Livros]
(
	[Id_livro] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Titulo] VARCHAR(150) NOT NULL, 
    [Autor] VARCHAR(150) NOT NULL, 
    [Volume] INT NOT NULL, 
    [DataPublicacao] DATETIME NOT NULL, 
    [Disponibilidade] BIT NOT NULL
)
