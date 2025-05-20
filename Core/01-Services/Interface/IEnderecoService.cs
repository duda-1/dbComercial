using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services.Interface
{
    public interface IEnderecoService
    {

        public Task AdicionarEndereco(Endereco endereco);
        public Task<IEnumerable<Endereco>> ListarEndereco();
        public  Task<Endereco> BuscarEnderecoPorId(int id);
        public  Task RemoverEndereco(int id);
        public  Task EditarEndereco(int idEndereco,Endereco endereco);

    }
}
