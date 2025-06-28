using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class CommentUsuario
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
