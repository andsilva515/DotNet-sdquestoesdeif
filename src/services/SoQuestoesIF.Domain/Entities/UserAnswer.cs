using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class UserAnswer
    {
        public Guid Id { get; set; }
        public DateTime AnsweredAt { get; set; }
        public bool IsCorrect { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public Guid SelectedAlternativeId { get; set; }
        public Alternative SelectedAlternative { get; set; } = null!;
        public Guid? AlternativeId { get; set; }    
        public Alternative Alternative { get; set; } = null!;
    }
}
