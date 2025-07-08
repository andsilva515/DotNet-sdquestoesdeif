using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class QuestionSetDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public List<Guid> QuestionIds { get; set; }
    }
    public class QuestionSetCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> QuestionIds { get; set; }
    }

    public class QuestionSetUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<Guid> QuestionIds { get; set; }
    }
}
