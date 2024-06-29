# Introdução

Este relatório apresenta o projeto de uma base de dados para a gestão de uma área de serviço, desenvolvido como parte da unidade curricular de Bases de Dados da Licenciatura em Engenharia de Computadores e Informática da Universidade de Aveiro.
O objetivo deste projeto é criar uma base de dados que possa gerir todas as operações de uma área de serviço, incluindo a gestão de estacionamentos, lojas, stocks, produtos, funcionários e gerentes. 
Neste relatório, descrevemos em detalhes o processo de análise de requisitos, o design das entidades e suas multiplicidades, o Diagrama Entidade Relação (DER), o Esquema Relacional (ER), bem como a implementação de Stored Procedures (SPs), Views, User-Defined Functions (UDFs), Triggers e Indexes. Cada seção do relatório concentra-se numa parte específica do projeto, fornecendo uma visão detalhada de como cada componente foi projetado e implementado.
De modo a ser possível a testagem da nossa interface noutra base de dados, é necessário aceder ao ficheiro DataBaseConnection.cs e mudar os atributos initialCatalog, uid e password para as credenciais desejadas. 
Figura 1Ficheiro DataBaseConnection.cs onde é possível alterar a conexão à base de dados.
Em anexo segue todo o código usado tanto para a interface como para a base de dados, a apresentação em .pdf e o vídeo demonstrativo.

# Análise de Requisitos

Podem-se registar na interface gerentes, identificados distintamente pelo seu NIF e contacto bem como o número da área de serviço em que atuam.
-	O sistema deve ser capaz de gerenciar as áreas de serviço, que são identificadas por um número único. Cada área de serviço tem uma localização e um nome.
-	Existem 2 tipos de funcionários: gerentes, funcionários.
-	Para um gerente registar a entrada de um novo produto no estoque, é necessário que o produto já esteja registado no sistema.
-	O gerente pode fazer encomendas a fornecedores de produtos que estejam em falta.
-	O gerente pode demitir funcionários ou então adicionar novos.
-	O gerente pode verificar os produtos que tem em stock nas lojas.

# Entidades e Multiplicidade

-	Area_Servico: Identificada pelo número da área (Num_Area). Possui atributos não únicos como localização e nome da área.
-	EstacionamentoON: Identificado pelo número do estacionamento (Num_Estacionamento). Possui atributos não únicos como capacidade e taxa. Relaciona-se com a entidade Area_Servico.
-	Loja: Identificada pelo ID. Possui atributo não único como nome. Relaciona-se com a entidade Area_Servico.
-	Estoque: Identificado pelo número do estoque (Num_Estoque). Possui atributo não único como quantidade. Relaciona-se com a entidade Loja.
-	Produto: Identificado pelo código (Codigo). Possui atributos não únicos como taxa de IVA, quantidade e preço. Relaciona-se com a entidade Estoque.
-	BombaCombustivel: Identificada pelo número da bomba (Num_Bomba). Possui atributos não únicos como marca e preço. Relaciona-se com a entidade Produto.
-	Pessoa: Identificada pelo NIF. Possui atributos não únicos como nome, contato e número da área de serviço. Relaciona-se com a entidade Area_Servico.
-	Fornecedor: Identificado pelo NIF. Possui atributo não único como marca.
-	Cliente: Identificado pelo NIF. Possui atributo não único como classificação de crédito.
-	Gerente: Identificado pelo NIF. Possui atributos não únicos como gabinete e senha.
-	Funcionario: Identificado pelo NIF. Possui atributos não únicos como cargo. Relaciona-se com a entidade Gerente.
-	Encomenda: Identificada pelo número da encomenda (Num_Encomenda). Possui atributo não único como data de entrega. Relaciona-se com as entidades Fornecedor e Gerente.
-	Item: Identificado pelo ID do item (ItemID). Possui atributo não único como quantidade. Relaciona-se com as entidades Produto e Encomenda.
