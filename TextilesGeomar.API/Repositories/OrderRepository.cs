using TextilesGeomar.Core.Interfaces.Repositories;
using TextilesGeomar.Core.Data;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using TextilesGeomar.Core.Models.DTOs;
using TextilesGeomar.Core.DTOs;

namespace TextilesGeomar.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TextilesGeomarDBContext _context;

        public OrderRepository(TextilesGeomarDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            return await _context.Orders
                .Select(o => new OrderDto
                {
                    OrderId = o.OrderId,
                    ClientId = o.ClientId,
                    ClientName = o.Client.Name,
                    ClientEmail = o.Client.Email,
                    InstitutionId = o.Institution.InstitutionId,
                    InstitutionName = o.Institution.Name,
                    UserId = o.UserId,
                    Username = o.User.Name,
                    StatusId = o.StatusId,
                    OrderStatus = o.Status.Name,
                    OrderDiscount = o.Discount,
                    OrderTotalPrice = o.TotalPrice,
                    OrderCreatedDate = o.CreatedDate,
                    OrderCompletedDate = o.CompletedDate,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        OrderItemId = oi.OrderItemId,
                        ItemId = oi.ItemId,
                        ItemName = oi.Item.Name,
                        Quantity = oi.Quantity,
                        ItemPrice = oi.Price
                    }).ToList()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderDto>> GetOrderById(int id)
        {
            return await _context.Orders
                .Select(o => new OrderDto
                {
                    OrderId = o.OrderId,
                    ClientId = o.ClientId,
                    ClientName = o.Client.Name,
                    ClientEmail = o.Client.Email,
                    InstitutionId = o.Institution.InstitutionId,
                    InstitutionName = o.Institution.Name,
                    UserId = o.UserId,
                    Username = o.User.Name,
                    StatusId = o.StatusId,
                    OrderStatus = o.Status.Name,
                    OrderDiscount = o.Discount,
                    OrderTotalPrice = o.TotalPrice,
                    OrderCreatedDate = o.CreatedDate,
                    OrderCompletedDate = o.CompletedDate,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        OrderItemId = oi.OrderItemId,
                        ItemId = oi.ItemId,
                        ItemName = oi.Item.Name,
                        Quantity = oi.Quantity,
                        ItemPrice = oi.Price
                    }).ToList()
                })
                .Where(o => o.OrderId == id)
                .ToListAsync();
        }

        //public async Task<IEnumerable<OrderDetailDto>> GetOrderDetails()
        //{
        //    return await _context.Orders
        //        .Join(_context.OrderDetails, o => o.OrderId, od => od.OrderId, (o, od) => new { o, od })
        //        .Join(_context.Items, temp => temp.od.ItemId, i => i.ItemId, (temp, i) => new { temp.o, temp.od, i })
        //        .Join(_context.UniformItems, temp => temp.od.UniformItemId, ui => ui.UniformItemId, (temp, ui) => new { temp.o, temp.od, temp.i, ui })
        //        .Join(_context.Uniforms, temp => temp.ui.UniformId, u => u.UniformId, (temp, u) => new { temp.o, temp.od, temp.i, temp.ui, u })
        //        .Select(temp => new OrderDetailDto
        //        {
        //            OrderId = temp.o.OrderId,
        //            OrderDetailId = temp.od.OrderDetailId,
        //            ItemName = temp.i.Name,
        //            Quantity = temp.od.Quantity,
        //            OrderPrice = (temp.od.Price - (temp.od.Price * temp.od.Discount / 100)) * temp.od.Quantity,
        //            ItemPrice = temp.i.Price,
        //            Discount = temp.od.Discount
        //        })
        //        .ToListAsync();
        //}

    }
}
