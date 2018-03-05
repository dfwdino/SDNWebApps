CREATE TABLE [Events].[WhoWhatTo] (
    [ID]               UNIQUEIDENTIFIER NOT NULL,
    [Who]              UNIQUEIDENTIFIER NOT NULL,
    [DidWhat]          UNIQUEIDENTIFIER NOT NULL,
    [ToWho]            UNIQUEIDENTIFIER NULL,
    [Deleted]          BIT              CONSTRAINT [DF_WhoWhatTo_Deleted] DEFAULT ((0)) NOT NULL,
    [EventID]          UNIQUEIDENTIFIER NOT NULL,
    [WDTRating]        INT              NULL,
    [ProtectionTypeID] INT              NULL,
    [IPAddress]        NVARCHAR (25)    NULL,
    [Longitude]        NVARCHAR (25)    NULL,
    [Latitude]         NVARCHAR (25)    NULL,
    CONSTRAINT [PK_WhoWhatTo] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_WhoWhatTo_ActionType] FOREIGN KEY ([DidWhat]) REFERENCES [Events].[ActionType] ([ID]),
    CONSTRAINT [FK_WhoWhatTo_Events] FOREIGN KEY ([EventID]) REFERENCES [Events].[Events] ([ID]),
    CONSTRAINT [FK_WhoWhatTo_People] FOREIGN KEY ([Who]) REFERENCES [Events].[People] ([ID]),
    CONSTRAINT [FK_WhoWhatTo_People1] FOREIGN KEY ([ToWho]) REFERENCES [Events].[People] ([ID]),
    CONSTRAINT [FK_WhoWhatTo_ProtectionType] FOREIGN KEY ([ProtectionTypeID]) REFERENCES [Events].[ProtectionType] ([ID]),
    CONSTRAINT [FK_WhoWhatTo_WhoWhatTo] FOREIGN KEY ([ID]) REFERENCES [Events].[WhoWhatTo] ([ID])
);

