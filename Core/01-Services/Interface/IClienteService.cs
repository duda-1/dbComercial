using Core._02_Repository.Interface;
using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface IClienteService
    {
        public  Task AdicionarCliente(Cliente cliente);
        public  Task<IEnumerable<Cliente>> ListarClientes();
        public  Task<Cliente> BuscarClientePorCpf(string cpf);
        public  Task RemoverCliente(string cpf);
        public  Task EditarCliente(string cpf, Cliente cliente);

        public  Task<Cliente> LoginCliente(string cpf, string senha);
    }
}
