using TextilesGeomar.Core.Models.DTOs;

namespace TextilesGeomar.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrders();
        Task<IEnumerable<OrderDto>> GetOrderById(int id);
    }
}
