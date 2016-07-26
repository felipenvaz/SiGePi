CREATE TABLE [dbo].[Pagamentos]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[IdCliente] INT NOT NULL,
	[Data] DATETIME NOT NULL,
	[Valor] INT NOT NULL, 
    CONSTRAINT [FK_Pagamentos_Clientes] FOREIGN KEY ([IdCLiente]) REFERENCES [Clientes]([Id])
)
