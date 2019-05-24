CREATE TABLE [Gas].[Gallons] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [AutoID]        INT            NOT NULL,
    [TotalMiles]    INT            NOT NULL,
    [DrivenMiles]   INT            NOT NULL,
    [TotalGallons]  FLOAT (53)     NOT NULL,
    [TotalPrice]    MONEY          NULL,
    [GasDate]       DATE           NULL,
    [TankFilled]    BIT            CONSTRAINT [DF_Gas_TankFilled] DEFAULT ((0)) NOT NULL,
    [Notes]         NVARCHAR (MAX) NULL,
    [StationID]     INT            NULL,
    [Delete]        BIT            CONSTRAINT [DF_Gallons_Delete] DEFAULT ((0)) NULL,
    [IPAddress]     NVARCHAR (25)  NULL,
    [Longitude]     NVARCHAR (25)  NULL,
    [Latitude]      NVARCHAR (25)  NULL,
    [EngineRunTime] TIME (7)       NULL,
    CONSTRAINT [PK_Gallons] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Gallons_Autos] FOREIGN KEY ([AutoID]) REFERENCES [Gas].[Autos] ([ID]),
    CONSTRAINT [FK_Gallons_Stations] FOREIGN KEY ([StationID]) REFERENCES [Gas].[Stations] ([StationID])
);



