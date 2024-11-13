using TextilesGeomar.Core.Models;
using TextilesGeomar.Core.Models.DTOs;

namespace TextilesGeomar.Orders.API.Services
{
    public interface IOrderService
    {
        Task SaveOrder(Order order);
    }
}
