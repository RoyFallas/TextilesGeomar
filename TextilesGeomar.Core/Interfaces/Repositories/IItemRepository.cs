using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Interfaces.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItems();
        Task <Item> GetItemById(int id);
        Task AddItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(int id);    
    }
}
