CREATE TABLE [Events].[EventLocation] (
    [ID]         UNIQUEIDENTIFIER NOT NULL,
    [LocationID] UNIQUEIDENTIFIER NOT NULL,
    [Deleted]    BIT              NOT NULL,
    [EventID]    UNIQUEIDENTIFIER NOT NULL,
    [IPAddress]  NVARCHAR (25)    NULL,
    [Longitude]  NVARCHAR (25)    NULL,
    [Latitude]   NVARCHAR (25)    NULL,
    CONSTRAINT [PK_EventLocation] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EventLocation_Events] FOREIGN KEY ([EventID]) REFERENCES [Events].[Events] ([ID]),
    CONSTRAINT [FK_EventLocation_Locations] FOREIGN KEY ([LocationID]) REFERENCES [Events].[Locations] ([ID])
);

