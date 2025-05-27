using Core._01_Services.Interface;
using Core._02_Repository.Interface;
using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repository;

        public FuncionarioService(IFuncionarioRepository repository)
        {
            _repository = repository;
        }

        // Adicionar funcionário
        public async Task AdicionarFuncionario(Funcionario funcionario)
        {
            // Aqui pode adicionar validações se quiser antes de inserir
            await _repository.AdicionarFuncionario(funcionario);
        }

        // Listar todos os funcionários
        public async Task<IEnumerable<Funcionario>> ListarFuncionarios()
        {
            return await _repository.ListarFuncionarios();
        }

        // Buscar funcionário por ID
        public async Task<Funcionario> BuscarFuncionarioPorId(int id)
        {
            return await _repository.BuscarPorId(id);
        }

        // Remover funcionário
        public async Task RemoverFuncionario(int id)
        {
            await _repository.Remover(id);
        }

        // Editar funcionário
        public async Task EditarFuncionario(int idFuncionario, Funcionario funcionario)
        {
            var funcionarioExistente = await _repository.BuscarPorId(idFuncionario);

            if (funcionarioExistente == null)
                throw new Exception("Funcionário não encontrado.");

            // Garante que o objeto que será atualizado tem o id correto
            funcionario.idFuncionarios = idFuncionario;

            await _repository.Editar(funcionario);
        }
    }
}
