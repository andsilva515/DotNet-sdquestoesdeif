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
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SubjectService(ISubjectRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SubjectDto> GetByIdAsync(Guid id)
        {
            var subject = await _repository.GetByIdAsync(id);
            if (subject == null)
                throw new Exception("Disciplina não encontrada.");

            return _mapper.Map<SubjectDto>(subject);
        }            
        public async Task<IEnumerable<SubjectDto>> GetAllAsync()
        {
            var subjects = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubjectDto>>(subjects);
        }
        public async Task CreateAsync(SubjectCreateDto dto)             
        {
            var subject = new Subject
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                IsActive = true
            };

            await _repository.AddAsync(subject);
            await _unitOfWork.CommitAsync();

        }
        public async Task UpdateAsync(Guid id, SubjectUpdateDto dto)          
        {
            var subject = await _repository.GetByIdAsync(id);
            if (subject == null)
                throw new Exception("Disciplina não encontrada.");

            subject.Name = dto.Name;
            subject.Description = dto.Description;
            subject.IsActive = dto.IsActive;
        }
        public async Task DeleteAsync(Guid id)
        {
            var subject = await _repository.GetByIdAsync(id);
            if (subject != null)
                throw new Exception("Disciplina não encontrada.");
            {
                _repository.Delete(subject);
                await _unitOfWork.CommitAsync();
            }
        }

        public Task UpdateAsync(SubjectUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
