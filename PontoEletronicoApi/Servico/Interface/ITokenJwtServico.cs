using PontoEletronico.JwtConfigurations;
using PontoEletronico.Models;
using PontoEletronico.Models.TokenConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Servico.Interface
{
    public interface ITokenJwtServico
    {
        object CriarTokenJwt(UserApp user, SigningConfigurations signingConfigurations, TokenConfiguration tokenConfigurations);
    }
}
