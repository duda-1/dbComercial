using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Dapper.Contrib.Extensions.Table("TabelaCompras")]
    public class TabelaCompras
    {
        [Dapper.Contrib.Extensions.Key]
        public int IdTabelaCompras { get; set; }

        public float? PrecoMercadoria { get; set; }

        public int? QtdMercadoria { get; set; }

        public string Cliente_CPFCliente { get; set; }
    }
}
