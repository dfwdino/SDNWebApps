CREATE TABLE [Events].[Locations] (
    [ID]        UNIQUEIDENTIFIER NOT NULL,
    [Name]      NVARCHAR (MAX)   NOT NULL,
    [Deleted]   BIT              CONSTRAINT [DF_Locations_Deleted] DEFAULT ((0)) NOT NULL,
    [Created]   DATETIME         CONSTRAINT [DF_Locations_Created] DEFAULT (getdate()) NULL,
    [Updated]   DATETIME         NULL,
    [IPAddress] NVARCHAR (25)    NULL,
    [Longitude] NVARCHAR (25)    NULL,
    [Latitude]  NVARCHAR (25)    NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY CLUSTERED ([ID] ASC)
);

