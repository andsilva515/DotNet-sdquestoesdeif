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
    public class EducationLevelRepository : IEducationLevelRepository
    {
        private readonly AppDbContext _context;

        public EducationLevelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EducationLevel> GetByIdAsync(Guid id)
        {
            return await _context.EducationLevels.FindAsync(id);
        }

        public async Task<IEnumerable<EducationLevel>> GetAllAsync()
        {
            return await _context.EducationLevels.ToListAsync();
        }

        public async Task AddAsync(EducationLevel educationLevel)
        {
            await _context.EducationLevels.AddAsync(educationLevel);
        }

        public void Update(EducationLevel educationLevel)
        {
            _context.EducationLevels.Update(educationLevel);
        }

        public void Delete(EducationLevel educationLevel)
        {
            _context.EducationLevels.Remove(educationLevel);
        }
    }
}
}
