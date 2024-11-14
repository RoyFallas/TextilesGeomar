using Microsoft.EntityFrameworkCore;
using TextilesGeomar.Core.Data;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Repositories;

namespace TextilesGeomar.Orders.API.Repositories
{
    public class ConsumeOrderRepository : IConsumeOrderRepository
    {
        private readonly TextilesGeomarDBContext _context;

        public ConsumeOrderRepository(TextilesGeomarDBContext context)
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