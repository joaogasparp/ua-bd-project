--CREATE SCHEMA Gestao_Area_Servico
--go

-- Remover tabelas existentes
IF OBJECT_ID('GAS_Item', 'U') IS NOT NULL DROP TABLE dbo.GAS_Item;
IF OBJECT_ID('GAS_Encomenda', 'U') IS NOT NULL DROP TABLE dbo.GAS_Encomenda;
IF OBJECT_ID('GAS_Funcionario', 'U') IS NOT NULL DROP TABLE dbo.GAS_Funcionario;
IF OBJECT_ID('GAS_Gerente', 'U') IS NOT NULL DROP TABLE dbo.GAS_Gerente;
IF OBJECT_ID('GAS_Cliente', 'U') IS NOT NULL DROP TABLE dbo.GAS_Cliente;
IF OBJECT_ID('GAS_Fornecedor', 'U') IS NOT NULL DROP TABLE dbo.GAS_Fornecedor;
IF OBJECT_ID('GAS_Pessoa', 'U') IS NOT NULL DROP TABLE dbo.GAS_Pessoa;
IF OBJECT_ID('GAS_BombaCombustivel', 'U') IS NOT NULL DROP TABLE dbo.GAS_BombaCombustivel;
IF OBJECT_ID('GAS_Produto', 'U') IS NOT NULL DROP TABLE dbo.GAS_Produto;
IF OBJECT_ID('GAS_Estoque', 'U') IS NOT NULL DROP TABLE dbo.GAS_Estoque;
IF OBJECT_ID('GAS_Loja', 'U') IS NOT NULL DROP TABLE dbo.GAS_Loja;
IF OBJECT_ID('GAS_EstacionamentoON', 'U') IS NOT NULL DROP TABLE dbo.GAS_EstacionamentoON;
IF OBJECT_ID('GAS_Area_Servico', 'U') IS NOT NULL DROP TABLE dbo.GAS_Area_Servico;

-- Criação das tabelas
CREATE TABLE GAS_Area_Servico (
    Num_Area INT NOT NULL,
    Localizacao VARCHAR(128) NOT NULL,
    NomeArea VARCHAR(128) NOT NULL,
    PRIMARY KEY (Num_Area)
);

CREATE TABLE GAS_EstacionamentoON (
    Num_Estacionamento INT NOT NULL,
    Capacidade INT NOT NULL,
    Taxa INT NOT NULL,
    AS_Num_Area INT NOT NULL,
    PRIMARY KEY (Num_Estacionamento),
    FOREIGN KEY (AS_Num_Area) REFERENCES GAS_Area_Servico (Num_Area)
);

CREATE TABLE GAS_Loja (
    ID INT NOT NULL,
    Nome VARCHAR(128) NOT NULL,
    AS_Num_Area INT NOT NULL,
    PRIMARY KEY (ID),
    FOREIGN KEY (AS_Num_Area) REFERENCES GAS_Area_Servico (Num_Area)
);

CREATE TABLE GAS_Estoque (
    Num_Estoque INT NOT NULL,
    Quantidade INT NOT NULL,
    L_ID INT NOT NULL,
    PRIMARY KEY (Num_Estoque),
    FOREIGN KEY (L_ID) REFERENCES GAS_Loja (ID)
);

CREATE TABLE GAS_Produto (
    Codigo INT NOT NULL,
    TaxaIva DECIMAL(5, 2) NOT NULL,
    Quantidade INT NOT NULL,
    Preco DECIMAL(10, 2) NOT NULL,
    E_Num_Estoque INT NOT NULL,
    PRIMARY KEY (Codigo),
    FOREIGN KEY (E_Num_Estoque) REFERENCES GAS_Estoque (Num_Estoque)
);

CREATE TABLE GAS_BombaCombustivel (
    Num_Bomba INT NOT NULL,
    Marca VARCHAR(128) NOT NULL,
    Preco DECIMAL(10, 2) NOT NULL,
    P_Codigo INT NOT NULL,
	AS_Num_Area INT NOT NULL,
    PRIMARY KEY (Num_Bomba),
    FOREIGN KEY (P_Codigo) REFERENCES GAS_Produto (Codigo),
	FOREIGN KEY (AS_Num_Area) REFERENCES GAS_Area_Servico (Num_Area)
);

CREATE TABLE GAS_Pessoa (
    NIF INT NOT NULL,
    Nome VARCHAR(128) NOT NULL,
    Contacto INT NOT NULL,
    AS_Num_Area INT NOT NULL,
    PRIMARY KEY (NIF),
    FOREIGN KEY (AS_Num_Area) REFERENCES GAS_Area_Servico (Num_Area)
);

CREATE TABLE GAS_Fornecedor (
    NIF INT NOT NULL,
    Marca VARCHAR(128) NOT NULL,
    PRIMARY KEY (NIF),
	FOREIGN KEY (NIF) REFERENCES GAS_Pessoa (NIF)
);

CREATE TABLE GAS_Cliente (
    NIF INT NOT NULL,
    Classificacao_Credito VARCHAR(128) NOT NULL,
    PRIMARY KEY (NIF),
	FOREIGN KEY (NIF) REFERENCES GAS_Pessoa (NIF)
);

CREATE TABLE GAS_Gerente (
    NIF INT NOT NULL,
    Gabinete INT NOT NULL,
    Senha VARBINARY(128) NOT NULL,
    PRIMARY KEY (NIF),
	FOREIGN KEY (NIF) REFERENCES GAS_Pessoa (NIF)
);

CREATE TABLE GAS_Funcionario (
    NIF INT NOT NULL,
    Cargo VARCHAR(128) NOT NULL,
    G_NIF INT NOT NULL,
    PRIMARY KEY (NIF),
    FOREIGN KEY (G_NIF) REFERENCES GAS_Gerente (NIF),
	FOREIGN KEY (NIF) REFERENCES GAS_Pessoa (NIF)
);

CREATE TABLE GAS_Encomenda (
    Num_Encomenda INT NOT NULL,
    Data_Entrega DATE NOT NULL,
    F_NIF INT NOT NULL,
    G_NIF INT NOT NULL,
    PRIMARY KEY (Num_Encomenda),
    FOREIGN KEY (F_NIF) REFERENCES GAS_Fornecedor (NIF),
    FOREIGN KEY (G_NIF) REFERENCES GAS_Gerente (NIF)
);

CREATE TABLE GAS_Item (
    ItemID INT NOT NULL,
    Quantidade INT NOT NULL,
    P_Codigo INT NOT NULL,
    Enc_Num_Encomenda INT NOT NULL,
    PRIMARY KEY (ItemID),
    FOREIGN KEY (P_Codigo) REFERENCES GAS_Produto (Codigo),
    FOREIGN KEY (Enc_Num_Encomenda) REFERENCES GAS_Encomenda (Num_Encomenda)
);
