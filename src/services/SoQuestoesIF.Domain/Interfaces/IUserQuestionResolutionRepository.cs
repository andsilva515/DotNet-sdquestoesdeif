using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IUserQuestionResolutionRepository
    {
        Task<UserQuestionResolutionLog?> GetTodayLogAsync(Guid userId, DateTime date);
        Task AddAsync(UserQuestionResolutionLog log);
        void Update(UserQuestionResolutionLog log);
    }

}
