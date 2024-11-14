using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Interfaces.Services
{
    public interface IConsumeOrderService
    {
        Task SaveOrder(Order order);
    }
}
