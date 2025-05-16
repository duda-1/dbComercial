using Core._01_Services.Interface;
using Core._02_Repository.Interface;
using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._01_Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repository;

        public EnderecoService(IEnderecoRepository repository)
        {
            _repository = repository;
        }

        public void Adicionar(Endereco endereco)
        {
            _repository.Adicionar(endereco);
        }

        public void Remover(int id)
        {
            _repository.Remover(id);
        }

        public List<Endereco> Listar()
        {
            return _repository.Listar();
        }

        public Endereco BuscarEnderecoPorId(int id)
        {
            return _repository.BuscarPorId(id);
        }

        public List<Endereco> ListarPorCidade(string cidade)
        {
            return _repository.ListarPorCidade(cidade);
        }

        public void Editar(Endereco endereco)
        {
            _repository.Editar(endereco);
        }
    }
}
