CREATE TABLE [KidsLog].[Entry] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [CreatedDate] DATE           CONSTRAINT [DF_Entry_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [IssueDate]   DATE           NOT NULL,
    [Issues]      NVARCHAR (MAX) NOT NULL,
    [Planned]     NVARCHAR (MAX) NOT NULL,
    [Deleted]     BIT            CONSTRAINT [DF_Entry_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Entry] PRIMARY KEY CLUSTERED ([ID] ASC)
);

