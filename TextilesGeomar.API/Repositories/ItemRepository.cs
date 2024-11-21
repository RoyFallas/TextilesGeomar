using Microsoft.EntityFrameworkCore;
using TextilesGeomar.Core.Data;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Repositories;

namespace TextilesGeomar.API.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly TextilesGeomarDBContext _context;
        public ItemRepository(TextilesGeomarDBContext context) 
        {
            _context = context;
        }
        public async Task AddItem(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null) 
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task UpdateItem(Item item)
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
