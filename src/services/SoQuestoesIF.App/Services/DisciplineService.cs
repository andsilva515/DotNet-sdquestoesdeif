using SoQuestoesIF.Domain.Interfaces;
using SoQuestoesIF.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class DisciplineService : IDisciplineService
    {

        private readonly IDisciplineRepository _reposistory;
        private readonly IUnitOfWork _unitOfWork;

        public DisciplineService(IDisciplineRepository repository, IUnitOfWork unitOfWork)
        {
            _reposistory = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Discipline> GetByIdAsync(Guid id)
        {
            return await _reposistory.GetByAllAsync();
        }

        public async Task<IEnumerable<Discipline>> GetAllAsync()
        {
            return await _reposistory.GetAllAsync();
        }
        public async Task AddAsync(Discipline entity)
        {
            await _reposistory.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }
      
        public async Task UpdateAsync(Discipline entity)
        {
            _reposistory.Update(entity);
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _reposistory.GetByIdAsync(id);
            if (entity != null)
            {
                _reposistory.Delete(entity);
                await _unitOfWork.CommitAsync();
            }
        }    
        
    }
}
