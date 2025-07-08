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
    public class EducationLevelService : IEducationLevelService
    {
        private readonly IEducationLevelRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EducationLevelService(IEducationLevelRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EducationLevelDto> GetByIdAsync(Guid id)
        {
            var educationLevel = await _repository.GetByIdAsync(id);
            if (educationLevel == null)
                throw new Exception("Órgão não encontrado.");

            return _mapper.Map<EducationLevelDto>(educationLevel);
        }

        public async Task<IEnumerable<EducationLevelDto>> GetAllAsync()
        {
            var educationLevels = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EducationLevelDto>>(educationLevels);
        }

        public async Task<Guid> CreateAsync(EducationLevelCreateDto dto)
        {
            var educationLevel = new EducationLevel
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                IsActive = true
            };

            await _repository.AddAsync(educationLevel);
            await _unitOfWork.CommitAsync();

            return educationLevel.Id;
        }

        public async Task UpdateAsync(Guid id, EducationLevelUpdateDto dto)
        {
            var educationLevel = await _repository.GetByIdAsync(id);
            if (educationLevel == null)
                throw new Exception("Órgão não encontrado.");

            educationLevel.Name = dto.Name;
            educationLevel.Description = dto.Description;
            educationLevel.IsActive = dto.IsActive;

            _repository.Update(educationLevel);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var educationLevel = await _repository.GetByIdAsync(id);
            if (educationLevel == null)
                throw new Exception("Órgão não encontrado.");

            _repository.Delete(educationLevel);
            await _unitOfWork.CommitAsync();
        }
      
    }


}
