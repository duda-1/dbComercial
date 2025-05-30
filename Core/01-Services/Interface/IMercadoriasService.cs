using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface IMercadoriasService
    {
        public Task AdicionarMercadoria(Mercadorias mercadoria);
        public Task<IEnumerable<Mercadorias>> ListarMercadorias();
        public Task<Mercadorias> BuscarMercadoriaPorId(int id);
        public Task EditarMercadoria(int id, Mercadorias mercadoria);
        public Task RemoverMercadoria(int id);
    }
}
