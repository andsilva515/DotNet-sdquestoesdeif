using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<Subscription?> GetByIdAsync(Guid id);
        Task<IEnumerable<Subscription>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Subscription subscription);
        void Update(Subscription subscription);
        Task<Subscription?> GetActiveSubscriptionAsync(Guid userId);
        
        // Novo método para pegar todas as ativas
        Task<IEnumerable<Subscription>> GetAllActiveAsync();
    }
}
