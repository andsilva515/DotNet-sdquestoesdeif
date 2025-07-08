using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class Exam
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid CreatedById { get; set; }
        public User CreatedBy { get; set; } = null!;
        public bool IsActive { get; set; }
        public ICollection<ExamQuestion> ExamQuestions { get; set; }
        public ICollection<ExamQuestion> Questions { get; set; } = new List<ExamQuestion>();

    }
}
