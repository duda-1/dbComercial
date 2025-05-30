using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
    public interface IFornecedorRepository
    {
        public Task<Fornecedor> Adicionar(Fornecedor fornecedor);
        public Task<IEnumerable<Fornecedor>> Listar();
        public Task<Fornecedor> BuscarPorId(int id);
        public Task Editar(Fornecedor fornecedor);
        public Task Remover(int id);
    }
}
