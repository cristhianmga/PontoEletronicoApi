using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PontoEletronico.Models
{
    public class Funcionario
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(11)]
        public string Cpf { get; set; }
        [Required]
        [MaxLength(100)]
        public string Senha { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
