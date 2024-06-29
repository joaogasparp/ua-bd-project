-- Inserir dados na tabela GAS_Area_Servico
INSERT INTO GAS_Area_Servico(Num_Area, Localizacao, NomeArea)
VALUES
(1, 'A1', 'Area1'),
(2, 'Nacional', 'Area2'),
(3, 'Rua do Pereres', 'Area3'),
(4, 'Tondela', 'Area4');

-- Inserir dados na tabela GAS_EstacionamentoON
INSERT INTO GAS_EstacionamentoON(Num_Estacionamento, Capacidade, Taxa, AS_Num_Area)
VALUES
(1, 100, 20, 1),
(2, 95, 15, 2),
(3, 120, 20, 3),
(4, 60, 10, 4),
(5, 40, 5, 4);

-- Inserir dados na tabela GAS_Loja
INSERT INTO GAS_Loja(ID, Nome, AS_Num_Area)
VALUES
(1, 'Buy Me', 1),
(2, 'Eat Me', 2),
(3, 'Drink Me', 2),
(4, 'STOP', 3),
(5, 'Go', 4);

-- Inserir dados na tabela GAS_Estoque
INSERT INTO GAS_Estoque(Num_Estoque, Quantidade, L_ID)
VALUES
(1, 100, 1),
(2, 100, 2),
(3, 60, 2),     
(4, 95, 3),
(5, 35, 3),
(6, 40, 4),
(7, 80, 4);

-- Inserir dados na tabela GAS_Produto
INSERT INTO GAS_Produto(Codigo, TaxaIva, Quantidade, Preco, E_Num_Estoque)
VALUES
(1, 0.23, 30, 1.5, 1),
(2, 0.23, 20, 1.2, 1),
(3, 0.23, 25, 1.7, 1),
(4, 0.23, 40, 1.5, 2),
(5, 0.23, 30, 1.5, 2),
(6, 0.23, 20, 1.5, 3),
(7, 0.23, 25, 1.7, 3),
(8, 0.23, 40, 1.5, 4),
(9, 0.23, 30, 1.5, 4),
(10, 0.23, 10, 1.5, 5),
(11, 0.23, 15, 1.7, 5),
(12, 0.23, 20, 1.5, 6), 
(13, 0.23, 15, 1.5, 6),
(14, 0.23, 20, 1.5, 7),
(15, 0.23, 10, 1.7, 7),
(16, 0.23, 30, 1.3, 7);

-- Inserir dados na tabela GAS_BombaCombustivel
INSERT INTO GAS_BombaCombustivel(Num_Bomba, Marca, Preco, P_Codigo, AS_Num_Area)
VALUES
(1, 'Repsol', 1.5, 1, 1),
(2, 'Galp', 1.5, 4, 2),
(3, 'BP', 1.5, 6, 3),
(4, 'Cepsa', 1.5, 8, 4),
(5, 'Repsol', 1.5, 10, 1),
(6, 'Prio', 1.5, 12, 2),
(7, 'BP', 1.5, 14, 3);

-- Inserir dados na tabela GAS_Pessoa (gerentes, funcionários, fornecedores e clientes)
INSERT INTO GAS_Pessoa(NIF, Nome, Contacto, AS_Num_Area)
VALUES
(248234958, 'João Silva', 912345678, 1),
(245754904, 'Maria Santos', 923454358, 1),
(190345950, 'Pedro Carlos', 934528016, 1),
(199345785, 'Rita Pereira', 912342678, 2),
(234567890, 'Miguel Santos', 923454350, 2),
(234567891, 'Ana Rafael', 912345673, 3),
(234567892, 'Rui Santos', 923454359, 3),
(234567893, 'Sara Santos', 912345674, 4),
(234567894, 'Pedro Ferreira', 923454351, 4),
(193456820, 'Marta Santos', 912345675, 4),
(193456821, 'Carlos Silva', 923454352, 4),
(987654322, 'BP', 912345678, 1),
(987654323, 'Galp', 923454358, 1),
(987654324, 'Repsol', 934528016, 1),
(987654325, 'Cepsa', 912342678, 2),
(987654326, 'Prio', 923454350, 2),
(987654330, 'Auchan', 912345673, 3),
(987654331, 'Continente', 923454359, 3),
(987654332, 'Pingo Doce', 912345674, 4),
(987654333, 'Lidl', 923454351, 4),
(987654334, 'Aldi', 912345675, 4),
(987654335, 'Minipreço', 923454352, 4),
(987654336, 'Intermarché', 912345678, 1),
(199243242, 'VISA', 923454358, 1),
(199243243, 'MasterCard', 934528016, 1),
(199243244, 'American Express', 912342678, 2),
(199243245, 'PayPal', 923454350, 2),
(199243246, 'MBWay', 912345673, 3),
(199243247, 'Revolut', 923454359, 3),
(199243248, 'Transferência Bancária', 912345674, 4),
(199243249, 'Dinheiro', 923454351, 4);

-- Inserir dados na tabela GAS_Fornecedor
INSERT INTO GAS_Fornecedor(NIF, Marca)
VALUES
(987654322, 'BP'),
(987654323, 'Galp'),
(987654324, 'Repsol'),
(987654325, 'Cepsa'),
(987654326, 'Prio'),
(987654330, 'Auchan'),
(987654331, 'Continente'),
(987654332, 'Pingo Doce'),
(987654333, 'Lidl'),
(987654334, 'Aldi'),
(987654335, 'Minipreço'),
(987654336, 'Intermarché');

-- Inserir dados na tabela GAS_Cliente
INSERT INTO GAS_Cliente(NIF, Classificacao_Credito)
VALUES
(199243242, 'VISA'),
(199243243, 'MasterCard'),
(199243244, 'American Express'),
(199243245, 'PayPal'),
(199243246, 'MBWay'),
(199243247, 'Revolut'),
(199243248, 'Transferência Bancária'),
(199243249, 'Dinheiro');

INSERT INTO GAS_Gerente(NIF, Gabinete, Senha)
VALUES
(248234958, 101, EncryptByPassPhrase('WhySoSerious', CONVERT(NVARCHAR(50), 'gerente1'))),
(199345785, 102, EncryptByPassPhrase('WhySoSerious', CONVERT(NVARCHAR(50), 'gerente2'))),
(234567891, 103, EncryptByPassPhrase('WhySoSerious', CONVERT(NVARCHAR(50), 'gerente3'))),
(234567893, 104, EncryptByPassPhrase('WhySoSerious', CONVERT(NVARCHAR(50), 'gerente4')));

-- Inserir dados na tabela GAS_Funcionario
INSERT INTO GAS_Funcionario(NIF, Cargo, G_NIF)
VALUES
(248234958, 'Gerente', 248234958),
(245754904, 'Funcionário', 248234958),
(190345950, 'Funcionário', 248234958),
(199345785, 'Gerente', 199345785),
(234567890, 'Funcionário', 199345785),
(234567891, 'Gerente', 234567891),
(234567892, 'Funcionário', 234567891),
(234567893, 'Gerente', 234567893),
(234567894, 'Funcionário', 234567893),
(193456820, 'Funcionário', 234567893),
(193456821, 'Funcionário', 234567893);

-- Inserir dados na tabela GAS_Encomenda
INSERT INTO GAS_Encomenda(Num_Encomenda, Data_entrega, F_NIF, G_NIF)
VALUES
(1, '2022-12-01', 987654322, 248234958),
(2, '2022-12-02', 987654323, 199345785),
(3, '2022-12-03', 987654324, 234567891),
(4, '2022-12-04', 987654325, 234567893),
(5, '2022-12-05', 987654326, 234567893),
(6, '2022-12-06', 987654330, 248234958),
(7, '2022-12-07', 987654331, 199345785),
(8, '2022-12-08', 987654332, 234567891),
(9, '2022-12-09', 987654333, 234567893),
(10, '2022-12-10', 987654334, 234567893),
(11, '2022-12-11', 987654335, 248234958),
(12, '2022-12-12', 987654336, 199345785),
(13, '2022-12-13', 987654322, 234567891),
(14, '2022-12-14', 987654323, 234567893),
(15, '2022-12-15', 987654324, 234567893),
(16, '2022-12-16', 987654325, 234567893),
(17, '2022-12-17', 987654326, 248234958),
(18, '2022-12-18', 987654330, 199345785),
(19, '2022-12-19', 987654331, 234567891),
(20, '2022-12-20', 987654332, 234567893),
(21, '2022-12-21', 987654333, 234567893),
(22, '2022-12-22', 987654334, 234567893),
(23, '2022-12-23', 987654335, 248234958),
(24, '2022-12-24', 987654336, 199345785),
(25, '2022-12-25', 987654322, 234567891),
(26, '2022-12-26', 987654323, 234567893),
(27, '2022-12-27', 987654324, 234567893);

-- Inserir dados na tabela GAS_Item
INSERT INTO GAS_Item(ItemID, Quantidade, P_Codigo, Enc_Num_Encomenda)
VALUES
(1, 30, 1, 1),
(2, 20, 2, 1),
(3, 25, 3, 2),
(4, 40, 4, 2),
(5, 30, 5, 3),
(6, 20, 6, 3),
(7, 25, 7, 4),
(8, 40, 8, 4),
(9, 30, 9, 5),
(10, 10, 10, 5),
(11, 15, 11, 6),
(12, 20, 12, 6),
(13, 15, 13, 7),
(14, 20, 14, 7),
(15, 10, 15, 8),
(16, 30, 16, 8),
(17, 30, 1, 9),
(18, 20, 2, 9),
(19, 25, 3, 10),
(20, 40, 4, 10),
(21, 30, 5, 11),
(22, 20, 6, 11),
(23, 25, 7, 12),
(24, 40, 8, 12),
(25, 30, 9, 13),
(26, 10, 10, 13),
(27, 15, 11, 14),
(28, 20, 12, 14),
(29, 15, 13, 15),
(30, 20, 14, 15),
(31, 10, 15, 16),
(32, 30, 16, 16),
(33, 30, 1, 17),
(34, 20, 2, 17),
(35, 25, 3, 18),
(36, 40, 4, 18),
(37, 30, 5, 19),
(38, 20, 6, 19),
(39, 25, 7, 20),
(40, 40, 8, 20),
(41, 30, 9, 21),
(42, 10, 10, 21),
(43, 15, 11, 22),
(44, 20, 12, 22),
(45, 15, 13, 23),
(46, 20, 14, 23),
(47, 10, 15, 24),
(48, 30, 16, 24),
(49, 30, 1, 25),
(50, 20, 2, 25),
(51, 25, 3, 26),
(52, 40, 4, 26),
(53, 30, 5, 27),
(54, 20, 6, 27);
