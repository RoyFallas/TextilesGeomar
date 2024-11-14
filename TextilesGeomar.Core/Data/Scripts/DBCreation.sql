--Create Database textilesgeomar;

use textilesgeomar;


CREATE TABLE Roles (
    RoleId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Description NVARCHAR(255)
);

CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    RoleId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(50),
    Password NVARCHAR(255) NOT NULL,
    FOREIGN KEY (RoleId) REFERENCES Roles(RoleId)
);

CREATE TABLE Institutions (
    InstitutionId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    Phone NVARCHAR(50)
);

CREATE TABLE Clients (
    ClientId INT PRIMARY KEY IDENTITY(1,1),
    InstitutionId INT NULL,
    Name NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Address NVARCHAR(255),
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Phone NVARCHAR(50),
    FOREIGN KEY (InstitutionId) REFERENCES Institutions(InstitutionId)
);

CREATE TABLE OrderStatuses (
    StatusId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE UniformStatuses (
    StatusId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE ItemStatuses (
    StatusId INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Uniforms (
    UniformId INT PRIMARY KEY IDENTITY(1,1),
    InstitutionId INT NULL,
    StatusId INT NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (InstitutionId) REFERENCES Institutions(InstitutionId),
    FOREIGN KEY (StatusId) REFERENCES UniformStatuses(StatusId)
);

CREATE TABLE Items (
    ItemId INT PRIMARY KEY IDENTITY(1,1),
    UniformId INT NULL,
    StatusId INT NOT NULL,
    InstitutionId INT NULL,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Size NVARCHAR(50),
    Color NVARCHAR(50),
    FabricType NVARCHAR(50),
    Price DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (UniformId) REFERENCES Uniforms(UniformId),
    FOREIGN KEY (StatusId) REFERENCES ItemStatuses(StatusId),
    FOREIGN KEY (InstitutionId) REFERENCES Institutions(InstitutionId)
);

CREATE TABLE Orders (
    OrderId INT PRIMARY KEY IDENTITY(1,1),
    ItemId INT NULL,
    UniformId INT NULL,
    ClientId INT NOT NULL,
    InstitutionId INT NULL,
    StatusId INT NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    CompletedDate DATETIME NULL,
    FOREIGN KEY (ItemId) REFERENCES Items(ItemId),
    FOREIGN KEY (UniformId) REFERENCES Uniforms(UniformId),
    FOREIGN KEY (ClientId) REFERENCES Clients(ClientId),
    FOREIGN KEY (InstitutionId) REFERENCES Institutions(InstitutionId),
    FOREIGN KEY (StatusId) REFERENCES OrderStatuses(StatusId)
);

CREATE TABLE PriceHistories (
    PriceHistoryId INT PRIMARY KEY IDENTITY(1,1),
    ItemId INT NULL,
    UniformId INT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    PriceChangeReason NVARCHAR(255),
    ChangeDate DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ItemId) REFERENCES Items(ItemId),
    FOREIGN KEY (UniformId) REFERENCES Uniforms(UniformId)
);

CREATE TABLE NotificationHistories (
    NotificationId INT PRIMARY KEY IDENTITY(1,1),
    EntityType NVARCHAR(50) NOT NULL,  -- E.g., 'Uniform', 'Item'
    EntityId INT NOT NULL,
    NotificationType NVARCHAR(50) NOT NULL,  -- E.g., 'Status Changed', 'Order Completed'
    SentDate DATETIME NOT NULL DEFAULT GETDATE(),
    RecipientEmail NVARCHAR(100),
    SentStatus NVARCHAR(50)  -- E.g., 'Sent', 'Failed'
);
