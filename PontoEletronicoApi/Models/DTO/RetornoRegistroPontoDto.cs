using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronicoApi.Models.DTO
{
    public class RetornoRegistroPontoDto
    {
        public DateTime Data { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public TimeSpan HoraSaida { get; set; }
        public TimeSpan Saldo { get; set; }
    }
}
