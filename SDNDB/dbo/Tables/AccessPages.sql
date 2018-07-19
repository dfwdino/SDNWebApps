CREATE TABLE [dbo].[AccessPages] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [AccessPage] NVARCHAR (50) NOT NULL,
    [Disactive]  BIT           CONSTRAINT [DF_AccessPages_Disactive] DEFAULT ((0)) NOT NULL,
    [PersonID]   INT           NOT NULL,
    CONSTRAINT [PK_AccessPages] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_AccessPages_People] FOREIGN KEY ([PersonID]) REFERENCES [Gas].[People] ([ID]),
    CONSTRAINT [FK_AccessPages_People1] FOREIGN KEY ([PersonID]) REFERENCES [Gas].[People] ([ID])
);



