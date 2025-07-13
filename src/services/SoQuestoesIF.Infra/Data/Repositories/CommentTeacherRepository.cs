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
    public class CommentTeacherRepository : ICommentTeacherRepository
    {
        private readonly AppDbContext _context;

        public CommentTeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CommentTeacher> GetByIdAsync(Guid id)
        {
            return await _context.CommentTeachers
                .Include(c => c.UserProf)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CommentTeacher>> GetAllByQuestionAsync(Guid questionId)
        {
            return await _context.CommentTeachers
                .Where(c => c.QuestionId == questionId)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(CommentTeacher entity)
        {
            await _context.CommentTeachers.AddAsync(entity);
        }

        public void Delete(CommentTeacher entity)
        {
            _context.CommentTeachers.Remove(entity);
        }
    }
}
