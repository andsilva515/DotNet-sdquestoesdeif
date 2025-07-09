using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class YearDto
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
    }

    public class YearCreateDto
    {
        public int Value { get; set; }
    }

    public class YearUpdateDto
    {
        public int Value { get; set; }
    }
}
