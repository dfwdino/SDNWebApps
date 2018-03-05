CREATE TABLE [Gas].[Autos] (
    [ID]        INT           IDENTITY (5, 1) NOT NULL,
    [WhosCar]   INT           NOT NULL,
    [AutoName]  NVARCHAR (50) NOT NULL,
    [Delete]    BIT           NULL,
    [IPAddress] NVARCHAR (25) NULL,
    [Longitude] NVARCHAR (25) NULL,
    [Latitude]  NVARCHAR (25) NULL,
    CONSTRAINT [PK_Autos] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Autos_People] FOREIGN KEY ([WhosCar]) REFERENCES [Gas].[People] ([ID])
);

