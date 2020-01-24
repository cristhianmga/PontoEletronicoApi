using System.Linq;

namespace CFC_Negocio.DTO.Ext
{
    public class PaginacaoDTO
    {
        private IQueryable<dynamic> listaObjeto;
        private PaginacaoConfigDTO config;

        public PaginacaoDTO(IQueryable<dynamic> listaObjeto, PaginacaoConfigDTO config)
        {
            this.listaObjeto = listaObjeto;
            this.config = config;
        }
        
        public IQueryable<dynamic> content
        {
            get
            {
                return listaObjeto.Count() != 0 ? listaObjeto.Skip(config.page * config.size).Take(config.size) : null;
            }
        }

        public int? totalElements
        {
            get
            {
                return listaObjeto.Count() != 0 ? listaObjeto.Count() : 0;
            }
        }
    }

}
