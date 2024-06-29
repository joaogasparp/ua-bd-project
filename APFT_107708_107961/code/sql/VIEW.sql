-- Remover views existentes
if object_id('vw_Item_Detalhes', 'v') is not null
	drop view vw_Item_Detalhes;
go
if object_id('vw_Funcionario_Detalhes', 'v') is not null
    drop view vw_Funcionario_Detalhes;
go
if object_id('vw_Estoque_Detalhes', 'v') is not null
    drop view vw_Estoque_Detalhes;
go
if object_id('vw_BombaCombustivel_Detalhes', 'v') is not null
    drop view vw_BombaCombustivel_Detalhes;
go
if object_id('vw_Encomenda_Detalhes', 'v') is not null
    drop view vw_Encomenda_Detalhes;
go
if object_id('vw_AreaServico_Detalhes', 'v') is not null
    drop view vw_AreaServico_Detalhes;
go
if object_id('vw_Pessoa_Detalhes', 'v') is not null
    drop view vw_Pessoa_Detalhes;
go
if object_id('vw_Fornecedor_Detalhes', 'v') is not null
    drop view vw_Fornecedor_Detalhes;
go
if object_id('vw_Loja_Detalhes', 'v') is not null
    drop view vw_Loja_Detalhes;
go
if object_id('vw_Produto_Detalhes', 'v') is not null
    drop view vw_Produto_Detalhes;
go
if object_id('vw_Gerente_Detalhes', 'v') is not null
    drop view vw_Gerente_Detalhes;
go

-- View para obter detalhes completos do item
CREATE VIEW vw_Item_Detalhes AS
SELECT i.ItemID, i.Quantidade, p.Codigo, p.TaxaIva, p.Preco, e.Num_Encomenda, e.Data_entrega
FROM GAS_Item i
JOIN GAS_Produto p ON i.P_Codigo = p.Codigo
JOIN GAS_Encomenda e ON i.Enc_Num_Encomenda = e.Num_Encomenda;
GO

-- View para obter detalhes completos do funcionário
CREATE VIEW vw_Funcionario_Detalhes AS
SELECT f.NIF, f.Cargo, g.NIF AS 'NIF Gerente', g.Gabinete
FROM GAS_Funcionario f
JOIN GAS_Gerente g ON f.G_NIF = g.NIF;
GO

-- View para obter detalhes completos do estoque
CREATE VIEW vw_Estoque_Detalhes AS
SELECT e.Num_Estoque, e.Quantidade, l.ID AS 'Area de Servico', l.Nome AS 'Nome Loja'
FROM GAS_Estoque e
JOIN GAS_Loja l ON e.L_ID = l.ID;
GO

-- View para obter detalhes completos da Bomba de Combustível
CREATE VIEW vw_BombaCombustivel_Detalhes AS
SELECT b.Num_Bomba, b.Marca, b.Preco, b.AS_Num_Area, p.Codigo AS 'Codigo Produto', p.TaxaIva, p.Quantidade AS 'Quantidade Produto', p.Preco AS 'Preco Produto'
FROM GAS_BombaCombustivel b
JOIN GAS_Produto p ON b.P_Codigo = p.Codigo;
GO

-- View para obter detalhes completos da Encomenda
CREATE VIEW vw_Encomenda_Detalhes AS
SELECT e.Num_Encomenda, e.Data_entrega, f.NIF AS 'NIF Fornecedor'
FROM GAS_Encomenda e
JOIN GAS_Fornecedor f ON e.F_NIF = f.NIF;
GO

-- View para obter detalhes completos da Área de Serviço
CREATE VIEW vw_AreaServico_Detalhes AS
SELECT a.Num_Area, a.Localizacao, l.ID, l.Nome AS 'Nome Loja'
FROM GAS_Area_servico a
JOIN GAS_Loja l ON a.Num_Area = l.AS_Num_Area;
GO

-- View para obter detalhes completos da Pessoa
CREATE VIEW vw_Pessoa_Detalhes AS
SELECT p.NIF, p.Nome, p.Contacto, a.Num_Area, a.Localizacao
FROM GAS_Pessoa p
JOIN GAS_Area_servico a ON p.AS_Num_Area = a.Num_Area;
GO

-- View para obter detalhes completos do Fornecedor
CREATE VIEW vw_Fornecedor_Detalhes AS
SELECT f.NIF, f.Marca
FROM GAS_Fornecedor f;
GO

-- View para obter detalhes completos da Loja
CREATE VIEW vw_Loja_Detalhes AS
SELECT l.ID, l.Nome, l.AS_Num_Area
FROM GAS_Loja l;
GO

-- View para obter detalhes completos do Produto
CREATE VIEW vw_Produto_Detalhes AS
SELECT p.Codigo, p.TaxaIva, p.Quantidade, p.Preco, e.Num_Estoque, e.Quantidade AS 'Quantidade Estoque', l.ID, l.Nome AS 'Nome Loja'
FROM GAS_Produto p
JOIN GAS_Estoque e ON p.E_Num_Estoque = e.Num_Estoque
JOIN GAS_Loja l ON e.L_ID = l.ID;
GO

-- View para obter detalhes completos do Gerente
CREATE VIEW vw_Gerente_Detalhes AS
SELECT g.NIF, g.Gabinete, p.Nome AS 'Nome Pessoa', p.Contacto, p.AS_Num_Area
FROM GAS_Gerente g
JOIN GAS_Pessoa p ON g.NIF = p.NIF;
GO
