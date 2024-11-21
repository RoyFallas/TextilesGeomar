using TextilesGeomar.Core.Entities;

namespace TextilesGeomar.Core.Interfaces.Services
{
    public interface IInstitutionService
    {
        Task<IEnumerable<Institution>> GetInstitutions();
        Task<Institution> GetInstitutionById(int id);
        Task DeleteInstitution(int id);
        Task UpdateInstitution(Institution institution);
        Task AddInstitution(Institution institution);
    }
}


