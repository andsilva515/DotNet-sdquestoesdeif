using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class CommentTeacher
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public Guid QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        public Guid UserProfId { get; set; } 
        public User UserProf { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }

}
