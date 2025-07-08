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
    public class AlternativeRepository : IAlternativeRepository
    {
        private readonly AppDbContext _context;

        public AlternativeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Alternative> GetByIdAsync(Guid id)
        {
            return await _context.Alternatives
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Alternative>> GetAllByQuestionIdAsync(Guid questionId)
        {
            return await _context.Alternatives
                .Where(a => a.QuestionId == questionId)
                .OrderBy(a => a.Letter)
                .ToListAsync();
        }

        public async Task AddAsync(Alternative alternative)
        {
            await _context.Alternatives.AddAsync(alternative);
        }

        public void Update(Alternative alternative)
        {
            _context.Alternatives.Update(alternative);
        }

        public void Delete(Alternative alternative)
        {
            _context.Alternatives.Remove(alternative);
        }
    }
}
