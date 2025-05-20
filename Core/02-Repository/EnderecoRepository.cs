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
        private readonly IConfiguration _connectionString;

        public EnderecoRepository(IConfiguration config)
        {
            _connectionString = config;
        }

        //Adicionar
        public async Task<Endereco> AdicionarEndereco(Endereco endereco)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            // Definindo a query de inserção
            var query = @"INSERT INTO Endereco 
                  (CEP, TipoVia, NomeVia, Numero, Complemento, Bairro, Cidade, UF) 
                  VALUES 
                  (@CEP, @TipoVia, @NomeVia, @Numero, @Complemento, @Bairro, @Cidade, @UF);";

            // Executando a query de inserção
            await connection.ExecuteAsync(query, new
            {
                CEP = endereco.CEP,
                TipoVia = endereco.TipoVia,
                NomeVia = endereco.NomeVia,
                Numero = endereco.Numero,
                Complemento = endereco.Complemento,
                Bairro = endereco.Bairro,
                Cidade = endereco.Cidade,
                UF = endereco.UF
            });

            // Atribuindo o ID gerado ao objeto Endereco
          // endereco.IdEndereco = IdEndereco;

            // Após a inserção, podemos retornar o objeto `Endereco` com os dados que foram inseridos.
            // O IdEndereco será gerado automaticamente pelo banco devido ao auto-incremento.
            return endereco;
        }


        //Listar
        public async Task<IEnumerable<Endereco>> ListarEndereco()
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));
            return await connection.QueryAsync<Endereco>("SELECT * FROM Endereco");
        }

        //Edidtar
        public async Task Editar(Endereco endereco)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            // Aqui vamos usar o Dapper Contrib para atualizar o registro
            var enderecoExistente = await connection.GetAsync<Endereco>(endereco.IdEndereco);

            if (enderecoExistente == null)
            {
                throw new Exception("Endereço não encontrado.");
            }

            // Atualiza os valores do endereço existente com os novos dados do objeto
            enderecoExistente.CEP = endereco.CEP;
            enderecoExistente.TipoVia = endereco.TipoVia;
            enderecoExistente.NomeVia = endereco.NomeVia;
            enderecoExistente.Numero = endereco.Numero;
            enderecoExistente.Complemento = endereco.Complemento;
            enderecoExistente.Bairro = endereco.Bairro;
            enderecoExistente.Cidade = endereco.Cidade;
            enderecoExistente.UF = endereco.UF;

            // Atualiza o endereço no banco de dados
            await connection.UpdateAsync(enderecoExistente);
        }



        //Remover
        public async Task Remover(int id)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            // Busca o endereço por ID
            var endereco = await BuscarPorId(id);

            // Se o endereço existir, apaga
            if (endereco != null)
            {
                var query = "DELETE FROM Endereco WHERE IdEndereco = @Id";

                // Executa a query de delete
                await connection.ExecuteAsync(query, new { Id = id });
            }
        }

        // Buscar por ID
        public async Task<Endereco> BuscarPorId(int id)
        {
            using var connection = new MySqlConnection(_connectionString.GetConnectionString("DefaultConnection"));

            // Query para buscar o endereço por ID
            var query = "SELECT * FROM Endereco WHERE IdEndereco = @Id";

            // Executa a consulta assíncrona e retorna o primeiro resultado encontrado
            return await connection.QuerySingleOrDefaultAsync<Endereco>(query, new { Id = id });
        }


        //// Exemplo de método customizado: lista por cidade
        //public List<Endereco> ListarPorCidade(string cidade)
        //{
        //    using var connection = new MySqlConnection(_connectionString);
        //    var sql = "SELECT * FROM Enderecos WHERE Cidade = @Cidade";
        //    return connection.Query<Endereco>(sql, new { Cidade = cidade }).ToList();
        //}
    }
}
