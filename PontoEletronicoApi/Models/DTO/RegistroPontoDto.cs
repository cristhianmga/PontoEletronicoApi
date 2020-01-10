using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models.DTO
{
    public class RegistroPontoDto
    {
        public int Id { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }
        public DadosContratacaoFuncionarioDto DadosContratacaoFuncionario { get; set; }
    }
}
