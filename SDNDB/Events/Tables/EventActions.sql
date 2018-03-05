CREATE TABLE [Events].[EventActions] (
    [ID]        UNIQUEIDENTIFIER NOT NULL,
    [ActionID]  UNIQUEIDENTIFIER NOT NULL,
    [Deleted]   BIT              CONSTRAINT [DF_EventActions_Deleted] DEFAULT ((0)) NOT NULL,
    [EventID]   UNIQUEIDENTIFIER NOT NULL,
    [IPAddress] NVARCHAR (25)    NULL,
    [Longitude] NVARCHAR (25)    NULL,
    [Latitude]  NVARCHAR (25)    NULL,
    CONSTRAINT [PK_EventActions] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EventActions_Actions] FOREIGN KEY ([ActionID]) REFERENCES [Events].[ActionType] ([ID]),
    CONSTRAINT [FK_EventActions_Events] FOREIGN KEY ([EventID]) REFERENCES [Events].[Events] ([ID])
);

