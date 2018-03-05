CREATE TABLE [Events].[PositionsDid] (
    [ID]             INT              IDENTITY (1, 1) NOT NULL,
    [PositionID]     INT              NOT NULL,
    [Deleted]        BIT              CONSTRAINT [DF_PositionsDid__Deleted] DEFAULT ((0)) NOT NULL,
    [EventID]        UNIQUEIDENTIFIER NOT NULL,
    [PositionRating] INT              NULL,
    [CumInside]      BIT              CONSTRAINT [DF_PositionsDid_CumInside] DEFAULT ((0)) NOT NULL,
    [IPAddress]      NVARCHAR (25)    NULL,
    [Longitude]      NVARCHAR (25)    NULL,
    [Latitude]       NVARCHAR (25)    NULL,
    CONSTRAINT [PK_PositionsDid] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PositionsDid_Events] FOREIGN KEY ([EventID]) REFERENCES [Events].[Events] ([ID]),
    CONSTRAINT [FK_PositionsDid_Positions] FOREIGN KEY ([PositionID]) REFERENCES [Events].[Positions] ([ID])
);

