using TextilesGeomar.Core.Models;
using TextilesGeomar.Core.Interfaces.Repositories;
using TextilesGeomar.Core.Interfaces.Services;
using TextilesGeomar.Core.Entities;
namespace TextilesGeomar.Orders.API.Services
{
    public class ConsumeOrderService : IConsumeOrderService
    {
        private readonly IConsumeOrderRepository _orderRepository;

        public ConsumeOrderService(IConsumeOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task SaveOrder(Order order)
        {
            await _orderRepository.SaveOrder(order);
        }
    }
}
