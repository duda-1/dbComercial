using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
   public interface ICargoService
    {
        public  Task AdicionarCargo(Cargos cargo);
        public  Task<IEnumerable<Cargos>> ListarCargos();
        public  Task<Cargos> BuscarCargoPorId(int id);
        public  Task RemoverCargo(int id);
        public  Task EditarCargo(int idCargo, Cargos cargo);

    }
}
