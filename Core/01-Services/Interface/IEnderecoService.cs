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
        public void Adicionar(Endereco endereco);
        public void Remover(int id);
        public List<Endereco> Listar();
        public Endereco BuscarEnderecoPorId(int id);
        public List<Endereco> ListarPorCidade(string cidade);
        public void Editar(Endereco endereco);
    }
}
