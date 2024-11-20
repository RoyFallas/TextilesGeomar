using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TextilesGeomar.Core.DTOs;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Repositories;
using TextilesGeomar.Core.Interfaces.Services;

namespace TextilesGeomar.API.Services
{
    public class UserService : IUserService
    {
        IUserRepository _repository;
        public UserService(IUserRepository repository) 
        {
            _repository = repository;
        }
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _repository.GetUsers();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _repository.GetUserById(id);
        }
        public async Task AddUser(User user)
        {
            await _repository.AddUser(user);
        }
        public async Task UpdateUser(User user)
        {
            await _repository.UpdateUser(user);
        }
        public async Task DeleteUser(int id) 
        {
            await _repository.DeleteUser(id);
        }
    }
}
