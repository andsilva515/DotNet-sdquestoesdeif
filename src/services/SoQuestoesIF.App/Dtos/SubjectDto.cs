using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class SubjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid DisciplineId { get; set; }
    }
}
