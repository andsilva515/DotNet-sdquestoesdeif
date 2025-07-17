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
        public string Statement { get; set; } = string.Empty;       
        public int Year { get; set; }   
        public EnumQuestionType QuestionType { get; set; } // Enum: MultipleChoice, TrueFalse
        public EnumQuestionDifficulty QuestionDifficulty {get; set; } // Enum: Easy, Medium, Hard
        public EnumQuestionStatus QuestionStatus {get; set; } // Enum: Active, Cancelled
        public string ExamNumber { get; set; } = string.Empty;
        public string ExamUrl { get; set; } = string.Empty;
        public string FullExamUrl { get; set; } = string.Empty;
        public int TotalAnswers { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public Guid AgencyId { get; set; }
        public Agency Agency { get; set; } = null!;
        public Guid ExamBoardId { get; set; }
        public ExamBoard ExamBoard { get; set; } = null!;
        public Guid PositionId { get; set; }
        public Position Position { get; set; } = null!;
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; } = null!;
        public ICollection<Alternative> Alternatives { get; set; } = new List<Alternative>();
        public ICollection<CommentUser> CommentsUsers { get; set; } = new List<CommentUser>();     
        public ICollection<ExamQuestion> ExamQuestions { get; set; } = new List<ExamQuestion>();
        public ICollection<CommentTeacher> CommentTeachers { get; set; } = new List<CommentTeacher>();
        public ICollection<QuestionSetQuestion> QuestionSetQuestions { get; set; } = new List<QuestionSetQuestion>();

        // Método validação completo
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Statement))
                throw new ArgumentException("O enunciado é obrigatório.");

            if (Year < 1900 || Year > DateTime.UtcNow.Year)
                throw new ArgumentException("O ano da questão é inválido.");

            if (!Enum.IsDefined(typeof(EnumQuestionType), QuestionType))
                throw new ArgumentException("O tipo de questão é inválido.");

            if (!Enum.IsDefined(typeof(EnumQuestionDifficulty), QuestionDifficulty))
                throw new ArgumentException("O nível de dificuldade é inválido.");

            if (!Enum.IsDefined(typeof(EnumQuestionStatus), QuestionStatus))
                throw new ArgumentException("O status da questão é inválido.");

            if (Alternatives == null || Alternatives.Count == 0)
            {
                if (QuestionType == EnumQuestionType.MultipleChoice)
                    throw new ArgumentException("Questões de múltipla escolha devem ter alternativas.");
            }

            if (QuestionType == EnumQuestionType.TrueFalse)
            {
                if (Alternatives != null && Alternatives.Count > 0)
                    throw new ArgumentException("Questões de certo/errado não devem ter alternativas.");
            }

            if (AgencyId == Guid.Empty)
                throw new ArgumentException("O orgão é obrigatório!");

            if (ExamBoardId == Guid.Empty)
                throw new ArgumentException("A banca examinadora é obrigatória.");

            if (PositionId == Guid.Empty)
                throw new ArgumentException("O cargo é obrigatório.");

            if (SubjectId == Guid.Empty)
                throw new ArgumentException("A disciplina é obrigatória.");

            if (TopicId == Guid.Empty)
                throw new ArgumentException("O assunto é obrigatório.");        }


        // Métodos validação auxiliar

        // Atualizar dados principais (edição) e faz vaidação de campos
        public void UpdateBasicInfo(
             string statement,
             int year,
             EnumQuestionDifficulty difficulty,
             EnumQuestionStatus status,
             string examNumber,
             string examUrl,
             string fullExamUrl)
        {
            if (string.IsNullOrWhiteSpace(statement))
                throw new ArgumentException("O enunciado é obrigatório.");

            if (year < 1900 || year > DateTime.UtcNow.Year)
                throw new ArgumentException("Ano inválido.");

            if (!Enum.IsDefined(typeof(EnumQuestionDifficulty), difficulty))
                throw new ArgumentException("Dificuldade inválida.");

            if (!Enum.IsDefined(typeof(EnumQuestionStatus), status))
                throw new ArgumentException("Status inválido.");

            Statement = statement;
            Year = year;
            QuestionDifficulty = difficulty;
            QuestionStatus = status;
            ExamNumber = examNumber;
            ExamUrl = examUrl;
            FullExamUrl = fullExamUrl;
        }     

        // Marcar a questão como cancelada
        public void Cancel()
        {
            QuestionStatus = EnumQuestionStatus.Cancelled;
        }

        // Trocar status
        public void ChangeStatus(EnumQuestionStatus newStatus)
        {
            QuestionStatus = newStatus;
        }

        // Marca a questão como Ativa
        public void Activate()
        {
            QuestionStatus = EnumQuestionStatus.Active;
        }

        // Atualiza estatísticas (total/certas/erradas)
        public void RegisterAnswer(bool isCorrect)
        {
            TotalAnswers++;
            if (isCorrect)
                CorrectAnswers++;
            else
                WrongAnswers++;
        }
    }
}
