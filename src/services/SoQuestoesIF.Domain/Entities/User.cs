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
        public string Name { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }       
        public DateTime? LastLoginAt { get; set; }
        public EnumUserType Type { get; set; } // Enum: Student, Teacher, Admin      
        public EnumUserRole Role { get; set; }
        public EnumUserStatus Status { get; set; }
        public ICollection<CommentUser> Comments { get; set; } = new List<CommentUser>();
        public ICollection<UserAnswer> Answers { get; set; } = new List<UserAnswer>();
        public ICollection<Exam> CreatedExams { get; set; } = new List<Exam>();
        public ICollection<QuestionSet> QuestionSets { get; set; } = new List<QuestionSet>();
        public ICollection<CommentTeacher> CommentTeachers { get; set; } = new List<CommentTeacher>();
        public ICollection<PasswordResetToken> PasswordResetTokens { get; set; } = new List<PasswordResetToken>();
        public ICollection<PackagePurchase> PackagePurchases { get; set; } = new List<PackagePurchase>();
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
