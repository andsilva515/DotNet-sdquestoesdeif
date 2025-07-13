using Microsoft.EntityFrameworkCore;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _context; // Assumindo AppDbContext é seu DbContext

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Exam?> GetByIdAsync(Guid id)
        {
            return await _context.Exams
                .Include(e => e.ExamQuestions)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            return await _context.Exams
                .Include(e => e.ExamQuestions)
                .ToListAsync();
        }

        public async Task AddAsync(Exam entity)
        {
            await _context.Exams.AddAsync(entity);
        }

        public void Update(Exam entity)
        {
            _context.Exams.Update(entity);
        }

        public void Delete(Exam entity)
        {
            _context.Exams.Remove(entity);
        }

        // Este método agora APENAS prepara as entidades. O SaveChangesAsync será feito pelo UnitOfWork.
        public async Task SaveExamQuestionsAsync(Exam exam, List<Guid> questionIds)
        {
            // Obtém as relações existentes
            var existingLinks = _context.ExamQuestions.Where(eq => eq.ExamId == exam.Id).ToList();

            // Identifica as questões a serem removidas (existem no banco, mas não na nova lista)
            var toRemove = existingLinks
                            .Where(eq => !questionIds.Contains(eq.QuestionId))
                            .ToList();

            _context.ExamQuestions.RemoveRange(toRemove);

            // Identifica as questões a serem adicionadas (estão na nova lista, mas não existem no banco)
            var existingQuestionIds = existingLinks.Select(eq => eq.QuestionId).ToHashSet(); // Usar HashSet para busca mais rápida
            var toAdd = questionIds
                        .Where(qid => !existingQuestionIds.Contains(qid))
                        .Select(qid => new ExamQuestion
                        {
                            ExamId = exam.Id,
                            QuestionId = qid
                        })
                        .ToList();

            await _context.ExamQuestions.AddRangeAsync(toAdd);

            // NENHUM SaveChangesAsync AQUI! Será feito pelo UnitOfWork no serviço.
        }
    }
}
