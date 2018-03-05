CREATE TABLE [Gas].[GasNotes] (
    [NotesID]   INT            IDENTITY (1, 1) NOT NULL,
    [Note]      NVARCHAR (MAX) NOT NULL,
    [AutoID]    INT            NOT NULL,
    [CreatedOn] DATETIME       CONSTRAINT [DF_GasNotes_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedOn] DATETIME       NULL,
    [IPAddress] NVARCHAR (15)  NULL,
    [Broswer]   NVARCHAR (100) NULL,
    [Deleted]   BIT            CONSTRAINT [DF_GasNotes_Deleted] DEFAULT ((0)) NOT NULL,
    [NoteDate]  DATETIME       NULL,
    CONSTRAINT [PK_GasNotes] PRIMARY KEY CLUSTERED ([NotesID] ASC),
    CONSTRAINT [FK_GasNotes_Autos] FOREIGN KEY ([AutoID]) REFERENCES [Gas].[Autos] ([ID])
);

