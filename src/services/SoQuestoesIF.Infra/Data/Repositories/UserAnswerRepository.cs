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
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private readonly AppDbContext _context;

        public UserAnswerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserAnswer?> GetByIdAsync(Guid id)
        {
            return await _context.UserAnswers
                .Include(ua => ua.Question)
                .Include(ua => ua.Alternative)
                .FirstOrDefaultAsync(ua => ua.Id == id);
        }

        public async Task<IEnumerable<UserAnswer>> GetAllByUserAsync(Guid userId)
        {
            return await _context.UserAnswers
                .Where(ua => ua.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(UserAnswer entity)
        {
            await _context.UserAnswers.AddAsync(entity);
        }
    }
}
