using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PontoEletronico.Models.DTO
{
    public class EmpresaDto
    {
        public int Id { get; set; }
        [Display(Name = "Razão Social")]
        [Required]
        public string RazaoSocial { get; set; }
        [Display(Name = "CNPJ")]
        [Required]
        public string Cnpj { get; set; }
    }
}
