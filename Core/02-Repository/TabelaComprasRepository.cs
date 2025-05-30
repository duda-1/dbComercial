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
    public class TabelaComprasRepository : ITabelaComprasRepository
    {
        private readonly IConfiguration _config;

        public TabelaComprasRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<TabelaCompras> Adicionar(TabelaCompras compra)
        {
            using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));

            var query = @"INSERT INTO TabelaCompras (PrecoMercadoria, QtdMercadoria, Cliente_CPFCliente)
                          VALUES (@PrecoMercadoria, @QtdMercadoria, @Cliente_CPFCliente);";

            await connection.ExecuteAsync(query, compra);
            return compra;
        }

        public async Task<IEnumerable<TabelaCompras>> Listar()
        {
            using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return await connection.GetAllAsync<TabelaCompras>();
        }

        public async Task<TabelaCompras> BuscarPorId(int id)
        {
            using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return await connection.GetAsync<TabelaCompras>(id);
        }

        public async Task Editar(TabelaCompras compra)
        {
            using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.UpdateAsync(compra);
        }

        public async Task Remover(int id)
        {
            using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            var compra = await BuscarPorId(id);
            if (compra != null)
            {
                await connection.DeleteAsync(compra);
            }
        }
    }
}
