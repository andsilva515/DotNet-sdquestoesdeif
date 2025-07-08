using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface ITopicRepository
    {
        Task<Topic> GetByIdAsync(Guid id);
        Task<IEnumerable<Topic>> GetAllAsync();
        Task AddAsync(Topic entity);
        void Update(Topic entity);
        void Delete(Topic entity);
    }
}
