using Microsoft.EntityFrameworkCore;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Enums;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    // Implementações específicas para Question
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Question> GetByIdAsync(Guid id)
        {
            return await _context.Questions
                .Include(q => q.Agency)
                .Include(q => q.ExamBoard)
                .Include(q => q.Position)
                .Include(q => q.Subject)
                .Include(q => q.Topic)
                .Include(q => q.Alternatives)
                .Include(q => q.CommentsUsers)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            return await _context.Questions
                .Include(q => q.Agency)
                .Include(q => q.ExamBoard)
                .Include(q => q.Position)
                .Include(q => q.Subject)
                .Include(q => q.Topic)
                .ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetByFilterAsync(
            Guid? agencyId,
            Guid? examBoardId,
            Guid? positionId,
            Guid? subjectId,
            Guid? topicId,
            EnumQuestionDifficulty? difficulty,
            int? year)
        {
            var query = _context.Questions.AsQueryable();

            if (agencyId.HasValue)
                query = query.Where(q => q.AgencyId == agencyId.Value);

            if (examBoardId.HasValue)
                query = query.Where(q => q.ExamBoardId == examBoardId.Value);

            if (positionId.HasValue)
                query = query.Where(q => q.PositionId == positionId.Value);

            if (subjectId.HasValue)
                query = query.Where(q => q.SubjectId == subjectId.Value);

            if (topicId.HasValue)
                query = query.Where(q => q.TopicId == topicId.Value);

            if (difficulty.HasValue)
                query = query.Where(q => q.QuestionDifficulty == difficulty.Value);

            if (year.HasValue)
                query = query.Where(q => q.Year == year.Value);

            return await query
                .Include(q => q.Agency)
                .Include(q => q.ExamBoard)
                .Include(q => q.Position)
                .Include(q => q.Subject)
                .Include(q => q.Topic)
                .ToListAsync();
        }
        public async Task AddAsync(Question question)
        {
            question.Validate();
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Question question)
        {
            question.Validate();
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Questions.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public void Update(Question entity)
        {
            _context.Questions.Update(entity);
        }
        public void Delete(Question entity)
        {
            _context.Questions.Remove(entity);
        }
    }

}
