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
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PositionService(IPositionRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PositionDto> GetByIdAsync(Guid id)
        {
            var position = await _repository.GetByIdAsync(id);
            if (position == null)
                throw new Exception("Órgão não encontrado.");

            return _mapper.Map<PositionDto>(position);
        }

        public async Task<IEnumerable<PositionDto>> GetAllAsync()
        {
            var positions = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PositionDto>>(positions);
        }

        public async Task<Guid> CreateAsync(PositionCreateDto dto)
        {
            var position = new Position
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                IsActive = true
            };

            await _repository.AddAsync(position);
            await _unitOfWork.CommitAsync();

            return position.Id;
        }

        public async Task UpdateAsync(Guid id, PositionUpdateDto dto)
        {
            var position = await _repository.GetByIdAsync(id);
            if (position == null)
                throw new Exception("Órgão não encontrado.");

            position.Name = dto.Name;
            position.Description = dto.Description;
            position.IsActive = dto.IsActive;

            _repository.Update(position);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var position = await _repository.GetByIdAsync(id);
            if (position == null)
                throw new Exception("Órgão não encontrado.");

            _repository.Delete(position);
            await _unitOfWork.CommitAsync();
        }
    }
}
