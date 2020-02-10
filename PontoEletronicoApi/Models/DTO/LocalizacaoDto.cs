using PontoEletronico.Models.DTO;

namespace PontoEletronicoApi.Models.DTO
{
    public class LocalizacaoDto
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Endereco { get; set; }
        public EmpresaDto Empresa { get; set; }
        public int EmpresaId { get; set; }
    }
}
