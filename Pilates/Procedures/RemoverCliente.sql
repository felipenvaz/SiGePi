CREATE PROCEDURE [dbo].[RemoverCliente]
	@Id INT
AS
	DELETE Aulas WHERE IdCliente = @Id
	DELETE Telefones WHERE IdCliente = @Id
	DELETE Pagamentos WHERE IdCliente = @Id
	DELETE Clientes WHERE Id = @Id
