using Microsoft.Extensions.Configuration;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task EnviarContatoAsync(ContactDto contato)
        {
            var smtpHost = _configuration["Smtp:Host"];
            var smtpPort = int.Parse(_configuration["Smtp:Port"]);
            var smtpUser = _configuration["Smtp:User"];
            var smtpPass = _configuration["Smtp:Password"];
            var emailDestino = _configuration["Smtp:Destino"];

            var mensagem = new MailMessage();
            mensagem.From = new MailAddress(smtpUser);
            mensagem.To.Add(emailDestino);
            mensagem.Subject = "Contato do Site";
            mensagem.Body = $"Nome: {contato.Nome}\nEmail: {contato.Email}\n\nMensagem:\n{contato.Message}";
            mensagem.IsBodyHtml = false;

            using var smtp = new SmtpClient(smtpHost, smtpPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(smtpUser, smtpPass)
            };

            await smtp.SendMailAsync(mensagem);
        }
    }
}
