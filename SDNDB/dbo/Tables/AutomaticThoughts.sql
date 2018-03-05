CREATE TABLE [dbo].[AutomaticThoughts] (
    [index]                  INT            IDENTITY (1, 1) NOT NULL,
    [HappenTime]             DATETIME       CONSTRAINT [DF_ThingsDone_StartTime] DEFAULT (getdate()) NOT NULL,
    [Delete]                 BIT            CONSTRAINT [DF_ThingsDone_Delete] DEFAULT ((0)) NOT NULL,
    [Situation]              NVARCHAR (MAX) NULL,
    [EmotionsRating]         INT            NULL,
    [AutomaticThought]       NVARCHAR (MAX) NULL,
    [AutomaticThoughtRating] INT            NULL,
    [RationalResponThought]  NVARCHAR (MAX) NULL,
    [RationalResponRating]   INT            NULL,
    [OurcomeThought]         NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_ThingsDone] PRIMARY KEY CLUSTERED ([index] ASC)
);

