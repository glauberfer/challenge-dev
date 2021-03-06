CREATE DATABASE [Challenge]

GO 

USE [Challenge]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carros](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MotoristaID] [int] NOT NULL,
	[Modelo] [nvarchar](max) NOT NULL,
	[Placa] [nvarchar](max) NOT NULL,
	[Marca] [nvarchar](max) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataExclusao] [datetime] NULL,
 CONSTRAINT [PK_dbo.Carros] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Motoristas]    Script Date: 10/06/2018 22:23:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Motoristas](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PrimeiroNome] [nvarchar](max) NOT NULL,
	[UltimoNome] [nvarchar](max) NOT NULL,
	[Endereco] [nvarchar](max) NOT NULL,
	[DataCadastro] [datetime] NOT NULL,
	[DataExclusao] [datetime] NULL,
	[EnderecoMaps] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Motorista] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
ALTER TABLE [dbo].[Carros]  WITH CHECK ADD FOREIGN KEY([MotoristaID])
REFERENCES [dbo].[Motoristas] ([ID])
GO
