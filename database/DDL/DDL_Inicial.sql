CREATE DATABASE Desafio
GO

USE Desafio
GO

CREATE TABLE dbo.Segmento(
	IdSegmento SMALLINT NOT NULL,
	DsSegmento VARCHAR(20) NOT NULL,
	Ativo BIT NOT NULL DEFAULT (1),
	CONSTRAINT PK_Segmento PRIMARY KEY (IdSegmento)
)
GO

CREATE TABLE dbo.Cliente(
	IdCliente BIGINT NOT NULL IDENTITY,
	CpfCnpj VARCHAR(14) NOT NULL,
	NomeCliente VARCHAR(250) NOT NULL,
	IdSegmento SMALLINT NOT NULL,
	CONSTRAINT PK_Cliente PRIMARY KEY (IdCliente),
	CONSTRAINT FK_Cliente_Segmento FOREIGN KEY (IdSegmento) REFERENCES dbo.Segmento (IdSegmento)
)
GO

CREATE TABLE dbo.TaxaCambio(
	IdTaxaCambio BIGINT NOT NULL IDENTITY,
	IdSegmento SMALLINT NOT NULL,
	ValorTaxa DECIMAL(10,4) NOT NULL,
	CONSTRAINT PK_TaxaCambio PRIMARY KEY (IdTaxaCambio),
	CONSTRAINT FK_TaxaCambio_Segmento FOREIGN KEY (IdSegmento) REFERENCES dbo.Segmento (IdSegmento),
	CONSTRAINT UK_TaxaCambio_IdSegmento UNIQUE (IdSegmento)
)
GO