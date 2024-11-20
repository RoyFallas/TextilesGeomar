using TextilesGeomar.Core.DTOs;
using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserDto>> GetUsers();
        Task<User> GetUserById(int id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(int id);
    }
}
