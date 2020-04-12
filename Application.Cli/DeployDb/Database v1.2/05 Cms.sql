﻿-- Cms

-- ComponentType (Page, Paragraph, Bullet, Image, Youtube, CodeBlock, Glossary)
GO
CREATE TABLE Demo.CmsComponentType
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(256) NOT NULL UNIQUE,
    Sort FLOAT,
)
GO
CREATE VIEW Demo.CmsComponentTypeBuiltIn AS
SELECT
    Id,
    Name AS IdName,
    Name,
    Sort
FROM
    Demo.CmsComponentType

-- CodeBlockType (csharp, shell, html, js)
GO
CREATE TABLE Demo.CmsCodeBlockType
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(256) NOT NULL UNIQUE,
    FileExtension NVARCHAR(256),
    Sort FLOAT
)
GO
CREATE VIEW Demo.CmsCodeBlockTypeBuiltIn AS
SELECT
    Id,
    Name AS IdName,
    Name,
    FileExtension,
    Sort
FROM
    Demo.CmsCodeBlockType

-- Component
GO
CREATE TABLE Demo.CmsComponent
(
    Id INT PRIMARY KEY IDENTITY,
    ParentId INT FOREIGN KEY REFERENCES Demo.CmsComponent(Id), -- ParentId BuiltIn naming convention for hierarchical structure.
    Name UNIQUEIDENTIFIER NOT NULL UNIQUE,
    ComponentTypeId INT FOREIGN KEY REFERENCES Demo.CmsComponentType(Id), -- Discriminator
    -- Page
    PageTitle NVARCHAR(256),
    PageImageLink NVARCHAR(256),
    PageDate DATETIME,
    -- Paragraph
    ParagraphTitle NVARCHAR(256),
    ParagraphText NVARCHAR(MAX),
    ParagraphIsNote BIT,
    -- Bullet
    BulletText NVARCHAR(256),
    -- Image
    ImageLink NVARCHAR(256),
    ImageText NVARCHAR(256),
    -- Youtube
    YoutubeLink NVARCHAR(256),
    -- CodeBlock
    CodeBlockText NVARCHAR(MAX),
    CodeBlockTypeId INT FOREIGN KEY REFERENCES Demo.CmsCodeBlockType(Id),
    -- Glossary
    GlossaryTerm NVARCHAR(256),
    GlossaryText NVARCHAR(MAX),
    -- BuiltIn
    IsBuiltIn BIT NOT NULL,
    IsExist BIT NOT NULL,
)
GO
CREATE VIEW Demo.CmsComponentBuiltIn AS
SELECT
    Id,
    Name AS IdName,
    ParentId,
    (SELECT DataParent.Name FROM Demo.CmsComponent DataParent WHERE DataParent.Id = Data.ParentId) AS ParentIdName,
    Name,
    -- Page
    PageTitle,
    PageImageLink,
    PageDate,
    -- Paragraph
    ParagraphTitle,
    ParagraphText,
    ParagraphIsNote,
    -- Bullet,
    BulletText,
    -- Image
    ImageLink,
    ImageText,
    -- Youtube
    YoutubeLink,
    -- CodeBlock
    CodeBlockText,
    CodeBlockTypeId,
    (SELECT IdName FROM CmsCodeBlockTypeBuiltIn WHERE Id = Data.CodeBlockTypeId) AS CodeBlockTypeIdName,
    -- Glossary
    GlossaryTerm,
    GlossaryText,
    -- BuiltIn
    IsBuiltIn,
    IsExist
FROM
    Demo.CmsComponent Data

GO
CREATE VIEW Demo.CmsComponentDisplay AS
SELECT
    Id,
    ParentId,
    (SELECT PageTitle FROM Demo.CmsComponent WHERE Id = Data.ParentId) AS ParentText,
    Name,
    ComponentTypeId,
    (SELECT Name FROM Demo.CmsComponentType WHERE Id = Data.ComponentTypeId) AS ComponentType,
    -- Page
    PageTitle,
    PageImageLink,
    PageDate,
    -- Paragraph
    ParagraphTitle,
    ParagraphText,
    ParagraphIsNote,
    -- Bullet
    BulletText,
    -- Image
    ImageLink,
    ImageText,
    -- Youtube
    YoutubeLink,
    -- CodeBlock
    CodeBlockText,
    CodeBlockTypeId,
    (SELECT CONCAT(Name, ' (', FileExtension, ')') FROM Demo.CmsCodeBlockType WHERE Id = Data.CodeBlockTypeId) AS CodeBlockType,
    -- Glossary
    GlossaryTerm,
    GlossaryText,
    -- BuiltIn
    IsBuiltIn,
    IsExist
FROM
    Demo.CmsComponent Data