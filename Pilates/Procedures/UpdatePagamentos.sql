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
