using SoQuestoesIF.Domain.Interfaces;
using SoQuestoesIF.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class InstitutionService : IInstitutionService
    {
        private readonly IInstitutionRepository _repository;
        private readonly IUnitOfWork _uniOfWork;

        public InstitutionService(IInstitutionRepository repository, IUnitOfWork uniOfWork)
        {
            _repository = repository;
            _uniOfWork = uniOfWork;
        }

        public async Task<Institution> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Institution>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task AddAsync(Institution entity)
        {
            await _repository.AddAsync(entity);
            await _uniOfWork.CommitAsync();
        }                  
        public async Task UpdateAsync(IInstitutionService entity)
        {
            _repository.Update(entity);
            await _uniOfWork.CommitAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                _repository.Delete(entity);
                await _uniOfWork.CommitAsync();
            }
        }
    }
}
