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
        public void Adicionar(Endereco endereco);
        public void Remover(int id);
        public void Editar(Endereco endereco);
        public List<Endereco> Listar();
        public Endereco BuscarPorId(int id);
        public List<Endereco> ListarPorCidade(string cidade);
    }
}
