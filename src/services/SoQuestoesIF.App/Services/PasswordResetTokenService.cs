using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class PasswordResetTokenService : IPasswordResetTokenService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordResetTokenRepository _resetRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailSenderService _emailSender;

        public PasswordResetTokenService(
            IUserRepository userRepository,
            IPasswordResetTokenRepository resetRepository,
            IUnitOfWork unitOfWork,
            IEmailSenderService emailSender)
        {
            _userRepository = userRepository;
            _resetRepository = resetRepository;
            _unitOfWork = unitOfWork;
            _emailSender = emailSender;
        }

        public async Task RequestResetAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
                return; // Nunca informa se existe

            var token = Guid.NewGuid().ToString("N");
            var resetToken = new PasswordResetToken
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Token = token,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddHours(2),
                Used = false
            };

            await _resetRepository.AddAsync(resetToken);
            await _unitOfWork.CommitAsync();

            var link = $"https://seusite.com/reset-password?token={token}";
            await _emailSender.SendAsync(email, "Recuperação de Senha", $"Clique no link para redefinir sua senha: {link}");
        }

        public async Task ResetPasswordAsync(string token, string newPassword)
        {
            var resetToken = await _resetRepository.GetValidTokenAsync(token);
            if (resetToken == null)
                throw new Exception("Token inválido ou expirado.");

            var user = await _userRepository.GetByIdAsync(resetToken.UserId);
            user.ChangePassword(BCrypt.Net.BCrypt.HashPassword(newPassword));

            resetToken.Used = true;

            _resetRepository.Update(resetToken);
            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();
        }
    }

}
