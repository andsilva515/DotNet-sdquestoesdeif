using AutoMapper;
using SoQuestoesIF.App.Dtos;
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
    public class CommentUserService : ICommentUserService
    {
        private readonly ICommentUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentUserService(
            ICommentUserRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentUserDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Comentário não encontrado.");

            return _mapper.Map<CommentUserDto>(entity);
        }

        public async Task<IEnumerable<CommentUserDto>> GetAllByQuestionAsync(Guid questionId)
        {
            var entities = await _repository.GetAllByQuestionAsync(questionId);
            return _mapper.Map<IEnumerable<CommentUserDto>>(entities);
        }

        public async Task<Guid> CreateAsync(CommentUserCreateDto dto)
        {
            var entity = new CommentUser
            {
                Id = Guid.NewGuid(),
                QuestionId = dto.QuestionId,
                UserId = dto.UserId,
                Content = dto.Content,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, CommentUserUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Comentário não encontrado.");

            entity.Content = dto.Content;

            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Comentário não encontrado.");

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
