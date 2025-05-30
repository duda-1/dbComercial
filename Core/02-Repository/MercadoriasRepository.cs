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
    public class MercadoriasRepository : IMercadoriasRepository
    {
        private readonly IConfiguration _configuration;

        public MercadoriasRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Mercadorias> Adicionar(Mercadorias mercadoria)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var query = @"INSERT INTO Mercadorias 
            (TituloMercadoria, DescricaoMercadoria, FabricanteFornecedorMercadoria, PrecoCompraMercadoria, PrecoVendaMercadoria, 
             LoteMercadoria, QtdMercadoria, QtdMinMercadoria, QtdMaxMercadoria, 
             TipoMercadoria_idTipoMercadoria, TipoMercadoria_Departamento_idDepartamento, TipoMercadoria_Departamento_Endereco_IdEndereco, 
             Empresa_CNPJ)
            VALUES
            (@TituloMercadoria, @DescricaoMercadoria, @FabricanteFornecedorMercadoria, @PrecoCompraMercadoria, @PrecoVendaMercadoria,
             @LoteMercadoria, @QtdMercadoria, @QtdMinMercadoria, @QtdMaxMercadoria,
             @TipoMercadoria_idTipoMercadoria, @TipoMercadoria_Departamento_idDepartamento, @TipoMercadoria_Departamento_Endereco_IdEndereco,
             @Empresa_CNPJ);";

            await connection.ExecuteAsync(query, mercadoria);
            return mercadoria;
        }

        public async Task<IEnumerable<Mercadorias>> Listar()
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<Mercadorias>("SELECT * FROM Mercadorias");
        }

        public async Task<Mercadorias> BuscarPorId(int id)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            return await connection.QuerySingleOrDefaultAsync<Mercadorias>("SELECT * FROM Mercadorias WHERE IdMercadorias = @Id", new { Id = id });
        }

        public async Task Editar(Mercadorias mercadoria)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var existente = await connection.GetAsync<Mercadorias>(mercadoria.IdMercadorias);

            if (existente == null)
                throw new Exception("Mercadoria não encontrada.");

            await connection.UpdateAsync(mercadoria);
        }

        public async Task Remover(int id)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var mercadoria = await BuscarPorId(id);

            if (mercadoria != null)
            {
                await connection.ExecuteAsync("DELETE FROM Mercadorias WHERE IdMercadorias = @Id", new { Id = id });
            }
        }
    }
}
