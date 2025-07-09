using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    public class YearRepository : IYearRepository
    {
        private readonly AppDbContext _context;

        public YearRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Year> GetByIdAsync(Guid id)
        {
            return await _context.Years.FirstOrDefaultAsync(y => y.Id == id);
        }

        public async Task<IEnumerable<Year>> GetAllAsync()
        {
            return await _context.Years
                .OrderByDescending(y => y.Value)
                .ToListAsync();
        }

        public async Task AddAsync(Year entity)
        {
            await _context.Years.AddAsync(entity);
        }

        public void Update(Year entity)
        {
            _context.Years.Update(entity);
        }

        public void Delete(Year entity)
        {
            _context.Years.Remove(entity);
        }
    }
}
