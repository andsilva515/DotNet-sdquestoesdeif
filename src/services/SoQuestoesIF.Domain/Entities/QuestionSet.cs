using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class QuestionSet
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome do caderno é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do caderno não pode exceder 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500, ErrorMessage = "A descrição do caderno não pode exceder 500 caracteres.")]
        public string Description { get; set; } = string.Empty ;
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; } = null!;
        public ICollection<QuestionSetQuestion> Questions { get; set; } = new List<QuestionSetQuestion>();
    }

 }
