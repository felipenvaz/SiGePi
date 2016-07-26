CREATE TABLE [dbo].[Telefones]
(
	[IdCliente] INT NOT NULL,
	[Ordem] INT NOT NULL,
	[Telefone] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Telefones_Clientes] FOREIGN KEY ([IdCliente]) REFERENCES [Clientes]([Id]), 
    CONSTRAINT [PK_Telefones] PRIMARY KEY ([IdCliente], [Ordem])
)
