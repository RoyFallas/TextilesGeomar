using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Interfaces.Services
{
    public interface IItemService
    {
        Task <IEnumerable<Item>>GetItems();
        Task <Item>GetItemById(int id);
        Task AddItem(Item item);
        Task UpdateItem(Item item);
        Task DeleteItem(int id);
    }
}
