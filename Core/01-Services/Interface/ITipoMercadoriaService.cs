using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface ITipoMercadoriaService
    {
        public Task AdicionarTipoMercadoria(TipoMercadoria tipo);
        public Task<IEnumerable<TipoMercadoria>> ListarTipoMercadorias();
        public Task<TipoMercadoria> BuscarTipoMercadoriaPorId(int id);
        public Task EditarTipoMercadoria(int id, TipoMercadoria tipo);
        public Task RemoverTipoMercadoria(int id);
    }
}
