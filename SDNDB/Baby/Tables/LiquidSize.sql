CREATE TABLE [Baby].[LiquidSize] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Type]      NVARCHAR (50) NOT NULL,
    [Deleted]   BIT           NOT NULL,
    [IPAddress] NVARCHAR (25) NULL,
    [Longitude] NVARCHAR (25) NULL,
    [Latitude]  NVARCHAR (25) NULL,
    CONSTRAINT [PK__LiquidSi__3214EC0753D3E9B8] PRIMARY KEY CLUSTERED ([Id] ASC)
);

