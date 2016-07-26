CREATE PROCEDURE [dbo].[UpdateAulas]
	@Id int,

	@Segunda BIT,
	@SegIn DATETIME = NULL,
	@SegFim DATETIME = NULL,

	@Terca BIT,
	@TerIn DATETIME = NULL,
	@TerFim DATETIME = NULL,

	@Quarta BIT,
	@QuaIn DATETIME = NULL,
	@QuaFim DATETIME = NULL,

	@Quinta BIT,
	@QuiIn DATETIME = NULL,
	@QuiFim DATETIME = NULL,

	@Sexta BIT,
	@SexIn DATETIME = NULL,
	@SexFim DATETIME = NULL
AS

	DELETE Aulas WHERE IdCliente = @Id

	IF (@Segunda = 1)
	BEGIN
		INSERT INTO Aulas (IdCliente, Dia, Inicio, Fim) VALUES (@Id, 1, @SegIn, @SegFim)
	END

	IF (@Terca = 1)
	BEGIN
		INSERT INTO Aulas (IdCliente, Dia, Inicio, Fim) VALUES (@Id, 2, @TerIn, @TerFim)
	END

	IF (@Quarta = 1)
	BEGIN
		INSERT INTO Aulas (IdCliente, Dia, Inicio, Fim) VALUES (@Id, 3, @QuaIn, @QuaFim)
	END

	IF (@Quinta = 1)
	BEGIN
		INSERT INTO Aulas (IdCliente, Dia, Inicio, Fim) VALUES (@Id, 4, @QuiIn, @QuiFim)
	END

	IF (@Sexta = 1)
	BEGIN
		INSERT INTO Aulas (IdCliente, Dia, Inicio, Fim) VALUES (@Id, 5, @SexIn, @SexFim)
	END
