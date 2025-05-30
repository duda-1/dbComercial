using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
    public interface ITabelaComprasMercadoriasRepository
    {
        public Task<TabelaComprasMercadorias> Adicionar(TabelaComprasMercadorias entidade);
        public Task<IEnumerable<TabelaComprasMercadorias>> Listar();
        public Task<TabelaComprasMercadorias> BuscarPorId(int id);
        public Task Editar(TabelaComprasMercadorias entidade);
        public Task Remover(int id);
    }
}
