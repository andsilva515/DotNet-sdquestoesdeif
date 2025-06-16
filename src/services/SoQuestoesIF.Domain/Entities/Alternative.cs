using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class Alternative
    {
        public Guid Id { get; set; }
        public string Letter { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Guid QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
