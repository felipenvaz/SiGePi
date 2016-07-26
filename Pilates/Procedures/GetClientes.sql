CREATE PROCEDURE [dbo].[GetClientes]
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
