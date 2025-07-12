using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class CommentUserDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid QuestionId { get; set; }
        public DateTime AnsweredAt { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class CommentUserCreateDto
    {
        public Guid QuestionId { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; } = string.Empty;
    }

    public class CommentUserUpdateDto
    {
        public string Content { get; set; } = string.Empty;
    }

}
