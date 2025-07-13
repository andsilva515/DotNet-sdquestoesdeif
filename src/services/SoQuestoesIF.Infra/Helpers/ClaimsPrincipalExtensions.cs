using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var claim = user.FindFirst(ClaimTypes.NameIdentifier)       
               ?? throw new Exception("Claim NameIdentifier não encontrada no usuário autenticado.");

            if (!Guid.TryParse(claim.Value, out var userId))
                throw new FormatException("O identificador do usuário não é um GUID válido.");

            return userId;
        }
    }

}

