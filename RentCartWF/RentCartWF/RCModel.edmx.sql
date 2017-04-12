
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/12/2017 10:40:24
-- Generated from EDMX file: C:\Users\juan.delacruz\Source\Repos\Rentcar\RentCartWF\RentCartWF\RCModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RENTCART];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[fk_Model_Brands]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VehicleModels] DROP CONSTRAINT [fk_Model_Brands];
GO
IF OBJECT_ID(N'[dbo].[fk_Vehicles_FuelTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [fk_Vehicles_FuelTypes];
GO
IF OBJECT_ID(N'[dbo].[fk_Vehicles_Models]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [fk_Vehicles_Models];
GO
IF OBJECT_ID(N'[dbo].[fk_Vehicles_VehicleTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Vehicles] DROP CONSTRAINT [fk_Vehicles_VehicleTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_Inspections_Clients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inspections] DROP CONSTRAINT [FK_pk_Inspections_Clients];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_Inspections_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inspections] DROP CONSTRAINT [FK_pk_Inspections_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_Inspections_Vehicles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inspections] DROP CONSTRAINT [FK_pk_Inspections_Vehicles];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_RentAndReturns_Clients]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RentAndReturns] DROP CONSTRAINT [FK_pk_RentAndReturns_Clients];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_RentAndReturns_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RentAndReturns] DROP CONSTRAINT [FK_pk_RentAndReturns_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_pk_RentAndReturns_Vehicles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RentAndReturns] DROP CONSTRAINT [FK_pk_RentAndReturns_Vehicles];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Brands]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Brands];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[FuelTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FuelTypes];
GO
IF OBJECT_ID(N'[dbo].[Inspections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inspections];
GO
IF OBJECT_ID(N'[dbo].[RentAndReturns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RentAndReturns];
GO
IF OBJECT_ID(N'[dbo].[VehicleModels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleModels];
GO
IF OBJECT_ID(N'[dbo].[Vehicles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehicles];
GO
IF OBJECT_ID(N'[dbo].[VehicleTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VehicleTypes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Brands'
CREATE TABLE [dbo].[Brands] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NULL,
    [State] nchar(20)  NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NULL,
    [IDCard] varchar(15)  NULL,
    [CreditCard] varchar(25)  NULL,
    [CreditLimit] real  NULL,
    [PersonType] varchar(10)  NULL,
    [State] nchar(20)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(50)  NULL,
    [IDCard] varchar(15)  NULL,
    [WorkShift] varchar(25)  NULL,
    [CommissionPercentage] real  NULL,
    [HireDate] datetime  NULL,
    [State] nchar(20)  NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Rol] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FuelTypes'
CREATE TABLE [dbo].[FuelTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NULL,
    [State] nchar(20)  NULL
);
GO

-- Creating table 'Inspections'
CREATE TABLE [dbo].[Inspections] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [VehicleID] int  NOT NULL,
    [ClientID] int  NOT NULL,
    [HaveScratches] varchar(3)  NULL,
    [FuelAmount] varchar(5)  NULL,
    [HasSpareTire] varchar(5)  NULL,
    [HasJack] varchar(5)  NULL,
    [HaveBrokenGlass] varchar(5)  NULL,
    [Date] datetime  NULL,
    [EmployeeID] int  NOT NULL,
    [TiresSate] varchar(100)  NULL,
    [State] nchar(20)  NULL
);
GO

-- Creating table 'RentAndReturns'
CREATE TABLE [dbo].[RentAndReturns] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [VehicleID] int  NOT NULL,
    [ClientID] int  NOT NULL,
    [EmployeeID] int  NOT NULL,
    [RentDate] datetime  NULL,
    [ReturnDate] datetime  NULL,
    [AmountXDay] real  NULL,
    [NumberOfDays] int  NULL,
    [Comment] varchar(100)  NULL,
    [State] nchar(20)  NULL
);
GO

-- Creating table 'VehicleModels'
CREATE TABLE [dbo].[VehicleModels] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [BrandID] int  NULL,
    [Description] varchar(50)  NULL,
    [State] nchar(20)  NULL
);
GO

-- Creating table 'Vehicles'
CREATE TABLE [dbo].[Vehicles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NULL,
    [ChassisNumber] int  NULL,
    [EngineNumber] int  NULL,
    [PlateNumber] varchar(10)  NULL,
    [VehicleTypeID] int  NULL,
    [BrandID] int  NULL,
    [ModelID] int  NULL,
    [FuelTypeID] int  NULL,
    [State] nchar(20)  NULL
);
GO

-- Creating table 'VehicleTypes'
CREATE TABLE [dbo].[VehicleTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Description] varchar(50)  NULL,
    [State] nchar(20)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Brands'
ALTER TABLE [dbo].[Brands]
ADD CONSTRAINT [PK_Brands]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'FuelTypes'
ALTER TABLE [dbo].[FuelTypes]
ADD CONSTRAINT [PK_FuelTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Inspections'
ALTER TABLE [dbo].[Inspections]
ADD CONSTRAINT [PK_Inspections]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RentAndReturns'
ALTER TABLE [dbo].[RentAndReturns]
ADD CONSTRAINT [PK_RentAndReturns]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'VehicleModels'
ALTER TABLE [dbo].[VehicleModels]
ADD CONSTRAINT [PK_VehicleModels]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [PK_Vehicles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'VehicleTypes'
ALTER TABLE [dbo].[VehicleTypes]
ADD CONSTRAINT [PK_VehicleTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [BrandID] in table 'VehicleModels'
ALTER TABLE [dbo].[VehicleModels]
ADD CONSTRAINT [fk_Model_Brands]
    FOREIGN KEY ([BrandID])
    REFERENCES [dbo].[Brands]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Model_Brands'
CREATE INDEX [IX_fk_Model_Brands]
ON [dbo].[VehicleModels]
    ([BrandID]);
GO

-- Creating foreign key on [FuelTypeID] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [fk_Vehicles_FuelTypes]
    FOREIGN KEY ([FuelTypeID])
    REFERENCES [dbo].[Brands]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Vehicles_FuelTypes'
CREATE INDEX [IX_fk_Vehicles_FuelTypes]
ON [dbo].[Vehicles]
    ([FuelTypeID]);
GO

-- Creating foreign key on [ClientID] in table 'Inspections'
ALTER TABLE [dbo].[Inspections]
ADD CONSTRAINT [FK_pk_Inspections_Clients]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[Clients]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_Inspections_Clients'
CREATE INDEX [IX_FK_pk_Inspections_Clients]
ON [dbo].[Inspections]
    ([ClientID]);
GO

-- Creating foreign key on [ClientID] in table 'RentAndReturns'
ALTER TABLE [dbo].[RentAndReturns]
ADD CONSTRAINT [FK_pk_RentAndReturns_Clients]
    FOREIGN KEY ([ClientID])
    REFERENCES [dbo].[Clients]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_RentAndReturns_Clients'
CREATE INDEX [IX_FK_pk_RentAndReturns_Clients]
ON [dbo].[RentAndReturns]
    ([ClientID]);
GO

-- Creating foreign key on [EmployeeID] in table 'Inspections'
ALTER TABLE [dbo].[Inspections]
ADD CONSTRAINT [FK_pk_Inspections_Employees]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_Inspections_Employees'
CREATE INDEX [IX_FK_pk_Inspections_Employees]
ON [dbo].[Inspections]
    ([EmployeeID]);
GO

-- Creating foreign key on [EmployeeID] in table 'RentAndReturns'
ALTER TABLE [dbo].[RentAndReturns]
ADD CONSTRAINT [FK_pk_RentAndReturns_Employees]
    FOREIGN KEY ([EmployeeID])
    REFERENCES [dbo].[Employees]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_RentAndReturns_Employees'
CREATE INDEX [IX_FK_pk_RentAndReturns_Employees]
ON [dbo].[RentAndReturns]
    ([EmployeeID]);
GO

-- Creating foreign key on [VehicleID] in table 'Inspections'
ALTER TABLE [dbo].[Inspections]
ADD CONSTRAINT [FK_pk_Inspections_Vehicles]
    FOREIGN KEY ([VehicleID])
    REFERENCES [dbo].[Vehicles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_Inspections_Vehicles'
CREATE INDEX [IX_FK_pk_Inspections_Vehicles]
ON [dbo].[Inspections]
    ([VehicleID]);
GO

-- Creating foreign key on [VehicleID] in table 'RentAndReturns'
ALTER TABLE [dbo].[RentAndReturns]
ADD CONSTRAINT [FK_pk_RentAndReturns_Vehicles]
    FOREIGN KEY ([VehicleID])
    REFERENCES [dbo].[Vehicles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_pk_RentAndReturns_Vehicles'
CREATE INDEX [IX_FK_pk_RentAndReturns_Vehicles]
ON [dbo].[RentAndReturns]
    ([VehicleID]);
GO

-- Creating foreign key on [ModelID] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [fk_Vehicles_Models]
    FOREIGN KEY ([ModelID])
    REFERENCES [dbo].[VehicleModels]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Vehicles_Models'
CREATE INDEX [IX_fk_Vehicles_Models]
ON [dbo].[Vehicles]
    ([ModelID]);
GO

-- Creating foreign key on [VehicleTypeID] in table 'Vehicles'
ALTER TABLE [dbo].[Vehicles]
ADD CONSTRAINT [fk_Vehicles_VehicleTypes]
    FOREIGN KEY ([VehicleTypeID])
    REFERENCES [dbo].[VehicleTypes]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Vehicles_VehicleTypes'
CREATE INDEX [IX_fk_Vehicles_VehicleTypes]
ON [dbo].[Vehicles]
    ([VehicleTypeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------