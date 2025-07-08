using AutoMapper;
using SoQuestoesIF.App.Dtos;
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
        private readonly IQuestionSetRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionSetService(IQuestionSetRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<QuestionSetDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Caderno não encontrado.");

            var dto = _mapper.Map<QuestionSetDto>(entity);
            dto.QuestionIds = entity.QuestionSetQuestions.Select(q => q.QuestionId).ToList();
            return dto;
        }

        public async Task<IEnumerable<QuestionSetDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new QuestionSetDto
            {
                Id = e.Id,
                Name = e.Name,
                Description = e.Description,
                CreatedAt = e.CreatedAt,
                UserId = e.UserId,
                IsActive = e.IsActive,
                QuestionIds = e.QuestionSetQuestions.Select(q => q.QuestionId).ToList()
            });
        }

        public async Task<Guid> CreateAsync(QuestionSetCreateDto dto)
        {
            var entity = new QuestionSet
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                UserId = dto.UserId,
                IsActive = true
            };

            await _repository.AddAsync(entity);
            await _repository.SaveQuestionSetQuestionsAsync(entity, dto.QuestionIds);
            await _unitOfWork.CommitAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, QuestionSetUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Caderno não encontrado.");

            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.IsActive = dto.IsActive;

            _repository.Update(entity);
            await _repository.SaveQuestionSetQuestionsAsync(entity, dto.QuestionIds);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Caderno não encontrado.");

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
