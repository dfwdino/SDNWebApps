CREATE TABLE [Weight].[CardioLog] (
    [ID]             INT             IDENTITY (1, 1) NOT NULL,
    [CardioItemID]   INT             NOT NULL,
    [Time]           DECIMAL (18, 2) NOT NULL,
    [CaloriesBurned] FLOAT (53)      NOT NULL,
    [WorkoutDate]    DATE            NOT NULL,
    [CreatedTime]    DATETIME        CONSTRAINT [DF_CardoLog_CreatedTime] DEFAULT (getdate()) NOT NULL,
    [Deleted]        BIT             CONSTRAINT [DF_CardoLog_Deleted] DEFAULT ((0)) NOT NULL,
    [CreatedBy]      INT             NOT NULL,
    [Distance]       DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_CardoLog] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_CardoLog_Items] FOREIGN KEY ([CardioItemID]) REFERENCES [Weight].[CardioItems] ([ID]),
    CONSTRAINT [FK_CardoLog_People] FOREIGN KEY ([CreatedBy]) REFERENCES [Gas].[People] ([ID])
);



