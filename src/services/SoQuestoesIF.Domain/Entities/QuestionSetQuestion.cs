using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class QuestionSetQuestion
    {
        public Guid QuestionSetId { get; set; }
        public QuestionSet QuestionSet { get; set; } = null!;

        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;
    }
}
