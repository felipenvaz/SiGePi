﻿CREATE TABLE [dbo].[Despesas]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Descricao] VARCHAR(MAX) NULL,
	[Valor] DECIMAL NOT NULL,
	[Data] DATETIME NOT NULL
)
