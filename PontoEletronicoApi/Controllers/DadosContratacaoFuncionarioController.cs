using System;
using System.Linq;
using AutoMapper;
using CFC_Negocio.DTO.Ext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Models.DTO;
using PontoEletronico.Servico.Base;
using PontoEletronico.Servico.Interface;

namespace PontoEletronicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosContratacaoFuncionarioController : ControllerBase
    {
        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        private readonly ITokenJwtServico _tokenJwtServico;
        public DadosContratacaoFuncionarioController(ApplicationDbContext ctx, IMapper mapper,ITokenJwtServico tokenJwtServico)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
            _tokenJwtServico = tokenJwtServico;
        }

        [HttpGet]
        [Route("ObterTodosPaginado")]
        public PaginacaoDTO<DadosContratacaoFuncionarioDto> ObterTodosPaginado([FromQuery]PaginacaoConfigDTO config)
        {
            StringValues token;
            Request.Headers.TryGetValue("Authorization", out token);
            var cpf = _tokenJwtServico.ReadToken(token).Claims.ToList()[0].Value;
            var dados = servico.ObterTodos<DadosContratacaoFuncionario>(new string[] { "Funcionario","Empresa" }).Where(x => x.Funcionario.Cpf == cpf).FirstOrDefault();
            var empresaId = dados.Empresa.Id;
            return servico.ObterTodos<DadosContratacaoFuncionario>(new string[] { "Funcionario", "Empresa" }).Where(x => x.Empresa.Id == empresaId).AsPaginado<DadosContratacaoFuncionarioDto>(config, _mapper);
        }

        [HttpPost]
        public DadosContratacaoFuncionario Salvar(DadosContratacaoFuncionarioDto dto)
        {
            var retorno = _mapper.Map<DadosContratacaoFuncionario>(dto);
            return servico.Salvar<DadosContratacaoFuncionario>(retorno);
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