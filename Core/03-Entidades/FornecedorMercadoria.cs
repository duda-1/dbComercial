using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Dapper.Contrib.Extensions.Table("Fornecedor_has_Mercadorias")]
    public class FornecedorMercadoria
    {
        public int Fornecedor_idFornecedor { get; set; }
        public int Mercadorias_idMercadorias { get; set; }
    }
}
