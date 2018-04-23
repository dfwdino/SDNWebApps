CREATE TABLE [Gas].[Stations] (
    [StationID]   INT            IDENTITY (1, 1) NOT NULL,
    [StationName] NVARCHAR (50)  NOT NULL,
    [CreatedOn]   DATETIME       CONSTRAINT [DF_Stations_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedOn]   DATETIME       NULL,
    [IPAddress]   NVARCHAR (15)  NULL,
    [Broswer]     NVARCHAR (100) NULL,
    [Deleted]     BIT            CONSTRAINT [DF_Stations_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Stations] PRIMARY KEY CLUSTERED ([StationID] ASC)
);



