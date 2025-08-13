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
            // Lê das variáveis de ambiente (no Azure use Smtp__Host, etc.)
            var smtpHost     = _configuration["Smtp:Host"];      // ex.: smtp-mail.outlook.com
            var smtpPortText = _configuration["Smtp:Port"];      // ex.: 587
            var smtpUser     = _configuration["Smtp:User"];      // ex.: anderson.ssilva@outlook.com
            var smtpPass     = _configuration["Smtp:Password"];  // senha da conta
            var emailDestino = _configuration["Smtp:Destino"];   // para quem enviar

            if (string.IsNullOrWhiteSpace(smtpHost))
                throw new InvalidOperationException("Config SMTP ausente: Smtp:Host");
            if (!int.TryParse(smtpPortText, out var smtpPort))
                smtpPort = 587; // padrão seguro
            if (string.IsNullOrWhiteSpace(smtpUser))
                throw new InvalidOperationException("Config SMTP ausente: Smtp:User");
            if (string.IsNullOrWhiteSpace(smtpPass))
                throw new InvalidOperationException("Config SMTP ausente: Smtp:Password");
            if (string.IsNullOrWhiteSpace(emailDestino))
                throw new InvalidOperationException("Config SMTP ausente: Smtp:Destino");

            var mensagem = new MailMessage
            {
                From = new MailAddress(smtpUser), // From deve ser o mesmo usuário
                Subject = "Contato do Site",
                Body = $"Nome: {contato.Nome}\nEmail: {contato.Email}\n\nMensagem:\n{contato.Message}",
                IsBodyHtml = false
            };
            mensagem.To.Add(emailDestino);

            using var smtp = new SmtpClient(smtpHost, smtpPort)
            {
                EnableSsl = true,                 // STARTTLS na 587
                UseDefaultCredentials = false,    // importante no Outlook.com
                Credentials = new NetworkCredential(smtpUser, smtpPass),
                Timeout = 20000
            };

            try
            {
                await smtp.SendMailAsync(mensagem);
            }
            catch (SmtpException ex)
            {
                // Repropaga com mensagem clara (aparece no Log Stream / 500)
                throw new Exception($"Falha SMTP: {ex.StatusCode} - {ex.Message}", ex);
            }
        }
    }
}
