using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models
{
    public class Empresa
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string RazaoSocial { get; set; }
        [Required]
        [MaxLength(14)]
        public string Cnpj { get; set; }
        public List<DadosContratacaoFuncionario> DadosContratacaoFuncionarios { get; set; }
    }
}
