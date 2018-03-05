CREATE TABLE [weighttracking].[Weight] (
    [WeightID]   INT            NOT NULL,
    [SizeID]     INT            NULL,
    [Pound]      INT            NULL,
    [CreatedOn]  DATETIME       CONSTRAINT [DF_Weight_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedOn]  DATETIME       NULL,
    [IPAddress]  NVARCHAR (20)  NULL,
    [Broswer]    NVARCHAR (250) NULL,
    [StatusDate] DATE           NOT NULL,
    CONSTRAINT [PK_Weight] PRIMARY KEY CLUSTERED ([WeightID] ASC),
    CONSTRAINT [FK_Weight_Size] FOREIGN KEY ([SizeID]) REFERENCES [weighttracking].[Size] ([SizeID])
);

