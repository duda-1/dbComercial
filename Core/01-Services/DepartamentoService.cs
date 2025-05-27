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
    public class DepartamentoService : IDepartamentoService
    {
        private readonly IDepartamentoRepository _repository;

        public DepartamentoService(IDepartamentoRepository repository)
        {
            _repository = repository;
        }

        // Adicionar
        public async Task AdicionarDepartamento(Departamento departamento)
        {
            await _repository.AdicionarDepartamento(departamento);
        }

        // Listar
        public async Task<IEnumerable<Departamento>> ListarDepartamento()
        {
            return await _repository.ListarDepartamento();
        }

        // Buscar por ID
        public async Task<Departamento> BuscarDepartamentoPorId(int idDepartamento)
        {
            return await _repository.BuscarPorId(idDepartamento);
        }

        // Remover
        public async Task RemoverDepartamento(int idDepartamento)
        {
            await _repository.Remover(idDepartamento);
        }

        // Editar
        public async Task EditarDepartamento(int idDepartamento, Departamento departamento)
        {
            var departamentoExistente = await _repository.BuscarPorId(idDepartamento);

            if (departamentoExistente == null)
            {
                throw new Exception("Departamento não encontrado.");
            }

            // Atualiza o id do objeto para garantir que o repositório atualize o registro correto
            departamento.idDepartamento = idDepartamento;

            await _repository.Editar(departamento);
        }


    }
}
