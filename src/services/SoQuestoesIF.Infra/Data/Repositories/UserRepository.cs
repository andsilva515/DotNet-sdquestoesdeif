using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    public class UserRepository
    {
        public UserRepository(AppDbContext context) : base(context){ }

        // Implmentações específicas para User
    }
}
