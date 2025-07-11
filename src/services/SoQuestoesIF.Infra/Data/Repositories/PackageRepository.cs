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
    public class PackageRepository : IPackageRepository
    {
        private readonly AppDbContext _context;

        public PackageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Package> GetByIdAsync(Guid id)
            => await _context.Packages.FindAsync(id);

        public async Task<IEnumerable<Package>> GetAllAsync()
            => await _context.Packages.ToListAsync();

        public async Task AddAsync(Package package)
            => await _context.Packages.AddAsync(package);

        public void Update(Package package)
            => _context.Packages.Update(package);
    }

}
