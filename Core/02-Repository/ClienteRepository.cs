using Core._02_Repository.Interface;
using Core._03_Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly IConfiguration _connectionString;

        public ClienteRepository(IConfiguration config)
        {
            _connectionString = config;
        }

        // Adicionar novo cliente
        public async Task<Cliente> AdicionarCliente(Cliente cliente)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            // Inserção com Dapper (query manual)
            var query = @"INSERT INTO Cliente 
                (CPFCliente, NomeCliente, DtNascimentoCliente, ViaCliente, NumCliente, ComplCliente, BairroCliente, CidadeCliente, UFCliente, CEPCliente,
                 TelefoneCliente, CelularCliente, EmailCliente, SenhaCliente, Empresa_CNPJ)
                VALUES
                (@CPFCliente, @NomeCliente, @DtNascimentoCliente, @ViaCliente, @NumCliente, @ComplCliente, @BairroCliente, @CidadeCliente, @UFCliente, @CEPCliente,
                 @TelefoneCliente, @CelularCliente, @EmailCliente, @SenhaCliente, @Empresa_CNPJ);";

            await connection.ExecuteAsync(query, cliente);
            return cliente;
        }

        // Listar todos os clientes
        public async Task<IEnumerable<Cliente>> ListarClientes()
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<Cliente>("SELECT * FROM Cliente");
        }

        // Editar cliente
        public async Task EditarCliente(Cliente cliente)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            // Substitui GetAsync por QuerySingleOrDefaultAsync para evitar erro
            var clienteExistente = await connection.QuerySingleOrDefaultAsync<Cliente>(
                "SELECT * FROM Cliente WHERE CPFCliente = @CPF", new { CPF = cliente.CPFCliente });

            if (clienteExistente == null)
            {
                throw new Exception("Cliente não encontrado.");
            }

            // Atualiza propriedades
            clienteExistente.NomeCliente = cliente.NomeCliente;
            clienteExistente.DtNascimentoCliente = cliente.DtNascimentoCliente;
            clienteExistente.ViaCliente = cliente.ViaCliente;
            clienteExistente.NumCliente = cliente.NumCliente;
            clienteExistente.ComplCliente = cliente.ComplCliente;
            clienteExistente.BairroCliente = cliente.BairroCliente;
            clienteExistente.CidadeCliente = cliente.CidadeCliente;
            clienteExistente.UFCliente = cliente.UFCliente;
            clienteExistente.CEPCliente = cliente.CEPCliente;
            clienteExistente.TelefoneCliente = cliente.TelefoneCliente;
            clienteExistente.CelularCliente = cliente.CelularCliente;
            clienteExistente.EmailCliente = cliente.EmailCliente;
            clienteExistente.SenhaCliente = cliente.SenhaCliente;
            clienteExistente.Empresa_CNPJ = cliente.Empresa_CNPJ;

            await connection.UpdateAsync(clienteExistente);
        }


        // Remover cliente
        public async Task RemoverCliente(string cpf)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var cliente = await BuscarPorCPF(cpf);
            if (cliente != null)
            {
                var query = "DELETE FROM Cliente WHERE CPFCliente = @CPF";
                await connection.ExecuteAsync(query, new { CPF = cpf });
            }
        }

        // Buscar cliente por CPF
        public async Task<Cliente> BuscarPorCPF(string cpf)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var query = "SELECT * FROM Cliente WHERE CPFCliente = @CPF";
            return await connection.QuerySingleOrDefaultAsync<Cliente>(query, new { CPF = cpf });
        }

        // Método para login de cliente
        public async Task<Cliente> LoginCliente(string cpf, string senha)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var query = @"SELECT * FROM Cliente WHERE CPFCliente = @CPF AND SenhaCliente = @Senha";

            return await connection.QuerySingleOrDefaultAsync<Cliente>(query, new { CPF = cpf, Senha = senha });
        }

    }
}
