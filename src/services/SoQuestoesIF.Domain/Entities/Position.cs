using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class Position
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public Guid EducationLevelId { get; set; }

        public EducationLevel EducationLevel { get; set; } = null!;

        public ICollection<Question> Questions { get; set; }
    }
}
