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
    public class ExamBoardRepository : IExamBoardRepository
    {
        private readonly AppDbContext _context; 
        public ExamBoardRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ExamBoard> GetByIdAsync(Guid id)
        {
            return await _context.ExamBoards.FindAsync(id);
        }
        public async Task<IEnumerable<ExamBoard>> GetAllAsync()
        {
            return await _context.ExamBoards.ToListAsync();
        }
        public async Task AddAsync(ExamBoard examBoard)
        {
            await _context.ExamBoards.AddAsync(examBoard);
        }                    
        public void Update(ExamBoard examBoard)
        {
            _context.ExamBoards.Update(examBoard);
        }
        public void Delete(ExamBoard examBoard)
        {
            _context.ExamBoards.Remove(examBoard);
        }

    }
}
