using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Dapper.Contrib.Extensions.Table("TabelaComprasMercadorias")]
    public class TabelaComprasMercadorias
    {
        [Dapper.Contrib.Extensions.Key]
        public int IdTabelaComprasMercadorias { get; set; }

        public int IdCompraMercadoria { get; set; }

        public float PrecoCompraMercadoria { get; set; }

        public int QtdCompraMercadoria { get; set; }

        public int TabelaCompras_idTabelaCompras { get; set; }

        public int Mercadorias_idMercadorias { get; set; }
    }
}
