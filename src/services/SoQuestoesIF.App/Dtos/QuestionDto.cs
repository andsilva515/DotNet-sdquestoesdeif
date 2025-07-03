using SoQuestoesIF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class QuestionDto
    {
        public Guid Id { get; set; }
        public string Statement { get; set; }
        public int Year { get; set; }
        public EnumQuestionType QuestionType { get; set; }
        public EnumQuestionDifficulty QuestionDifficulty { get; set; }
        public EnumQuestionStatus QuestionStatus { get; set; }
        public string ExamNumber { get; set; }
        public string ExamUrl { get; set; }
        public string FullExamUrl { get; set; }
        public int TotalAnswers { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public Guid AgencyId { get; set; }
        public Guid ExamBoardId { get; set; }
        public Guid PositionId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid TopicId { get; set; }
        public ICollection<AlternativeDto> Alternatives { get; set; }
    }

    public class QuestionCreateDto
    {
        public string Statement { get; set; }
        public int Year { get; set; }
        public EnumQuestionType QuestionType { get; set; }
        public EnumQuestionDifficulty QuestionDifficulty { get; set; }
        public string ExamNumber { get; set; }
        public string ExamUrl { get; set; }
        public string FullExamUrl { get; set; }
        public Guid AgencyId { get; set; }
        public Guid ExamBoardId { get; set; }
        public Guid PositionId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid TopicId { get; set; }
        public ICollection<AlternativeDto> Alternatives { get; set; }
    }

    public class QuestionUpdateDto
    {
        public string Statement { get; set; }
        public int Year { get; set; }
        public EnumQuestionDifficulty QuestionDifficulty { get; set; }
        public EnumQuestionStatus QuestionStatus { get; set; }
        public string ExamNumber { get; set; }
        public string ExamUrl { get; set; }
        public string FullExamUrl { get; set; }
        public ICollection<AlternativeDto> Alternatives { get; set; }
    }

    public class AlternativeDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
