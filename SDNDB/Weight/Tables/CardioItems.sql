CREATE TABLE [Weight].[CardioItems] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Item]        NVARCHAR (50) NOT NULL,
    [CreatedDate] DATETIME      CONSTRAINT [DF_Items_CreatedDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK_Items_1] PRIMARY KEY CLUSTERED ([ID] ASC)
);

