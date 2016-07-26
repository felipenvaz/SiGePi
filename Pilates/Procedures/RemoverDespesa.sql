CREATE PROCEDURE [dbo].[RemoverDespesa]
	@Id INT
AS
BEGIN
Delete Despesas WHERE Id = @Id
END
