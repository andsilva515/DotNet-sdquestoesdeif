using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class QuestionSetDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public List<Guid> QuestionIds { get; set; } = new List<Guid>();
    }
    public class QuestionSetCreateDto
    {
        [Required(ErrorMessage = "O nome do caderno é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do caderno não pode exceder 100 caracteres.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "A descrição do caderno não pode exceder 500 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O ID do usuário é obrigatório.")]
        public Guid UserId { get; set; }
        public List<Guid> QuestionIds { get; set; } = new List<Guid>();
    }

    public class QuestionSetUpdateDto

    {
        [Required(ErrorMessage = "O nome do caderno é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do caderno não pode exceder 100 caracteres.")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "A descrição do caderno não pode exceder 500 caracteres.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<Guid> QuestionIds { get; set; } = new List<Guid>();
    }   


    // Exceções Personalizadas

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
    }

    public class UnauthorizedAccessException : Exception
    {
        public UnauthorizedAccessException(string message = "Acesso não autorizado.") : base(message) { }
    }

}
