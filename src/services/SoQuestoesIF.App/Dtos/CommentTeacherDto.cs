using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class CommentTeacherDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public Guid QuestionId { get; set; }
        public Guid UserProfId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CommentTeacherCreateDto
    {
        public string Text { get; set; } = string.Empty;
        public Guid QuestionId { get; set; }
        public Guid UserProfId { get; set; }
    }
}
