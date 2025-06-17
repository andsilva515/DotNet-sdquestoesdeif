using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    public class AnswerHistoryRepository : Repository<AnswerHistory>, IAnswerHistoryRepository
    {
        public AnswerHistoryRepository(AppDbContext context) : base(context) { }
        
        // Implementações especificas para AnswerHistory
    }
}
