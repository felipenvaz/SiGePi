CREATE PROCEDURE [dbo].[InserirDespesa]
	@Id INT OUTPUT,
	@Descricao VARCHAR(MAX) = NULL,
	@Valor DECIMAL,
	@Data DATETIME
AS
BEGIN
	INSERT INTO Despesas (Descricao, Valor, Data) values (@Descricao, @Valor, @Data)

	SET @Id = SCOPE_IDENTITY();
END
