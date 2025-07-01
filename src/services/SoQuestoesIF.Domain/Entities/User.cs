using SoQuestoesIF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }       
        public DateTime? LastLoginAt { get; set; }
        public EnumUserType Type { get; set; } // Enum: Student, Teacher, Admin      
        public EnumUserRole Role { get; set; }
        public EnumUserStatus Status { get; set; }
        public ICollection<CommentUser> Comments { get; set; }
        public ICollection<UserAnswer> Answers { get; set; }
        public ICollection<Exam> CreatedExams { get; set; }
        public ICollection<QuestionSet> QuestionSets { get; set; }
        public void Activate()
        {
            Status = EnumUserStatus.Active;
        }

        public void Deactivate()
        {
            Status = EnumUserStatus.Inactive;
        }

        public void ChangePassword(string newHash)
        {
            if (string.IsNullOrWhiteSpace(newHash))
                throw new ArgumentException("Senha inválida.");
            PasswordHash = newHash;
        }

    }
    
}
