use DonaLaura

Create table TBProduto(
	Id_produto int identity (1,1) primary key,
	Nome VARCHAR(250) NOT NULL,
	PrecoCusto decimal not null,
	PrecoVenda decimal not null,
	DataFabricacao datetime not null,
	DataValidade datetime not null,
	Disponibilidade bit not null default 0


)


create table TBCliente(
	Id_cliente int identity (1,1) primary key,
	NomeCliente varchar(250) not null

)

CREATE TABLE TBVenda(
	Id_venda int identity(1,1) primary key,
	Produto_Id int,
	CONSTRAINT FK_Produto FOREIGN KEY (Produto_Id) references TBProduto(Id_produto),
	Quantidade INT NOT NULL,
	Cliente_Id INT,
	CONSTRAINT FK_Cliente FOREIGN KEY (Cliente_Id) references TBCliente(Id_cliente),
	Lucro decimal not null
	
)

select * from TBVenda