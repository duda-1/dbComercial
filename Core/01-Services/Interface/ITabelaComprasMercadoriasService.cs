using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface ITabelaComprasMercadoriasService
    {
        public Task Adicionar(TabelaComprasMercadorias entidade);
        public Task<IEnumerable<TabelaComprasMercadorias>> Listar();
        public Task<TabelaComprasMercadorias> BuscarPorId(int id);
        public Task Editar(int id, TabelaComprasMercadorias entidade);
        public Task Remover(int id);
    }
}
