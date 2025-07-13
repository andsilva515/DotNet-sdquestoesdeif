using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class QuestionSetDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }

        public List<Guid> QuestionIds { get; set; } = new List<Guid>();
    }

    public class QuestionSetCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        public Guid UserId { get; set; }
        public List<Guid> QuestionIds { get; set; } = new List<Guid>();
    }

    public class QuestionSetUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public List<Guid> QuestionIds { get; set; } = new List<Guid>();
    }

}
