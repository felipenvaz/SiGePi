CREATE TABLE [dbo].[Clientes] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (MAX) NOT NULL,
	[Cpf] VARCHAR (MAX) NULL,
	[Endereco] VARCHAR (MAX) NULL,
	[Email] VARCHAR (MAX) NULL,

	[DataNascimento] DATETIME NULL,

	[Profissao] VARCHAR (MAX) NULL,
	[QuemIndicou] VARCHAR (MAX) NULL,

	[ComoConheceu] INT NOT NULL,

	[PraticaAtividade] VARCHAR (MAX) NULL,
	[Medicacao] VARCHAR (MAX) NULL,

	[Riscos] INT NOT NULL,

	[Doenca] VARCHAR (MAX) NULL,
	[Dor] VARCHAR (MAX) NULL,
	[Objetivo] VARCHAR (MAX) NULL,
	[ExamesComplementares] VARCHAR (MAX) NULL,
	[Observacao] VARCHAR (MAX) NULL,

	[Pes] INT NOT NULL,
	[Joelhos] INT NOT NULL,
	[Pelve] INT NOT NULL,
	[Coluna] INT NOT NULL,
	[Ombros] INT NOT NULL,
	[Cabeca] INT NOT NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC)
);