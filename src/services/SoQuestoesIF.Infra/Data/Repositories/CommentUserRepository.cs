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
    public class CommentUserRepository : ICommentUserRepository
    {
        private readonly AppDbContext _context;

        public CommentUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CommentUser?> GetByIdAsync(Guid id)
        {
            return await _context.CommentUsers
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CommentUser>> GetAllByQuestionAsync(Guid questionId)
        {
            return await _context.CommentUsers
                .Where(c => c.QuestionId == questionId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(CommentUser entity)
        {
            await _context.CommentUsers.AddAsync(entity);
        }

        public void Update(CommentUser entity)
        {
            _context.CommentUsers.Update(entity);
        }

        public void Delete(CommentUser entity)
        {
            _context.CommentUsers.Remove(entity);
        }
    }
}
