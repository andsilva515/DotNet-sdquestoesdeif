using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
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
       private readonly IPasswordHasher _passwordHasher;
        public LoginService(IUserRepository userRepository, IPasswordHasher passwordHasher, IConfiguration configuration)
       {
           _userRepository = userRepository;           
           _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

       public async Task<LoginResponseDto> AuthenticateAsync(LoginDto dto)
       {
           var user = await _userRepository.GetByEmailAsync(dto.Email)
           ?? throw new Exception("Usuário não encontrado.");
           
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                    throw new Exception("Senha inválida.");

            var token = GenerateToken(user);
            var expiracao = DateTime.UtcNow.AddHours(2);

            return new LoginResponseDto(token, expiracao);
       }

       private string GenerateToken(User user)
       {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var claims = new[]
            {
            
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Perfil.ToString())
            
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
    
}
