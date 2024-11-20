using Microsoft.EntityFrameworkCore;
using TextilesGeomar.Core.Data;
using TextilesGeomar.Core.Interfaces.Repositories;

namespace TextilesGeomar.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TextilesGeomarDBContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(TextilesGeomarDBContext context) 
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null) 
            {
                _dbSet.Remove(result);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
