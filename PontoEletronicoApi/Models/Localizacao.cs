using PontoEletronico.Models;
using System.ComponentModel.DataAnnotations;

namespace PontoEletronicoApi.Models
{
    public class Localizacao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string Endereco { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
    }
}
