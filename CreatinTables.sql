
CREATE TABLE [dbo].[Posts]
(
	[IdPost] INT NOT NULL PRIMARY KEY,
	[Description] TEXT NOT NULL,
	[IdThread] INT NOT NULL,
	FOREIGN KEY(IdThread) REFERENCES Threads(IdThread)
);