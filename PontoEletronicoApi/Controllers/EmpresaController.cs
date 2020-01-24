using AutoMapper;
using CFC_Negocio.DTO.Ext;
using Microsoft.AspNetCore.Mvc;
using PontoEletronico.Data;
using PontoEletronico.Models;
using PontoEletronico.Servico.Base;

namespace PontoEletronicoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly BaseServico servico;
        private readonly IMapper _mapper;
        public EmpresaController(ApplicationDbContext ctx,IMapper mapper)
        {
            servico = new BaseServico(ctx);
            _mapper = mapper;
        }

        [Route("ObterTodosPaginado")]
        public PaginacaoDTO ObterTodosPaginado(PaginacaoConfigDTO config)
        {
            return servico.ObterTodos<Empresa>().AsPaginado(config);
        }
    }
}