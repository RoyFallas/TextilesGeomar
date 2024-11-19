SELECT 
    o.OrderId,
    o.ClientId,
    c.Name AS ClientName,
    c.Email AS ClientEmail,
    o.StatusId,
    s.Name AS OrderStatus,
    o.Discount AS OrderDiscount,
    o.TotalPrice AS OrderTotalPrice,
    o.CreatedDate AS OrderCreatedDate,
    o.CompletedDate AS OrderCompletedDate,
    -- Generate a list of order items as JSON
    (
        SELECT 
            oi.OrderItemId,
            i.Name AS ItemName,
            oi.Quantity,
            oi.Price AS ItemPrice,
            (oi.Quantity * oi.Price) AS ItemTotal
        FROM 
            OrderItem oi
        JOIN 
            Item i ON oi.ItemId = i.ItemId
        WHERE 
            oi.OrderId = o.OrderId
        FOR JSON PATH
    ) AS OrderItems -- Nested list of order items as JSON
FROM 
    [Order] o
JOIN 
    Client c ON o.ClientId = c.ClientId
JOIN 
    Status s ON o.StatusId = s.StatusId
WHERE 
    o.OrderId = 1; -- Specify the OrderId you want to retrieve
