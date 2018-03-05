CREATE TABLE [Dreams].[Dreams] (
    [ID]            UNIQUEIDENTIFIER CONSTRAINT [DF_Dreams_ID] DEFAULT (newid()) NOT NULL,
    [Date]          DATE             NOT NULL,
    [Dream]         NVARCHAR (MAX)   NOT NULL,
    [Person]        INT              NULL,
    [DidMeditation] BIT              CONSTRAINT [DF_Dreams_DidDeditation] DEFAULT ((1)) NOT NULL,
    [Deleted]       BIT              CONSTRAINT [DF_Dreams_Deleted] DEFAULT ((0)) NOT NULL,
    [Links]         NVARCHAR (MAX)   NULL,
    [IPAddress]     NVARCHAR (25)    NULL,
    [Longitude]     NVARCHAR (25)    NULL,
    [Latitude]      NVARCHAR (25)    NULL,
    CONSTRAINT [PK_Dreams] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Dreams_People] FOREIGN KEY ([Person]) REFERENCES [Gas].[People] ([ID])
);

