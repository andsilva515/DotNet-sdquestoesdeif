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
    public class StateService : IStateService
    {
        private readonly IStateRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StateService(
            IStateRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StateDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Estado não encontrado.");
            return _mapper.Map<StateDto>(entity);
        }

        public async Task<IEnumerable<StateDto>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<StateDto>>(list);
        }

        public async Task<Guid> CreateAsync(StateCreateDto dto)
        {
            var entity = new State
            {
                Id = Guid.NewGuid(),
                Uf = dto.Uf,
                Name = dto.Name
            };

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(Guid id, StateUpdateDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Estado não encontrado.");

            entity.Uf = dto.Uf;
            entity.Name = dto.Name;

            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) throw new Exception("Estado não encontrado.");

            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
