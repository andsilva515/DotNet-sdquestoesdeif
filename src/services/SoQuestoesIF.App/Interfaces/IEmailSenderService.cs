using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendAsync(string to, string subject, string body);
    }

    // E implemente conforme seu provedor de e-mail.
}
