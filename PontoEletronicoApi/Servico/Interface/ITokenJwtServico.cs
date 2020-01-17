using PontoEletronico.Models;

namespace PontoEletronico.Servico.Interface
{
    public interface ITokenJwtServico
    {
        object CriarTokenJwt(UserApp user);
    }
}
