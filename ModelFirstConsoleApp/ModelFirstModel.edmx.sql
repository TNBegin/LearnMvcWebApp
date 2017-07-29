
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/29/2017 16:22:15
-- Generated from EDMX file: E:\study\LearnMvcWebApp\ModelFirstConsoleApp\ModelFirstModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelFistDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CustomerOrder]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Order] DROP CONSTRAINT [FK_CustomerOrder];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerProduct_Customer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerProduct] DROP CONSTRAINT [FK_CustomerProduct_Customer];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerProduct_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CustomerProduct] DROP CONSTRAINT [FK_CustomerProduct_Product];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Order]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Order];
GO
IF OBJECT_ID(N'[dbo].[Product]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Product];
GO
IF OBJECT_ID(N'[dbo].[CustomerProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CustomerProduct];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customer'
CREATE TABLE [dbo].[Customer] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(30)  NULL,
    [Age] int  NULL,
    [Sex] nvarchar(8)  NULL,
    [ComepanyName] nvarchar(30)  NOT NULL,
    [Telphone] nvarchar(10)  NULL
);
GO

-- Creating table 'Order'
CREATE TABLE [dbo].[Order] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrderNo] nvarchar(12)  NULL,
    [Amount] decimal(4,0)  NULL,
    [CreateTime] datetime  NULL,
    [CustomerId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Product'
CREATE TABLE [dbo].[Product] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(11)  NULL,
    [Price] decimal(4,0)  NULL,
    [Weight] decimal(4,0)  NULL
);
GO

-- Creating table 'CustomerProduct'
CREATE TABLE [dbo].[CustomerProduct] (
    [Customer_Id] uniqueidentifier  NOT NULL,
    [Product_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Customer'
ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT [PK_Customer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [PK_Order]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Product'
ALTER TABLE [dbo].[Product]
ADD CONSTRAINT [PK_Product]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Customer_Id], [Product_Id] in table 'CustomerProduct'
ALTER TABLE [dbo].[CustomerProduct]
ADD CONSTRAINT [PK_CustomerProduct]
    PRIMARY KEY CLUSTERED ([Customer_Id], [Product_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Order'
ALTER TABLE [dbo].[Order]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[Order]
    ([CustomerId]);
GO

-- Creating foreign key on [Customer_Id] in table 'CustomerProduct'
ALTER TABLE [dbo].[CustomerProduct]
ADD CONSTRAINT [FK_CustomerProduct_Customer]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Customer]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Product_Id] in table 'CustomerProduct'
ALTER TABLE [dbo].[CustomerProduct]
ADD CONSTRAINT [FK_CustomerProduct_Product]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[Product]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerProduct_Product'
CREATE INDEX [IX_FK_CustomerProduct_Product]
ON [dbo].[CustomerProduct]
    ([Product_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------