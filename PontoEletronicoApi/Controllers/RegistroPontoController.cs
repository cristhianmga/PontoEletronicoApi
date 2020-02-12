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
using PontoEletronicoApi.Models.DTO;

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
        [Route("ObterRegistroPonto")]
        public ObjectResult ObterTodosPaginado([FromQuery]DadosRegistroPontoDto dto)
        {
            var date = new DateTime(dto.Ano, dto.Mes, 1);
            List<DateTime> days = new List<DateTime>();
            while(date.Month == dto.Mes)
            {
                days.Add(date);
                date = date.AddDays(1);
            }
            var dados = servico.ObterTodos<DadosContratacaoFuncionario>().Where(x => x.FuncionarioId == dto.FuncionarioId && x.EmpresaId == dto.EmpresaId).FirstOrDefault();
            var ponto = servico.ObterTodos<RegistroPonto>().Where(x => x.DadosContratacaoFuncionario.EmpresaId == dto.EmpresaId && x.DadosContratacaoFuncionario.FuncionarioId == dto.FuncionarioId);
            List<RetornoRegistroPontoDto> list = new List<RetornoRegistroPontoDto>();
            days.ForEach(x =>
            {
            RetornoRegistroPontoDto entity = new RetornoRegistroPontoDto();
                if (ponto.Any(y => y.Data == x))
                {
                    var busca = ponto.Where(z => z.Data == x).FirstOrDefault();
                    entity.Data = x;
                    entity.HoraEntrada = busca.HoraEntrada;
                    entity.HoraSaida = busca.HoraSaida;
                    entity.Saldo = busca.DadosContratacaoFuncionario.CargaHoraria - (busca.HoraSaida - busca.HoraEntrada);
                    list.Add(entity);
                }
                else
                {
                    entity.Data = x;
                    entity.HoraEntrada = new TimeSpan();
                    entity.HoraSaida = new TimeSpan();
                    entity.Saldo = dados.CargaHoraria;
                    list.Add(entity);
                }
            });

            return Ok(list);
        }
    }
}