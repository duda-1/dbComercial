using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Dapper.Contrib.Extensions.Table("Fornecedor")]
    public class Fornecedor
    {
        [Dapper.Contrib.Extensions.Key]
        public int IdFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
        public string CEPFornecedor { get; set; }
        public string RuaFornecedor { get; set; }
        public string NumFornecedor { get; set; }
        public string ComplFornecedor { get; set; }
        public string BairroFornecedor { get; set; }
        public string CidadeFornecedor { get; set; }
        public string UFFornecedor { get; set; }
        public string TelefoneFornecedor { get; set; }
        public string CelularFornecedor { get; set; }
        public string EmailFornecedor { get; set; }
    }
}
