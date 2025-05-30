using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Dapper.Contrib.Extensions.Table("Mercadorias")]
    public class Mercadorias
    {
        [Dapper.Contrib.Extensions.Key]
        public int IdMercadorias { get; set; }

        public string TituloMercadoria { get; set; }
        public string DescricaoMercadoria { get; set; }
        public string FabricanteFornecedorMercadoria { get; set; }
        public float PrecoCompraMercadoria { get; set; }
        public float PrecoVendaMercadoria { get; set; }
        public string LoteMercadoria { get; set; }
        public int? QtdMercadoria { get; set; }
        public int QtdMinMercadoria { get; set; }
        public int? QtdMaxMercadoria { get; set; }

        public int TipoMercadoria_idTipoMercadoria { get; set; }
        public int TipoMercadoria_Departamento_idDepartamento { get; set; }
        public int TipoMercadoria_Departamento_Endereco_IdEndereco { get; set; }

        public string Empresa_CNPJ { get; set; }
    }
}
