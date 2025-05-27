using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Dapper.Contrib.Extensions.Table("Cargos")]
    public class Cargos
    {
        [Dapper.Contrib.Extensions.Key]
        public int idCargos { get; set; }  // PK, auto_increment

        public string Cargo { get; set; }  // VARCHAR(45)
    }
}
