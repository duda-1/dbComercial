using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
    public interface IEnderecoRepository
    {
        public  Task<Endereco> AdicionarEndereco(Endereco endereco);
        public  Task<IEnumerable<Endereco>> ListarEndereco();
        public Task Editar(Endereco endereco);
        public  Task Remover(int id);
        public  Task<Endereco> BuscarPorId(int id);
    }
}
