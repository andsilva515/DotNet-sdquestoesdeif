using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using SoQuestoesIF.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class AgencyService : IAgencyService
    {
        private readonly IAgencyRepository _repository;
        private readonly IUnitOfWork _uniOfWork;

        public AgencyService(IAgencyRepository repository, IUnitOfWork uniOfWork)
        {
            _repository = repository;
            _uniOfWork = uniOfWork;
        }

        public async Task<Agency> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<Agency>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task AddAsync(Agency entity)
        {
            await _repository.AddAsync(entity);
            await _uniOfWork.CommitAsync();
        }                  
        public async Task UpdateAsync(IAgencyService entity)
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
