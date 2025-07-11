using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Dtos
{
    public class PasswordResetTokenDto
    {
        public string Email { get; set; }
    }

    public class ResetPasswordTokenDto
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }

}
