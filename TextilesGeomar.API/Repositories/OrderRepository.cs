using Microsoft.EntityFrameworkCore;
using TextilesGeomar.Core.Data;
using TextilesGeomar.Core.Models;

namespace TextilesGeomar.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TextilesGeomarDBContext _context;

        public OrderRepository(TextilesGeomarDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Institution)
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Institution)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }
    }
}
