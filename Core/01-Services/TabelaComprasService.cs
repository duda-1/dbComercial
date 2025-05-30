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
    public class TabelaComprasService : ITabelaComprasService
    {
        private readonly ITabelaComprasRepository _repository;

        public TabelaComprasService(ITabelaComprasRepository repository)
        {
            _repository = repository;
        }

        public async Task Adicionar(TabelaCompras compra)
        {
            await _repository.Adicionar(compra);
        }

        public async Task<IEnumerable<TabelaCompras>> Listar()
        {
            return await _repository.Listar();
        }

        public async Task<TabelaCompras> BuscarPorId(int id)
        {
            return await _repository.BuscarPorId(id);
        }

        public async Task Editar(int id, TabelaCompras compra)
        {
            var existente = await _repository.BuscarPorId(id);
            if (existente == null)
                throw new Exception("Compra não encontrada.");

            compra.IdTabelaCompras = id;
            await _repository.Editar(compra);
        }

        public async Task Remover(int id)
        {
            await _repository.Remover(id);
        }
    }
}
