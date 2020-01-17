using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PontoEletronico.Models;
using PontoEletronico.Servico.Interface;

namespace PontoEletronico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly ITokenJwtServico _tokenJwtServico;
        public AutenticacaoController(ITokenJwtServico tokenJwtServico)
        {
            _tokenJwtServico = tokenJwtServico;
        }

        [HttpPost]
        public object Login(UserApp user)
        {
            return _tokenJwtServico.CriarTokenJwt(user);
        }

        [HttpGet]
        [Authorize("Bearer")]
        public object TestarToken()
        {
            return new { Nome = "Passou", Senha = "Sim" };
        }
    }
}