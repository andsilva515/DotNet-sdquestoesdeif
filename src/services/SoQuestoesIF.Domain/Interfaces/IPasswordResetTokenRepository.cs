using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Domain.Interfaces
{
    public interface IPasswordResetTokenRepository
    {
        Task AddAsync(PasswordResetToken token);
        Task<PasswordResetToken> GetValidTokenAsync(string token);
        void Update(PasswordResetToken token);
    }

}
