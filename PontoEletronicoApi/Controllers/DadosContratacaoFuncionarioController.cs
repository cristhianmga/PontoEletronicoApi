using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CFC_Negocio.DTO.Ext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Models.DTO;
using PontoEletronico.Servico.Base;

namespace PontoEletronicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosContratacaoFuncionarioController : ControllerBase
    {
        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        public DadosContratacaoFuncionarioController(ApplicationDbContext ctx, IMapper mapper)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ObterTodosPaginado")]
        public PaginacaoDTO<DadosContratacaoFuncionarioDto> ObterTodosPaginado([FromQuery]PaginacaoConfigDTO config)
        {
            StringValues token;
            Request.Headers.TryGetValue("Authorization", out token);
            return servico.ObterTodos<DadosContratacaoFuncionario>().AsPaginado<DadosContratacaoFuncionarioDto>(config, _mapper);
        }

        [HttpPost]
        public DadosContratacaoFuncionario Salvar(DadosContratacaoFuncionario dto)
        {
            return servico.Salvar<DadosContratacaoFuncionario>(dto);
        }

        [HttpPut]
        public StatusCodeResult Atualizar(DadosContratacaoFuncionario dto)
        {
            try
            {
                servico.Atualizar<DadosContratacaoFuncionario>(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public DadosContratacaoFuncionarioDto Obter(int id)
        {
            return _mapper.Map<DadosContratacaoFuncionarioDto>(servico.ObterTodos<DadosContratacaoFuncionario>().Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpDelete]
        [Route("{id}")]
        public StatusCodeResult Deletar(int id)
        {
            servico.ExcluirAsync<DadosContratacaoFuncionario>(id);
            return Ok();
        }
    }
}