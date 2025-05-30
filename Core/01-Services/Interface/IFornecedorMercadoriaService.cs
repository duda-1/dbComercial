using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface IFornecedorMercadoriaService
    {
        public Task AdicionarRelacao(FornecedorMercadoria relacao);
        public Task RemoverRelacao(int fornecedorId, int mercadoriaId);
        public Task<IEnumerable<FornecedorMercadoria>> ListarRelacoes();
        public Task<IEnumerable<Mercadorias>> ListarMercadoriasPorFornecedor(int fornecedorId);
        public Task<IEnumerable<Fornecedor>> ListarFornecedoresPorMercadoria(int mercadoriaId);
    }
}
