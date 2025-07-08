using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IExamRepository
    {
        Task<Exam> GetByIdAsync(Guid id);
        Task<IEnumerable<Exam>> GetAllAsync();
        Task AddAsync(Exam entity);
        void Update(Exam entity);
        void Delete(Exam entity);
        Task SaveExamQuestionsAsync(Exam exam, List<Guid> questionIds);
    }
}
