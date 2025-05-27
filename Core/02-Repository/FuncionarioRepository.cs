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
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IConfiguration _connectionString;

        public FuncionarioRepository(IConfiguration config)
        {
            _connectionString = config;
        }

        // Adicionar Funcionário
        public async Task<Funcionario> AdicionarFuncionario(Funcionario funcionario)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var query = @"
        INSERT INTO Funcionarios
        (NomeFuncionario, CPFFuncionario, DataNascimento, DataContrato, DataDemissao, CEPFuncionario, RuaFuncionario,
         BairroFuncionario, NumResidenciaFuncionario, ComplFuncionario, UFFuncionario, TelefoneFuncionario,
         CelularFuncionario, IdDepartamentoFuncionario, Cargos_idCargos, EmailFuncionario, SenhaFuncionario,
         Departamento_idDepartamento, Departamento_Endereco_IdEndereco)
        VALUES
        (@NomeFuncionario, @CPFFuncionario, @DataNascimento, @DataContrato, @DataDemissao, @CEPFuncionario, @RuaFuncionario,
         @BairroFuncionario, @NumResidenciaFuncionario, @ComplFuncionario, @UFFuncionario, @TelefoneFuncionario,
         @CelularFuncionario, @IdDepartamentoFuncionario, @Cargos_idCargos, @EmailFuncionario, @SenhaFuncionario,
         @Departamento_idDepartamento, @Departamento_Endereco_IdEndereco);
        SELECT LAST_INSERT_ID();";

            // Executa o insert e captura o ID gerado
            var id = await connection.ExecuteScalarAsync<int>(query, new
            {
                funcionario.NomeFuncionario,
                funcionario.CPFFuncionario,
                funcionario.DataNascimento,
                funcionario.DataContrato,
                funcionario.DataDemissao,
                funcionario.CEPFuncionario,
                funcionario.RuaFuncionario,
                funcionario.BairroFuncionario,
                funcionario.NumResidenciaFuncionario,
                funcionario.ComplFuncionario,
                funcionario.UFFuncionario,
                funcionario.TelefoneFuncionario,
                funcionario.CelularFuncionario,
                funcionario.IdDepartamentoFuncionario,
                funcionario.Cargos_idCargos,
                funcionario.EmailFuncionario,
                funcionario.SenhaFuncionario,
                funcionario.Departamento_idDepartamento,
                funcionario.Departamento_Endereco_IdEndereco
            });

            // Atualiza o ID no objeto e retorna
            funcionario.idFuncionarios = id;

            return funcionario;
        }


        // Listar Funcionários
        public async Task<IEnumerable<Funcionario>> ListarFuncionarios()
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<Funcionario>("SELECT * FROM Funcionarios");
        }

        // Editar Funcionário
        public async Task Editar(Funcionario funcionario)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var funcionarioExistente = await connection.GetAsync<Funcionario>(funcionario.idFuncionarios);

            if (funcionarioExistente == null)
                throw new Exception("Funcionário não encontrado.");

            // Atualiza campos
            funcionarioExistente.NomeFuncionario = funcionario.NomeFuncionario;
            funcionarioExistente.CPFFuncionario = funcionario.CPFFuncionario;
            funcionarioExistente.DataNascimento = funcionario.DataNascimento;
            funcionarioExistente.DataContrato = funcionario.DataContrato;
            funcionarioExistente.DataDemissao = funcionario.DataDemissao;
            funcionarioExistente.CEPFuncionario = funcionario.CEPFuncionario;
            funcionarioExistente.RuaFuncionario = funcionario.RuaFuncionario;
            funcionarioExistente.BairroFuncionario = funcionario.BairroFuncionario;
            funcionarioExistente.NumResidenciaFuncionario = funcionario.NumResidenciaFuncionario;
            funcionarioExistente.ComplFuncionario = funcionario.ComplFuncionario;
            funcionarioExistente.UFFuncionario = funcionario.UFFuncionario;
            funcionarioExistente.TelefoneFuncionario = funcionario.TelefoneFuncionario;
            funcionarioExistente.CelularFuncionario = funcionario.CelularFuncionario;
            funcionarioExistente.IdDepartamentoFuncionario = funcionario.IdDepartamentoFuncionario;
            funcionarioExistente.Cargos_idCargos = funcionario.Cargos_idCargos;
            funcionarioExistente.EmailFuncionario = funcionario.EmailFuncionario;
            funcionarioExistente.SenhaFuncionario = funcionario.SenhaFuncionario;
            funcionarioExistente.Departamento_idDepartamento = funcionario.Departamento_idDepartamento;
            funcionarioExistente.Departamento_Endereco_IdEndereco = funcionario.Departamento_Endereco_IdEndereco;

            await connection.UpdateAsync(funcionarioExistente);
        }

        // Remover Funcionário
        public async Task Remover(int id)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var funcionario = await BuscarPorId(id);
            if (funcionario != null)
            {
                var query = "DELETE FROM Funcionarios WHERE idFuncionarios = @Id";
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        // Buscar Funcionário por ID
        public async Task<Funcionario> BuscarPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            var query = "SELECT * FROM Funcionarios WHERE idFuncionarios = @Id";
            return await connection.QuerySingleOrDefaultAsync<Funcionario>(query, new { Id = id });
        }
    }
}
