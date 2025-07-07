using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class ExamBoardDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class ExamBoardCreateDto
    {
        public string Name { get; set; }
        public string Decription { get; set; }
    }

    public class ExamBoardUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; } 
        public bool IsActive { get; set; }
    }
}



