using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IPasswordResetTokenService
    {
        Task RequestResetAsync(string email);
        Task ResetPasswordAsync(string token, string newPassword);
    }

}
