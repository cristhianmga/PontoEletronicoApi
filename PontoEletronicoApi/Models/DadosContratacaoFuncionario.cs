using System;
using System.ComponentModel.DataAnnotations;

namespace PontoEletronico.Models
{
    public class DadosContratacaoFuncionario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Empresa Empresa { get; set; }
        [Required]
        public Funcionario Funcionario { get; set; }
        [Required]
        public string Cargo { get; set; }
        [Required]
        public TimeSpan CargaHoraria { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }

    }
}
