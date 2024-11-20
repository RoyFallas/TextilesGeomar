using Microsoft.EntityFrameworkCore;
using TextilesGeomar.Core.Data;
using TextilesGeomar.Core.DTOs;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Repositories;

namespace TextilesGeomar.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TextilesGeomarDBContext _context;
        public UserRepository(TextilesGeomarDBContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _context.Users.Select(u => new
            UserDto 
            {
                UserId = u.UserId,
                RoleId = u.RoleId,  
                RoleName = u.Role.Name,
                UserName = u.Name,
                UserLastName = u.LastName,
                Address = u.Address,
                Email = u.Email,
                Phone = u.Phone
            }).ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task AddUser(User user) 
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null) 
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}

