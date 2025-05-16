using Core._02_Repository.Interface;
using Core._03_Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;


namespace Core._02_Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string _connectionString;

        public EnderecoRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        public void Adicionar(Endereco endereco)
        {
            using var connection = new MySqlConnection(_connectionString);
            object value = connection.Insert(endereco);
        }

        public void Remover(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            var endereco = BuscarPorId(id);
            if (endereco != null)
            {
                connection.Delete(endereco);
            }
        }

        public void Editar(Endereco endereco)
        {
            using var connection = new MySqlConnection(_connectionString);
            connection.Update(endereco);
        }

        public List<Endereco> Listar()
        {
            using var connection = new MySqlConnection(_connectionString);
            return connection.GetAll<Endereco>().ToList();
        }

        public Endereco BuscarPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            return connection.Get<Endereco>(id);
        }

        // Exemplo de método customizado: lista por cidade
        public List<Endereco> ListarPorCidade(string cidade)
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "SELECT * FROM Enderecos WHERE Cidade = @Cidade";
            return connection.Query<Endereco>(sql, new { Cidade = cidade }).ToList();
        }
    }
}
