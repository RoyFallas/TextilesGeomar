using TextilesGeomar.Core.Models;

namespace TextilesGeomar.Data.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
    }
}
