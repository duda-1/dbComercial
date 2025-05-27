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
    public class CargoService : ICargoService
    {
        private readonly ICargoRepository _repository;

        public CargoService(ICargoRepository repository)
        {
            _repository = repository;
        }

        // Adicionar
        public async Task AdicionarCargo(Cargos cargo)
        {
            await _repository.AdicionarCargo(cargo);
        }

        // Listar
        public async Task<IEnumerable<Cargos>> ListarCargos()
        {
            return await _repository.ListarCargos();
        }

        // Buscar por ID
        public async Task<Cargos> BuscarCargoPorId(int id)
        {
            return await _repository.BuscarPorId(id);
        }

        // Remover
        public async Task RemoverCargo(int id)
        {
            await _repository.Remover(id);
        }

        // Editar
        public async Task EditarCargo(int idCargo, Cargos cargo)
        {
            var cargoExistente = await _repository.BuscarPorId(idCargo);

            if (cargoExistente == null)
            {
                throw new Exception("Cargo não encontrado.");
            }

            cargo.idCargos = idCargo;
            await _repository.Editar(cargo);
        }
    }
}
