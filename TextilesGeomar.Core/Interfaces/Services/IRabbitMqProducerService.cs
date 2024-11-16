using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Interfaces.Services
{
    public interface IRabbitMqProducerService
    {
        Task SendOrderToQueueAsync(Order order);
    }
}
