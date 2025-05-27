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
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        // Adicionar novo cliente
        public async Task AdicionarCliente(Cliente cliente)
        {
            await _repository.AdicionarCliente(cliente);
        }

        // Listar todos os clientes
        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            return await _repository.ListarClientes();
        }

        // Buscar cliente por CPF
        public async Task<Cliente> BuscarClientePorCpf(string cpf)
        {
            return await _repository.BuscarPorCPF(cpf);
        }

        // Remover cliente
        public async Task RemoverCliente(string cpf)
        {
            await _repository.RemoverCliente(cpf);
        }

        // Editar cliente
        public async Task EditarCliente(string cpf, Cliente cliente)
        {
            var clienteExistente = await _repository.BuscarPorCPF(cpf);

            if (clienteExistente == null)
            {
                throw new Exception("Cliente não encontrado.");
            }

            // Garante que o CPF original não seja sobrescrito por engano
            cliente.CPFCliente = cpf;

            await _repository.EditarCliente(cliente);
        }

        // Login do cliente
        public async Task<Cliente> LoginCliente(string cpf, string senha)
        {
            var cliente = await _repository.LoginCliente(cpf, senha);

            if (cliente == null)
            {
                throw new Exception("CPF ou senha inválidos.");
            }

            return cliente;
        }

    }
}
