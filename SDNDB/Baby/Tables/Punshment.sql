CREATE TABLE [Baby].[Punshment] (
    [index]            INT            IDENTITY (1, 1) NOT NULL,
    [BabyNameID]       INT            NULL,
    [PunshmentActions] INT            NOT NULL,
    [StartTime]        DATETIME       CONSTRAINT [DF_Punshment_StartTime] DEFAULT (getdate()) NOT NULL,
    [Delete]           BIT            CONSTRAINT [DF_Punshment_Delete] DEFAULT ((0)) NOT NULL,
    [Notes]            NVARCHAR (MAX) NULL,
    [IPAddress]        NVARCHAR (25)  NULL,
    [Longitude]        NVARCHAR (25)  NULL,
    [Latitude]         NVARCHAR (25)  NULL,
    [LiquidSizeID]     INT            NULL,
    CONSTRAINT [PK_Punshment] PRIMARY KEY CLUSTERED ([index] ASC),
    CONSTRAINT [FK_Punshment_BabyNames] FOREIGN KEY ([BabyNameID]) REFERENCES [Baby].[BabyNames] ([ID]),
    CONSTRAINT [FK_Punshment_PunshmentActions] FOREIGN KEY ([PunshmentActions]) REFERENCES [Baby].[PunshmentActions] ([index])
);

