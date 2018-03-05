CREATE TABLE [Grocery].[Stores] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [StoreName] VARCHAR (50)  NOT NULL,
    [IPAddress] NVARCHAR (25) NULL,
    [Longitude] NVARCHAR (25) NULL,
    [Latitude]  NVARCHAR (25) NULL,
    [Deleted]   BIT           NULL,
    CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED ([ID] ASC)
);

