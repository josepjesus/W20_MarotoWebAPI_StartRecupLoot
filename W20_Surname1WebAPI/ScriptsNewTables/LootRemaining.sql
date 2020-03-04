CREATE TABLE [dbo].[LootRemaining] (
    [Id]     INT NOT NULL,
    [Points] INT DEFAULT ((1000)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
