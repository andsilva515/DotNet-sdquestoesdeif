using Microsoft.EntityFrameworkCore;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    public class QuestionSetRepository : IQuestionSetRepository
    {
        private readonly AppDbContext _context;

        public QuestionSetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<QuestionSet?> GetByIdAsync(Guid id)
        {
            return await _context.QuestionSets
                .Include(qs => qs.QuestionSetQuestions)
                .FirstOrDefaultAsync(qs => qs.Id == id);
        }

        public async Task<IEnumerable<QuestionSet>> GetAllAsync()
        {
            return await _context.QuestionSets
                .Include(qs => qs.QuestionSetQuestions)
                .ToListAsync();
        }

        public async Task AddAsync(QuestionSet entity)
        {
            await _context.QuestionSets.AddAsync(entity);
        }

        public void Update(QuestionSet entity)
        {
            _context.QuestionSets.Update(entity);
        }

        public void Delete(QuestionSet entity)
        {
            _context.QuestionSets.Remove(entity);
        }

        public async Task SaveQuestionSetQuestionsAsync(QuestionSet set, List<Guid> questionIds)
        {
            var existing = _context.QuestionSetQuestions.Where(q => q.QuestionSetId == set.Id);
            _context.QuestionSetQuestions.RemoveRange(existing);

            var newLinks = questionIds.Select(qid => new QuestionSetQuestion
            {
                QuestionSetId = set.Id,
                QuestionId = qid
            });

            await _context.QuestionSetQuestions.AddRangeAsync(newLinks);
        }
    }
}
