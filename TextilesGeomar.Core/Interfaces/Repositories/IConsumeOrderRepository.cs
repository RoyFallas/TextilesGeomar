using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Interfaces.Repositories
{
    public interface IConsumeOrderRepository
    {
        Task SaveOrder(Order order);
    }
}
