USE [master]

-- Database [Fixture]
IF (NOT EXISTS (SELECT 1 FROM sys.sysdatabases WHERE name = 'Fixture' ))
BEGIN
     CREATE DATABASE Fixture
END
GO

-- Set compatibility to SqlServer 2012
ALTER DATABASE [Fixture] SET COMPATIBILITY_LEVEL = 110
GO

USE [Fixture]
GO

-- Login [fixtureUser]
IF (NOT EXISTS (SELECT 1 FROM sys.syslogins where name = 'fixtureUser'))
BEGIN
	CREATE LOGIN [fixtureUser]
			WITH PASSWORD = 'argentina',
			DEFAULT_DATABASE = [Fixture],
			CHECK_EXPIRATION = OFF,
			CHECK_POLICY = OFF
END
GO

-- User [fixtureUser]
IF (NOT EXISTS (SELECT 1 FROM fixture.sys.database_principals where name = 'fixtureUser' ))
BEGIN
	CREATE USER [fixtureUser] FOR LOGIN [fixtureUser] WITH DEFAULT_SCHEMA = [fixture]
END
GO

-- Schema [fixture]
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'fixture')
BEGIN
	EXEC('CREATE SCHEMA [fixture]');
END
GO

GRANT SELECT ON SCHEMA::fixture TO fixtureUser
GRANT INSERT ON SCHEMA::fixture TO fixtureUser
GRANT UPDATE ON SCHEMA::fixture TO fixtureUser
GRANT DELETE ON SCHEMA::fixture TO fixtureUser
GRANT EXECUTE ON SCHEMA::fixture TO fixtureUser

-- Login [reporter]
IF (NOT EXISTS (SELECT 1 FROM sys.syslogins WHERE name = 'reporter'))
BEGIN
	CREATE LOGIN [reporter]
			WITH PASSWORD = 'argentina',
			DEFAULT_DATABASE = Fixture,
			CHECK_EXPIRATION = OFF,
			CHECK_POLICY = OFF
END
GO

-- User [reporter]
IF (NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'reporter'))
BEGIN
	CREATE USER [reporter] FOR LOGIN reporter WITH DEFAULT_SCHEMA = [report]
END
GO

-- Schema [reporter]
IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = 'report')
BEGIN
	EXEC('CREATE SCHEMA [report]')
END
GO

GRANT SELECT ON SCHEMA::report TO reporter
GRANT INSERT ON SCHEMA::report TO reporter
GRANT UPDATE ON SCHEMA::report TO reporter
GRANT DELETE ON SCHEMA::report TO reporter
GRANT EXECUTE ON SCHEMA::report TO reporter

-- Table [fixture].[MatchType] : Represents the type of match in the tournament, e.g. "Semifinal", "Final"
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'fixture' AND TABLE_NAME = 'MatchType')
BEGIN
	CREATE TABLE [fixture].[MatchType](
		[Id] [int] NOT NULL IDENTITY(1,1),
		[Name] [nvarchar](50) NOT NULL,
	 CONSTRAINT [PK_MatchType] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)
	)
END
GO

-- Table [fixture].[Team] : Represents the playing teams
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'fixture' AND TABLE_NAME = 'Team')
BEGIN
	CREATE TABLE [fixture].[Team](
		[Id] [int] NOT NULL IDENTITY(1,1),
		[Name] [nvarchar](50) NOT NULL,
	 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)
	)
END
GO

-- Table [fixture].[Tournament] : Represents the tournament, e.g. "Copa América Centenario"
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'fixture' AND TABLE_NAME = 'Tournament')
BEGIN
	CREATE TABLE [fixture].[Tournament](
		[Id] [int] NOT NULL IDENTITY(1,1),
		[Name] [nvarchar](50) NOT NULL,
	 CONSTRAINT [PK_Tournament] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)
	)
END
GO

-- Table [fixture].[Match] : Table representing the matchs in a tournament
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'fixture' AND TABLE_NAME = 'Match')
BEGIN
	CREATE TABLE [fixture].[Match](
		[Id] [int] NOT NULL IDENTITY(1,1),
		[TournamentId] [int] NOT NULL,
		[HomeTeamId] [int] NOT NULL,
		[AwayTeamId] [int] NOT NULL,
		[HomeTeamGoals] [int] NULL,
		[AwayTeamGoals] [int] NULL,
		[TypeId] [int] NULL,		
		[Date] [date] NULL,
	 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED
		(
			[Id] ASC
		)
	)
END
GO

-- Match-Team Many to one relationship on AwayTeamId-Id
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Match_AwayTeam')
BEGIN
	ALTER TABLE [fixture].[Match]  WITH CHECK ADD CONSTRAINT [FK_Match_AwayTeam] FOREIGN KEY([AwayTeamId])
	REFERENCES [fixture].[Team] ([Id])
END
GO

-- Match-Team Many to one relationship on HomeTeamId-Id
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Match_HomeTeam')
BEGIN
	ALTER TABLE [fixture].[Match]  WITH CHECK ADD CONSTRAINT [FK_Match_HomeTeam] FOREIGN KEY([HomeTeamId])
	REFERENCES [fixture].[Team] ([Id])
END
GO

-- Match-MatchType Many to one relationship on TypeId-Id
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Match_MatchType')
BEGIN
	ALTER TABLE [fixture].[Match]  WITH CHECK ADD CONSTRAINT [FK_Match_MatchType] FOREIGN KEY([TypeId])
	REFERENCES [fixture].[MatchType] ([Id])
END
GO

-- Match-Tournament Many to one relationship on TournamentId-Id
IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Match_TournamentId')
BEGIN
	ALTER TABLE [fixture].[Match]  WITH CHECK ADD CONSTRAINT [FK_Match_TournamentId] FOREIGN KEY([TournamentId]) 
	REFERENCES [fixture].[Tournament] ([Id])
	ON DELETE CASCADE
END
GO