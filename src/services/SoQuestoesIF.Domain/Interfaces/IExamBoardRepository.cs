using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IExamBoardRepository
    {
        Task<ExamBoard?> GetByIdAsync(Guid id);
        Task<IEnumerable<ExamBoard>> GetAllAsync();
        Task AddAsync(ExamBoard examBoard);
        void Update(ExamBoard examBoard);
        void Delete(ExamBoard examBoard);
    }
}
