CREATE TABLE [Grocery].[ItemSize] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Size]      NVARCHAR (50) NOT NULL,
    [IPAddress] NVARCHAR (25) NULL,
    [Longitude] NVARCHAR (25) NULL,
    [Latitude]  NVARCHAR (25) NULL,
    [CreatedOn] DATETIME      NULL,
    CONSTRAINT [PK_ItemSize] PRIMARY KEY CLUSTERED ([Id] ASC)
);

