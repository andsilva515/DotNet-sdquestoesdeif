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
    public class UserAnswerService : IUserAnswerService
    {
        private readonly IUserAnswerRepository _repository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IAlternativeRepository _alternativeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserAnswerService(
            IUserAnswerRepository repository,
            IQuestionRepository questionRepository,
            IAlternativeRepository alternativeRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _questionRepository = questionRepository;
            _alternativeRepository = alternativeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserAnswerDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Resposta não encontrada.");

            return _mapper.Map<UserAnswerDto>(entity);
        }

        public async Task<IEnumerable<UserAnswerDto>> GetAllByUserAsync(Guid userId)
        {
            var entities = await _repository.GetAllByUserAsync(userId);
            return _mapper.Map<IEnumerable<UserAnswerDto>>(entities);
        }

        public async Task<Guid> CreateAsync(UserAnswerCreateDto dto)
        {
            var question = await _questionRepository.GetByIdAsync(dto.QuestionId);
            if (question == null)
                throw new Exception("Questão não encontrada.");

            bool isCorrect;
            if (dto.AlternativeId.HasValue)
            {
                var alternative = await _alternativeRepository.GetByIdAsync(dto.AlternativeId.Value);
                if (alternative == null)
                    throw new Exception("Alternativa não encontrada.");

                isCorrect = alternative.IsCorrect;
            }
            else
            {
                // Se questão do tipo certo/errado: considerar "true" se sem alternativa
                isCorrect = true; // ou alguma outra lógica de conferência
            }

            var entity = new UserAnswer
            {
                Id = Guid.NewGuid(),
                UserId = dto.UserId,
                QuestionId = dto.QuestionId,
                AlternativeId = dto.AlternativeId,
                IsCorrect = isCorrect,
                AnsweredAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity.Id;
        }
    }
}

