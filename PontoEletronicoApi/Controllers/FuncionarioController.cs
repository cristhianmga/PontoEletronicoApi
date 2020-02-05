using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Models.DTO;
using PontoEletronico.Servico.Base;
using PontoEletronico.Servico.Interface;
using System.Linq;

namespace PontoEletronicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        private readonly ITokenJwtServico _tokenJwtServico;
        public FuncionarioController(ApplicationDbContext ctx, IMapper mapper, ITokenJwtServico tokenJwtServico)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
            _tokenJwtServico = tokenJwtServico;
        }

        [HttpGet]
        [Route("verificaCpf/{cpf}")]
        public ObjectResult verificaCpf(string cpf)
        {
            if(servico.ObterTodos<Funcionario>().Any(x => x.Cpf == cpf))
            {
                var func = servico.ObterTodos<Funcionario>().Where(x => x.Cpf == cpf).FirstOrDefault();
                return StatusCode(200, func);
            }
            else
            {
                return StatusCode(200, null);
            }
        }
        [HttpGet]
        [Route("obterDadosUsuario")]
        public ObjectResult ObterDadosUsuario()
        {
            StringValues token;
            Request.Headers.TryGetValue("Authorization", out token);
            var cpf = _tokenJwtServico.ReadToken(token).Claims.ToList()[0].Value;
            var dados = _mapper.Map<DadosContratacaoFuncionarioDto>(servico.ObterTodos<DadosContratacaoFuncionario>(new string[] { "Empresa","Funcionario" }).Where(x => x.Funcionario.Cpf == cpf).FirstOrDefault());

            var retorno = new
            {
                funcionario = dados.Funcionario,
                empresa = dados.Empresa
            };

            return StatusCode(200, retorno);
        }
    }
}