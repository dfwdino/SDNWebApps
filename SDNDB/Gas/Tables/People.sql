﻿CREATE TABLE [Gas].[People] (
    [ID]         INT           IDENTITY (5, 1) NOT NULL,
    [PersonName] NVARCHAR (50) NOT NULL,
    [Username]   NVARCHAR (25) NULL,
    [Password]   NVARCHAR (50) NULL,
    [Sait]       NCHAR (10)    NULL,
    [Hash]       NVARCHAR (50) NULL,
    [Delete]     BIT           NULL,
    [IPAddress]  NVARCHAR (25) NULL,
    [Longitude]  NVARCHAR (25) NULL,
    [Latitude]   NVARCHAR (25) NULL,
    [Role]       NVARCHAR (50) NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([ID] ASC)
);





