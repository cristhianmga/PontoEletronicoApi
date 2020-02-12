using System;
using System.ComponentModel.DataAnnotations;

namespace PontoEletronico.Models
{
    public class RegistroPonto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public TimeSpan HoraEntrada { get; set; }
        [Required]
        public TimeSpan HoraSaida { get; set; }
        [Required]
        public DadosContratacaoFuncionario DadosContratacaoFuncionario { get; set; }
    }
}
