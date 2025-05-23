using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface IEmpresaService
    {
        public  Task AdicionarEmpresa(Empresa empresa);
        public  Task<IEnumerable<Empresa>> ListarEmpresa();
        public  Task<Empresa> BuscarEmpresaPorCnpj(string cnpj);
        public  Task RemoverEmpresa(string cnpj);
        public  Task EditarEmpresa(string cnpj, Empresa empresa);
    }
}
