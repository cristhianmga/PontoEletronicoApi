using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace CFC_Negocio.DTO.Ext
{
    public class PaginacaoDTO<R>
    {
        private IQueryable<dynamic> listaObjeto;
        private PaginacaoConfigDTO config;
        private IMapper _mapper;

        public PaginacaoDTO(IQueryable<dynamic> listaObjeto, PaginacaoConfigDTO config,IMapper mapper)
        {
            this.listaObjeto = listaObjeto;
            this.config = config;
            _mapper = mapper;
        }
        
        public List<R> content
        {
            get
            {
                return _mapper.Map<List<R>>(listaObjeto.Count() != 0 ? listaObjeto.Skip(config.page * config.size).Take(config.size) : null);
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
