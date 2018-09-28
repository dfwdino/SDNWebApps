CREATE TABLE [Weight].[WeightLog] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [PersonID]   INT            NOT NULL,
    [Weight]     FLOAT (53)     NOT NULL,
    [WeightDate] DATE           NOT NULL,
    [Deleted]    BIT            CONSTRAINT [DF_WeightLog_Deleted] DEFAULT ((0)) NOT NULL,
    [Notes]      NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_WeightLog] PRIMARY KEY CLUSTERED ([ID] ASC)
);



