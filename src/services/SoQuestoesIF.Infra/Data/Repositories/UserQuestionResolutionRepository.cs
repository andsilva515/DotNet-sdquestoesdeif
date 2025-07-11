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
    public class UserQuestionResolutionRepository : IUserQuestionResolutionRepository
    {
        private readonly AppDbContext _context;

        public UserQuestionResolutionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserQuestionResolutionLog> GetTodayLogAsync(Guid userId, DateTime date)
        {
            return await _context.UserQuestionResolutionLogs
                .FirstOrDefaultAsync(x => x.UserId == userId && x.Date == date.Date);
        }

        public async Task AddAsync(UserQuestionResolutionLog log)
        {
            await _context.UserQuestionResolutionLogs.AddAsync(log);
        }

        public void Update(UserQuestionResolutionLog log)
        {
            _context.UserQuestionResolutionLogs.Update(log);
        }
    }

}
