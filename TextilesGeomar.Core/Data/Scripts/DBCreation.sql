-- Disconnect users and drop the database if it exists
USE master;
GO

-- Check if the database is in use and disconnect if necessary
ALTER DATABASE textilesgeomar SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE IF EXISTS textilesgeomar;
GO

-- Create the database
CREATE DATABASE textilesgeomar;
PRINT 'Database "textilesgeomar" created successfully.';
GO

-- Switch to the new database
USE textilesgeomar;
GO

-- Roles Table
CREATE TABLE [Role] (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255)
);

-- Users Table
CREATE TABLE [User] (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    RoleId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(50),
    Password NVARCHAR(255) NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES [Role](RoleId)
);

-- Institutions Table
CREATE TABLE Institution (
    InstitutionId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    Phone NVARCHAR(50)
);

-- Clients Table
CREATE TABLE Client (
    ClientId INT PRIMARY KEY IDENTITY(1,1),
    InstitutionId INT NULL,
    Name NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(50),
    FOREIGN KEY (InstitutionId) REFERENCES Institution(InstitutionId)
);

-- Statuses Table
CREATE TABLE Status (
    StatusId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255)
);

-- Uniforms Table (removed Price)
CREATE TABLE Uniform (
    UniformId INT PRIMARY KEY IDENTITY(1,1),
    InstitutionId INT NULL,
    Name NVARCHAR(100) NOT NULL,
    FOREIGN KEY (InstitutionId) REFERENCES Institution(InstitutionId)
);

-- Items Table
CREATE TABLE Item (
    ItemId INT PRIMARY KEY IDENTITY(1,1),
    UniformId INT NULL,
    InstitutionId INT NULL,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Size NVARCHAR(50),
    Color NVARCHAR(50),
    FabricType NVARCHAR(50),
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (UniformId) REFERENCES Uniform(UniformId),
    FOREIGN KEY (InstitutionId) REFERENCES Institution(InstitutionId)
);

-- UniformItems Table
CREATE TABLE UniformItems (
    UniformItemId INT PRIMARY KEY IDENTITY(1,1),
    UniformId INT NOT NULL,
    ItemId INT NOT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    FOREIGN KEY (UniformId) REFERENCES Uniform(UniformId),
    FOREIGN KEY (ItemId) REFERENCES Item(ItemId),
    CONSTRAINT UC_UniformItem UNIQUE (UniformId, ItemId)
);

-- Orders Table
CREATE TABLE [Order] (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    ClientId INT NOT NULL,
    InstitutionId INT NULL,
    UserId INT NOT NULL,
    StatusId INT NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CompletedDate DATETIME NULL,
    FOREIGN KEY (ClientId) REFERENCES Client(ClientId),
    FOREIGN KEY (InstitutionId) REFERENCES Institution(InstitutionId),
    FOREIGN KEY (UserId) REFERENCES [User](UserId),
    FOREIGN KEY (StatusId) REFERENCES Status(StatusId)
);

-- Order Details Table (added Discount)
CREATE TABLE OrderDetail (
    OrderDetailId INT PRIMARY KEY IDENTITY(1,1),
    OrderId INT NOT NULL,
    UniformItemId INT NULL,
    ItemId INT NULL,
    Quantity INT NOT NULL DEFAULT 1,
    Price DECIMAL(10, 2) NOT NULL,
    Discount DECIMAL(5, 2) NOT NULL DEFAULT 0, -- New field
    FOREIGN KEY (OrderId) REFERENCES [Order](OrderId),
    FOREIGN KEY (UniformItemId) REFERENCES UniformItems(UniformItemId),
    FOREIGN KEY (ItemId) REFERENCES Item(ItemId)
);

-- Price Histories Table
CREATE TABLE PriceHistory (
    PriceHistoryId INT PRIMARY KEY IDENTITY(1,1),
    ItemId INT NULL,
    UniformId INT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    PriceChangeReason NVARCHAR(255),
    ChangeDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ItemId) REFERENCES Item(ItemId),
    FOREIGN KEY (UniformId) REFERENCES Uniform(UniformId)
);

-- Notification Histories Table
CREATE TABLE NotificationHistory (
    NotificationId INT PRIMARY KEY IDENTITY(1,1),
    EntityType NVARCHAR(50) NOT NULL,
    EntityId INT NOT NULL,
    NotificationType NVARCHAR(50) NOT NULL,
    SentDate DATETIME NOT NULL DEFAULT GETDATE(),
    RecipientEmail NVARCHAR(100),
    SentStatus NVARCHAR(50)
);
