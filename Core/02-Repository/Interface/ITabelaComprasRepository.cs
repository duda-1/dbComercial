using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
    public interface ITabelaComprasRepository
    {
        public Task<TabelaCompras> Adicionar(TabelaCompras compra);
        public Task<IEnumerable<TabelaCompras>> Listar();
        public Task<TabelaCompras> BuscarPorId(int id);
        public Task Editar(TabelaCompras compra);
        public Task Remover(int id);
    }
}
