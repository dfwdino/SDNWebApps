CREATE TABLE [Baby].[ReminderTypes] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [Type]      NVARCHAR (25) NOT NULL,
    [Deleted]   BIT           CONSTRAINT [DF__ReminderT__Delet__1E8F7FEF] DEFAULT ((0)) NOT NULL,
    [IPAddress] NVARCHAR (25) NULL,
    [Longitude] NVARCHAR (25) NULL,
    [Latitude]  NVARCHAR (25) NULL,
    CONSTRAINT [PK_ReminderTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

