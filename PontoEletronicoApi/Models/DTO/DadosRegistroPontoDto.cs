using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoApi.Models.DTO
{
    public class DadosRegistroPontoDto
    {
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int EmpresaId { get; set; }
        public int FuncionarioId { get; set; }
    }
}
