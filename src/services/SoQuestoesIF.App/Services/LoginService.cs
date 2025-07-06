using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class LoginService
    {
        public class LoginService : ILoginService
        {
            private readonly IUserRepository _usuarioRepository;
            private readonly IPasswordHasher _passwordHasher;
            private readonly IConfiguration _configuration;

            public LoginService(IUserRepository usuarioRepository, IPasswordHasher passwordHasher, IConfiguration configuration)
            {
                _usuarioRepository = usuarioRepository;
                _passwordHasher = passwordHasher;
                _configuration = configuration;
            }

            public async Task<LoginResponseDto> AutenticarAsync(LoginDto dto)
            {
                var usuario = await _usuarioRepository.ObterPorEmailAsync(dto.Email)
                    ?? throw new Exception("Usuário não encontrado.");

                if (!_passwordHasher.Verify(dto.Senha, usuario.SenhaHash))
                    throw new Exception("Senha inválida.");

                var token = GerarToken(usuario);
                var expiracao = DateTime.UtcNow.AddHours(2);

                return new LoginResponseDto(token, expiracao);
            }

            private string GerarToken(Usuario usuario)
            {
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
            new Claim(ClaimTypes.Role, usuario.Perfil.ToString())
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
}
