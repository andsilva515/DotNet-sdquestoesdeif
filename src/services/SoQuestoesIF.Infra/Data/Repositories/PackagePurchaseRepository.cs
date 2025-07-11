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
    public class PackagePurchaseRepository : IPackagePurchaseRepository
    {
        private readonly AppDbContext _context;

        public PackagePurchaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PackagePurchase>> GetByUserIdAsync(Guid userId)
            => await _context.PackagePurchases
                .Include(p => p.Package)
                .Where(p => p.UserId == userId)
                .ToListAsync();

        public async Task AddAsync(PackagePurchase purchase)
            => await _context.PackagePurchases.AddAsync(purchase);
    }

}
