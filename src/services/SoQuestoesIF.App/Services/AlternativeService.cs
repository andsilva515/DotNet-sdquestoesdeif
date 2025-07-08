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
    public class AlternativeService : IAlternativeService
    {
        private readonly IAlternativeRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlternativeService(
            IAlternativeRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AlternativeDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Alternativa não encontrada.");
            return _mapper.Map<AlternativeDto>(entity);
        }

        public async Task<IEnumerable<AlternativeDto>> GetAllByQuestionAsync(Guid questionId)
        {
            var list = await _repository.GetAllByQuestionIdAsync(questionId);
            return _mapper.Map<IEnumerable<AlternativeDto>>(list);
        }

        public async Task<Guid> CreateAsync(AlternativeCreateDto dto)
        {
            var entity = new Alternative
            {
                Id = Guid.NewGuid(),
                Letter = dto.Letter,
                Text = dto.Text,
                IsCorrect = dto.IsCorrect,
                QuestionId = dto.QuestionId
            };
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, AlternativeUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Alternativa não encontrada.");

            entity.Letter = dto.Letter;
            entity.Text = dto.Text;
            entity.IsCorrect = dto.IsCorrect;

            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Alternativa não encontrada.");

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
