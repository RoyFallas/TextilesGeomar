using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TextilesGeomar.Core.DTOs;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Repositories;
using TextilesGeomar.Core.Interfaces.Services;

namespace TextilesGeomar.API.Services
{
    public class RoleService : IRoleService
    {
        IGenericRepository<Role> _repository;
        public RoleService(IGenericRepository<Role> repository) 
        {
            _repository = repository;
        }

        public async Task AddRole(Role Role)
        {
            await _repository.AddAsync(Role);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteRole(int id)
        {
            await _repository.DeleteAsync(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            await _repository.GetAllAsync();
            return await _repository.GetAllAsync();
        }

        public async Task UpdateRole(Role Role)
        {
            await _repository.UpdateAsync(Role);
            await _repository.SaveChangesAsync();
        }
    }
}
