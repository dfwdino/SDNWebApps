CREATE TABLE [Baby].[PunshmentActions] (
    [index]     INT           IDENTITY (1, 1) NOT NULL,
    [Title]     NVARCHAR (50) NOT NULL,
    [Delete]    BIT           CONSTRAINT [DF_PunshmentActions_Delete] DEFAULT ((0)) NOT NULL,
    [IPAddress] NVARCHAR (25) NULL,
    [Longitude] NVARCHAR (25) NULL,
    [Latitude]  NVARCHAR (25) NULL,
    CONSTRAINT [PK_PunshmentActions.Index] PRIMARY KEY CLUSTERED ([index] ASC)
);

