using System.Runtime.CompilerServices;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Repositories;
using TextilesGeomar.Core.Interfaces.Services;

namespace TextilesGeomar.API.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _repository;
        public ItemService(IItemRepository repository) 
        {
            _repository = repository;
        }
        public async Task AddItem(Item item)
        {
            await _repository.AddItem(item);
        }

        public async Task DeleteItem(int id)
        {
            await _repository.DeleteItem(id);
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _repository.GetItemById(id);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _repository.GetItems();
        }

        public async Task UpdateItem(Item item)
        {
            await _repository.UpdateItem(item);
        }
    }
}
