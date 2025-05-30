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
    public class TabelaComprasMercadoriasService : ITabelaComprasMercadoriasService
    {
        private readonly ITabelaComprasMercadoriasRepository _repository;

        public TabelaComprasMercadoriasService(ITabelaComprasMercadoriasRepository repository)
        {
            _repository = repository;
        }

        public async Task Adicionar(TabelaComprasMercadorias entidade)
        {
            await _repository.Adicionar(entidade);
        }

        public async Task<IEnumerable<TabelaComprasMercadorias>> Listar()
        {
            return await _repository.Listar();
        }

        public async Task<TabelaComprasMercadorias> BuscarPorId(int id)
        {
            return await _repository.BuscarPorId(id);
        }

        public async Task Editar(int id, TabelaComprasMercadorias entidade)
        {
            var existente = await _repository.BuscarPorId(id);
            if (existente == null)
                throw new Exception("Registro não encontrado.");

            entidade.IdTabelaComprasMercadorias = id;
            await _repository.Editar(entidade);
        }

        public async Task Remover(int id)
        {
            await _repository.Remover(id);
        }
    }
}
