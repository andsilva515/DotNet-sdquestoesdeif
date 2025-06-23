using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Statement { get; set; }
        public string Type { get; set; }
        public Guid SubjectId { get; set; }
        public Guid DisciplineId { get; set; }
        public Guid InstitutionId { get; set; }
        public Guid ExamBoardId { get; set; }
        public string Year { get; set; }
        public string Answer { get; set; }
        public string Explanation { get; set; }
        public string Status { get; set; }
        public string Difficulty { get; set; }
        public string EditalUrl { get; set; }
        public string ExamUrl { get; set; }

    }
}
