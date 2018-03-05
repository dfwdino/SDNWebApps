CREATE TABLE [Events].[BiologicalSexualOrientation] (
    [ID]                INT            IDENTITY (1, 1) NOT NULL,
    [BiologicalSexName] VARCHAR (25)   NOT NULL,
    [CreatedOn]         DATETIME       CONSTRAINT [DF_BiologicalSexualOrientation_CreatedOn] DEFAULT (getdate()) NULL,
    [BroserInfo]        NVARCHAR (MAX) NULL,
    [IPAddress]         NVARCHAR (20)  NULL,
    [UpdatedOn]         DATETIME       NULL,
    [Latitude]          NVARCHAR (20)  NULL,
    [Longitude]         NVARCHAR (20)  NULL,
    CONSTRAINT [PK_BiologicalSexualOrientation] PRIMARY KEY CLUSTERED ([ID] ASC)
);

