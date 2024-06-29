-- Remover triggers existentes
IF OBJECT_ID('dbo.CheckQuantidadeProduto', 'TR') IS NOT NULL DROP TRIGGER dbo.CheckQuantidadeProduto;
IF OBJECT_ID('dbo.CheckCapacidadeEstacionamento', 'TR') IS NOT NULL DROP TRIGGER dbo.CheckCapacidadeEstacionamento;
IF OBJECT_ID('dbo.AutoOrderProduct', 'TR') IS NOT NULL DROP TRIGGER dbo.AutoOrderProduct;
GO

-- Criação do trigger que verifica se a quantidade de um produto é negativa
CREATE TRIGGER CheckQuantidadeProduto
ON GAS_Produto
FOR INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE Quantidade < 0)
    BEGIN
        RAISERROR ('A quantidade de um produto não pode ser negativa.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Criação do trigger que verifica se a capacidade de um estacionamento é negativa
CREATE TRIGGER CheckCapacidadeEstacionamento
ON GAS_EstacionamentoON
FOR INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT 1 FROM inserted WHERE Capacidade < 0)
    BEGIN
        RAISERROR ('A capacidade do estacionamento não pode ser negativa.', 16, 1);
        ROLLBACK TRANSACTION;
    END
END;
GO

-- Criação do trigger que verifica se a quantidade de um produto está abaixo do limite
CREATE TRIGGER AutoOrderProduct
ON GAS_Produto
FOR UPDATE
AS
BEGIN
    DECLARE @CodigoProduto INT;
    DECLARE @QuantidadeAtual INT;
    DECLARE @LimiteQuantidade INT = 10;
    DECLARE @NumEncomenda INT;
    DECLARE @DataEntrega DATE = DATEADD(day, 7, GETDATE());
    DECLARE @FornecedorNIF INT;
    DECLARE @GerenteNIF INT;

    SELECT @CodigoProduto = Codigo, @QuantidadeAtual = Quantidade FROM inserted;

    IF @QuantidadeAtual < @LimiteQuantidade
    BEGIN
        SELECT @FornecedorNIF = NIF FROM GAS_Fornecedor WHERE NIF IN (
            SELECT NIF FROM GAS_Pessoa WHERE AS_Num_Area IN (
                SELECT AS_Num_Area FROM GAS_Produto WHERE Codigo = @CodigoProduto));
        SELECT @GerenteNIF = NIF FROM GAS_Gerente WHERE NIF IN (
            SELECT NIF FROM GAS_Pessoa WHERE AS_Num_Area IN (
                SELECT AS_Num_Area FROM GAS_Produto WHERE Codigo = @CodigoProduto));

        IF @FornecedorNIF IS NOT NULL AND @GerenteNIF IS NOT NULL
        BEGIN
            INSERT INTO GAS_Encomenda (Data_Entrega, F_NIF, G_NIF)
            VALUES (@DataEntrega, @FornecedorNIF, @GerenteNIF);

            SET @NumEncomenda = SCOPE_IDENTITY();

            INSERT INTO GAS_Item (Quantidade, P_Codigo, Enc_Num_Encomenda)
            VALUES (@LimiteQuantidade - @QuantidadeAtual, @CodigoProduto, @NumEncomenda);
        END
        ELSE
        BEGIN
            RAISERROR ('Fornecedor ou gerente não disponível para processar a encomenda.', 16, 1);
            ROLLBACK TRANSACTION;
        END
    END
END;
GO
