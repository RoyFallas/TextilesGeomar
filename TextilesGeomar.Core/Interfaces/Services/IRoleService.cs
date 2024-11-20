
using TextilesGeomar.Core.DTOs;
using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Interfaces.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetRoles();
        Task<Role> GetRoleById(int id);
        Task AddRole(Role Role);
        Task UpdateRole(Role Role);
        Task DeleteRole(int id);
    }
}
