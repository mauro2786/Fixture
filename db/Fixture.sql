USE [master]
GO

/* Database [Fixture] */
CREATE DATABASE [Fixture]
GO

/*Set compatibility to SqlServer 2012*/
ALTER DATABASE [Fixture] SET COMPATIBILITY_LEVEL = 110
GO

USE [Fixture]
GO

/* User [fixtureU] */
CREATE USER [fixtureU] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO

/* Schema [fixture] */
CREATE SCHEMA [fixture]
GO

/* User [reportU] */
CREATE USER [reportU] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO

/* Schema [report] */
CREATE SCHEMA [report]
GO

/* Table [fixture].[MatchType] : Represents the type of match in the tournament, e.g. "Semifinal", "Final" */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [fixture].[MatchType](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__MatchType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY]
GO

/* Table [fixture].[Team] : Represents the playing teams */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [fixture].[Team](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Team] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY]
GO

/* Table [fixture].[Tournament] : Represents the tournament, e.g. "Copa América Centenario" */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [fixture].[Tournament](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__Tourname__3214EC0734D92CEA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/* Table [fixture].[Match] : Table representing the matchs in a tournament */
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [fixture].[Match](
	[Id] [int] NOT NULL,
	[HomeTeamId] [int] NOT NULL,
	[AwayTeamId] [int] NOT NULL,
	[HomeTeamGoals] [int] NULL,
	[AwayTeamGoals] [int] NULL,
	[TypeId] [int] NULL,
 CONSTRAINT [PK__Match] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)
) ON [PRIMARY]
GO

ALTER TABLE [fixture].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_AwayTeam] FOREIGN KEY([AwayTeamId])
REFERENCES [fixture].[Team] ([Id])
GO

ALTER TABLE [fixture].[Match] CHECK CONSTRAINT [FK_Match_AwayTeam]
GO

ALTER TABLE [fixture].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_HomeTeam] FOREIGN KEY([HomeTeamId])
REFERENCES [fixture].[Team] ([Id])
GO

ALTER TABLE [fixture].[Match] CHECK CONSTRAINT [FK_Match_HomeTeam]
GO

ALTER TABLE [fixture].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_MatchType] FOREIGN KEY([TypeId])
REFERENCES [fixture].[MatchType] ([Id])
GO

ALTER TABLE [fixture].[Match] CHECK CONSTRAINT [FK_Match_MatchType]
GO
