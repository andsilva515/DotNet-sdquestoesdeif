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
            var smtpPort = int.Parse(_configuration["Smtp:Port"] ?? "587");
            var smtpUser = _configuration["Smtp:User"];
            var smtpPass = _configuration["Smtp:Password"];
            var emailDestino = _configuration["Smtp:Destino"];

            if (string.IsNullOrWhiteSpace(smtpUser))
                throw new Exception("O e-mail do remetente (Smtp:User) não está configurado.");

            if (string.IsNullOrWhiteSpace(emailDestino))
                throw new Exception("O e-mail de destino (Smtp:Destino) não está configurado.");

            var mensagem = new MailMessage
            {
                From = new MailAddress(smtpUser),
                Subject = "Contato do Site",
                Body = $"Nome: {contato.Nome}\nEmail: {contato.Email}\n\nMensagem:\n{contato.Message}",
                IsBodyHtml = false
            };

            mensagem.To.Add(emailDestino);

            using var smtp = new SmtpClient(smtpHost, smtpPort)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(smtpUser, smtpPass)
            };

            await smtp.SendMailAsync(mensagem);
        }

    }
}
