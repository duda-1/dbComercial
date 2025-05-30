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
    public class MercadoriasService : IMercadoriasService
    {
        private readonly IMercadoriasRepository _repository;

        public MercadoriasService(IMercadoriasRepository repository)
        {
            _repository = repository;
        }

        public async Task AdicionarMercadoria(Mercadorias mercadoria)
        {
            await _repository.Adicionar(mercadoria);
        }

        public async Task<IEnumerable<Mercadorias>> ListarMercadorias()
        {
            return await _repository.Listar();
        }

        public async Task<Mercadorias> BuscarMercadoriaPorId(int id)
        {
            return await _repository.BuscarPorId(id);
        }

        public async Task EditarMercadoria(int id, Mercadorias mercadoria)
        {
            var existente = await _repository.BuscarPorId(id);
            if (existente == null)
                throw new Exception("Mercadoria não encontrada.");

            await _repository.Editar(mercadoria);
        }

        public async Task RemoverMercadoria(int id)
        {
            await _repository.Remover(id);
        }

    }
}
