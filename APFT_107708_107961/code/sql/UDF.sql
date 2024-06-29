-- Remover funções existentes
IF OBJECT_ID('dbo.GetNumeroBombasGasolina', 'FN') IS NOT NULL DROP FUNCTION dbo.GetNumeroBombasGasolina;
IF OBJECT_ID('dbo.GetCapacidadeTotalEstacionamento', 'FN') IS NOT NULL DROP FUNCTION dbo.GetCapacidadeTotalEstacionamento;
IF OBJECT_ID('dbo.GetTotalFuncionariosPorGerente', 'FN') IS NOT NULL DROP FUNCTION dbo.GetTotalFuncionariosPorGerente;
IF OBJECT_ID('dbo.VerificarSenhaGerente', 'FN') IS NOT NULL DROP FUNCTION dbo.VerificarSenhaGerente;
IF OBJECT_ID('dbo.GetLojasPorGerente', 'FN') IS NOT NULL DROP FUNCTION dbo.GetLojasPorGerente;
GO

-- Obter o numero de bombas de gasolina de uma área de serviço
CREATE FUNCTION dbo.GetNumeroBombasGasolina(@AS_Num_Area int)
RETURNS int
AS
BEGIN
    DECLARE @NumeroBombas int;

    SELECT @NumeroBombas = COUNT(*)
    FROM GAS_BombaCombustivel
    WHERE P_Codigo IN (SELECT Codigo FROM GAS_Produto WHERE E_Num_Estoque IN (SELECT Num_Estoque FROM GAS_Estoque WHERE L_ID IN (SELECT ID FROM GAS_Loja WHERE AS_Num_Area = @AS_Num_Area)));
    RETURN ISNULL(@NumeroBombas, 0);
END;
GO

-- Obter a capacidade total de um estacionamento de uma área de serviço
CREATE FUNCTION dbo.GetCapacidadeTotalEstacionamento(@AS_Num_Area int)
RETURNS int
AS
BEGIN
    DECLARE @CapacidadeTotal int;

    SELECT @CapacidadeTotal = SUM(Capacidade)
    FROM GAS_EstacionamentoON
    WHERE AS_Num_Area = @AS_Num_Area;

    RETURN ISNULL(@CapacidadeTotal, 0);
END;
GO

-- Obter o total de funcionários por gerente
CREATE FUNCTION dbo.GetTotalFuncionariosPorGerente(@G_NIF int)
RETURNS int
AS
BEGIN
    DECLARE @TotalFuncionarios int;

    SELECT @TotalFuncionarios = COUNT(*)
    FROM GAS_Funcionario
    WHERE G_NIF = @G_NIF;

    RETURN ISNULL(@TotalFuncionarios, 0);
END;
GO

-- Verificar se a senha do gerente está correta
CREATE FUNCTION dbo.VerificarSenhaGerente (@NIF INT, @Senha VARCHAR(128))
RETURNS BIT AS
BEGIN
    DECLARE @Resultado BIT;

    IF EXISTS (SELECT 1 FROM GAS_Gerente WHERE NIF = @NIF AND Senha = @Senha)
        SET @Resultado = 1;
    ELSE
        SET @Resultado = 0;

    RETURN @Resultado;
END;
GO

-- Obter os nomes das lojas de um gerente
CREATE FUNCTION dbo.GetLojasPorGerente(@G_NIF int)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    DECLARE @NomesLojas NVARCHAR(MAX);

    SELECT @NomesLojas = COALESCE(@NomesLojas + ', ', '') + GAS_Loja.Nome
    FROM GAS_Loja
    INNER JOIN GAS_Area_Servico ON GAS_Loja.AS_Num_Area = GAS_Area_Servico.Num_Area
    INNER JOIN GAS_Pessoa ON GAS_Pessoa.AS_Num_Area = GAS_Area_Servico.Num_Area
    INNER JOIN GAS_Gerente ON GAS_Gerente.NIF = GAS_Pessoa.NIF
    WHERE GAS_Gerente.NIF = @G_NIF;

    RETURN ISNULL(@NomesLojas, '');
END;
GO
