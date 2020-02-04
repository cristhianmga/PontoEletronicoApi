using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Servico.Base;
using System.Linq;

namespace PontoEletronicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {

        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        public FuncionarioController(ApplicationDbContext ctx, IMapper mapper)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
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
    }
}