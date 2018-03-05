CREATE TABLE [Events].[ProtectionType] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [Type]      VARCHAR (50)  NOT NULL,
    [IPAddress] NVARCHAR (25) NULL,
    [Longitude] NVARCHAR (25) NULL,
    [Latitude]  NVARCHAR (25) NULL,
    CONSTRAINT [PK_ProtectionType] PRIMARY KEY CLUSTERED ([ID] ASC)
);

