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

        public Task AddRole(Role Role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRole(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetRoleById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Role>> GetRoles()
        {
            await _repository.GetAllAsync();
            return await _repository.GetAllAsync();
        }

        public Task UpdateRole(Role Role)
        {
            throw new NotImplementedException();
        }
    }
}
