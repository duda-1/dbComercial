using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
    public interface IEmpresaRepository
    {
        public Task<Empresa> AdicionarEmpresa(Empresa empresa);
        public Task<IEnumerable<Empresa>> ListarEmpresa();
        public Task Editar(Empresa empresa);
        public Task Remover(string cnpj);
        public Task<Empresa> BuscarPorCnpj(string cnpj);
    }
}
