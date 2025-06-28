using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    public class UserAnswerRepository : Repository<UserAnswer>, IUserAnswerRepository
    {
        public UserAnswerRepository(ApplicationDbContext context) : base(context) { }
        
        public async Task<List<UserAnswer>> GetByUserIdAsync(Guid userId)
        {
            return await _context.UserAnswers.Where(x => x.UserId == userId)
                .ToListAsync();

        }

        public async Task<int> CountCorrectAnswerAsync(Guid userId)
        {
            return await _context.UserAnswers.CountAsync(x => x.UserId == userId && x.IsCorrect);
        }
    }
}
