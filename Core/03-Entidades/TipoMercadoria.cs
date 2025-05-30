using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Dapper.Contrib.Extensions.Table("TipoMercadoria")]
    public class TipoMercadoria
    {
        [Dapper.Contrib.Extensions.Key]
        public int IdTipoMercadoria { get; set; }
        public string Tipo { get; set; }
        public int Departamento_idDepartamento { get; set; }
        public int Departamento_Endereco_IdEndereco { get; set; }
    }

}
