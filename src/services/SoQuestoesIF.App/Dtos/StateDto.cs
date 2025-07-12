using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class StateDto
    {
        public Guid Id { get; set; }
        public string Uf { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class StateCreateDto
    {
        public string Uf { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }

    public class StateUpdateDto
    {
        public string Uf { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
