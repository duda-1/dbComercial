using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
   public interface ICargoRepository
    {
        public  Task<Cargos> AdicionarCargo(Cargos cargo);
        public  Task<IEnumerable<Cargos>> ListarCargos();
        public  Task Editar(Cargos cargo);
        public  Task Remover(int id);
        public  Task<Cargos> BuscarPorId(int id);
    }
}
