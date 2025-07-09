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

        public async Task<QuestionSetDto> GetByIdAsync(Guid id, Guid currentUserId)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException("Caderno não encontrado.");

            if (entity.UserId != currentUserId)
                throw new UnauthorizedAccessException("Você não tem permissão para acessar este caderno.");

            return _mapper.Map<QuestionSetDto>(entity);
        }

        public async Task<PagedResult<QuestionSetDto>> GetAllAsync(QuestionSetFilterDto filter, Guid currentUserId)
        {
            // Garante que o filtro por UserId seja aplicado, para que um usuário só veja seus próprios cadernos
            filter.UserId = currentUserId;

            var pagedResult = await _repository.GetAllAsync(filter);

            var dtoList = pagedResult.Items.Select(e => _mapper.Map<QuestionSetDto>(e)).ToList();

            return new PagedResult<QuestionSetDto>
            {
                Items = dtoList,
                TotalCount = pagedResult.TotalCount,
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize
            };
        }

        public async Task<Guid> CreateAsync(QuestionSetCreateDto dto, Guid currentUserId)
        {
            if (dto.UserId != currentUserId)
            {
                throw new ValidationException("Você só pode criar cadernos para sua própria conta de usuário.");
            }

            // Valida se todas as QuestionIds fornecidas realmente existem
            foreach (var qid in dto.QuestionIds)
            {
                if (!await _repository.QuestionExistsAsync(qid))
                {
                    throw new ValidationException($"Questão com ID '{qid}' não encontrada. Não é possível criar o caderno.");
                }
            }

            var entity = _mapper.Map<QuestionSet>(dto);
            entity.Id = Guid.NewGuid();
            entity.CreatedAt = DateTime.UtcNow;
            entity.IsActive = true; // Cadernos são ativos por padrão ao serem criados

            await _repository.AddAsync(entity);
            await _repository.SaveQuestionSetQuestionsAsync(entity, dto.QuestionIds);
            await _unitOfWork.CommitAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, QuestionSetUpdateDto dto, Guid currentUserId)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException("Caderno não encontrado.");

            if (entity.UserId != currentUserId)
                throw new UnauthorizedAccessException("Você não tem permissão para atualizar este caderno.");

            // Valida se todas as QuestionIds fornecidas realmente existem
            foreach (var qid in dto.QuestionIds)
            {
                if (!await _repository.QuestionExistsAsync(qid))
                {
                    throw new ValidationException($"Questão com ID '{qid}' não encontrada. Não é possível atualizar o caderno.");
                }
            }

            _mapper.Map(dto, entity); // Mapeia as propriedades do DTO para a entidade existente

            _repository.Update(entity);
            await _repository.SaveQuestionSetQuestionsAsync(entity, dto.QuestionIds);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id, Guid currentUserId)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException("Caderno não encontrado.");

            if (entity.UserId != currentUserId)
                throw new UnauthorizedAccessException("Você não tem permissão para deletar este caderno.");

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
