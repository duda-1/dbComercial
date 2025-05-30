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
    public class TipoMercadoriaRepository : ITipoMercadoriaRepository
    {
        private readonly IConfiguration _configuration;

        public TipoMercadoriaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TipoMercadoria> AdicionarTipoMercadoria(TipoMercadoria tipo)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            var query = @"INSERT INTO TipoMercadoria 
                          (TipoMercadoria, Departamento_idDepartamento, Departamento_Endereco_IdEndereco)
                          VALUES (@Tipo, @Departamento_idDepartamento, @Departamento_Endereco_IdEndereco);";

            await connection.ExecuteAsync(query, tipo);
            return tipo;
        }

        public async Task<IEnumerable<TipoMercadoria>> ListarTipoMercadorias()
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<TipoMercadoria>("SELECT * FROM TipoMercadoria");
        }

        public async Task<TipoMercadoria> BuscarPorId(int id)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await connection.QuerySingleOrDefaultAsync<TipoMercadoria>("SELECT * FROM TipoMercadoria WHERE IdTipoMercadoria = @Id", new { Id = id });
        }

        public async Task Editar(TipoMercadoria tipo)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var tipoExistente = await connection.GetAsync<TipoMercadoria>(tipo.IdTipoMercadoria);

            if (tipoExistente == null)
                throw new Exception("Tipo de mercadoria não encontrado.");

            tipoExistente.Tipo = tipo.Tipo;
            tipoExistente.Departamento_idDepartamento = tipo.Departamento_idDepartamento;
            tipoExistente.Departamento_Endereco_IdEndereco = tipo.Departamento_Endereco_IdEndereco;

            await connection.UpdateAsync(tipoExistente);
        }

        public async Task Remover(int id)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var tipo = await BuscarPorId(id);

            if (tipo != null)
            {
                await connection.ExecuteAsync("DELETE FROM TipoMercadoria WHERE IdTipoMercadoria = @Id", new { Id = id });
            }
        }
    }
}
