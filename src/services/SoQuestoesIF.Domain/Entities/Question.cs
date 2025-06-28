using SoQuestoesIF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public string Statement { get; set; }   
    
        public int Year { get; set; }   

        public EnumQuestionType QuestionType { get; set; } // Enum: MultipleChoice, TrueFalse
        public EnumQuestionDifficulty QuestionDifficulty {get; set; } // Enum: Easy, Medium, Hard
        public EnumQuestionStatus QuestionStatus {get; set; } // Enum: Active, Cancelled

        public string ExamNumber { get; set; }
        public string ExamUrl { get; set; }
        public string FullExamUrl { get; set; }

        public int TotalAnswers { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }

        public Guid AgencyId { get; set; }
        public Agency Agency { get; set; }

        public Guid ExamBoardId { get; set; }

        public ExamBoard ExamBoard { get; set; }


        public Guid PositionId { get; set; }
        public Position Position { get; set; }

        public Guid SubjectId { get; set; }

        public Subject Subject { get; set; }

        public Guid TopicId { get; set; }

        public Topic Topic { get; set; }

        public ICollection<Alternative> Alternatives { get; set; }

        public ICollection<CommentUser> CommentsUsers { get; set; }

    }
}
