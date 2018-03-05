CREATE TABLE [Events].[Positions] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Poisition]     NVARCHAR (50)  NOT NULL,
    [ImageLocation] NVARCHAR (255) NULL,
    [Deleted]       BIT            CONSTRAINT [DF_Poisitions_Deleted] DEFAULT ((0)) NOT NULL,
    [IPAddress]     NVARCHAR (25)  NULL,
    [Longitude]     NVARCHAR (25)  NULL,
    [Latitude]      NVARCHAR (25)  NULL,
    CONSTRAINT [PK_Poisitions] PRIMARY KEY CLUSTERED ([ID] ASC)
);

