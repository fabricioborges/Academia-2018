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
	Quantidade INT NOT NULL,
	Lucro decimal not null
	
)

create table TBProduto_Venda(
	Id_produto_venda int identity(1,1) primary key,
	Produto_id INT,
	CONSTRAINT FK_TBProuto FOREIGN KEY (Produto_id) REFERENCES TBProduto(Id_produto), 
	Venda_id INT,
	CONSTRAINT FK_TBVenda FOREIGN KEY (Venda_id) REFERENCES TBProduto(Id_venda)
)

create table TBCliente_Venda(
	Id_cliente_venda int identity(1,1) primary key,
	Cliente_id INT,
	CONSTRAINT FK_TBCliente FOREIGN KEY (Cliente_id) REFERENCES TBCliente(Id_cliente), 
	Venda_id INT,
	CONSTRAINT FK_TBVenda_cliente FOREIGN KEY (Venda_id) REFERENCES TBVenda(Id_venda)
)

select * from TBCliente_Venda