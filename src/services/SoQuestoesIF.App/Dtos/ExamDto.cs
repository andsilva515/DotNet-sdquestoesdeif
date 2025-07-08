using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class ExamDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActiv { get; set; }
        public List<Guid> QuestionId { get; set; }
    }

    public class ExamCreateDto
    {
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> QuestionId { get; set; }
    }

    public class ExamUpdateDto
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public List<Guid> QuestionId { get; set; }
    }

}
