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
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;

        public SubscriptionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Subscription> GetByIdAsync(Guid id)
            => await _context.Subscriptions.FindAsync(id);

        public async Task<IEnumerable<Subscription>> GetByUserIdAsync(Guid userId)
            => await _context.Subscriptions
                .Where(s => s.UserId == userId)
                .ToListAsync();

        public async Task AddAsync(Subscription subscription)
            => await _context.Subscriptions.AddAsync(subscription);

        public void Update(Subscription subscription)
            => _context.Subscriptions.Update(subscription);
    }


}

