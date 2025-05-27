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
    public class CargoRepository : ICargoRepository
    {
        private readonly IConfiguration _connectionString;

        public CargoRepository(IConfiguration config)
        {
            _connectionString = config;
        }

        // Adicionar
        public async Task<Cargos> AdicionarCargo(Cargos cargo)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var query = @"INSERT INTO Cargos (Cargo) VALUES (@Cargo);";

            await connection.ExecuteAsync(query, new { cargo.Cargo });

            return cargo;
        }

        // Listar todos
        public async Task<IEnumerable<Cargos>> ListarCargos()
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<Cargos>("SELECT * FROM Cargos");
        }

        // Editar
        public async Task Editar(Cargos cargo)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var cargoExistente = await connection.GetAsync<Cargos>(cargo.idCargos);

            if (cargoExistente == null)
            {
                throw new Exception("Cargo não encontrado.");
            }

            cargoExistente.Cargo = cargo.Cargo;

            await connection.UpdateAsync(cargoExistente);
        }

        // Remover
        public async Task Remover(int id)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var cargo = await BuscarPorId(id);
            if (cargo != null)
            {
                await connection.ExecuteAsync("DELETE FROM Cargos WHERE idCargos = @Id", new { Id = id });
            }
        }

        // Buscar por ID
        public async Task<Cargos> BuscarPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));
            return await connection.QuerySingleOrDefaultAsync<Cargos>("SELECT * FROM Cargos WHERE idCargos = @Id", new { Id = id });
        }
    }
}
