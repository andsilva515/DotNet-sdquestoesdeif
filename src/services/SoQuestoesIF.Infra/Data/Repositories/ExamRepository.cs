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
        private readonly AppDbContext _context;
        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Exam> GetByIdAsync(Guid id)
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

        public async Task SaveExamQuestionsAsync(Exam exam, List<Guid> questionIds)
        {
            // Remove as antigas
            var existing = _context.ExamQuestions.Where(eq => eq.ExamId == exam.Id);
            _context.ExamQuestions.RemoveRange(existing);                           
            

            // Adiciona novas
            var newLinks = questionIds.Select(qid => new ExamQuestion
            {
                ExamId = exam.Id,
                QuestionId = qid
            });

            await _context.ExamQuestions.AddRangeAsync(newLinks);
        }
      
    }
}
