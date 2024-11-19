-- Insert Statuses
INSERT INTO Status (Name, Description)
VALUES 
    ('Pending', 'Order is pending'),
    ('Completed', 'Order is completed'),
    ('Delivered', 'Order is delivered');

-- Insert roles
INSERT INTO [Role] (Name, Description) 
VALUES ('Admin', 'Administrator of the system'),
       ('User', 'Regular user');

-- Insert users
INSERT INTO [User] (RoleId, Name, LastName, Email, Phone, Password)
VALUES 
    (1, 'Marjorie', 'Tencio', 'marjorie@example.com', '123456789', 'password123'),
    (1, 'Geovanny', 'Monge', 'geovanny@example.com', '987654321', 'password123');

-- Insert institutions
INSERT INTO Institution (Name, Address, Phone)
VALUES 
    ('CTP José Figueres Ferrer', 'San José, Costa Rica', '22223333'),
    ('Liceo Frailes', 'Frailes, Costa Rica', '33334444');

-- Insert clients
INSERT INTO Client (InstitutionId, Name, LastName, Email, Phone)
VALUES 
    ((SELECT InstitutionId FROM Institution WHERE Name = 'CTP José Figueres Ferrer'), 'Roy', 'Fallas', 'roy.fallas@example.com', '55555555'),
    ((SELECT InstitutionId FROM Institution WHERE Name = 'Liceo Frailes'), 'Trasi', 'Barrios', 'trasi.b@example.com', '66666666');

-- Insert items
INSERT INTO Item (InstitutionId, Name, Description, Size, Color, FabricType, Price)
VALUES 
    (NULL, 'Sueter', 'A warm sweater', 'M', 'Red', 'Cotton', 15.00),
    (NULL, 'Blazer', 'Formal blazer', 'L', 'Black', 'Wool', 50.00),
    ((SELECT InstitutionId FROM Institution WHERE Name = 'CTP José Figueres Ferrer'), 'Pantalón José Figueres Ferrer', 'Pantalón for CTP José Figueres Ferrer', 'L', 'Blue', 'Denim', 25.00),
    ((SELECT InstitutionId FROM Institution WHERE Name = 'CTP José Figueres Ferrer'), 'Camisa José Figueres Ferrer', 'Camisa for CTP José Figueres Ferrer', 'M', 'White', 'Cotton', 20.00),
    ((SELECT InstitutionId FROM Institution WHERE Name = 'CTP José Figueres Ferrer'), 'Medias José Figueres Ferrer', 'Medias for CTP José Figueres Ferrer', 'M', 'White', 'Cotton', 10.00),
    ((SELECT InstitutionId FROM Institution WHERE Name = 'Liceo Frailes'), 'Pantalón Liceo Frailes', 'Pantalón for Liceo Frailes', 'M', 'Gray', 'Polyester', 30.00),
    ((SELECT InstitutionId FROM Institution WHERE Name = 'Liceo Frailes'), 'Camisa Liceo Frailes', 'Camisa for Liceo Frailes', 'M', 'Red', 'Cotton', 18.00),
    ((SELECT InstitutionId FROM Institution WHERE Name = 'Liceo Frailes'), 'Medias Liceo Frailes', 'Medias for Liceo Frailes', 'M', 'Black', 'Cotton', 8.00);

-- Insert first order (Uniform for CTP José Figueres Ferrer)
INSERT INTO [Order] (ClientId, InstitutionId, UserId, StatusId, Discount, TotalPrice, CreatedDate)
VALUES 
    (
        (SELECT ClientId FROM Client WHERE Name = 'Roy' AND LastName = 'Fallas'),
        (SELECT InstitutionId FROM Institution WHERE Name = 'CTP José Figueres Ferrer'),
        (SELECT UserId FROM [User] WHERE Name = 'Marjorie' AND LastName = 'Tencio'),
        (SELECT StatusId FROM Status WHERE Name = 'Pending'), -- StatusId for Pending
        10.00, -- Discount
        0.00,  -- TotalPrice (will update below)
        GETDATE()
    );

-- Insert order items for the first order
DECLARE @FirstOrderId INT = SCOPE_IDENTITY();

INSERT INTO OrderItem (OrderId, ItemId, Quantity, Price)
VALUES 
    (@FirstOrderId, (SELECT ItemId FROM Item WHERE Name = 'Pantalón José Figueres Ferrer'), 1, 25.00),
    (@FirstOrderId, (SELECT ItemId FROM Item WHERE Name = 'Camisa José Figueres Ferrer'), 1, 20.00),
    (@FirstOrderId, (SELECT ItemId FROM Item WHERE Name = 'Medias José Figueres Ferrer'), 1, 10.00);

-- Update total price for the first order
UPDATE [Order]
SET TotalPrice = (SELECT SUM(Price * Quantity) - Discount FROM OrderItem WHERE OrderId = @FirstOrderId)
WHERE OrderId = @FirstOrderId;

-- Insert second order (Two independent items: Sueter and Blazer)
INSERT INTO [Order] (ClientId, InstitutionId, UserId, StatusId, Discount, TotalPrice, CreatedDate)
VALUES 
    (
        (SELECT ClientId FROM Client WHERE Name = 'Trasi' AND LastName = 'Barrios'),
        NULL, -- No InstitutionId for independent items
        (SELECT UserId FROM [User] WHERE Name = 'Geovanny' AND LastName = 'Monge'),
        (SELECT StatusId FROM Status WHERE Name = 'Pending'), -- StatusId for Pending
        5.00, -- Discount
        0.00, -- TotalPrice (will update below)
        GETDATE()
    );

-- Insert order items for the second order
DECLARE @SecondOrderId INT = SCOPE_IDENTITY();

INSERT INTO OrderItem (OrderId, ItemId, Quantity, Price)
VALUES 
    (@SecondOrderId, (SELECT ItemId FROM Item WHERE Name = 'Sueter'), 1, 15.50),
    (@SecondOrderId, (SELECT ItemId FROM Item WHERE Name = 'Blazer'), 1, 50.00);

-- Update total price for the second order
UPDATE [Order]
SET TotalPrice = (SELECT SUM(Price * Quantity) - Discount FROM OrderItem WHERE OrderId = @SecondOrderId)
WHERE OrderId = @SecondOrderId;

