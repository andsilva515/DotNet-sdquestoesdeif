using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class LoginService : ILoginService
    {

        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;
        public LoginService(
            IUserRepository userRepository,
            IConfiguration configuration,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }

        public async Task<LoginResponseDto> AuthenticateAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email)
                ?? throw new Exception("Usuário ou senha inválidos.");

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("Usuário ou senha inválidos.");

            // Atualizar última data de login
            user.LastLoginAt = DateTime.UtcNow;
            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();

            var token = GenerateToken(user);
            var expiration = DateTime.UtcNow.AddHours(2);

            return new LoginResponseDto
            {
                Token = token,
                Expiration = expiration
            };
        }

        private string GenerateToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }       
    
}
