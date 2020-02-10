using AutoMapper;
using PontoEletronico.Models.DTO;
using PontoEletronicoApi.Models;
using PontoEletronicoApi.Models.DTO;

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
            CreateMap<Localizacao, LocalizacaoDto>().ReverseMap();
        }
    }
}
