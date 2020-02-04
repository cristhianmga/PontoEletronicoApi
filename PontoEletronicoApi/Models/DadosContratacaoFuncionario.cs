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
        public string Cargo { get; set; }
        public TimeSpan CargaHoraria { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Ceo { get;set; }

    }
}
