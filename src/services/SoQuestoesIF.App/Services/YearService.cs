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
    public class YearService : IYearService
    {
        private readonly IYearRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public YearService(
            IYearRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<YearDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Ano não encontrado.");
            return _mapper.Map<YearDto>(entity);
        }

        public async Task<IEnumerable<YearDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<YearDto>>(list);
        }

        public async Task<Guid> CreateAsync(YearCreateDto dto)
        {
            var entity = new Year
            {
                Id = Guid.NewGuid(),
                Value = dto.Value
            };

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, YearUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Ano não encontrado.");

            entity.Value = dto.Value;

            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Ano não encontrado.");

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}

