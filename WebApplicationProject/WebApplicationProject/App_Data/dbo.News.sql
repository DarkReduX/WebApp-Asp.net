CREATE TABLE [dbo].[News] (
    [ID]     INT             IDENTITY (1, 1) NOT NULL,
    [header] NVARCHAR (MAX)  NOT NULL,
    [info]   NVARCHAR (MAX)  NOT NULL,
    [Image]  VARBINARY (MAX) NULL,
    [UserId] INT  NULL,
    CONSTRAINT [PK_dbo.News] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_dbo.News] FOREIGN KEY (UserId) REFERENCES [dbo].[PostLike](UserId)
);

