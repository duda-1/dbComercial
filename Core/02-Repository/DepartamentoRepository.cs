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
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly IConfiguration _connectionString;

        public DepartamentoRepository(IConfiguration config)
        {
            _connectionString = config;
        }

        //Adicionar
        public async Task<Departamento> AdicionarDepartamento(Departamento departamento)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            // Definindo a query de inserção
            var query = @"INSERT INTO Departamento 
                  (NomeDepartamento, TelefoneDepartamento, CelularDepartamento, EmailDepartamento, Endereco_IdEndereco) 
                  VALUES 
                  (@NomeDepartamento, @TelefoneDepartamento, @CelularDepartamento, @EmailDepartamento, @Endereco_IdEndereco);";

            // Executando a query de inserção
            await connection.ExecuteAsync(query, new
            {
                NomeDepartamento = departamento.NomeDepartamento,
                TelefoneDepartamento = departamento.TelefoneDepartamento,
                CelularDepartamento = departamento.CelularDepartamento,
                EmailDepartamento = departamento.EmailDepartamento,
                Endereco_IdEndereco = departamento.Endereco_IdEndereco
            });

            return departamento;
        }


        //Listar
        public async Task<IEnumerable<Departamento>> ListarDepartamento()
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<Departamento>("SELECT * FROM Departamento");
        }

        //Editar
        public async Task Editar(Departamento departamento)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var departamentoExistente = await connection.GetAsync<Departamento>(departamento.idDepartamento);

            if (departamentoExistente == null)
            {
                throw new Exception("Departamento não encontrado.");
            }

            departamentoExistente.NomeDepartamento = departamento.NomeDepartamento;
            departamentoExistente.TelefoneDepartamento = departamento.TelefoneDepartamento;
            departamentoExistente.CelularDepartamento = departamento.CelularDepartamento;
            departamentoExistente.EmailDepartamento = departamento.EmailDepartamento;
            departamentoExistente.Endereco_IdEndereco = departamento.Endereco_IdEndereco;

            await connection.UpdateAsync(departamentoExistente);
        }

        //Deletar
        public async Task Remover(int idDepartamento)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var departamento = await BuscarPorId(idDepartamento);

            if (departamento != null)
            {
                var query = "DELETE FROM Departamento WHERE idDepartamento = @idDepartamento";
                await connection.ExecuteAsync(query, new { idDepartamento });
            }
        }

        //Buscar por idDepartamento
        public async Task<Departamento> BuscarPorId(int idDepartamento)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var query = "SELECT * FROM Departamento WHERE idDepartamento = @idDepartamento";
            return await connection.QuerySingleOrDefaultAsync<Departamento>(query, new { idDepartamento });
        }


    }
}
