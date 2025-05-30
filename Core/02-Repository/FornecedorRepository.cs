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
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly IConfiguration _configuration;

        public FornecedorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Fornecedor> Adicionar(Fornecedor fornecedor)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var query = @"INSERT INTO Fornecedor
            (NomeFornecedor, CNPJFornecedor, CEPFornecedor, RuaFornecedor, NumFornecedor, ComplFornecedor,
             BairroFornecedor, CidadeFornecedor, UFFornecedor, TelefoneFornecedor, CelularFornecedor, EmailFornecedor)
            VALUES
            (@NomeFornecedor, @CNPJFornecedor, @CEPFornecedor, @RuaFornecedor, @NumFornecedor, @ComplFornecedor,
             @BairroFornecedor, @CidadeFornecedor, @UFFornecedor, @TelefoneFornecedor, @CelularFornecedor, @EmailFornecedor);";

            await connection.ExecuteAsync(query, fornecedor);
            return fornecedor;
        }

        public async Task<IEnumerable<Fornecedor>> Listar()
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<Fornecedor>("SELECT * FROM Fornecedor");
        }

        public async Task<Fornecedor> BuscarPorId(int id)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await connection.QuerySingleOrDefaultAsync<Fornecedor>("SELECT * FROM Fornecedor WHERE idFornecedor = @Id", new { Id = id });
        }

        public async Task Editar(Fornecedor fornecedor)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var existente = await connection.GetAsync<Fornecedor>(fornecedor.IdFornecedor);

            if (existente == null)
                throw new Exception("Fornecedor não encontrado.");

            await connection.UpdateAsync(fornecedor);
        }

        public async Task Remover(int id)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var fornecedor = await BuscarPorId(id);

            if (fornecedor != null)
            {
                await connection.ExecuteAsync("DELETE FROM Fornecedor WHERE idFornecedor = @Id", new { Id = id });
            }
        }
    }
}
