using SoQuestoesIF.App.Interfaces;
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
    public class ExamBoardService : IExamBoardService
    {
        private readonly IExamBoardRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ExamBoardService(IExamBoardRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<ExamBoard> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<ExamBoard>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
        public async Task AddAsync(ExamBoard entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }                
        public async Task UpdateAsync(ExamBoard entity)
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
