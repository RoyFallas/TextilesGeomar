using Microsoft.EntityFrameworkCore;
using TextilesGeomar.Core.Data;
using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Repositories;

namespace TextilesGeomar.API.Repositories
{
    public class InstitutionRepository : IInstitutionRepository
    {
        private readonly TextilesGeomarDBContext _context;

        public InstitutionRepository(TextilesGeomarDBContext context)
        {
            _context = context;
        }
        public async Task AddInstitution(Institution institution)
        {
            await _context.Institutions.AddAsync(institution);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteInstitution(int id)
        {
            var institution = await _context.Institutions.FindAsync(id);
            if (institution != null)
            {
                _context.Institutions.Remove(institution);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<Institution> GetInstitutionById(int id)
        {
            return await _context.Institutions.FindAsync(id);
        }

        public async Task<IEnumerable<Institution>> GetInstitutions()
        {
            return await _context.Institutions.ToListAsync();
        }

        public async Task UpdateInstitution(Institution institution)
        {
            _context.Institutions.Update(institution);
            await _context.SaveChangesAsync();
        }
    }
}

