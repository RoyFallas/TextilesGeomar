using TextilesGeomar.Core.Models;
using TextilesGeomar.Core.Interfaces.Repositories;
using TextilesGeomar.Core.Interfaces.Services;
using TextilesGeomar.Core.Entities;
namespace TextilesGeomar.Orders.API.Services
{
    public class ConsumeOrderService : IConsumeOrderService
    {
        private readonly IConsumeOrderRepository _consumeOrderRepository;

        public ConsumeOrderService(IConsumeOrderRepository consumeOrderRepository)
        {
            _consumeOrderRepository = consumeOrderRepository;
        }

        public async Task SaveOrder(Order order)
        {
            await _consumeOrderRepository.SaveOrder(order);
        }
    }
}
