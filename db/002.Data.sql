USE [Fixture]

IF NOT EXISTS(SELECT 1 FROM [fixture].[Tournament])
BEGIN
	INSERT INTO [fixture].[Tournament] ([Name])
	VALUES ('Copa América Centenario')
END
GO

IF EXISTS(SELECT 1 FROM [fixture].[MatchType])
BEGIN			
	IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS WHERE CONSTRAINT_NAME ='FK_Match_MatchType')
	BEGIN
		--Truncates Match table to safely truncate MatchType table
		TRUNCATE TABLE [fixture].[Match]

		--Drops foreign key constraint that references MatchType
		ALTER TABLE [fixture].[Match]
		DROP CONSTRAINT [FK_Match_MatchType]

		--Truncates Table
		TRUNCATE TABLE [fixture].[MatchType]

		--Recreates foreign key constraint
		ALTER TABLE [fixture].[Match]  WITH CHECK ADD CONSTRAINT [FK_Match_MatchType] FOREIGN KEY([TypeId])
		REFERENCES [fixture].[MatchType] ([Id])
	END
END
	INSERT INTO [fixture].[MatchType] ([Name])
	VALUES ('Cuartos de Final')

	INSERT INTO [fixture].[MatchType] ([Name])
	VALUES ('Semifinal')

	INSERT INTO [fixture].[MatchType] ([Name])
	VALUES ('Final')
GO


IF NOT EXISTS(SELECT 1 FROM [fixture].[Team])
BEGIN
	INSERT INTO [fixture].[Team] ([Name])
	VALUES ('Argentina');

	INSERT INTO [fixture].[Team] ([Name])
	VALUES ('Venezuela');

	INSERT INTO [fixture].[Team] ([Name])
	VALUES ('USA');

	INSERT INTO [fixture].[Team] ([Name])
	VALUES ('Ecuador');

	INSERT INTO [fixture].[Team] ([Name])
	VALUES ('Perú');

	INSERT INTO [fixture].[Team] ([Name])
	VALUES ('Colombia');

	INSERT INTO [fixture].[Team] ([Name])
	VALUES ('Chile');

	INSERT INTO [fixture].[Team] ([Name])
	VALUES ('México');
END
GO

DECLARE
@AmericanCupTournamentId int = (SELECT TOP 1 [Id] FROM [fixture].[Tournament] WHERE [Name] = 'Copa América Centenario'),
@CuarterFinalsId int = (SELECT TOP 1 [Id] FROM [fixture].[MatchType] WHERE [Name] = 'Cuartos de Final'),
@ArgentinaTeamId int = (SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Argentina'),
@VenezuelaTeamId int = (SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Venezuela'),
@USATeamId int = (SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'USA'),
@EcuadorTeamId int = (SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Ecuador'),
@PeruTeamId int = (SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Perú'),
@ColombiaTeamId int = (SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Colombia'),
@MexicoTeamId int = (SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'México'),
@ChileTeamId int = (SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Chile');

IF NOT EXISTS(SELECT 1 FROM [fixture].[Match])
BEGIN
	INSERT INTO [fixture].[Match] ([TournamentId], [TypeId], [HomeTeamId], [AwayTeamId], [HomeTeamGoals], [AwayTeamGoals], [Date])
	VALUES(
		@AmericanCupTournamentId,
		@CuarterFinalsId,
		@ArgentinaTeamId,
		@VenezuelaTeamId,
		4,
		1,
		'2016-07-04'
	)
	INSERT INTO [fixture].[Match] ([TournamentId], [TypeId], [HomeTeamId], [AwayTeamId], [HomeTeamGoals], [AwayTeamGoals], [Date])
	VALUES(
		@AmericanCupTournamentId,
		@CuarterFinalsId,
		@USATeamId,
		@EcuadorTeamId,
		4,
		1,
		'2016-07-04'
	)
	INSERT INTO [fixture].[Match] ([TournamentId], [TypeId], [HomeTeamId], [AwayTeamId], [HomeTeamGoals], [AwayTeamGoals], [Date])
	VALUES(
		@AmericanCupTournamentId,
		@CuarterFinalsId,
		@PeruTeamId,
		@ColombiaTeamId,
		4,
		1,
		'2016-07-04'
	)
	INSERT INTO [fixture].[Match] ([TournamentId], [TypeId], [HomeTeamId], [AwayTeamId], [HomeTeamGoals], [AwayTeamGoals], [Date])
	VALUES(
		@AmericanCupTournamentId,
		@CuarterFinalsId,
		@MexicoTeamId,
		@ChileTeamId,
		4,
		1,
		'2016-07-04'
	)
END
GO