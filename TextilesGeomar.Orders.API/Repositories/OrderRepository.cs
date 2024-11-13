using Microsoft.EntityFrameworkCore;
using TextilesGeomar.Core.Data;
using TextilesGeomar.Core.Models;
using TextilesGeomar.Core.Models.DTOs;

namespace TextilesGeomar.Orders.API.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TextilesGeomarDBContext _context;

        public OrderRepository(TextilesGeomarDBContext context)
        {
            _context = context;
        }

        public async Task SaveOrder(Order order)
        {
            _context.Orders.Add(order);

            await _context.SaveChangesAsync();
        }
    }
}