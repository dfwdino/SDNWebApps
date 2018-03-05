CREATE TABLE [Grocery].[Items] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [StoreID]       INT            NULL,
    [Name]          NVARCHAR (255) NOT NULL,
    [Price]         MONEY          CONSTRAINT [DF_Items_Price] DEFAULT ((0.00)) NULL,
    [Have]          BIT            CONSTRAINT [DF_Items_Have] DEFAULT ((0)) NOT NULL,
    [Image]         IMAGE          NULL,
    [Amount]        NVARCHAR (50)  NULL,
    [LastGotten]    DATE           NULL,
    [ImageLocation] NVARCHAR (MAX) NULL,
    [IPAddress]     NVARCHAR (25)  NULL,
    [Longitude]     NVARCHAR (25)  NULL,
    [Latitude]      NVARCHAR (25)  NULL,
    [ItemSizeID]    INT            NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Items_ItemSize] FOREIGN KEY ([ItemSizeID]) REFERENCES [Grocery].[ItemSize] ([Id]),
    CONSTRAINT [FK_Items_Stores] FOREIGN KEY ([StoreID]) REFERENCES [Grocery].[Stores] ([ID])
);


GO
CREATE STATISTICS [_dta_stat_1634104862_5_3]
    ON [Grocery].[Items]([Have], [Name]);


GO
CREATE STATISTICS [_dta_stat_1634104862_2_1]
    ON [Grocery].[Items]([StoreID], [ID]);

