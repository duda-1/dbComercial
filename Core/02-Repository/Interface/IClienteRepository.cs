using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._02_Repository.Interface
{
    public interface IClienteRepository
    {
        public Task<Cliente> AdicionarCliente(Cliente cliente);
        public Task<IEnumerable<Cliente>> ListarClientes();
        public Task EditarCliente(Cliente cliente);
        public Task RemoverCliente(string cpf);
        public Task<Cliente> BuscarPorCPF(string cpf);

        public  Task<Cliente> LoginCliente(string cpf, string senha);
    }
}
