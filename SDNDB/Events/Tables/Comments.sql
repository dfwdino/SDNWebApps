CREATE TABLE [Events].[Comments] (
    [CommentID] INT              NOT NULL,
    [EventID]   UNIQUEIDENTIFIER NOT NULL,
    [Comment]   NVARCHAR (MAX)   NULL,
    [CreatedOn] DATETIME         CONSTRAINT [DF_Comments_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedOn] DATETIME         NULL,
    [IPAddress] NVARCHAR (15)    NULL,
    [Broswer]   NVARCHAR (100)   NULL,
    [Deleted]   BIT              CONSTRAINT [DF_Comments_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED ([CommentID] ASC),
    CONSTRAINT [FK_Comments_Events] FOREIGN KEY ([EventID]) REFERENCES [Events].[Events] ([ID])
);

