using Core._02_Repository.Interface;
using Core._03_Entidades;
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
    public class TabelaComprasMercadoriasRepository : ITabelaComprasMercadoriasRepository
    {
        private readonly IConfiguration _config;

        public TabelaComprasMercadoriasRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<TabelaComprasMercadorias> Adicionar(TabelaComprasMercadorias entidade)
        {
            using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.InsertAsync(entidade);
            return entidade;
        }

        public async Task<IEnumerable<TabelaComprasMercadorias>> Listar()
        {
            using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return await connection.GetAllAsync<TabelaComprasMercadorias>();
        }

        public async Task<TabelaComprasMercadorias> BuscarPorId(int id)
        {
            using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return await connection.GetAsync<TabelaComprasMercadorias>(id);
        }

        public async Task Editar(TabelaComprasMercadorias entidade)
        {
            using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.UpdateAsync(entidade);
        }

        public async Task Remover(int id)
        {
            using var connection = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            var entidade = await BuscarPorId(id);
            if (entidade != null)
            {
                await connection.DeleteAsync(entidade);
            }
        }
    }
}
