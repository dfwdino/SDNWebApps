CREATE TABLE [Events].[Reports] (
    [ID]               INT            IDENTITY (1, 1) NOT NULL,
    [CreateOn]         DATETIME       CONSTRAINT [DF_Report_CreateOn] DEFAULT (getdate()) NULL,
    [OverAllHowWasIt]  NVARCHAR (MAX) NOT NULL,
    [BestThingHappend] NVARCHAR (MAX) NULL,
    [CouldHaveDone]    NVARCHAR (MAX) NULL,
    [BeBetter]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED ([ID] ASC)
);

