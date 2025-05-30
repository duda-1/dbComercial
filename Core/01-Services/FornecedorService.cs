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
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public async Task AdicionarFornecedor(Fornecedor fornecedor)
        {
            await _repository.Adicionar(fornecedor);
        }

        public async Task<IEnumerable<Fornecedor>> ListarFornecedores()
        {
            return await _repository.Listar();
        }

        public async Task<Fornecedor> BuscarFornecedorPorId(int id)
        {
            return await _repository.BuscarPorId(id);
        }

        public async Task EditarFornecedor(int id, Fornecedor fornecedor)
        {
            var existente = await _repository.BuscarPorId(id);
            if (existente == null)
                throw new Exception("Fornecedor não encontrado.");

            await _repository.Editar(fornecedor);
        }

        public async Task RemoverFornecedor(int id)
        {
            await _repository.Remover(id);
        }
    }
}
