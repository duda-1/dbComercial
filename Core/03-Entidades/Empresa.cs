using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Table("Empresa")]
    public class Empresa
    {
        [ExplicitKey] // Usado porque o CNPJ é a chave primária mas não é auto-incrementável
        public string CNPJ { get; set; }                 // VARCHAR(14), PRIMARY KEY

        public string RazaoSocial { get; set; }          // VARCHAR(45), pode ser NULL
        public string NomeFantasia { get; set; }         // VARCHAR(45), pode ser NULL
        public string TelefoneEmpresa { get; set; }      // VARCHAR(10), pode ser NULL
        public string CelularEmpresa { get; set; }       // VARCHAR(11), pode ser NULL
        public int Endereco_IdEndereco { get; set; }     // INT, FOREIGN KEY
        public string EmailEmpresa { get; set; }         // VARCHAR(45), pode ser NULL
    }
}
