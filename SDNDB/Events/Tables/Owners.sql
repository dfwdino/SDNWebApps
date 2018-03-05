﻿CREATE TABLE [Events].[Owners] (
    [OwnerID]    UNIQUEIDENTIFIER NOT NULL,
    [PersonName] NVARCHAR (50)    NOT NULL,
    [Username]   NVARCHAR (25)    NULL,
    [Password]   NVARCHAR (50)    NULL,
    [SaltHash]   NVARCHAR (50)    NULL,
    [IPAddress]  NVARCHAR (25)    NULL,
    [Longitude]  NVARCHAR (25)    NULL,
    [Latitude]   NVARCHAR (25)    NULL,
    CONSTRAINT [PK_Owners] PRIMARY KEY CLUSTERED ([OwnerID] ASC)
);

