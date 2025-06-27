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
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public EnumUserType Type { get; set; } // Enum: Student, Teacher, Admin

        public DateTime CreatedAt { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserAnswer> Answers { get; set; }
        public ICollection<Exam> CreatedExams { get; set; }
        public ICollection<QuestionSet> QuestionSets { get; set; }


        public EnumUserType UserType { get; set; }


    }

    
}
