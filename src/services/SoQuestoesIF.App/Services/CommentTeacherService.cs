using AutoMapper;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class CommentTeacherService : ICommentTeacherService
    {
        private readonly ICommentTeacherRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentTeacherService(
            ICommentTeacherRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommentTeacherDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Comentário não encontrado.");
            return _mapper.Map<CommentTeacherDto>(entity);
        }

        public async Task<IEnumerable<CommentTeacherDto>> GetAllByQuestionAsync(Guid questionId)
        {
            var list = await _repository.GetAllByQuestionAsync(questionId);
            return _mapper.Map<IEnumerable<CommentTeacherDto>>(list);
        }

        public async Task<Guid> CreateAsync(CommentTeacherCreateDto dto)
        {
            var entity = new CommentTeacher
            {
                Id = Guid.NewGuid(),
                Text = dto.Text,
                QuestionId = dto.QuestionId,
                UserProfId = dto.UserProfId,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Comentário não encontrado.");

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
