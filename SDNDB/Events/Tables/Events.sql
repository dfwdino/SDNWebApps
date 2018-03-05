CREATE TABLE [Events].[Events] (
    [ID]            UNIQUEIDENTIFIER ROWGUIDCOL NOT NULL,
    [Title]         NVARCHAR (MAX)   NULL,
    [Notes]         NVARCHAR (MAX)   NULL,
    [Rating]        INT              NULL,
    [Date]          DATETIME         NOT NULL,
    [Came]          INT              NULL,
    [BroserInfo]    NVARCHAR (MAX)   NULL,
    [IPAddress]     NVARCHAR (20)    NULL,
    [UpdatedOn]     DATETIME         NULL,
    [OwnerID]       UNIQUEIDENTIFIER NULL,
    [Orgasms]       INT              NULL,
    [Squirt]        INT              CONSTRAINT [DF_Events_Squrit] DEFAULT ((0)) NULL,
    [CumLocationID] INT              CONSTRAINT [DF_Events_CumLocationID] DEFAULT (NULL) NULL,
    [Deleted]       BIT              CONSTRAINT [DF_Events_Deleted] DEFAULT ((0)) NOT NULL,
    [CreatedOn]     DATETIME         CONSTRAINT [DF_Events_CreatedOn] DEFAULT (getdate()) NULL,
    [Latitude]      NVARCHAR (20)    NULL,
    [Longitude]     NVARCHAR (20)    NULL,
    CONSTRAINT [PK_Events] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_CumLocation] FOREIGN KEY ([CumLocationID]) REFERENCES [Events].[CumLocation] ([ID]),
    CONSTRAINT [FK_Events_Events] FOREIGN KEY ([ID]) REFERENCES [Events].[Events] ([ID]),
    CONSTRAINT [FK_Events_Owners] FOREIGN KEY ([OwnerID]) REFERENCES [Events].[Owners] ([OwnerID])
);

