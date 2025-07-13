using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<Subject?> GetByIdAsync(Guid id);
        Task<IEnumerable<Subject>> GetAllAsync();
        Task AddAsync(Subject subject);
        void Update(Subject subject);
        void Delete(Subject subject);
        Task CreateAsync(Subject subject);
    }
}
