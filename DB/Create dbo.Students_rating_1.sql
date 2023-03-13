USE [Student_Grades]
GO

/****** Объект: Table [dbo].[Students_rating] Дата скрипта: 14.03.2023 1:03:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students_rating] (
    [Id]               INT           NOT NULL,
    [Firstname]        NVARCHAR (20) NOT NULL,
    [Surname]          NVARCHAR (20) NOT NULL,
    [Group]            NVARCHAR (10) NOT NULL,
    [Avarage_rating]   INT           NULL,
    [Name_subject_min] NVARCHAR (20) NOT NULL,
    [Name_subject_max] NVARCHAR (20) NOT NULL
);


