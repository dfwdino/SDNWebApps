CREATE TABLE [Task].[Tasks] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (MAX) NOT NULL,
    [DueDate]   DATE           NULL,
    [Done]      BIT            CONSTRAINT [DF_Task.Tasks_Done] DEFAULT ((0)) NOT NULL,
    [PersonID]  INT            NOT NULL,
    [IPAddress] NVARCHAR (25)  NULL,
    [Longitude] NVARCHAR (25)  NULL,
    [Latitude]  NVARCHAR (25)  NULL,
    [Deleted]   BIT            NULL,
    CONSTRAINT [PK_Task.Tasks] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Tasks_People1] FOREIGN KEY ([PersonID]) REFERENCES [Gas].[People] ([ID])
);

