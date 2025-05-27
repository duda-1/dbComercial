using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Dapper.Contrib.Extensions.Table("Cliente")]
    public class Cliente
    {
        [Dapper.Contrib.Extensions.Key] // Chave primária da tabela
        public string CPFCliente { get; set; }

        public string NomeCliente { get; set; }
        public DateTime? DtNascimentoCliente { get; set; }
        public string ViaCliente { get; set; }
        public string NumCliente { get; set; }
        public string ComplCliente { get; set; }
        public string BairroCliente { get; set; }
        public string CidadeCliente { get; set; }
        public string UFCliente { get; set; }
        public string CEPCliente { get; set; }
        public string TelefoneCliente { get; set; }
        public string CelularCliente { get; set; }
        public string EmailCliente { get; set; }
        public string SenhaCliente { get; set; }

        // Chave estrangeira (Empresa_CNPJ), apenas para manter o dado
        public string Empresa_CNPJ { get; set; }
    }
}
