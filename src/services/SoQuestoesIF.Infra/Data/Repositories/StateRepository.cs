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
    public class StateRepository : IStateRepository
    {
        private readonly AppDbContext _context;

        public StateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<State> GetByIdAsync(Guid id)
        {
            return await _context.States.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<State>> GetAllAsync()
        {
            return await _context.States
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task AddAsync(State entity)
        {
            await _context.States.AddAsync(entity);
        }

        public void Update(State entity)
        {
            _context.States.Update(entity);
        }

        public void Delete(State entity)
        {
            _context.States.Remove(entity);
        }
    }
}
