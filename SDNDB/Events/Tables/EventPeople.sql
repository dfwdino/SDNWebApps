CREATE TABLE [Events].[EventPeople] (
    [ID]        UNIQUEIDENTIFIER NOT NULL,
    [PeopleID]  UNIQUEIDENTIFIER NOT NULL,
    [Deleted]   BIT              NOT NULL,
    [EventID]   UNIQUEIDENTIFIER NOT NULL,
    [IPAddress] NVARCHAR (25)    NULL,
    [Longitude] NVARCHAR (25)    NULL,
    [Latitude]  NVARCHAR (25)    NULL,
    CONSTRAINT [PK_EventPeople] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_EventPeople_Events] FOREIGN KEY ([EventID]) REFERENCES [Events].[Events] ([ID]),
    CONSTRAINT [FK_EventPeople_People] FOREIGN KEY ([PeopleID]) REFERENCES [Events].[People] ([ID])
);

