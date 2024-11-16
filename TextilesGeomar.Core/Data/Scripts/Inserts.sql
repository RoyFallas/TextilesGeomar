-- Insert Roles
INSERT INTO [Role] (Name, Description)
VALUES 
('Admin', 'Administrator role with full access rights'),
('Manager', 'Manager role with limited access to manage orders and clients'),
('User', 'Basic user role with access to only their orders and client details');

-- Insert Users
INSERT INTO [User] (RoleId, Name, LastName, Address, Email, Phone, Password)
VALUES 
(1, 'Marjorie', 'Tencio', '123 Main St', 'marjorie.tencio@example.com', '555-1234', 'hashedpassword1'),
(2, 'Geovanny', 'Monge', '456 Oak St', 'geovanny.monge@example.com', '555-5678', 'hashedpassword2');

-- Insert Institutions (High Schools)
INSERT INTO Institution (Name, Address, Phone)
VALUES 
('CTP José Figueres Ferrer', '123 High School St, City', '555-2222'),
('Liceo Frailes', '456 High School Ave, City', '555-3333');

-- Insert Clients
INSERT INTO Client (InstitutionId, Name, LastName, Address, Email, Phone)
VALUES 
(1, 'Roy', 'Fallas', '789 Pine St', 'roy.fallas@example.com', '555-1111'),
(2, 'Trasi', 'Barrios', '101 Elm St', 'trasi.barrios@example.com', '555-4444');

-- Insert Statuses
INSERT INTO Status (Name, Description)
VALUES 
('Pending', 'Order is in progress'),
('Completed', 'Order is completed'),
('Delivered', 'Order is delivered');

-- Insert Uniforms
INSERT INTO Uniform (InstitutionId, Name)
VALUES 
(1, 'Uniforme CTP José Figueres Ferrer'),
(2, 'Uniforme Liceo Frailes');

-- Insert Items (with no uniform association)
INSERT INTO Item (UniformId, InstitutionId, Name, Description, Size, Color, FabricType, Price)
VALUES 
(NULL, NULL, 'Sueter', 'Warm sweater', 'M', 'Red', 'Wool', 29.99),
(NULL, NULL, 'Blazer', 'Formal blazer', 'L', 'Black', 'Cotton', 45.99),
(1, 1, 'Pantalón José Figueres Ferrer', 'Pants for CTP José Figueres Ferrer', 'M', 'Gray', 'Polyester', 25.99),
(1, 1, 'Camisa José Figueres Ferrer', 'Shirt for CTP José Figueres Ferrer', 'M', 'White', 'Cotton', 15.99),
(1, 1, 'Medias José Figueres Ferrer', 'Socks for CTP José Figueres Ferrer', 'M', 'White', 'Cotton', 5.99),
(2, 2, 'Pantalón Liceo Frailes', 'Pants for Liceo Frailes', 'L', 'Blue', 'Polyester', 28.99),
(2, 2, 'Camisa Liceo Frailes', 'Shirt for Liceo Frailes', 'L', 'Blue', 'Cotton', 17.99),
(2, 2, 'Medias Liceo Frailes', 'Socks for Liceo Frailes', 'L', 'Blue', 'Cotton', 6.99);

-- Insert UniformItems (relationship between uniforms and items)
INSERT INTO UniformItems (UniformId, ItemId, Quantity)
VALUES 
(1, 3, 1),
(1, 4, 1),
(1, 5, 1),
(2, 6, 1),
(2, 7, 1),
(2, 8, 1);

-- Insert Orders
INSERT INTO [Order] (ClientId, InstitutionId, UserId, StatusId, CreatedDate)
VALUES 
(1, 1, 1, 1, '2024-11-01'),
(2, 2, 2, 1, '2024-11-02');

-- Insert OrderDetails
-- Insert OrderDetails with Discounts
INSERT INTO OrderDetail (OrderId, ItemId, UniformItemId, Quantity, Price, Discount)
VALUES 
(1, 3, 1, 1, 25.99, 10.00), -- 10% discount on item price
(1, 4, 1, 2, 15.99, 5.00),  -- 5% discount
(1, 5, 1, 1, 5.99, 0.00),   -- No discount
(2, 6, 2, 1, 59.99, 15.00); -- 15% discount


-- Insert Price Histories
INSERT INTO PriceHistory (ItemId, UniformId, Price, PriceChangeReason, ChangeDate)
VALUES 
(3, NULL, 26.99, 'Price update', '2024-11-03'),
(4, NULL, 17.99, 'Price update', '2024-11-03'),
(6, NULL, 29.99, 'New price', '2024-11-03');

-- Insert Notification Histories
INSERT INTO NotificationHistory (EntityType, EntityId, NotificationType, SentDate, RecipientEmail, SentStatus)
VALUES 
('Order', 1, 'Order Created', '2024-11-01', 'roy.fallas@example.com', 'Sent'),
('Item', 4, 'Item Price Updated', '2024-11-03', 'marjorie.tencio@example.com', 'Sent'),
('Order', 2, 'Order Completed', '2024-11-02', 'trasi.barrios@example.com', 'Sent');
