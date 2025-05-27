using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Dapper.Contrib.Extensions.Table("Funcionarios")]
    public class Funcionario
    {
        [Dapper.Contrib.Extensions.Key]
        public int idFuncionarios { get; set; }

        public string NomeFuncionario { get; set; }
        public string CPFFuncionario { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataContrato { get; set; }
        public DateTime? DataDemissao { get; set; }
        public string CEPFuncionario { get; set; }
        public string RuaFuncionario { get; set; }
        public string BairroFuncionario { get; set; }
        public string NumResidenciaFuncionario { get; set; }
        public string ComplFuncionario { get; set; }
        public string UFFuncionario { get; set; }
        public string TelefoneFuncionario { get; set; }
        public string CelularFuncionario { get; set; }

        public int? IdDepartamentoFuncionario { get; set; }
        public int Cargos_idCargos { get; set; }

        public string EmailFuncionario { get; set; }
        public string SenhaFuncionario { get; set; }

        public int Departamento_idDepartamento { get; set; }
        public int Departamento_Endereco_IdEndereco { get; set; }
    }
}
