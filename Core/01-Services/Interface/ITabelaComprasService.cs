using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface ITabelaComprasService
    {
        public Task Adicionar(TabelaCompras compra);
        public Task<IEnumerable<TabelaCompras>> Listar();
        public Task<TabelaCompras> BuscarPorId(int id);
        public Task Editar(int id, TabelaCompras compra);
        public Task Remover(int id);
    }
}
