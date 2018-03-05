CREATE TABLE [Baby].[Reminders] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Deleted]     BIT           CONSTRAINT [DF__Reminders__Delet__2354350C] DEFAULT ((0)) NOT NULL,
    [IPAddress]   NVARCHAR (25) NULL,
    [Longitude]   NVARCHAR (25) NULL,
    [Latitude]    NVARCHAR (25) NULL,
    [StartDate]   DATETIME      NOT NULL,
    [EndDate]     DATETIME      NULL,
    [ActionID]    INT           NOT NULL,
    [RemeberType] INT           NOT NULL,
    [Every]       INT           NOT NULL,
    CONSTRAINT [PK_Reminders] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Reminders_Actions] FOREIGN KEY ([ActionID]) REFERENCES [Baby].[Actions] ([index]),
    CONSTRAINT [FK_Reminders_ReminderTypes] FOREIGN KEY ([RemeberType]) REFERENCES [Baby].[ReminderTypes] ([ID])
);

