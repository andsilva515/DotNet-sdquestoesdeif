using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IPackagePurchaseRepository
    {
        Task<IEnumerable<PackagePurchase>> GetByUserIdAsync(Guid userId);
        Task AddAsync(PackagePurchase purchase);
    }
}
