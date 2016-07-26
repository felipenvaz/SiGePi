ALTER PROCEDURE [dbo].[GetClientes]
	@Id int = 0,
	@filtro int
AS
BEGIN

SELECT * FROM Clientes WHERE (Id = @Id) OR (@Id = 0)

IF(@filtro & 0x2 = 0x2)
BEGIN
	SELECT * FROM Aulas WHERE (IdCliente = @Id) OR (@Id = 0)
END

IF(@filtro & 0x4 = 0x4)
BEGIN
	SELECT * FROM Pagamentos WHERE (IdCliente = @Id) OR (@Id = 0)
END

IF(@filtro & 0x8 = 0x8)
BEGIN
	SELECT * FROM Telefones WHERE (IdCliente = @Id) OR (@Id = 0)
END

END

GO
--------------------------------------------------------------

CREATE TABLE [dbo].[Despesas]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Descricao] VARCHAR(MAX) NULL,
	[Valor] DECIMAL NOT NULL,
	[Data] DATETIME NOT NULL
)

GO
-------------------------------------------------------------------

CREATE PROCEDURE [dbo].[InserirDespesa]
	@Id INT OUTPUT,
	@Descricao VARCHAR(MAX) = NULL,
	@Valor INT,
	@Data DATETIME
AS
BEGIN
	INSERT INTO Despesas (Descricao, Valor, Data) values (@Descricao, @Valor, @Data)

	SET @Id = SCOPE_IDENTITY();
END

GO
---------------------------

CREATE PROCEDURE [dbo].[GetDespesas]
AS
BEGIN
	SELECT * FROM Despesas;
END

GO
-------------------------------

CREATE PROCEDURE [dbo].[RemoverDespesa]
	@Id INT
AS
BEGIN
Delete Despesas WHERE Id = @Id
END

GO
--------------------------------------

