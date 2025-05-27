using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface IFuncionarioService
    {
        public Task AdicionarFuncionario(Funcionario funcionario);
        public  Task<IEnumerable<Funcionario>> ListarFuncionarios();
        public  Task<Funcionario> BuscarFuncionarioPorId(int id);
        public  Task RemoverFuncionario(int id);
        public  Task EditarFuncionario(int idFuncionario, Funcionario funcionario);
    }
}
