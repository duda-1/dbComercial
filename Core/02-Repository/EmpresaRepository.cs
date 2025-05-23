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
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IConfiguration _connectionString;

        public EmpresaRepository(IConfiguration config)
        {
            _connectionString = config;
        }

        //Adicionar
        public async Task<Empresa> AdicionarEmpresa(Empresa empresa)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            // 1. Validação: verifica se o endereço existe
            var enderecoExiste = await connection.QueryFirstOrDefaultAsync<int>(
                "SELECT COUNT(1) FROM Endereco WHERE IdEndereco = @IdEndereco",
                new { IdEndereco = empresa.Endereco_IdEndereco });

            if (enderecoExiste == 0)
            {
                throw new Exception("Endereço informado não existe.");
            }

            // 2. Insere a empresa
            var query = @"
        INSERT INTO Empresa 
        (CNPJ, RazaoSocial, NomeFantasia, TelefoneEmpresa, CelularEmpresa, Endereco_IdEndereco, EmailEmpresa)
        VALUES
        (@CNPJ, @RazaoSocial, @NomeFantasia, @TelefoneEmpresa, @CelularEmpresa, @Endereco_IdEndereco, @EmailEmpresa);";

            await connection.ExecuteAsync(query, new
            {
                CNPJ = empresa.CNPJ,
                RazaoSocial = empresa.RazaoSocial,
                NomeFantasia = empresa.NomeFantasia,
                TelefoneEmpresa = empresa.TelefoneEmpresa,
                CelularEmpresa = empresa.CelularEmpresa,
                Endereco_IdEndereco = empresa.Endereco_IdEndereco,
                EmailEmpresa = empresa.EmailEmpresa
            });

            return empresa;
        }


        //Listar
        public async Task<IEnumerable<Empresa>> ListarEmpresa()
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<Empresa>("SELECT * FROM Empresa");
        }

        //Editar
        public async Task Editar(Empresa empresa)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var empresaExistente = await connection.GetAsync<Empresa>(empresa.CNPJ);

            if (empresaExistente == null)
            {
                throw new Exception("Empresa não encontrada.");
            }

            empresaExistente.RazaoSocial = empresa.RazaoSocial;
            empresaExistente.NomeFantasia = empresa.NomeFantasia;
            empresaExistente.TelefoneEmpresa = empresa.TelefoneEmpresa;
            empresaExistente.CelularEmpresa = empresa.CelularEmpresa;
            empresaExistente.Endereco_IdEndereco = empresa.Endereco_IdEndereco;
            empresaExistente.EmailEmpresa = empresa.EmailEmpresa;

            await connection.UpdateAsync(empresaExistente);
        }


        //Deletar
        public async Task Remover(string cnpj)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var empresa = await BuscarPorCnpj(cnpj);

            if (empresa != null)
            {
                var query = "DELETE FROM Empresa WHERE CNPJ = @CNPJ";
                await connection.ExecuteAsync(query, new { CNPJ = cnpj });
            }
        }

        //Buscar por CNPJ
        public async Task<Empresa> BuscarPorCnpj(string cnpj)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var query = "SELECT * FROM Empresa WHERE CNPJ = @CNPJ";
            return await connection.QuerySingleOrDefaultAsync<Empresa>(query, new { CNPJ = cnpj });
        }


    }
}
