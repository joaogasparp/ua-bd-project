-- Remover stored procedures existentes
IF OBJECT_ID('dbo.InserirEstacionamentoON', 'P') IS NOT NULL DROP PROCEDURE dbo.InserirEstacionamentoON;
IF OBJECT_ID('dbo.InserirLoja', 'P') IS NOT NULL DROP PROCEDURE dbo.InserirLoja;
IF OBJECT_ID('dbo.VerifyGerente', 'P') IS NOT NULL DROP PROCEDURE dbo.VerifyGerente;
IF OBJECT_ID('dbo.RegisterUser', 'P') IS NOT NULL DROP PROCEDURE dbo.RegisterUser;
IF OBJECT_ID('dbo.AddFuncionario', 'P') IS NOT NULL DROP PROCEDURE dbo.AddFuncionario;
IF OBJECT_ID('dbo.AtualizarGerente', 'P') IS NOT NULL DROP PROCEDURE dbo.AtualizarGerente;
IF OBJECT_ID('dbo.BuscarEncomendasPorNIF', 'P') IS NOT NULL DROP PROCEDURE dbo.BuscarEncomendasPorNIF;
IF OBJECT_ID('dbo.BuscarDetalhesDaEncomenda', 'P') IS NOT NULL DROP PROCEDURE dbo.BuscarDetalhesDaEncomenda;
IF OBJECT_ID('dbo.CreateOrderAndItems', 'P') IS NOT NULL DROP PROCEDURE dbo.CreateOrderAndItems;
GO

-- Inserir um novo estacionamento
CREATE PROCEDURE dbo.InserirEstacionamentoON
    @Num_Estacionamento int,
    @Capacidade int,
    @Taxa int,
    @AS_Num_Area int
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM GAS_EstacionamentoON WHERE Num_Estacionamento = @Num_Estacionamento)
    BEGIN
        INSERT INTO GAS_EstacionamentoON(Num_Estacionamento, Capacidade, Taxa, AS_Num_Area)
        VALUES (@Num_Estacionamento, @Capacidade, @Taxa, @AS_Num_Area);
    END
    ELSE
    BEGIN
        PRINT 'O estacionamento com o número especificado já existe.';
    END
END;
GO

-- Inserir uma nova loja
CREATE PROCEDURE dbo.InserirLoja
    @ID int,
    @Nome varchar(128),
    @AS_Num_Area int
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM GAS_Loja WHERE ID = @ID)
    BEGIN
        INSERT INTO GAS_Loja(ID, Nome, AS_Num_Area)
        VALUES (@ID, @Nome, @AS_Num_Area);
    END
    ELSE
    BEGIN
        PRINT 'A loja com o ID especificado já existe.';
    END
END;
GO

-- Verificar se a Senha e o nif são do mesmo gerente
CREATE PROCEDURE dbo.VerifyGerente
    @NIF INT,
    @Senha NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @EncryptedSenha VARBINARY(128);
    SELECT @EncryptedSenha = Senha
    FROM dbo.GAS_Gerente
    WHERE NIF = @NIF;

    IF @EncryptedSenha IS NOT NULL AND 
       CONVERT(NVARCHAR(50), DecryptByPassPhrase('WhySoSerious', @EncryptedSenha)) = @Senha
    BEGIN
        SELECT 1 AS Result;
    END
    ELSE
    BEGIN
        SELECT 0 AS Result;
    END
END;
GO


-- Registar um novo gerente
CREATE PROCEDURE dbo.RegisterUser
    @Num_Area INT,
    @Localizacao NVARCHAR(100),
    @NomeArea NVARCHAR(100),
    @NIF int,
    @NomePessoa NVARCHAR(100),
    @Contacto int,
    @Gabinete NVARCHAR(50),
    @Senha NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO dbo.GAS_Area_Servico (Num_Area, Localizacao, NomeArea)
        VALUES (@Num_Area, @Localizacao, @NomeArea);

        INSERT INTO dbo.GAS_Pessoa (NIF, Nome, Contacto, AS_Num_Area)
        VALUES (@NIF, @NomePessoa, @Contacto, @Num_Area);

        INSERT INTO dbo.GAS_Gerente (NIF, Gabinete, Senha)
        VALUES (@NIF, @Gabinete, EncryptByPassPhrase('WhySoSerious', @Senha));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO


-- Registar um novo funcionario
CREATE PROCEDURE dbo.AddFuncionario
    @F_NIF INT,
    @F_Nome NVARCHAR(100),
    @F_Contacto INT,
    @F_Cargo NVARCHAR(100),
    @F_GerenteNIF INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @F_AS_Num_Area INT;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Obter o AS_Num_Area da tabela GAS_Pessoa com base no NIF do gerente
        SELECT @F_AS_Num_Area = AS_Num_Area
        FROM dbo.GAS_Pessoa
        WHERE NIF = @F_GerenteNIF;

        -- Verifica se o AS_Num_Area foi encontrado
        IF @F_AS_Num_Area IS NULL
        BEGIN
            THROW 50000, 'AS_Num_Area não encontrado para o NIF do gerente fornecido.', 1;
        END

        -- Inserir na tabela GAS_Pessoa
        INSERT INTO dbo.GAS_Pessoa (NIF, Nome, Contacto, AS_Num_Area)
        VALUES (@F_NIF, @F_Nome, @F_Contacto, @F_AS_Num_Area);

        -- Inserir na tabela GAS_Funcionario
        INSERT INTO dbo.GAS_Funcionario (NIF, Cargo, G_NIF)
        VALUES (@F_NIF, @F_Cargo, @F_GerenteNIF);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO

-- Atualizar o gerente
CREATE PROCEDURE dbo.AtualizarGerente
    @NIF INT,
    @Nome VARCHAR(128),
    @Contacto INT,
    @Gabinete INT
AS
BEGIN
    UPDATE GAS_Pessoa
    SET Nome = @Nome,
        Contacto = @Contacto
    WHERE NIF = @NIF;

    UPDATE GAS_Gerente
    SET Gabinete = @Gabinete
    WHERE NIF = @NIF;
END;
GO

-- Obter encomendas pelo NIF do gerente 
CREATE PROCEDURE dbo.BuscarEncomendasPorNIF
    @NIF INT
AS
BEGIN
    SELECT e.Num_Encomenda, e.Data_entrega, f.NIF AS 'NIF Fornecedor'
    FROM GAS_Encomenda e
    JOIN GAS_Fornecedor f ON e.F_NIF = f.NIF
    WHERE e.G_NIF = @NIF;
END;
GO

-- Buscar detalhes da encomenda
CREATE PROCEDURE dbo.BuscarDetalhesDaEncomenda
    @Num_Encomenda INT
AS
BEGIN
    SELECT i.ItemID, i.Quantidade, p.Preco, e.Num_Estoque
    FROM GAS_Item i
    JOIN GAS_Produto p ON i.P_Codigo = p.Codigo
    JOIN GAS_Estoque e ON p.E_Num_Estoque = e.Num_Estoque
    WHERE i.Enc_Num_Encomenda = @Num_Encomenda;
END;
GO

-- Criar uma nova encomenda e os respetivos items
CREATE PROCEDURE CreateOrderAndItems
    @NifGerente INT,
    @NumEncomenda INT,
    @DataEntrega DATETIME,
    @NifFornecedor INT,
    @ItemId INT,
    @Quantidade INT,
    @Preco DECIMAL,
    @NumEstoque INT
AS
BEGIN
    INSERT INTO GAS_Encomenda (Num_Encomenda, Data_Entrega, F_NIF, G_NIF) 
    VALUES (@NumEncomenda, @DataEntrega, @NifFornecedor, @NifGerente);

    INSERT INTO GAS_Produto (Codigo, TaxaIva, Quantidade, Preco, E_Num_Estoque)
    VALUES (@ItemId, 0.23, @Quantidade, @Preco, @NumEstoque);

    INSERT INTO GAS_Item (ItemID, Quantidade, P_Codigo, Enc_Num_Encomenda) 
    VALUES (@ItemId, @Quantidade, @ItemId, @NumEncomenda);

    UPDATE GAS_Estoque 
    SET Quantidade = Quantidade - @Quantidade 
    WHERE Num_Estoque = @NumEstoque;
END;
GO
