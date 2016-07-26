CREATE PROCEDURE [dbo].[UpdateTelefones]
	@Id INT,
	@Telefone1 VARCHAR (MAX) = NULL,
	@Telefone2 VARCHAR (MAX) = NULL
AS
BEGIN
	DELETE Telefones WHERE IdCliente = @Id

	if(@Telefone1 IS NOT NULL)
	BEGIN
		INSERT INTO Telefones (IdCliente, Ordem, Telefone) VALUES (@Id, 1, @Telefone1)
	END

	if(@Telefone2 IS NOT NULL)
	BEGIN
		INSERT INTO Telefones (IdCliente, Ordem, Telefone) VALUES (@Id, 2, @Telefone2)
	END
END
