using TextilesGeomar.Core.Interfaces.Services;
using TextilesGeomar.Core.Interfaces.Repositories;
using TextilesGeomar.Core.Models.DTOs;
using TextilesGeomar.Core.Entities;
namespace TextilesGeomar.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }

        public async Task<IEnumerable<OrderDto>> GetOrderById(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }
    }
}
