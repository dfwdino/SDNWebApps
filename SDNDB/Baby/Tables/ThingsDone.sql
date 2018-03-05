CREATE TABLE [Baby].[ThingsDone] (
    [index]        INT            IDENTITY (1, 1) NOT NULL,
    [Action]       INT            NOT NULL,
    [StartTime]    DATETIME       CONSTRAINT [DF_ThingsDone_StartTime] DEFAULT (getdate()) NOT NULL,
    [EndTime]      DATETIME       NULL,
    [Delete]       BIT            CONSTRAINT [DF_ThingsDone_Delete] DEFAULT ((0)) NOT NULL,
    [OZ]           FLOAT (53)     NULL,
    [Mood]         NVARCHAR (50)  NULL,
    [Notes]        NVARCHAR (MAX) NULL,
    [IPAddress]    NVARCHAR (25)  NULL,
    [Longitude]    NVARCHAR (25)  NULL,
    [Latitude]     NVARCHAR (25)  NULL,
    [LiquidSizeID] INT            NULL,
    [BabyNameID]   INT            NULL,
    CONSTRAINT [PK_ThingsDone] PRIMARY KEY CLUSTERED ([index] ASC),
    CONSTRAINT [FK_ThingsDone_Actions] FOREIGN KEY ([Action]) REFERENCES [Baby].[Actions] ([index]),
    CONSTRAINT [FK_ThingsDone_BabyNames] FOREIGN KEY ([BabyNameID]) REFERENCES [Baby].[BabyNames] ([ID]),
    CONSTRAINT [FK_ThingsDone_LiquidSize] FOREIGN KEY ([LiquidSizeID]) REFERENCES [Baby].[LiquidSize] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [_dta_index_ThingsDone_12_1298103665__K5_K3_1_2_4_6_7_8]
    ON [Baby].[ThingsDone]([Delete] ASC, [StartTime] ASC)
    INCLUDE([index], [Action], [EndTime], [OZ], [Mood], [Notes]);


GO
CREATE STATISTICS [_dta_stat_1298103665_3_5]
    ON [Baby].[ThingsDone]([StartTime], [Delete]);

