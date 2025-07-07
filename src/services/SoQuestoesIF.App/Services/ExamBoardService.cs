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
    public class ExamBoardService : IExamBoardService
    {
        private readonly IExamBoardRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExamBoardService(IExamBoardRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ExamBoardDto> GetByIdAsync(Guid id)
        {
            var examBoard = await _repository.GetByIdAsync(id);
            if (examBoard == null)
                throw new Exception("Banca não encontrada.");

            return _mapper.Map<ExamBoardDto>(examBoard);
        }
        public async Task<IEnumerable<ExamBoardDto>> GetAllAsync()
        {
            var examBoards = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ExamBoardDto>>(examBoards);
        }
        public async Task<Guid> CreateAsync(ExamBoardCreateDto dto)
        {
            var examBoard = new ExamBoard
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Decription,
                IsActive = true
            };

            await _repository.AddAsync(examBoard);
            await _unitOfWork.CommitAsync();

            return examBoard.Id;
        }                
        public async Task UpdateAsync(Guid id, ExamBoardUpdateDto dto)
        {
            var examBoard = await _repository.GetByIdAsync(id);
            if (examBoard == null)
                throw new Exception("Banca não encontrada.");

            examBoard.Name = dto.Name;
            examBoard.Description = dto.Description;
            examBoard.IsActive = dto.IsActive;

            _repository.Update(examBoard);     
             await _unitOfWork.CommitAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var examBoard = await _repository.GetByIdAsync(id);
            if (examBoard == null)
                throw new Exception("Banca não encontrada.");
            
             _repository.Delete(examBoard);
             await _unitOfWork.CommitAsync();
        }
    }      
    
}
