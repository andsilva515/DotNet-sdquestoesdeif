using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IUserAnswerRepository : IRepository<UserAnswer>
    {
        Task<List<UserAnswer>> GetByUserIdAsync(Guid userId);
        Task<int> CountCorrectAnswerSync(Guid userId);
    }
}
