using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
   public interface IDepartamentoRepository
    {
        public  Task<Departamento> AdicionarDepartamento(Departamento departamento);
        public  Task<IEnumerable<Departamento>> ListarDepartamento();
        public  Task Editar(Departamento departamento);
        public  Task Remover(int idDepartamento);
        public  Task<Departamento> BuscarPorId(int idDepartamento);
    }
}
