CREATE TABLE [Events].[People] (
    [ID]                            UNIQUEIDENTIFIER NOT NULL,
    [Name]                          NVARCHAR (50)    NOT NULL,
    [Deleted]                       BIT              CONSTRAINT [DF_People_Deleted] DEFAULT ((0)) NOT NULL,
    [BiologicalSexualOrientationID] INT              NULL,
    [IPAddress]                     NVARCHAR (25)    NULL,
    [Longitude]                     NVARCHAR (25)    NULL,
    [Latitude]                      NVARCHAR (25)    NULL,
    [WhereDidYouMeetThem]           VARCHAR (MAX)    NULL,
    CONSTRAINT [PK_People_2] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_People_BiologicalSexualOrientation] FOREIGN KEY ([BiologicalSexualOrientationID]) REFERENCES [Events].[BiologicalSexualOrientation] ([ID])
);

