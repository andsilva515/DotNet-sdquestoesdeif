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
    public class SubjectRepository : ISubjectRepository
    {
        private readonly AppDbContext _context;

        public SubjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Subject?> GetByIdAsync(Guid id)
        {
            return await _context.Subjects.FindAsync(id);
        }
        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await _context.Subjects.ToListAsync();
        }
        public async Task AddAsync(Subject subject)
        {
            await _context.Subjects.AddAsync(subject);  
        }            
        
        public void Update(Subject subject)
        {
            _context.Subjects.Update(subject);
        }

        public void Delete(Subject subject)
        {
            _context.Subjects.Remove(subject);
        }

        public Task CreateAsync(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
