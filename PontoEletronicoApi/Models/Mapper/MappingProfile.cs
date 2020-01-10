using AutoMapper;
using PontoEletronico.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Empresa, EmpresaDto>().ReverseMap();
            CreateMap<Funcionario, FuncionarioDto>().ReverseMap();
            CreateMap<RegistroPonto, RegistroPontoDto>().ReverseMap();
            CreateMap<DadosContratacaoFuncionario, DadosContratacaoFuncionarioDto>().ReverseMap();
        }
    }
}
