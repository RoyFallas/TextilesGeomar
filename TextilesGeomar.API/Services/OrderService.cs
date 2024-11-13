using TextilesGeomar.Data.Repositories;
using TextilesGeomar.Core.Models;
using TextilesGeomar.Core.Models.DTOs;
namespace TextilesGeomar.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetOrdersAsync();

            return orders.Select(o => new OrderDto
            {
                OrderId = o.OrderId,
                StatusId = o.StatusId,
                CreatedDate = o.CreatedDate,
                CompletedDate = o.CompletedDate,
                ClientName = o.Client.Name + " " + o.Client.LastName,
                InstitutionName = o.Institution?.Name ?? "N/A"
            });
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderByIdAsync(id);

            if (order == null)
                return null;

            return new OrderDto
            {
                OrderId = order.OrderId,
                StatusId = order.StatusId,
                CreatedDate = order.CreatedDate,
                CompletedDate = order.CompletedDate,
                ClientName = order.Client.Name + " " + order.Client.LastName,
                InstitutionName = order.Institution?.Name ?? "N/A"
            };
        }
    }
}
