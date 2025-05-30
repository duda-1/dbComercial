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
    public class TipoMercadoriaService : ITipoMercadoriaService
    {
        private readonly ITipoMercadoriaRepository _repository;

        public TipoMercadoriaService(ITipoMercadoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task AdicionarTipoMercadoria(TipoMercadoria tipo)
        {
            await _repository.AdicionarTipoMercadoria(tipo);
        }

        public async Task<IEnumerable<TipoMercadoria>> ListarTipoMercadorias()
        {
            return await _repository.ListarTipoMercadorias();
        }

        public async Task<TipoMercadoria> BuscarTipoMercadoriaPorId(int id)
        {
            return await _repository.BuscarPorId(id);
        }

        public async Task EditarTipoMercadoria(int id, TipoMercadoria tipo)
        {
            var existente = await _repository.BuscarPorId(id);
            if (existente == null)
                throw new Exception("Tipo de mercadoria não encontrado.");

            await _repository.Editar(tipo);
        }

        public async Task RemoverTipoMercadoria(int id)
        {
            await _repository.Remover(id);
        }
    }
}
