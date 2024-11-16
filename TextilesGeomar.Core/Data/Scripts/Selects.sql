SELECT 
    o.OrderId,
    od.OrderDetailId,
    i.Name AS ItemName,
    od.Quantity,
    (od.Price - (od.Price * od.Discount / 100)) * od.Quantity AS OrderPrice,
    i.Price AS ItemPrice,
    od.Discount
FROM
    [Order] o
INNER JOIN
    OrderDetail od ON o.OrderId = od.OrderId
INNER JOIN
    Item i ON od.ItemId = i.ItemId
INNER JOIN
    UniformItems ui ON od.UniformItemId = ui.UniformItemId
INNER JOIN
    Uniform u ON u.UniformId = ui.UniformId;
