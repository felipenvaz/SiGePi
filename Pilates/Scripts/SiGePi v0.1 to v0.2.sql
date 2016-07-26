alter table Clientes
add Cpf VARCHAR(MAX);


GO
CREATE TABLE [dbo].[Pagamentos] (
    [Id]        INT      IDENTITY (1, 1) NOT NULL,
    [IdCliente] INT      NOT NULL,
    [Data]      DATETIME NOT NULL,
    [Valor]     INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);



GO
ALTER TABLE [dbo].[Pagamentos] WITH NOCHECK
    ADD CONSTRAINT [FK_Pagamentos_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[Clientes] ([Id]);


GO
ALTER PROCEDURE [dbo].[AtualizarCliente]
	@Id INT,
    @Nome VARCHAR (MAX),
	@Cpf VARCHAR (MAX) = NULL,
	@Endereco VARCHAR (MAX) = NULL,
	@Email VARCHAR (MAX) = NULL,
	@DataNascimento DATETIME = NULL,
	@Profissao VARCHAR (MAX) = NULL,
	@QuemIndicou VARCHAR (MAX) = NULL,
	@ComoConheceu INT,
	@PraticaAtividade VARCHAR (MAX) = NULL,
	@Medicacao VARCHAR (MAX) = NULL,
	@Riscos INT,
	@Doenca VARCHAR (MAX) = NULL,
	@Dor VARCHAR (MAX) = NULL,
	@Objetivo VARCHAR (MAX) = NULL,
	@ExamesComplementares VARCHAR (MAX) = NULL,
	@Observacao VARCHAR (MAX) = NULL,
	@Pes INT,
	@Joelhos INT,
	@Pelve INT,
	@Coluna INT,
	@Ombros INT,
	@Cabeca INT
AS
	UPDATE Clientes SET Nome = @Nome, 
	Cpf = @Cpf,
	Endereco = @Endereco,
	Email = @Email,
	DataNascimento = @DataNascimento,
	Profissao = @Profissao,
	QuemIndicou = @QuemIndicou,
	ComoConheceu = @ComoConheceu,
	PraticaAtividade = @PraticaAtividade,
	Medicacao = @Medicacao,
	Riscos = @Riscos,
	Doenca = @Doenca,
	Dor = @Dor,
	Objetivo = @Objetivo,
	ExamesComplementares = @ExamesComplementares,
	Observacao = @Observacao,
	Pes = @Pes,
	Joelhos = @Joelhos,
	Pelve = @Pelve,
	Coluna = @Coluna,
	Ombros = @Ombros,
	Cabeca = @Cabeca
	WHERE Id = @Id
GO
PRINT N'Altering [dbo].[GetClientes]...';


GO
ALTER PROCEDURE [dbo].[GetClientes]
	@Id int = 0,
	@filtro int
AS
BEGIN

SELECT * FROM Clientes WHERE (Id = @Id) OR (@Id = 0)

IF(@filtro & 0x2 = 0x2)
BEGIN
	SELECT * FROM Telefones WHERE (IdCliente = @Id) OR (@Id = 0)

	SELECT * FROM Aulas WHERE (IdCliente = @Id) OR (@Id = 0)

	SELECT * FROM Pagamentos WHERE (IdCliente = @Id) OR (@Id = 0)
END

END
GO
PRINT N'Altering [dbo].[InserirCliente]...';


GO
ALTER PROCEDURE [dbo].[InserirCliente]
	@Id INT OUTPUT,
    @Nome VARCHAR (MAX),
	@Cpf VARCHAR (MAX) = NULL,
	@Endereco VARCHAR (MAX) = NULL,
	@Email VARCHAR (MAX) = NULL,
	@DataNascimento DATETIME = NULL,
	@Profissao VARCHAR (MAX) = NULL,
	@QuemIndicou VARCHAR (MAX) = NULL,
	@ComoConheceu INT,
	@PraticaAtividade VARCHAR (MAX) = NULL,
	@Medicacao VARCHAR (MAX) = NULL,
	@Riscos INT,
	@Doenca VARCHAR (MAX) = NULL,
	@Dor VARCHAR (MAX) = NULL,
	@Objetivo VARCHAR (MAX) = NULL,
	@ExamesComplementares VARCHAR (MAX) = NULL,
	@Observacao VARCHAR (MAX) = NULL,
	@Pes INT,
	@Joelhos INT,
	@Pelve INT,
	@Coluna INT,
	@Ombros INT,
	@Cabeca INT
AS
BEGIN
	INSERT INTO Clientes 
	(			
	Nome,
	Cpf,			
	Endereco,			
	Email,			
	DataNascimento,	
	Profissao,		
	QuemIndicou,		
	ComoConheceu,		
	PraticaAtividade,	
	Medicacao,			
	Riscos,		
	Doenca,		
	Dor,			
	Objetivo,			
	ExamesComplementares,
	Observacao,	
	Pes,			
	Joelhos,			
	Pelve,			
	Coluna,		
	Ombros,		
	Cabeca 			
	) 
	VALUES 
	(@Nome,	
	@Cpf,		
	@Endereco,			
	@Email,		
	@DataNascimento,	
	@Profissao,	
	@QuemIndicou,	
	@ComoConheceu,	
	@PraticaAtividade, 	
	@Medicacao,	
	@Riscos,	
	@Doenca,		
	@Dor,		
	@Objetivo,		
	@ExamesComplementares,
	@Observacao,	
	@Pes,		
	@Joelhos,		
	@Pelve,		
	@Coluna,			
	@Ombros,			
	@Cabeca);	

	SET @Id = SCOPE_IDENTITY();
END
GO
PRINT N'Altering [dbo].[RemoverCliente]...';


GO
ALTER PROCEDURE [dbo].[RemoverCliente]
	@Id INT
AS
	DELETE Aulas WHERE IdCliente = @Id
	DELETE Telefones WHERE IdCliente = @Id
	DELETE Pagamentos WHERE IdCliente = @Id
	DELETE Clientes WHERE Id = @Id
GO
PRINT N'Creating [dbo].[UpdatePagamentos]...';


GO
CREATE PROCEDURE [dbo].[UpdatePagamentos]
	@IdCliente int,
	@Dados varchar (max) = NULL
AS
BEGIN

	DELETE Pagamentos WHERE IdCliente = @IdCliente

	IF (@Dados IS NOT NULL)
	BEGIN

		declare @sub varchar(max),
		@inicio INT,
		@end INT,
		@tam INT,
		@valor INT,
		@data DATETIME

		set @inicio = 0
		set @end = 0
		set @tam = len (@Dados)

		WHILE @inicio <= @tam
		BEGIN

		SET @end = CHARINDEX('|', @Dados, @inicio);
		IF (@end = 0)
		BEGIN
		SET @end = @tam + 1
		END

		SET @data = SUBSTRING (@Dados, @inicio, @end - @inicio);
		SET @inicio = @end + 1
		-----------------------------------------------
		SET @end = CHARINDEX('|', @Dados, @inicio);
		IF (@end = 0)
		BEGIN
		SET @end = @tam + 1
		END

		SET @valor = SUBSTRING (@Dados, @inicio, @end - @inicio);
		SET @inicio = @end + 1

		insert into Pagamentos (IdCliente, Data, Valor) VALUES (@IdCliente, @data, @valor)

		END

	END

END
GO
PRINT N'Checking existing data against newly created constraints';


GO

ALTER TABLE [dbo].[Pagamentos] WITH CHECK CHECK CONSTRAINT [FK_Pagamentos_Clientes];


GO
PRINT N'Update complete.';


GO
