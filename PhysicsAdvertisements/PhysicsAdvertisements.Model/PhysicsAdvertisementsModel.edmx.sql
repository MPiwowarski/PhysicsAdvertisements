
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/01/2016 13:32:28
-- Generated from EDMX file: D:\PhysicsAdvertisementsRepo\PhysicsAdvertisements\PhysicsAdvertisements.Model\PhysicsAdvertisementsModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [PhysicsAdvertisements];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PhysicsAreasAdvertisement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advertisement] DROP CONSTRAINT [FK_PhysicsAreasAdvertisement];
GO
IF OBJECT_ID(N'[dbo].[FK_UserAdvertisement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advertisement] DROP CONSTRAINT [FK_UserAdvertisement];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryAdvertisement]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advertisement] DROP CONSTRAINT [FK_CategoryAdvertisement];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[PhysicsAreasDictionary]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhysicsAreasDictionary];
GO
IF OBJECT_ID(N'[dbo].[PhysicsAreas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhysicsAreas];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[Advertisement]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Advertisement];
GO
IF OBJECT_ID(N'[dbo].[Category]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Category];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'PhysicsAreasDictionary'
CREATE TABLE [dbo].[PhysicsAreasDictionary] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PhysicsAreas'
CREATE TABLE [dbo].[PhysicsAreas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Surname] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [Birthday] datetime  NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Gender] int  NOT NULL,
    [Role] int  NOT NULL
);
GO

-- Creating table 'Advertisement'
CREATE TABLE [dbo].[Advertisement] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AddedDate] nvarchar(max)  NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Content] nvarchar(max)  NOT NULL,
    [UserId] int  NOT NULL,
    [CategoryId] int  NOT NULL,
    [PhysicsAreasId] int  NOT NULL
);
GO

-- Creating table 'Category'
CREATE TABLE [dbo].[Category] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'PhysicsAreasDictionary'
ALTER TABLE [dbo].[PhysicsAreasDictionary]
ADD CONSTRAINT [PK_PhysicsAreasDictionary]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PhysicsAreas'
ALTER TABLE [dbo].[PhysicsAreas]
ADD CONSTRAINT [PK_PhysicsAreas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Advertisement'
ALTER TABLE [dbo].[Advertisement]
ADD CONSTRAINT [PK_Advertisement]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Category'
ALTER TABLE [dbo].[Category]
ADD CONSTRAINT [PK_Category]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PhysicsAreasId] in table 'Advertisement'
ALTER TABLE [dbo].[Advertisement]
ADD CONSTRAINT [FK_PhysicsAreasAdvertisement]
    FOREIGN KEY ([PhysicsAreasId])
    REFERENCES [dbo].[PhysicsAreas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhysicsAreasAdvertisement'
CREATE INDEX [IX_FK_PhysicsAreasAdvertisement]
ON [dbo].[Advertisement]
    ([PhysicsAreasId]);
GO

-- Creating foreign key on [UserId] in table 'Advertisement'
ALTER TABLE [dbo].[Advertisement]
ADD CONSTRAINT [FK_UserAdvertisement]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[User]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserAdvertisement'
CREATE INDEX [IX_FK_UserAdvertisement]
ON [dbo].[Advertisement]
    ([UserId]);
GO

-- Creating foreign key on [CategoryId] in table 'Advertisement'
ALTER TABLE [dbo].[Advertisement]
ADD CONSTRAINT [FK_CategoryAdvertisement]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Category]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryAdvertisement'
CREATE INDEX [IX_FK_CategoryAdvertisement]
ON [dbo].[Advertisement]
    ([CategoryId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------