using TextilesGeomar.Core.Models;
using TextilesGeomar.Core.Models.DTOs;

namespace TextilesGeomar.Orders.API.Repositories
{
    public interface IOrderRepository
    {
        Task SaveOrder(Order order);
    }
}
