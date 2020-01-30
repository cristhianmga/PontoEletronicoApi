using AutoMapper;
using CFC_Negocio.DTO.Ext;
using Microsoft.AspNetCore.Mvc;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Models.DTO;
using PontoEletronico.Servico.Base;
using System;
using System.Linq;

namespace PontoEletronicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        public EmpresaController(ApplicationDbContext ctx, IMapper mapper)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ObterTodosPaginado")]
        public PaginacaoDTO<EmpresaDto> ObterTodosPaginado([FromQuery]PaginacaoConfigDTO config)
        {
            return servico.ObterTodos<Empresa>().AsPaginado<EmpresaDto>(config, _mapper);
        }

        [HttpPost]
        public Empresa Salvar(Empresa dto)
        {
            return servico.Salvar<Empresa>(dto);
        }

        [HttpPut]
        public StatusCodeResult Atualizar(Empresa dto)
        {
            try
            {
                servico.Atualizar<Empresa>(dto);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public EmpresaDto Obter(int id)
        {
            return _mapper.Map<EmpresaDto>(servico.ObterTodos<Empresa>().Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpDelete]
        [Route("{id}")]
        public StatusCodeResult Deletar(int id)
        {
            servico.ExcluirAsync<Empresa>(id);
            return Ok();
        }
    }
}