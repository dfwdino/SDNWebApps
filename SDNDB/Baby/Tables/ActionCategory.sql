CREATE TABLE [Baby].[ActionCategory] (
    [Index]     UNIQUEIDENTIFIER CONSTRAINT [DF_ActionCategory_Index] DEFAULT (newid()) NOT NULL,
    [Category]  NVARCHAR (50)    NOT NULL,
    [Delete]    BIT              CONSTRAINT [DF_ActionCategory_Delete] DEFAULT ((0)) NOT NULL,
    [IPAddress] NVARCHAR (25)    NULL,
    [Longitude] NVARCHAR (25)    NULL,
    [Latitude]  NVARCHAR (25)    NULL,
    CONSTRAINT [PK_ActionCategory] PRIMARY KEY CLUSTERED ([Index] ASC)
);

