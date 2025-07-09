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
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamService(IExamRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ExamDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Simulado não encontrado.");

            var dto = _mapper.Map<ExamDto>(entity);
            dto.QuestionId = entity.ExamQuestions.Select(eq => eq.QuestionId).ToList();
            return dto;
        }

        public async Task<IEnumerable<ExamDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new ExamDto
            {
                Id = e.Id,
                Title = e.Title,
                CreatedAt = e.CreatedAt,
                UserId = e.UserId,
                IsActive = e.IsActive,
                QuestionId = e.ExamQuestions.Select(eq => eq.QuestionId).ToList()
            });
        }

        public async Task<Guid> CreateAsync(ExamCreateDto dto)
        {
            var exam = new Exam
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                CreatedAt = DateTime.UtcNow,
                ExamQuestions = dto.QuestionIds.Select(qId => new ExamQuestion
                {
                    ExamId = Guid.NewGuid(),
                    QuestionId = qId
                }).ToList()
            };

            await _repository.AddAsync(exam);
            await _unitOfWork.CommitAsync();

            return exam.Id;
        }


        public async Task UpdateAsync(Guid id, ExamUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Simulado não encontrado.");

            entity.Title = dto.Title;
            entity.IsActive = dto.IsActive;

            _repository.Update(entity);
            await _repository.SaveExamQuestionsAsync(entity, dto.QuestionIds);
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity != null)
                throw new Exception("Simulado não encontrado.");
            
                _repository.Delete(entity);
                await _unitOfWork.CommitAsync();
        }
    }       
    
}
