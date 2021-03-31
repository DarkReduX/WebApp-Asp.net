CREATE TABLE [dbo].[PostLike] (
    [Id]       INT NOT NULL,
    [UserId]   INT NOT NULL,
    [NewsId]   INT NOT NULL,
    [UserLike] BIT NULL,
    PRIMARY KEY CLUSTERED ([UserId])
);

