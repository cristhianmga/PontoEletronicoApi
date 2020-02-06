using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models.DTO
{
    public class DadosContratacaoFuncionarioDto
    {
        public int Id { get; set; }
        public EmpresaDto Empresa { get; set; }
        public FuncionarioDto Funcionario { get; set; }
        public string Cargo { get; set; }
        public TimeSpan CargaHoraria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int EmpresaId { get; set; }
        public int FuncionarioId { get; set; }
    }
}
