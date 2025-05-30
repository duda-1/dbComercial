using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
    public interface IFornecedorMercadoriaRepository
    {
        public Task Adicionar(FornecedorMercadoria relacao);
        public Task Remover(int fornecedorId, int mercadoriaId);
        public Task<IEnumerable<FornecedorMercadoria>> Listar();
        public Task<IEnumerable<Mercadorias>> ListarMercadoriasPorFornecedor(int fornecedorId);
        public Task<IEnumerable<Fornecedor>> ListarFornecedoresPorMercadoria(int mercadoriaId);
    }
}
