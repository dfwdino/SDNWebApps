CREATE TABLE [Events].[PeopleSTICheck] (
    [ID]             INT              IDENTITY (1, 1) NOT NULL,
    [EventPerson]    UNIQUEIDENTIFIER NOT NULL,
    [CheckDate]      DATE             NULL,
    [OverAllResults] BIT              CONSTRAINT [DF_PeopleSTICheck_OverAllResults] DEFAULT ((0)) NULL,
    [Notes]          VARCHAR (MAX)    NULL,
    [IPAddress]      VARCHAR (15)     NULL,
    [Longitude]      DECIMAL (9, 6)   NULL,
    [Latitude]       DECIMAL (9, 6)   NULL,
    [CreatedOn]      DATETIME         CONSTRAINT [DF_PeopleSTICheck_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [ChangedOn]      DATETIME         NULL,
    [Deleted]        BIT              CONSTRAINT [DF_PeopleSTICheck_Deleted] DEFAULT ((0)) NULL,
    [Browser]        VARCHAR (250)    NULL,
    CONSTRAINT [PK__PeopleST__3214EC276F64574F] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_PeopleSTICheck_People] FOREIGN KEY ([EventPerson]) REFERENCES [Events].[People] ([ID])
);

