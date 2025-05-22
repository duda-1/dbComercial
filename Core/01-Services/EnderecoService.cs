using Core._01_Services.Interface;
using Core._02_Repository;
using Core._02_Repository.Interface;
using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;

        public EnderecoService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        //Adicionar
        public async Task AdicionarEndereco(Endereco endereco)
        {
            // Chama o método de adicionar da repository
            await _repository.AdicionarEndereco(endereco);
        }

        //Listar
        public async Task<IEnumerable<Endereco>> ListarEndereco()
        {
            return await _repository.ListarEndereco();
        }

        //Buscar por ID
        public async Task<Endereco> BuscarEnderecoPorId(int id)
        {
            // Chama o método assíncrono de buscar na repository
            return await _repository.BuscarPorId(id);
        }

        //Remover
        public async Task RemoverEndereco(int id)
        {
            // Chama o método de remoção da repository
            await _repository.Remover(id);
        }

        //Editar
        public async Task EditarEndereco(int idEndereco, Endereco endereco)
        {
            // Chama o método de buscar por ID
            var enderecoExistente = await _repository.BuscarPorId(idEndereco);

            if (enderecoExistente == null)
            {
                throw new Exception("Endereço não encontrado.");
            }

            // Chama o método de editar da repository
            await _repository.Editar(endereco);
        }


    }
}
