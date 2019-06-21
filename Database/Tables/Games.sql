CREATE TABLE [dbo].[Games]
(
	[GameId] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,
	[MinPlayers] INT NOT NULL,
	[MaxPlayers] INT NOT NULL,
	[RecommendedAge] INT NOT NULL

	CONSTRAINT [PK_GameId] PRIMARY KEY ([GameId])
)
