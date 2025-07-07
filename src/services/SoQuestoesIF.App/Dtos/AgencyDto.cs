using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class AgencyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class AgencyCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class AgencyUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
