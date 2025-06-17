using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    public class QuestionRepository
    {
        public QuestionRepository(AppDbContext context) : base(context) { }

        // Implementações específicas para Question
    }
}
