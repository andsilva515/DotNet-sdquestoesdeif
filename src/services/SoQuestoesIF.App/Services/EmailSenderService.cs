using SoQuestoesIF.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        //  EmailSenderFake.cs (caso não use e-mail real):
        public Task SendAsync(string to, string subject, string body)
        {
            Console.WriteLine($"[FAKE EMAIL] Para: {to}\nAssunto: {subject}\nMensagem: {body}");
            return Task.CompletedTask;
        }
    }
}
