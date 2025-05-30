using Core._01_Services.Interface;
using Core._02_Repository.Interface;
using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services
{
    public class FornecedorMercadoriaService : IFornecedorMercadoriaService
    {
        private readonly IFornecedorMercadoriaRepository _repository;

        public FornecedorMercadoriaService(IFornecedorMercadoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task AdicionarRelacao(FornecedorMercadoria relacao)
        {
            await _repository.Adicionar(relacao);
        }

        public async Task RemoverRelacao(int fornecedorId, int mercadoriaId)
        {
            await _repository.Remover(fornecedorId, mercadoriaId);
        }

        public async Task<IEnumerable<FornecedorMercadoria>> ListarRelacoes()
        {
            return await _repository.Listar();
        }

        public async Task<IEnumerable<Mercadorias>> ListarMercadoriasPorFornecedor(int fornecedorId)
        {
            return await _repository.ListarMercadoriasPorFornecedor(fornecedorId);
        }

        public async Task<IEnumerable<Fornecedor>> ListarFornecedoresPorMercadoria(int mercadoriaId)
        {
            return await _repository.ListarFornecedoresPorMercadoria(mercadoriaId);
        }

    }
}
