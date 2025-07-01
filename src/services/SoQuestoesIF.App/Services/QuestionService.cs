using AutoMapper;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Enums;
using SoQuestoesIF.Domain.Interfaces;
using SoQuestoesIF.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _repository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<QuestionDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Questão não encontrada.");

            return _mapper.Map<QuestionDto>(entity);
        }

        public async Task<IEnumerable<QuestionDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<QuestionDto>>(entities);
        }

        public async Task<IEnumerable<QuestionDto>> GetByFilterAsync(
            Guid? agencyId,
            Guid? examBoardId,
            Guid? positionId,
            Guid? subjectId,
            Guid? topicId,
            EnumQuestionDifficulty? difficulty,
            int? year)
        {
            var entities = await _repository.GetByFilterAsync(
                agencyId, examBoardId, positionId, subjectId, topicId, difficulty, year);

            return _mapper.Map<IEnumerable<QuestionDto>>(entities);
        }

        public async Task<Guid> CreateAsync(QuestionDto dto)
        {
            var entity = _mapper.Map<Question>(dto);

            entity.Validate();

            await _repository.AddAsync(entity);

            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, QuestionDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Questão não encontrada.");

            entity.UpdateBasicInfo(
                dto.Statement,
                dto.Year,
                dto.QuestionDifficulty,
                dto.QuestionStatus,
                dto.ExamNumber,
                dto.ExamUrl,
                dto.FullExamUrl
            );

            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task RegisterAnswerAsync(Guid questionId, bool isCorrect)
        {
            var entity = await _repository.GetByIdAsync(questionId);
            if (entity == null)
                throw new Exception("Questão não encontrada.");

            entity.RegisterAnswer(isCorrect);

            await _repository.UpdateAsync(entity);
        }

        public async Task CancelAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Questão não encontrada.");

            entity.Cancel();

            await _unitOfWork.CommitAsync();
        }

    }

}
