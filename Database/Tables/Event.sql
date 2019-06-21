CREATE TABLE [dbo].[Event]
(
	[EventId] INT NOT NULL IDENTITY (1,1),
	[GameId] INT NOT NULL,
	[EventTypeId] INT NOT NULL,
	[TimeStamp] DATETIME NOT NULL,
	[Source] VARCHAR(20) NOT NULL,

	CONSTRAINT [PK_EventId] PRIMARY KEY ([EventId]),
	CONSTRAINT [FK_GameId] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Games]([GameId])
)
