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
    public class QuestionSetService : IQuestionSetService
    {   
        private readonly IQuestionSetService _repository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionSetService(IQuestionSetRepositoty repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<QuestionSet> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<QuestionSet>> GetAllAsync()
        {
            return await _repository.GetByIdAsync();
        }
        public async Task AddAsync(QuestionSet entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateAsync(QuestionSet entity)
        {
            _repository.UpdateAsync(entity);
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
