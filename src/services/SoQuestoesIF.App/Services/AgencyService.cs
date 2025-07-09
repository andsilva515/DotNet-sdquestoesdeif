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
    public class AgencyService : IAgencyService
    {
        private readonly IAgencyRepository _repository;
        private readonly IUnitOfWork _uniOfWork;
        private readonly IMapper _mapper;

        public AgencyService(IAgencyRepository repository, IUnitOfWork uniOfWork, IMapper mapper)
        {
            _repository = repository;
            _uniOfWork = uniOfWork;
            _mapper = mapper;
        }

        public async Task<AgencyDto> GetByIdAsync(Guid id)
        {
            var agency = await _repository.GetByIdAsync(id);
            if (agency == null)
                throw new Exception("Órgão não encontrato.");

            return _mapper.Map<AgencyDto>(agency);
        }
        public async Task<IEnumerable<AgencyDto>> GetAllAsync()
        {
            var agencys = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AgencyDto>>(agencys);
        }
        public async Task<Guid> CreateAsync(AgencyCreateDto dto)
        {
            var agency = new Agency
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                IsActive = true
            };

            await _repository.AddAsync(agency);
            await _uniOfWork.CommitAsync();

            return agency.Id;
        }                  
        public async Task UpdateAsync(Guid id, AgencyUpdateDto dto)
        {

            var agency = await _repository.GetByIdAsync(id);
            if (agency == null)
                throw new Exception("Órgão não encontrado.");

            agency.Name = dto.Name;
            agency.Description = dto.Description;
            agency.IsActive = dto.IsActive;         
                       
            _repository.Update(agency);
            await _uniOfWork.CommitAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var agency = await _repository.GetByIdAsync(id);
            if (agency != null)
                throw new Exception("Órgão não econtrado.");
            
                _repository.Delete(agency);
                await _uniOfWork.CommitAsync();            
        }    
    }
}
