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
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public List<Guid> QuestionId { get; set; } = new List<Guid>();
    }

    public class ExamCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public List<Guid> QuestionId { get; set; } = new List<Guid>();
        // Se o CreatedById não vier do token/contexto, adicione aqui:
        // public Guid CreatedById { get; set; } 
    }

    public class ExamUpdateDto
    {
        public string Title { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<Guid> QuestionId { get; set; } = new List<Guid>();
    }

}
