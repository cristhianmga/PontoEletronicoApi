using Microsoft.Extensions.Primitives;
using PontoEletronico.Models;
using System.IdentityModel.Tokens.Jwt;

namespace PontoEletronico.Servico.Interface
{
    public interface ITokenJwtServico
    {
        object CriarTokenJwt(UserApp user);
        JwtSecurityToken ReadToken(StringValues token);
    }
}
