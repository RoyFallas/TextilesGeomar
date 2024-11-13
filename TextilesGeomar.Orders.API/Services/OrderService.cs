using TextilesGeomar.Orders.API.Repositories;
using TextilesGeomar.Core.Models;
namespace TextilesGeomar.Orders.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task SaveOrder(Order order)
        {
            await _orderRepository.SaveOrder(order);
        }
    }
}
