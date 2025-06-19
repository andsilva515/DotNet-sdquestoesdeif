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
    public class EducationLevelService : IEducationLevelService
    {

        private readonly IEducationLevelRepostory _repository;
        private readonly IUnitOfWork _unitOfWork;

        public EducationLevelService(IEducationLevelRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<EducationLevel> GetByIdAsync(Guid id)
        {
            return await -_repository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<EducationLevel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task AddAsync(EducationLevel entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateAsync(EducationLevel entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
            {
                _repository.Delete(entity);
                await _unitOfWork.CommitAsync();
            }
        }                 
       
    }
}
