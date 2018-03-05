CREATE TABLE [Grocery].[PriceHistory] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [StoreID]   INT           NOT NULL,
    [ItemID]    INT           NOT NULL,
    [Price]     MONEY         NOT NULL,
    [Date]      DATETIME      CONSTRAINT [DF_Grocery.PriceHistory_Date] DEFAULT (getdate()) NOT NULL,
    [IPAddress] NVARCHAR (25) NULL,
    [Longitude] NVARCHAR (25) NULL,
    [Latitude]  NVARCHAR (25) NULL,
    CONSTRAINT [PK_Grocery.PriceHistory] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Grocery.PriceHistory_Stores] FOREIGN KEY ([StoreID]) REFERENCES [Grocery].[Stores] ([ID]),
    CONSTRAINT [FK_PriceHistory_Items] FOREIGN KEY ([ItemID]) REFERENCES [Grocery].[Items] ([ID])
);

