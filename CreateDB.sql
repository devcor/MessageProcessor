USE [master]
GO

CREATE DATABASE [WordProcessor]
GO
USE [WordProcessor]
GO
CREATE TABLE [dbo].[Message](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Input] [varchar](max) NOT NULL,
	[Characters] [bigint] NOT NULL,
	[Words] [int] NOT NULL,
	[Sentences] [int] NOT NULL,
	[Paragraphs] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO