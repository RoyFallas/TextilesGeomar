using TextilesGeomar.Core.Models.DTOs;

namespace TextilesGeomar.Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int id);
    }
}
