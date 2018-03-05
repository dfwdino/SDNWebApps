CREATE TABLE [weighttracking].[Size] (
    [SizeID]     INT            IDENTITY (1, 1) NOT NULL,
    [PeopleID]   INT            NOT NULL,
    [Wrist]      INT            NULL,
    [Chest]      INT            NULL,
    [Forearm]    INT            NULL,
    [Waist]      INT            NULL,
    [Thigh]      INT            NULL,
    [Hip]        INT            NULL,
    [Calve]      INT            NULL,
    [Bicep]      INT            NULL,
    [Neck]       INT            NULL,
    [Notes]      NVARCHAR (MAX) NULL,
    [CreatedOn]  DATETIME       CONSTRAINT [DF_Size_CreatedOn] DEFAULT (getdate()) NOT NULL,
    [UpdatedOn]  DATETIME       NULL,
    [IPAddress]  NVARCHAR (20)  NULL,
    [Broswer]    NVARCHAR (250) NULL,
    [StatusDate] DATE           NOT NULL,
    CONSTRAINT [PK_Size] PRIMARY KEY CLUSTERED ([SizeID] ASC),
    CONSTRAINT [FK_Size_People] FOREIGN KEY ([PeopleID]) REFERENCES [Gas].[People] ([ID])
);

