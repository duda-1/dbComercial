using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface IFornecedorService
    {
        public Task AdicionarFornecedor(Fornecedor fornecedor);
        public Task<IEnumerable<Fornecedor>> ListarFornecedores();
        public Task<Fornecedor> BuscarFornecedorPorId(int id);
        public Task EditarFornecedor(int id, Fornecedor fornecedor);
        public Task RemoverFornecedor(int id);
    }
}
