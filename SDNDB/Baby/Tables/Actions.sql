CREATE TABLE [Baby].[Actions] (
    [index]      INT              IDENTITY (1, 1) NOT NULL,
    [Title]      NVARCHAR (50)    NOT NULL,
    [Delete]     BIT              CONSTRAINT [DF_Actions_Delete] DEFAULT ((0)) NOT NULL,
    [CategoryID] UNIQUEIDENTIFIER NULL,
    [IPAddress]  NVARCHAR (25)    NULL,
    [Longitude]  NVARCHAR (25)    NULL,
    [Latitude]   NVARCHAR (25)    NULL,
    CONSTRAINT [PK_Baby.Item] PRIMARY KEY CLUSTERED ([index] ASC),
    CONSTRAINT [FK_Actions_ActionCategory] FOREIGN KEY ([CategoryID]) REFERENCES [Baby].[ActionCategory] ([Index])
);

