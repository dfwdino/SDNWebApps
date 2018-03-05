CREATE TABLE [Events].[LizNightlyQuestions] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [Question1]     NVARCHAR (255) NULL,
    [Answer1]       VARCHAR (50)   NULL,
    [Question2]     NVARCHAR (255) NULL,
    [Answer2]       VARCHAR (50)   NULL,
    [Qustion3]      NVARCHAR (250) NULL,
    [Answer3PartA]  VARCHAR (50)   NULL,
    [DateSubmitted] DATE           CONSTRAINT [DF_LizNightlyQuestions_DateSubmitted] DEFAULT (getdate()) NULL,
    [Answer3PartB]  VARCHAR (50)   NULL
);

