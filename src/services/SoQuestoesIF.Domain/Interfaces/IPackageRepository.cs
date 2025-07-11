using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IPackageRepository
    {
        Task<Package> GetByIdAsync(Guid id);
        Task<IEnumerable<Package>> GetAllAsync();
        Task AddAsync(Package package);
        void Update(Package package);
    }
}
