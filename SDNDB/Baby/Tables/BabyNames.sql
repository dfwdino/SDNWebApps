CREATE TABLE [Baby].[BabyNames] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [BabyName]  VARCHAR (50)  NOT NULL,
    [Delete]    BIT           CONSTRAINT [DF_BabyNames_Delete] DEFAULT ((0)) NOT NULL,
    [IPAddress] NVARCHAR (25) NULL,
    [Longitude] NVARCHAR (25) NULL,
    [Latitude]  NVARCHAR (25) NULL,
    CONSTRAINT [PK_BabyNames] PRIMARY KEY CLUSTERED ([ID] ASC)
);

