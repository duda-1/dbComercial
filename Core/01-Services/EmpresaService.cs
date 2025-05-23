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
   public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _repository;

        public EmpresaService(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        // Adicionar
        public async Task AdicionarEmpresa(Empresa empresa)
        {
            await _repository.AdicionarEmpresa(empresa);
        }

        // Listar
        public async Task<IEnumerable<Empresa>> ListarEmpresa()
        {
            return await _repository.ListarEmpresa();
        }

        // Buscar por CNPJ
        public async Task<Empresa> BuscarEmpresaPorCnpj(string cnpj)
        {
            return await _repository.BuscarPorCnpj(cnpj);
        }

        // Remover
        public async Task RemoverEmpresa(string cnpj)
        {
            await _repository.Remover(cnpj);
        }

        // Editar
        public async Task EditarEmpresa(string cnpj, Empresa empresa)
        {
            var empresaExistente = await _repository.BuscarPorCnpj(cnpj);

            if (empresaExistente == null)
            {
                throw new Exception("Empresa não encontrada.");
            }

            await _repository.Editar(empresa);
        }
    }
}
