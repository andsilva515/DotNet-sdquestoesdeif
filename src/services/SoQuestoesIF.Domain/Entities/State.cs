using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Entities
{
    public class State
    {
        public Guid Id { get; set; }
        public string Uf { get; set; } = string.Empty; // Ex.: "SP", "RJ"
        public string Name { get; set; } = string.Empty; // Ex.: "São Paulo"
    }
}
