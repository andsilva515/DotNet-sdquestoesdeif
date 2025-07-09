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
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repository;
        private readonly IUnitOfWork _unitOfWork; // Reintroduzido para gerenciar transações
        private readonly IMapper _mapper;

        public ExamService(IExamRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ExamDto> GetByIdAsync(Guid id)
        {
            var exam = await _repository.GetByIdAsync(id);
            if (exam == null)
            {
                throw new Exception("Simulado não encontrado."); // Idealmente, use uma exceção customizada ou NotFoundException
            }

            var dto = _mapper.Map<ExamDto>(exam);
            // Mapeamento manual da lista de IDs de questões
            dto.QuestionId = exam.ExamQuestions.Select(eq => eq.QuestionId).ToList();
            return dto;
        }

        public async Task<IEnumerable<ExamDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => new ExamDto
            {
                Id = e.Id,
                Title = e.Title,
                CreatedAt = e.CreatedAt,
                IsActive = e.IsActive,
                QuestionId = e.ExamQuestions.Select(eq => eq.QuestionId).ToList()
            });
        }

        public async Task<Guid> CreateAsync(ExamCreateDto dto)
        {
            var examId = Guid.NewGuid();
            var exam = new Exam
            {
                Id = examId,
                Title = dto.Title,
                CreatedAt = DateTime.UtcNow,
                IsActive = true, // Define como ativo por padrão na criação
                                 // TODO: Obtenha o ID do usuário logado (ex: do HttpContext.User ou de um serviço de identidade)
                CreatedById = Guid.Parse("SEU_USER_ID_AQUI"), // Exemplo: Guid.Parse(httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString()),
                ExamQuestions = dto.QuestionId.Select(qId => new ExamQuestion
                {
                    ExamId = examId, // ID do simulado pai
                    QuestionId = qId
                }).ToList()
            };

            await _repository.AddAsync(exam);
            await _unitOfWork.CommitAsync(); // Salva o novo simulado e suas relações de uma vez

            return exam.Id;
        }

        public async Task UpdateAsync(Guid id, ExamUpdateDto dto)
        {
            var exam = await _repository.GetByIdAsync(id);
            if (exam == null)
            {
                throw new Exception("Simulado não encontrado.");
            }

            exam.Title = dto.Title;
            exam.IsActive = dto.IsActive;

            _repository.Update(exam); // Marca o simulado para atualização
            await _repository.SaveExamQuestionsAsync(exam, dto.QuestionId); // Prepara as relações para atualização
            await _unitOfWork.CommitAsync(); // Salva as alterações no simulado e nas relações de uma vez
        }

        public async Task DeleteAsync(Guid id)
        {
            var exam = await _repository.GetByIdAsync(id);
            if (exam == null)
            {
                throw new Exception("Simulado não encontrado.");
            }

            _repository.Delete(exam); // Marca o simulado para exclusão
            await _unitOfOfWork.CommitAsync(); // Salva a exclusão do simulado (e suas relações, se configurado em cascata no EF Core)
        }
    }

}
