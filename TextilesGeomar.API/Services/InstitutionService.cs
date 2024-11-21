using TextilesGeomar.Core.Entities;
using TextilesGeomar.Core.Interfaces.Repositories;
using TextilesGeomar.Core.Interfaces.Services;

namespace TextilesGeomar.API.Services
{
    public class InstitutionService:IInstitutionService
    {
        private readonly IInstitutionRepository _repository;
        public InstitutionService(IInstitutionRepository repository) 
        {
            _repository = repository;
        }

        public async Task AddInstitution(Institution institution)
        {
            await _repository.AddInstitution(institution);
        }

        public async Task DeleteInstitution(int id)
        {
            await _repository.DeleteInstitution(id);
        }

        public async Task<Institution> GetInstitutionById(int id)
        {
            return await _repository.GetInstitutionById(id);
        }

        public async Task<IEnumerable<Institution>> GetInstitutions()
        {
            return await _repository.GetInstitutions(); 
        }

        public async Task UpdateInstitution(Institution institution)
        {
            await _repository.UpdateInstitution(institution);
        }
    }
}
