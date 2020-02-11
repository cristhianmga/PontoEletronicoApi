using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CFC_Negocio.DTO.Ext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Models.DTO;
using PontoEletronico.Servico.Base;

namespace PontoEletronicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroPontoController : ControllerBase
    {

        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        public RegistroPontoController(ApplicationDbContext ctx, IMapper mapper)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ObterTodosPaginado")]
        public PaginacaoDTO<RegistroPontoDto> ObterTodosPaginado([FromQuery]PaginacaoConfigDTO config,[FromQuery] int empresaId)
        {
            return servico.ObterTodos<RegistroPonto>().Where(x => x.DadosContratacaoFuncionario.EmpresaId == empresaId).AsPaginado<RegistroPontoDto>(config, _mapper);
        }
    }
}