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
    public class AgencyRepository : IAgencyRepository
    {
        private readonly AppDbContext _context;

        public AgencyRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Agency?> GetByIdAsync(Guid id)
        {
            return await _context.Agencies.FindAsync(id);
        }
        public async Task<IEnumerable<Agency>> GetAllAsync()
        {
            return await _context.Agencies.ToListAsync();
        }
        public async Task AddAsync(Agency agency)
        {
            await _context.Agencies.AddAsync(agency);
        }                      
        public void Update(Agency agency)
        {
            _context.Agencies.Update(agency);
        }
        public void Delete(Agency agency)
        {
            _context.Agencies.Remove(agency);
        }
    }
}
