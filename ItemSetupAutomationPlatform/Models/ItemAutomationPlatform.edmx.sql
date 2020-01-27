
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/27/2020 16:32:03
-- Generated from EDMX file: C:\Users\Osman Mejia\source\repos\ItemSetupAutomationPlatform\ItemSetupAutomationPlatform\Models\ItemAutomationPlatform.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ItemAutomationPlatform];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[IAP_Fields]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IAP_Fields];
GO
IF OBJECT_ID(N'[dbo].[IAP_FieldTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IAP_FieldTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'IAP_Fields'
CREATE TABLE [dbo].[IAP_Fields] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FieldName] nchar(40)  NOT NULL,
    [FieldType] nchar(10)  NOT NULL,
    [FieldLabel] nvarchar(max)  NOT NULL,
    [FieldLenght] int  NULL,
    [FieldDataSource] nvarchar(max)  NULL,
    [FieldOptions] nvarchar(max)  NULL
);
GO

-- Creating table 'IAP_FieldTypes'
CREATE TABLE [dbo].[IAP_FieldTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Description] nchar(40)  NOT NULL,
    [UseDataSource] bit  NULL,
    [UseOptions] bit  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [FieldName] in table 'IAP_Fields'
ALTER TABLE [dbo].[IAP_Fields]
ADD CONSTRAINT [PK_IAP_Fields]
    PRIMARY KEY CLUSTERED ([FieldName] ASC);
GO

-- Creating primary key on [Id] in table 'IAP_FieldTypes'
ALTER TABLE [dbo].[IAP_FieldTypes]
ADD CONSTRAINT [PK_IAP_FieldTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------