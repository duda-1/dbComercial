using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
    public interface ITipoMercadoriaRepository
    {
        public Task<TipoMercadoria> AdicionarTipoMercadoria(TipoMercadoria tipo);
        public Task<IEnumerable<TipoMercadoria>> ListarTipoMercadorias();
        public Task<TipoMercadoria> BuscarPorId(int id);
        public Task Editar(TipoMercadoria tipo);
        public Task Remover(int id);
    }
}
