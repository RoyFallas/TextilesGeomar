using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Interfaces.Repositories
{
    public interface IInstitutionRepository
    {
        Task<IEnumerable<Institution>> GetInstitutions();
        Task<Institution> GetInstitutionById(int id);
        Task DeleteInstitution(int id);
        Task UpdateInstitution(Institution institution);
        Task AddInstitution(Institution institution);
    }
}

