using System;
using System.ComponentModel.DataAnnotations;

namespace PontoEletronico.Models
{
    public class RegistroPonto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime HoraEntrada { get; set; }
        [Required]
        public DateTime HoraSaida { get; set; }
        [Required]
        public DadosContratacaoFuncionario DadosContratacaoFuncionario { get; set; }
    }
}
