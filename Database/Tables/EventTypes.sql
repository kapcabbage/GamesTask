CREATE TABLE [dbo].[EventTypes]
(
	[EventTypeId] INT NOT NULL IDENTITY(1,1),
	[Name] VARCHAR(100) NOT NULL,

	CONSTRAINT [PK_EventTypeId] PRIMARY KEY ([EventTypeId])
)
