CREATE TABLE [Events].[ActionType] (
    [ID]        UNIQUEIDENTIFIER CONSTRAINT [DF_Actions_ID] DEFAULT (newid()) ROWGUIDCOL NOT NULL,
    [Action]    NVARCHAR (50)    NOT NULL,
    [Deleted]   BIT              CONSTRAINT [DF_Actions_Deleted] DEFAULT ((0)) NOT NULL,
    [IPAddress] NVARCHAR (25)    NULL,
    [Longitude] NVARCHAR (25)    NULL,
    [Latitude]  NVARCHAR (25)    NULL,
    CONSTRAINT [PK_Actions] PRIMARY KEY CLUSTERED ([ID] ASC)
);

