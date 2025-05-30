using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
    public interface IMercadoriasRepository
    {
        public Task<Mercadorias> Adicionar(Mercadorias mercadoria);
        public Task<IEnumerable<Mercadorias>> Listar();
        public Task<Mercadorias> BuscarPorId(int id);
        public Task Editar(Mercadorias mercadoria);
        public Task Remover(int id);
    }
}
