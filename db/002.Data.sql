USE [Fixture]

IF NOT EXISTS(SELECT 1 FROM [fixture].[Tournament])
BEGIN
	INSERT INTO [fixture].[Tournament] ([Name])
	VALUES ('Copa América Centenario')
END
GO

IF EXISTS(SELECT 1 FROM [fixture].[MatchType])
BEGIN
	--Deletes Teams with foreign key to MatchType, should probably remove all rows from table
	DELETE FROM [fixture].[Match] WHERE [TypeId] IS NOT NULL

	--Para truncar la tabla MatchType tengo que dropear las constraints y volverlas a generar, 
	--o hacer un ALTER SWITCH a otra tabla con la misma estructura pero sin constraints
	DELETE FROM [fixture].[MatchType]
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


IF NOT EXISTS(SELECT 1 FROM [fixture].[Match])
BEGIN
	INSERT INTO [fixture].[Match] ([TournamentId], [TypeId], [HomeTeamId], [AwayTeamId], [HomeTeamGoals], [AwayTeamGoals], [Date])
	VALUES(
		(SELECT TOP 1 [Id] FROM [fixture].[Tournament] WHERE [Name] = 'Copa América Centenario'),
		(SELECT TOP 1 [Id] FROM [fixture].[MatchType] WHERE [Name] = 'Cuartos de Final'),
		(SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Argentina'),
		(SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Venezuela'),
		4,
		1,
		'2016-07-04'
	)
	INSERT INTO [fixture].[Match] ([TournamentId], [TypeId], [HomeTeamId], [AwayTeamId], [HomeTeamGoals], [AwayTeamGoals], [Date])
	VALUES(
		(SELECT TOP 1 [Id] FROM [fixture].[Tournament] WHERE [Name] = 'Copa América Centenario'),
		(SELECT TOP 1 [Id] FROM [fixture].[MatchType] WHERE [Name] = 'Cuartos de Final'),
		(SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'USA'),
		(SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Ecuador'),
		4,
		1,
		'2016-07-04'
	)
	INSERT INTO [fixture].[Match] ([TournamentId], [TypeId], [HomeTeamId], [AwayTeamId], [HomeTeamGoals], [AwayTeamGoals], [Date])
	VALUES(
		(SELECT TOP 1 [Id] FROM [fixture].[Tournament] WHERE [Name] = 'Copa América Centenario'),
		(SELECT TOP 1 [Id] FROM [fixture].[MatchType] WHERE [Name] = 'Cuartos de Final'),
		(SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Perú'),
		(SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Colombia'),
		4,
		1,
		'2016-07-04'
	)
	INSERT INTO [fixture].[Match] ([TournamentId], [TypeId], [HomeTeamId], [AwayTeamId], [HomeTeamGoals], [AwayTeamGoals], [Date])
	VALUES(
		(SELECT TOP 1 [Id] FROM [fixture].[Tournament] WHERE [Name] = 'Copa América Centenario'),
		(SELECT TOP 1 [Id] FROM [fixture].[MatchType] WHERE [Name] = 'Cuartos de Final'),
		(SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'México'),
		(SELECT TOP 1 [Id] FROM [fixture].[Team] WHERE [Name] = 'Chile'),
		4,
		1,
		'2016-07-04'
	)	
END
GO