﻿CREATE TABLE [dbo].[TB_Emprestimos]
(
	[Id_emprestimo] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Cliente] VARCHAR(150) NOT NULL, 
    [DataDevolucao] DATETIME NOT NULL, 
    [Cliente_id] INT NOT NULL,
	CONSTRAINT [FK_livro_emprestimo] FOREIGN KEY (Cliente_id) REFERENCES TB_Livros(Id_livro)
)
