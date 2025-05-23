using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface IDepartamentoService
    {
        public  Task AdicionarDepartamento(Departamento departamento);
        public  Task<IEnumerable<Departamento>> ListarDepartamento();
        public  Task<Departamento> BuscarDepartamentoPorId(int idDepartamento);
        public  Task RemoverDepartamento(int idDepartamento);
        public  Task EditarDepartamento(int idDepartamento, Departamento departamento);
    }
}
