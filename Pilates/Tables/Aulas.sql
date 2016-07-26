CREATE TABLE [dbo].[Aulas]
(
	[IdCliente] INT NOT NULL,
	[Dia] INT NOT NULL,
	[Inicio] DATETIME NOT NULL,
	[Fim] DATETIME NOT NULL, 
    CONSTRAINT [PK_Aulas] PRIMARY KEY ([IdCliente], [Dia])
)
