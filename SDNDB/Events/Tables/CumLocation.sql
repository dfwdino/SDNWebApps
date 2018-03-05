CREATE TABLE [Events].[CumLocation] (
    [ID]          INT           IDENTITY (1, 1) NOT NULL,
    [Deleted]     BIT           CONSTRAINT [DF_CumLocation_Deleted] DEFAULT ((0)) NOT NULL,
    [CreatedOn]   DATETIME      CONSTRAINT [DF_CumLocation_CreatedOn] DEFAULT (getdate()) NULL,
    [Latitude]    NVARCHAR (20) NULL,
    [Longitude]   NVARCHAR (20) NULL,
    [CumLocation] NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_CumLocation] PRIMARY KEY CLUSTERED ([ID] ASC)
);

