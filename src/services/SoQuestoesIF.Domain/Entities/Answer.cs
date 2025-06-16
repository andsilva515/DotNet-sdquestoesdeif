using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class Answer
    {
        public Guid Id { get; set; }
        public DateTime AnsweredAt { get; set; }
        public bool IsCorrect { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid QuestionId { get; set; }
        public Question Question { get; set; }

        public Guid SelectedAlternativeId { get; set; }
        public Alternative SelectedAlternative { get; set; }


    }
}
