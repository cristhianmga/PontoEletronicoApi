using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Servico.Base;
using PontoEletronico.Servico.Interface;
using PontoEletronicoApi.Models;
using PontoEletronicoApi.Models.DTO;

namespace PontoEletronicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        private readonly ITokenJwtServico _tokenJwtServico;
        public LocalizacaoController(ApplicationDbContext ctx, IMapper mapper, ITokenJwtServico tokenJwtServico)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
            _tokenJwtServico = tokenJwtServico;
        }


        [HttpPost]
        public StatusCodeResult Salvar(List<LocalizacaoDto> dto)
        {

            StringValues token;
            Request.Headers.TryGetValue("Authorization", out token);
            var cpf = _tokenJwtServico.ReadToken(token).Claims.ToList()[0].Value;
            var dados = servico.ObterTodos<DadosContratacaoFuncionario>(new string[] { "Funcionario","Empresa" },true).Where(x => x.Funcionario.Cpf == cpf).FirstOrDefault();
            var empresaId = dados.Empresa.Id;

            var entity = _mapper.Map<List<Localizacao>>(dto);

            var listIds = servico.ObterTodos<Localizacao>(null,true).Where(x => x.EmpresaId == entity[0].EmpresaId).Select(y => y.Id).ToList();

            var excluidos = listIds.Where(x => !entity.Any(y => y.Id == x)).ToList();

            if (excluidos.Any())
            {
                foreach(int item in excluidos)
                {
                    servico.ExcluirAsync<Localizacao>(item);
                }
            }
            foreach(Localizacao item in entity)
            {
                item.EmpresaId = empresaId;
                if(item.Id == 0)
                {
                    servico.Salvar(item);
                }else
                {
                    item.Empresa = null;
                    servico.Atualizar<Localizacao>(item);
                }
            }
            return Ok();
        }

        [HttpGet]
        [Route("listarTodos")]
        public ObjectResult ListarTodos()
        {

            StringValues token;
            Request.Headers.TryGetValue("Authorization", out token);
            var cpf = _tokenJwtServico.ReadToken(token).Claims.ToList()[0].Value;
            var dados = servico.ObterTodos<DadosContratacaoFuncionario>(new string[] { "Funcionario", "Empresa" }).Where(x => x.Funcionario.Cpf == cpf).FirstOrDefault();
            var empresaId = dados.Empresa.Id;

            return Ok(servico.ObterTodos<Localizacao>().Where(x => x.EmpresaId == empresaId));
        }
    }
}