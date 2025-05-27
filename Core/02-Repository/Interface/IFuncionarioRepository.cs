using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
    public interface IFuncionarioRepository
    {
        public  Task<Funcionario> AdicionarFuncionario(Funcionario funcionario);
        public Task<IEnumerable<Funcionario>> ListarFuncionarios();
        public  Task Editar(Funcionario funcionario);
        public Task Remover(int id);
        public  Task<Funcionario> BuscarPorId(int id);
    }
}
