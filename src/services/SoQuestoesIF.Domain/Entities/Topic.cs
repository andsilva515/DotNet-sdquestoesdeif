using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; } = null!;
        public ICollection<Question> Questions { get; set; }
    }
}

