using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Models.DTOs;

namespace TextilesGeomar.Core.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderDto>> GetOrders();
        Task<IEnumerable<OrderDto>> GetOrderById(int id);
    }
}
