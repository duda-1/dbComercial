using Core._02_Repository.Interface;
using Core._03_Entidades;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository
{
    public class FornecedorMercadoriaRepository : IFornecedorMercadoriaRepository
    {
        private readonly IConfiguration _configuration;

        public FornecedorMercadoriaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Adicionar(FornecedorMercadoria relacao)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var query = @"INSERT INTO Fornecedor_has_Mercadorias 
                        (Fornecedor_idFornecedor, Mercadorias_idMercadorias) 
                        VALUES (@Fornecedor_idFornecedor, @Mercadorias_idMercadorias);";
            await connection.ExecuteAsync(query, relacao);
        }

        public async Task Remover(int fornecedorId, int mercadoriaId)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var query = @"DELETE FROM Fornecedor_has_Mercadorias 
                          WHERE Fornecedor_idFornecedor = @Fornecedor_id 
                            AND Mercadorias_idMercadorias = @Mercadoria_id;";
            await connection.ExecuteAsync(query, new { Fornecedor_id = fornecedorId, Mercadoria_id = mercadoriaId });
        }

        public async Task<IEnumerable<FornecedorMercadoria>> Listar()
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<FornecedorMercadoria>("SELECT * FROM Fornecedor_has_Mercadorias");
        }

        public async Task<IEnumerable<Mercadorias>> ListarMercadoriasPorFornecedor(int fornecedorId)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var query = @"SELECT M.* FROM Mercadorias M
                          JOIN Fornecedor_has_Mercadorias FM ON M.IdMercadorias = FM.Mercadorias_idMercadorias
                          WHERE FM.Fornecedor_idFornecedor = @Id";
            return await connection.QueryAsync<Mercadorias>(query, new { Id = fornecedorId });
        }

        public async Task<IEnumerable<Fornecedor>> ListarFornecedoresPorMercadoria(int mercadoriaId)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var query = @"SELECT F.* FROM Fornecedor F
                          JOIN Fornecedor_has_Mercadorias FM ON F.IdFornecedor = FM.Fornecedor_idFornecedor
                          WHERE FM.Mercadorias_idMercadorias = @Id";
            return await connection.QueryAsync<Fornecedor>(query, new { Id = mercadoriaId });
        }
    }
}
